using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [Serializable]
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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return false;

            Tag tag = (Tag)obj;

            return tagName == tag.tagName;
        }

        public override string ToString()
        {
            return $"{tagName} {driver} {ioAddress}";
        }

        [Key]
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public string IOAddress
        {
            get { return ioAddress; }
            set { ioAddress = value; }
        }
    }
}