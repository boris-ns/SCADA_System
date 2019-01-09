using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class AnalogOutput : OutputTag
    {
        private float lowLimit;
        private float highLimit;
        private string units;

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