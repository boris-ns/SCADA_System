using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class OutputTag : Tag
    {
        private float initValue;

        public OutputTag()
        {
        }

        public OutputTag(string tagName, string description, string driver, string ioAddress, float initValue)
            : base(tagName, description, driver, ioAddress)
        {
            this.initValue = initValue;
        }
    }
}