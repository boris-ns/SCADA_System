using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [Serializable]
    [DataContract]
    public class AnalogInput : InputTag
    {
        [DataMember] private float lowLimit;
        [DataMember] private float highLimit;
        [DataMember] private string units;

        public AnalogInput()
        {
        }

        public AnalogInput(string tagName, string description, string driver, int ioAddress,
                            int scanTime, bool enableScan, bool manualMode,
                            float lowLimit, float highLimit, string units)
            : base(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode)
        {
            this.lowLimit = lowLimit;
            this.highLimit = highLimit;
            this.units = units;
        }

        public float LowLimit
        {
            get { return lowLimit; }
            set { lowLimit = value; }
        }

        public float HighLimit
        {
            get { return highLimit; }
            set { highLimit = value; }
        }

        public string Units
        {
            get { return units; }
            set { units = value; }
        }
    }
}