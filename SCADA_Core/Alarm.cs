using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual InputTag Tag { get; set; }

        public Alarm()
        {
        }

        public Alarm(string alarmId, DateTime alarmDateTime)
        {
            this.alarmId = alarmId;
            this.alarmDateTime = alarmDateTime;
        }

        public string AlarmId
        {
            get { return alarmId; }
            set { alarmId = value; }
        }

        public DateTime AlarmDateTime
        {
            get { return alarmDateTime; }
            set { alarmDateTime = value; }
        }
    }
}