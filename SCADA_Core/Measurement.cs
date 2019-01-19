using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class Measurement
    {
        [Key]
        public string TagName { get; set; }
        public float Value { get; set; }
        public DateTime TimeStamp { get; set; }

        public Measurement()
        {
        }

        public Measurement(string tagName, float value, DateTime timeStamp)
        {
            TagName = tagName;
            Value = value;
            TimeStamp = timeStamp;
        }
    }
}