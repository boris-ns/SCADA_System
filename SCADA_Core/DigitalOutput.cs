using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace SCADA_Core
{
    [DataContract]
    public class DigitalOutput : OutputTag
    {
        public DigitalOutput()
        {
        }

        public DigitalOutput(string tagName, string description, string driver, string ioAddress, float initValue)
            : base(tagName, description, driver, ioAddress, initValue)
        {
        }
    }
}