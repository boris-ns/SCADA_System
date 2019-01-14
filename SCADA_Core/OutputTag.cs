using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace SCADA_Core
{
    [DataContract]
    public class OutputTag : Tag
    {
        [DataMember] private float initValue;

        public OutputTag()
        {
        }

        public OutputTag(string tagName, string description, string driver, string ioAddress, float initValue)
            : base(tagName, description, driver, ioAddress)
        {
            this.initValue = initValue;
        }

        public float InitValue
        {
            get { return initValue; }
            set { initValue = value; }
        }
    }
}