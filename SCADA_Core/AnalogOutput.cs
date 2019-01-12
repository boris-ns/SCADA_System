using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [DataContract]
    public class AnalogOutput : OutputTag
    {
        [DataMember] private float lowLimit;
        [DataMember] private float highLimit;
        [DataMember] private string units;

        public AnalogOutput()
        {
        }

        public AnalogOutput(string tagName, string description, string driver, string ioAddress, float initValue,
                            float lowLimit, float highLimit, string units)
            : base(tagName, description, driver, ioAddress, initValue)
        {
            this.lowLimit = lowLimit;
            this.highLimit = highLimit;
            this.units = units;
        }
    }
}