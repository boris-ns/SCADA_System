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
        [DataMember] private int alarmId;
        [DataMember] private string alarmType;
        [DataMember] private DateTime alarmDateTime;

        public virtual InputTag Tag { get; set; }

        public Alarm()
        {
        }

        public Alarm(int alarmId, string alarmType, DateTime alarmDateTime)
        {
            this.alarmId = alarmId;
            this.alarmType = alarmType;
            this.alarmDateTime = alarmDateTime;
        }

        public int AlarmId
        {
            get { return alarmId; }
            set { alarmId = value; }
        }

        public string AlarmType
        {
            get { return alarmType; }
            set { alarmType = value; }
        }

        public DateTime AlarmDateTime
        {
            get { return alarmDateTime; }
            set { alarmDateTime = value; }
        }
    }
}