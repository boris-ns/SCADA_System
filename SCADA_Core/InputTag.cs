using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [DataContract]
    public class InputTag : Tag
    {
        [DataMember] private float scanTime;
        [DataMember] private List<Alarm> alarms;
        [DataMember] private bool enableScan;
        [DataMember] private bool manualMode;

        public InputTag()
        {
        }

        public InputTag(string tagName, string description, string driver, string ioAddress,
                        float scanTime, List<Alarm> alarms, bool enableScan, bool manualMode)
            : base(tagName, description, driver, ioAddress)
        {
            this.scanTime = scanTime;
            this.alarms = alarms;
            this.enableScan = enableScan;
            this.manualMode = manualMode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}