using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataMember] private string alarmName;
        [DataMember] private int alarmId;
        [DataMember] private string alarmType;
        [DataMember] private DateTime alarmDateTime;
        [DataMember] private float lowLimit;
        [DataMember] private float highLimit;

        public virtual InputTag Tag { get; set; }

        public Alarm()
        {
        }

        public Alarm(string alarmName, int alarmId, string alarmType, DateTime alarmDateTime)
        {
            this.alarmName = alarmName;
            this.alarmId = alarmId;
            this.alarmType = alarmType;
            this.alarmDateTime = alarmDateTime;
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int AlarmId
        {
            get { return alarmId; }
            set { alarmId = value; }
        }

        public string AlarmName
        {
            get { return alarmName; }
            set { alarmName = value; }
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

        public float LowLimit
        {
            get { return lowLimit; }
            set { lowLimit = value; }
        }

        public float HighLimit
        {
            get { return highLimit; }
            set { highLimit = value; }
        }
    }
}