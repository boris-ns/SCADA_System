using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [DataContract]
    public class Tag
    {
        [DataMember] private string tagName;
        [DataMember] private string description;
        [DataMember] private string driver;
        [DataMember] private string ioAddress;

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

        public override string ToString()
        {
            return $"{tagName} {driver} {ioAddress}";
        }
    }
}