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
        [DataMember] private List<DigitalInput> digitalInputTags;
        [DataMember] private List<DigitalOutput> digitalOutputTags;
        [DataMember] private List<AnalogInput> analogInputTags;
        [DataMember] private List<AnalogOutput> analogOutputTags;

        public ListOfTags()
        {
            digitalInputTags = new List<DigitalInput>();
            digitalOutputTags = new List<DigitalOutput>();
            analogInputTags = new List<AnalogInput>();
            analogOutputTags = new List<AnalogOutput>();
        }

        public ListOfTags(string dummy)
        {
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

        public void RemoveTag(string tagName)
        {
            if (DigitalInputs.Any(tag => tag.TagName == tagName))
                DigitalInputs.Remove(new DigitalInput() { TagName = tagName });
            else if (DigitalOutputs.Any(tag => tag.TagName == tagName))
                DigitalOutputs.Remove(new DigitalOutput() { TagName = tagName });
            else if (AnalogInputs.Any(tag => tag.TagName == tagName))
                AnalogInputs.Remove(new AnalogInput() { TagName = tagName });
            else if (AnalogOutputs.Any(tag => tag.TagName == tagName))
                AnalogOutputs.Remove(new AnalogOutput() { TagName = tagName });

            WriteTagsToFile();
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