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
        public static string fileLocationTags = @"C:\scadaConfig.xml";

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

        // @TODO @FIX Not the best idea for this to be 'public static'
        public static void LoadTagsFromFile()
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

        public ListOfTags GetTags()
        {
            return listOfTags;
        }

        public void AddDigitalInput(string tagName, string description, string driver, string ioAddress,
                            float scanTime, bool enableScan, bool manualMode)
        {
            DigitalInput newTag = new DigitalInput(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode);
            listOfTags.DigitalInputs.Add(newTag);
            listOfTags.WriteTagsToFile();
        }

        public void AddDigitalOutput(string tagName, string description, string driver, string ioAddress, float initValue)
        {
            DigitalOutput newTag = new DigitalOutput(tagName, description, driver, ioAddress, initValue);
            listOfTags.DigitalOutputs.Add(newTag);
            listOfTags.WriteTagsToFile();
        }

        public void AddAnalogInput(string tagName, string description, string driver, string ioAddress,
                                    float scanTime, bool enableScan, bool manualMode,
                                    float lowLimit, float highLimit, string units)
        {
            AnalogInput newTag = new AnalogInput(tagName, description, driver, ioAddress, scanTime, 
                                                enableScan, manualMode, lowLimit, highLimit, units);
            listOfTags.AnalogInputs.Add(newTag);
            listOfTags.WriteTagsToFile();
        }

        public void AddAnalogOutput(string tagName, string description, string driver, string ioAddress, 
                                    float initValue, float lowLimit, float highLimit, string units)
        {
            AnalogOutput newTag = new AnalogOutput(tagName, description, driver, ioAddress,
                                                    initValue, lowLimit, highLimit, units);
            listOfTags.AnalogOutputs.Add(newTag);
            listOfTags.WriteTagsToFile();
        }
    }
}
