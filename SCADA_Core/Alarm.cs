using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [DataContract]
    public class Alarm
    {
        [DataMember] private string alarmId;
        [DataMember] private Tag tag; // mozda ovo moze da koristi kao tip alarma
        [DataMember] private DateTime alarmDateTime;

        public Alarm()
        {
        }

        public Alarm(Tag tag, DateTime alarmDateTime)
        {
            this.tag = tag;
            this.alarmDateTime = alarmDateTime;
        }
    }
}