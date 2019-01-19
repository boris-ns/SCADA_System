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
    public class ScadaService : IRealTimeUnit, IAlarmDisplay, IDatabaseManager, ITrending
    {
        // Attributes for digital signatures
        //public static string fileLocationTags = @"D:\scadaConfig.xml";
        private static Dictionary<string, string> publicKeysForRTUs = new Dictionary<string, string>();
        private static CspParameters csp = new CspParameters();
        private static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);

        // Tags
        public static string fileLocationTags = "scadaConfig.xml";
        public static TagProcessing tagProcessing = new TagProcessing();
        public static ListOfTags tags = new ListOfTags("");

        // Drivers
        public static SimulationDriver simulationDriver = new SimulationDriver(1000);
        public static RealTimeDriver realTimeDriver = new RealTimeDriver();

        // Callbacks to clients
        public static IAlarmDisplayCallback alarmDisplayCallback = null;
        public static ITrendingCallback trendingCallback = null;
        

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

        private static void StartProcessingLoadedTags()
        {
            foreach (Tag tag in tags.DigitalInputs)  tagProcessing.StartProcessing(tag);
            foreach (Tag tag in tags.DigitalOutputs) tagProcessing.StartProcessing(tag);
            foreach (Tag tag in tags.AnalogInputs)   tagProcessing.StartProcessing(tag);
            foreach (Tag tag in tags.AnalogOutputs)  tagProcessing.StartProcessing(tag);
        }

        public static void LoadTagsFromFile()
        {
            if (!File.Exists(@"C:\Program Files (x86)\IIS Express\scadaConfig.xml"))
                return;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListOfTags));

            using (StreamReader reader = new StreamReader(fileLocationTags))
            {
                tags = (ListOfTags)xmlSerializer.Deserialize(reader);
            }

            StartProcessingLoadedTags();
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

            float generatedValue = float.Parse(message);
            realTimeDriver.WriteValue(rtuName, generatedValue);

            return true;
        }


        /*********************************************************/
        /*                    IAlarmDisplay                      */
        /*********************************************************/


        public void AlarmDisplayClientInit()
        {
            alarmDisplayCallback = OperationContext.Current.GetCallbackChannel<IAlarmDisplayCallback>();
        }


        /*********************************************************/
        /*                       ITrending                       */
        /*********************************************************/


        public void TrendingClientInit()
        {
            trendingCallback = OperationContext.Current.GetCallbackChannel<ITrendingCallback>();
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
            //using (DatabaseContext db = new DatabaseContext())
            //{
            //    if (db.Alarms.Count() != 0)
            //        lastAlarmID = db.Alarms.Last().AlarmId;
            //}

            // Alarm is identified by tag name and alarmID
            int lastAlarmId = 0;
            Alarm lastAlarm = tag.Alarms.LastOrDefault();

            if (lastAlarm != null)
                ++lastAlarmId;

            foreach (Alarm alarm in alarms)
            {
                alarm.AlarmId = lastAlarmId;
                ++lastAlarmId;
                tag.Alarms.Add(alarm);
            }
        }

        public ListOfTags GetTags()
        {
            // Database way to load all tags
            //ListOfTags list = new ListOfTags();

            //using (DatabaseContext db = new DatabaseContext())
            //{
            //    list.DigitalInputs = (from tag in db.Tags.OfType<DigitalInput>() select tag).ToList();
            //    list.DigitalOutputs = (from tag in db.Tags.OfType<DigitalOutput>() select tag).ToList();
            //    list.AnalogInputs = (from tag in db.Tags.OfType<AnalogInput>() select tag).ToList();
            //    list.AnalogOutputs = (from tag in db.Tags.OfType<AnalogOutput>() select tag).ToList();
            //}

            //return list;

            // XML way to load all tags
            LoadTagsFromFile();
            return tags;
        }

        public void AddDigitalInput(string tagName, string description, string driver, int ioAddress,
                            int scanTime, bool enableScan, bool manualMode, Alarm[] alarms)
        {
            DigitalInput newTag = new DigitalInput(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode);
            AddAlarmsToTag(newTag, alarms);
            //AddTagToDatabase(newTag);
            tags.DigitalInputs.Add(newTag);
            tagProcessing.StartProcessing(newTag);
            tags.WriteTagsToFile();
        }

        public void AddDigitalOutput(string tagName, string description, string driver, int ioAddress, float initValue)
        {
            DigitalOutput newTag = new DigitalOutput(tagName, description, driver, ioAddress, initValue);
            //AddTagToDatabase(newTag);
            tags.DigitalOutputs.Add(newTag);
            tags.WriteTagsToFile();
        }

        public void AddAnalogInput(string tagName, string description, string driver, int ioAddress,
                                    int scanTime, bool enableScan, bool manualMode,
                                    float lowLimit, float highLimit, string units, Alarm[] alarms)
        {
            AnalogInput newTag = new AnalogInput(tagName, description, driver, ioAddress, scanTime, 
                                                enableScan, manualMode, lowLimit, highLimit, units);
            AddAlarmsToTag(newTag, alarms);
            //AddTagToDatabase(newTag);
            tags.AnalogInputs.Add(newTag);
            tags.WriteTagsToFile();
        }

        public void AddAnalogOutput(string tagName, string description, string driver, int ioAddress, 
                                    float initValue, float lowLimit, float highLimit, string units)
        {
            AnalogOutput newTag = new AnalogOutput(tagName, description, driver, ioAddress,
                                                    initValue, lowLimit, highLimit, units);
            //AddTagToDatabase(newTag);
            tags.AnalogOutputs.Add(newTag);
            tags.WriteTagsToFile();
        }

        public void RemoveTag(string tagName)
        {
            //using (DatabaseContext db = new DatabaseContext())
            //{
            //    Tag tagToRemove = (from tag in db.Tags where tag.TagName == tagName select tag).Single();
            //    db.Tags.Remove(tagToRemove);
            //    db.SaveChanges();
            //}

            tags.RemoveTag(tagName);
        }

    }
}
