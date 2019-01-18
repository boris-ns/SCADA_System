using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace SCADA_Core
{
    public class TagProcessing
    {
        private Dictionary<Tag, Thread> threads;

        public TagProcessing()
        {
            threads = new Dictionary<Tag, Thread>();
        }

        public void StartProcessing(Tag tag)
        {
            Thread thread = null;

            if (threads.ContainsKey(tag))
                return;

            if (tag is DigitalInput)
                thread = new Thread(new ParameterizedThreadStart(ProcessDigitalInput));
            else if (tag is DigitalOutput)
                thread = new Thread(new ParameterizedThreadStart(ProcessDigitalOutput));
            else if (tag is AnalogInput)
                thread = new Thread(new ParameterizedThreadStart(ProcessAnalogInput));
            else if (tag is AnalogOutput)
                thread = new Thread(new ParameterizedThreadStart(ProcessAnalogOutput));

            threads[tag] = thread;
            thread.Start(tag);
        }

        public void StopProcessing(Tag tag)
        {
            if (!threads.ContainsKey(tag))
                return;

            threads[tag].Abort();
        }

        private void ProcessDigitalInput(object tag)
        {
            // @TODO dont forget on/off scan and auto/manual variables 

            DigitalInput diTag = (DigitalInput)tag;

            while (true)
            {
                float valueFromDriver = ScadaService.simulationDriver.ReadValue(diTag.IOAddress);

                foreach (Alarm alarm in diTag.Alarms)
                {
                    if (valueFromDriver < alarm.LowLimit || valueFromDriver > alarm.HighLimit)
                    {
                        alarm.AlarmDateTime = DateTime.Now;
                        ScadaService.alarmDisplayCallback.PrintAlarmInfo(alarm, diTag.TagName, valueFromDriver);
                    }
                }

                // notify Trending client
                // notify database - write measured value into database

                Thread.Sleep(diTag.ScanTime * 1000);
            }
        }

        private void ProcessDigitalOutput(object tag)
        {
            // @TODO dont forget on/off scan and auto/manual variables 

        }

        private void ProcessAnalogInput(object tag)
        {
            // @TODO dont forget on/off scan and auto/manual variables 

            AnalogInput aiTag = (AnalogInput)tag;

            while (true)
            {
                float valueFromDriver = 0.0f;

                if (aiTag.Driver == "Simulation driver")
                    valueFromDriver = ScadaService.simulationDriver.ReadValue(aiTag.IOAddress);
                else
                    valueFromDriver = ScadaService.realTimeDriver.ReadValue(aiTag.IOAddress);

                foreach (Alarm alarm in aiTag.Alarms)
                {
                    if (valueFromDriver < alarm.LowLimit || valueFromDriver > alarm.HighLimit)
                    {
                        alarm.AlarmDateTime = DateTime.Now;
                        ScadaService.alarmDisplayCallback.PrintAlarmInfo(alarm, aiTag.TagName, valueFromDriver);
                    }
                }

                // notify Trending client
                // notify database - write measured value into database

                Thread.Sleep(aiTag.ScanTime * 1000);
            }
        }

        private void ProcessAnalogOutput(object tag)
        {
            // @TODO dont forget on/off scan and auto/manual variables 

        }
    }
}