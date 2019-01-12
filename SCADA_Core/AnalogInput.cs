using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [DataContract]
    public class AnalogInput : InputTag
    {
        [DataMember] private float lowLimit;
        [DataMember] private float highLimit;
        [DataMember] private string units;

        public AnalogInput()
        {
        }

        public AnalogInput(string tagName, string description, string driver, string ioAddress,
                            float scanTime, List<Alarm> alarms, bool enableScan, bool manualMode,
                            float lowLimit, float highLimit, string units)
            : base(tagName, description, driver, ioAddress, scanTime, alarms, enableScan, manualMode)
        {
            this.lowLimit = lowLimit;
            this.highLimit = highLimit;
            this.units = units;
        }
    }
}