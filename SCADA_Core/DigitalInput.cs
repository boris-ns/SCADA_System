using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [Serializable]
    [DataContract]
    public class DigitalInput : InputTag
    {
        public DigitalInput()
        {
        }

        public DigitalInput(string tagName, string description, string driver, int ioAddress,
                            int scanTime, bool enableScan, bool manualMode, float manualValue)
            : base(tagName, description, driver, ioAddress, scanTime, enableScan, manualMode, manualValue)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}