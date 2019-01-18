using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlarmDisplay.ServiceReference;

namespace AlarmDisplay
{
    public class AlarmDisplayHandler : ServiceReference.IAlarmDisplayCallback
    {
        private delegate void PrintInfo(string info);
        private event PrintInfo Print = null;

        public AlarmDisplayHandler()
        {
            Print += PrintInfoToConsole;
            Print += PrintInfoToFile;
        }

        public void PrintAlarmInfo(Alarm alarm, string tagName, float measuredValue)
        {
            string alarmInfo = $"Tag name {tagName}, Alarm ID: {alarm.alarmId}, " +
                                $"Name: {alarm.alarmName}, Date & Time: {alarm.alarmDateTime}, " +
                                $"Alarm type: {alarm.alarmType}, Low Limit: {alarm.lowLimit}, " +
                                $"High Limit {alarm.highLimit}, Measured value: {measuredValue}";

            Print(alarmInfo);
        }

        private void PrintInfoToFile(string info)
        {
            Console.WriteLine(info);
            Console.WriteLine("\n---------------------------------------------\n");
        }

        private void PrintInfoToConsole(string info)
        {
            using (StreamWriter writer = File.AppendText("alarmsLog.txt"))
            {
                writer.WriteLine(info);
                writer.WriteLine("---------------------------------------------");
            }
        }
    }
}
