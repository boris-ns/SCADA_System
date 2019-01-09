using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
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