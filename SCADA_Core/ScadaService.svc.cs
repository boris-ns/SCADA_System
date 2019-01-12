using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SCADA_Core
{
    public class ScadaService : IRealTimeUnit, IAlarmDisplay, IDatabaseManager
    {
        private static Dictionary<string, string> publicKeysForRTUs = new Dictionary<string, string>();

        private static List<DigitalInput> digitalInputTags = null;
        private static List<DigitalOutput> digitalOutputTags = null;
        private static List<AnalogInput> analogInputTags = null;
        private static List<AnalogOutput> analogOutputTags = null;

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
            // @TODO @FIX This initialization move to another Init method, this is just for testing
            digitalInputTags = new List<DigitalInput>();
            digitalInputTags.Add(new DigitalInput("DI 1", "Description", "sim", "1", 1, new List<Alarm>(), false, false));
            return digitalInputTags;
        }
        
        public List<DigitalOutput> GetAllDigitalOutputs()
        {
            return digitalOutputTags;
        }

        public List<AnalogInput> GetAllAnalogInputs()
        {
            return analogInputTags;
        }

        public List<AnalogOutput> GetAllAnalogOutputs()
        {
            return analogOutputTags;
        }
    }
}
