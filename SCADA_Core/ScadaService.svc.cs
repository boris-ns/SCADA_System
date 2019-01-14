using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace SCADA_Core
{
    public class ScadaService : IRealTimeUnit, IAlarmDisplay, IDatabaseManager
    {
        private static string fileLocationTags = @"C:\scadaConfig.xml";

        private static Dictionary<string, string> publicKeysForRTUs = new Dictionary<string, string>();

        private static ListOfTags listOfTags = new ListOfTags();

        private static CspParameters csp = new CspParameters();
        private static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);

        private static void LoadPublicKey(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                rsa.FromXmlString(reader.ReadToEnd());
            }
        }

        private static bool VerifyMessage(string message, byte[] signature)
        {
            byte[] hashVal = null;

            using (SHA256 sha = SHA256Managed.Create())
            {
                hashVal = sha.ComputeHash(Encoding.UTF8.GetBytes(message));
            }

            RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(rsa);
            deformatter.SetHashAlgorithm("SHA256");

            return deformatter.VerifySignature(hashVal, signature);
        }

        private void WriteTagsToFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListOfTags));

            using (FileStream fs = new FileStream(fileLocationTags, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, listOfTags);
            }
        }

        private void LoadTagsFromFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListOfTags));

            using (FileStream fs = new FileStream(fileLocationTags, FileMode.Open))
            {
                listOfTags = (ListOfTags)xmlSerializer.Deserialize(fs);
            }
        }

        /*********************************************************/
        /*                    IRealTimeUnit                      */
        /*********************************************************/

        public bool IsRTUNameAvailable(string name)
        {
            return !publicKeysForRTUs.ContainsKey(name);
        }

        public void InitRealTimeUnit(string rtuName, string publicKeyPath)
        {
            if (publicKeysForRTUs.ContainsKey(rtuName))
                return;

            lock (publicKeysForRTUs)
            {
                publicKeysForRTUs[rtuName] = publicKeyPath;
            }
        }

        public void SendValue(string message, byte[] signature)
        {
            throw new NotImplementedException();
        }

        /*********************************************************/
        /*                    IAlarmDisplay                      */
        /*********************************************************/

        public void AlarmDisplayClientInit()
        {
            throw new NotImplementedException();
        }


        /*********************************************************/
        /*                    IDatabaseManager                   */
        /*********************************************************/

        public List<DigitalInput> GetAllDigitalInputs()
        {
            GetAllDigitalOutputs();
            return listOfTags.DigitalInputs;
        }
        
        public List<DigitalOutput> GetAllDigitalOutputs()
        {
            LoadTagsFromFile();
            return listOfTags.DigitalOutputs;
        }

        public List<AnalogInput> GetAllAnalogInputs()
        {
            return listOfTags.AnalogInputs;
        }

        public List<AnalogOutput> GetAllAnalogOutputs()
        {
            return listOfTags.AnalogOutputs;
        }

        public void AddDigitalInput(string tagName, string description, string driver, string ioAddress,
                            float scanTime, bool enableScan, bool manualMode)
        {
            DigitalInput newTag = new DigitalInput(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode);
            listOfTags.DigitalInputs.Add(newTag);
            WriteTagsToFile();
        }
    }
}
