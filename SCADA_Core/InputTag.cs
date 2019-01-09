using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class InputTag : Tag
    {
        private float scanTime;
        private List<Alarm> alarms;
        private bool enableScan;
        private bool manualMode;

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
    }
}