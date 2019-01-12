﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [DataContract]
    public class DigitalInput : InputTag
    {
        public DigitalInput()
        {
        }

        public DigitalInput(string tagName, string description, string driver, string ioAddress,
                            float scanTime, List<Alarm> alarms, bool enableScan, bool manualMode)
            : base(tagName, description, driver, ioAddress, scanTime, alarms, enableScan, manualMode)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}