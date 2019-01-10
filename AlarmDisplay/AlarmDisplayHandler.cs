using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlarmDisplay.ServiceReference;

namespace AlarmDisplay
{
    public class AlarmDisplayHandler : ServiceReference.IAlarmDisplayCallback
    {
        public void PrintAlarmsInfo(Alarm[] alarms)
        {
            // @TODO: implement this!
            // it will be basic foreach loop and printing alarm parameters to the console and file
            throw new NotImplementedException();
        }
    }
}
