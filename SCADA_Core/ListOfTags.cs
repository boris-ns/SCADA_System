using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SCADA_Core
{
    [Serializable]
    [XmlRoot("Tags")]
    public class ListOfTags
    {
        private static List<DigitalInput> digitalInputTags = null;
        private static List<DigitalOutput> digitalOutputTags = null;
        private static List<AnalogInput> analogInputTags = null;
        private static List<AnalogOutput> analogOutputTags = null;

        public ListOfTags()
        {
            digitalInputTags = new List<DigitalInput>();
            digitalOutputTags = new List<DigitalOutput>();
            analogInputTags = new List<AnalogInput>();
            analogOutputTags = new List<AnalogOutput>();
        }

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

        public List<AnalogInput> AnalogInputs
        {
            get { return analogInputTags; }
            set { analogInputTags = value; }
        }

        public List<AnalogOutput> AnalogOutputs
        {
            get { return analogOutputTags; }
            set { analogOutputTags = value; }
        }
    }
}