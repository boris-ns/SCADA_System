using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class Tag
    {
        private string tagName;
        private string description;
        private string driver;
        private string ioAddress;

        public Tag()
        {
        }

        public Tag(string tagName, string description, string driver, string ioAddress)
        {
            this.tagName = tagName;
            this.description = description;
            this.driver = driver;
            this.ioAddress = ioAddress;
        }
    }
}