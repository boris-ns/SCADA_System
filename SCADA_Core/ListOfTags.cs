using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace SCADA_Core
{
    [XmlRoot("Tags")]
    [DataContract]
    public class ListOfTags
    {
        [DataMember] private List<DigitalInput> digitalInputTags = null;
        [DataMember] private List<DigitalOutput> digitalOutputTags = null;
        [DataMember] private List<AnalogInput> analogInputTags = null;
        [DataMember] private List<AnalogOutput> analogOutputTags = null;

        public ListOfTags()
        {
            digitalInputTags = new List<DigitalInput>();
            digitalOutputTags = new List<DigitalOutput>();
            analogInputTags = new List<AnalogInput>();
            analogOutputTags = new List<AnalogOutput>();

            ScadaService.LoadTagsFromFile();
        }

        public void WriteTagsToFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListOfTags));

            using (FileStream fs = new FileStream(ScadaService.fileLocationTags, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, this);
            }
        }

        [XmlArray("DigitalInputs"), XmlArrayItem(typeof(DigitalInput), ElementName = "DigitalInput")]
        public List<DigitalInput> DigitalInputs
        {
            get { return digitalInputTags; }
            set { digitalInputTags = value; }
        }

        [XmlArray("DigitalOutputs"), XmlArrayItem(typeof(DigitalOutput), ElementName = "DigitalOutput")]
        public List<DigitalOutput> DigitalOutputs
        {
            get { return digitalOutputTags; }
            set { digitalOutputTags = value; }
        }

        [XmlArray("AnalogInputs"), XmlArrayItem(typeof(AnalogInput), ElementName = "AnalogInput")]
        public List<AnalogInput> AnalogInputs
        {
            get { return analogInputTags; }
            set { analogInputTags = value; }
        }

        [XmlArray("AnalogOutputs"), XmlArrayItem(typeof(AnalogOutput), ElementName = "AnalogOutput")]
        public List<AnalogOutput> AnalogOutputs
        {
            get { return analogOutputTags; }
            set { analogOutputTags = value; }
        }
    }
}