using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADA_Core
{
    [Serializable]
    [DataContract]
    public class Alarm
    {
        [DataMember] private string alarmId;
        [DataMember] private DateTime alarmDateTime;

        public Alarm()
        {
        }

        public Alarm(string alarmId, DateTime alarmDateTime)
        {
            this.alarmId = alarmId;
            this.alarmDateTime = alarmDateTime;
        }
    }
}