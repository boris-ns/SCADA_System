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
        // Digital signatures
        public static string fileLocationTags = @"C:\scadaConfig.xml";
        private static Dictionary<string, string> publicKeysForRTUs = new Dictionary<string, string>();
        private static CspParameters csp = new CspParameters();
        private static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);

        private static Dictionary<string, float> realTimeDriverValues = new Dictionary<string, float>();

        // Drivers
        private static SimulationDriver simulationDriver = new SimulationDriver(1000);
        private static RealTimeDriver realTimeDriver = new RealTimeDriver();


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
        // Sometimes this function will break because it can't access requested file.
        public static void LoadTagsFromFile()
        {
            if (!File.Exists(fileLocationTags))
                return;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListOfTags));

            using (FileStream fs = new FileStream(fileLocationTags, FileMode.Open))
            {
                //listOfTags = (ListOfTags)xmlSerializer.Deserialize(fs);
            }
        }

        /*********************************************************/
        /*                    IRealTimeUnit                      */
        /*********************************************************/

        public bool IsRTUNameAvailable(string name)
        {
            return !publicKeysForRTUs.ContainsKey(name);
        }

        public bool IsIOAddressAvailable(int address)
        {
            return !realTimeDriver.ValuesOnAddresses.ContainsKey(address);
        }

        public void InitRealTimeUnit(string rtuName, int address, string publicKeyPath)
        {
            if (publicKeysForRTUs.ContainsKey(rtuName))
                return;

            lock (publicKeysForRTUs)
            {
                publicKeysForRTUs[rtuName] = publicKeyPath;
            }

            realTimeDriver.RegisterRTU(rtuName, address);
        }

        public bool SendValue(string rtuName, string message, byte[] signature)
        {
            if (!publicKeysForRTUs.ContainsKey(rtuName))
                return false;

            LoadPublicKey(publicKeysForRTUs[rtuName]);

            if (!VerifyMessage(message, signature))
                return false;

            float generatedValue = 0.0f;
            if (float.TryParse(message, out generatedValue))
            {
                realTimeDriverValues[rtuName] = generatedValue;
                return true;
            }

            return false;
        }

        public void DisconnectRTU(string rtuName)
        {
            if (publicKeysForRTUs.ContainsKey(rtuName))
            {
                publicKeysForRTUs.Remove(rtuName);
            }

            if (realTimeDriverValues.ContainsKey(rtuName))
            {
                realTimeDriverValues.Remove(rtuName);
            }

            // @TODO: Stop tags from reading ? OR in method for reading
            // always check if RTU is connected, when it isn't stop reading
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

        private void AddTagToDatabase(Tag tag)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Tags.Add(tag);
                db.SaveChanges();
            }
        }

        private void AddAlarmsToTag(InputTag tag, Alarm[] alarms)
        {
            //int lastAlarmID = 0;
            //using (DatabaseContext db = new DatabaseContext())
            //{
            //    if (db.Alarms.Count() != 0)
            //        lastAlarmID = db.Alarms.Last().AlarmId;
            //}

            //++lastAlarmID;

            foreach (Alarm alarm in alarms)
            {
                //alarm.AlarmId = lastAlarmID;
                //++lastAlarmID;
                tag.Alarms.Add(alarm);
            }
        }

        public ListOfTags GetTags()
        {
            ListOfTags list = new ListOfTags();

            using (DatabaseContext db = new DatabaseContext())
            {
                list.DigitalInputs = (from tag in db.Tags.OfType<DigitalInput>() select tag).ToList();
                list.DigitalOutputs = (from tag in db.Tags.OfType<DigitalOutput>() select tag).ToList();
                list.AnalogInputs = (from tag in db.Tags.OfType<AnalogInput>() select tag).ToList();
                list.AnalogOutputs = (from tag in db.Tags.OfType<AnalogOutput>() select tag).ToList();
            }

            return list;
        }

        public void AddDigitalInput(string tagName, string description, string driver, string ioAddress,
                            float scanTime, bool enableScan, bool manualMode, Alarm[] alarms)
        {
            DigitalInput newTag = new DigitalInput(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode);
            AddAlarmsToTag(newTag, alarms);
            AddTagToDatabase(newTag);
        }

        public void AddDigitalOutput(string tagName, string description, string driver, string ioAddress, float initValue)
        {
            DigitalOutput newTag = new DigitalOutput(tagName, description, driver, ioAddress, initValue);
            AddTagToDatabase(newTag);
        }

        public void AddAnalogInput(string tagName, string description, string driver, string ioAddress,
                                    float scanTime, bool enableScan, bool manualMode,
                                    float lowLimit, float highLimit, string units, Alarm[] alarms)
        {
            AnalogInput newTag = new AnalogInput(tagName, description, driver, ioAddress, scanTime, 
                                                enableScan, manualMode, lowLimit, highLimit, units);
            AddAlarmsToTag(newTag, alarms);
            AddTagToDatabase(newTag);
        }

        public void AddAnalogOutput(string tagName, string description, string driver, string ioAddress, 
                                    float initValue, float lowLimit, float highLimit, string units)
        {
            AnalogOutput newTag = new AnalogOutput(tagName, description, driver, ioAddress,
                                                    initValue, lowLimit, highLimit, units);
            AddTagToDatabase(newTag);
        }

        public void RemoveTag(string tagName)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Tag tagToRemove = (from tag in db.Tags where tag.TagName == tagName select tag).Single();
                db.Tags.Remove(tagToRemove);
                db.SaveChanges();
            }
        }

    }
}
