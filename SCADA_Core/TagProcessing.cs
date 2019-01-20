using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace SCADA_Core
{
    public class TagProcessing
    {
        private Dictionary<string, Thread> threads;

        public TagProcessing()
        {
            threads = new Dictionary<string, Thread>();
        }

        public void StartProcessing(Tag tag)
        {
            Thread thread = null;

            if (threads.ContainsKey(tag.TagName))
                return;

            if (tag is DigitalInput)
                thread = new Thread(new ParameterizedThreadStart(ProcessDigitalInput));
            else if (tag is DigitalOutput)
                thread = new Thread(new ParameterizedThreadStart(ProcessDigitalOutput));
            else if (tag is AnalogInput)
                thread = new Thread(new ParameterizedThreadStart(ProcessAnalogInput));
            else if (tag is AnalogOutput)
                thread = new Thread(new ParameterizedThreadStart(ProcessAnalogOutput));

            threads[tag.TagName] = thread;
            thread.Start(tag);
        }

        public void StopProcessing(string tagName)
        {
            if (!threads.ContainsKey(tagName))
                return;

            threads[tagName].Abort();
            threads.Remove(tagName);
        }

        private void WriteTagValueToDatabase(string tagName, float value)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Measurements.Add(new Measurement(tagName, value, DateTime.Now));
            }
        }

        private void ProcessDigitalInput(object tag)
        {
            DigitalInput diTag = (DigitalInput)tag;

            while (true)
            {
                // Digital input can be connected only to the simulation driver
                float valueFromDriver = ScadaService.simulationDriver.ReadValue(diTag.IOAddress);

                if (valueFromDriver <= 0) valueFromDriver = 0.0f;
                else valueFromDriver = 1.0f;

                if (diTag.ManualMode)
                {
                    valueFromDriver = diTag.ManualValue;
                    ScadaService.simulationDriver.WriteValue(diTag.IOAddress, valueFromDriver);
                }

                if (diTag.EnableScan)
                {
                    // Alarm logging
                    foreach (Alarm alarm in diTag.Alarms)
                    {
                        if (valueFromDriver < alarm.LowLimit || valueFromDriver > alarm.HighLimit)
                        {
                            alarm.AlarmDateTime = DateTime.Now;

                            if (ScadaService.alarmDisplayCallback != null)
                                ScadaService.alarmDisplayCallback.PrintAlarmInfo(alarm, diTag.TagName, valueFromDriver);
                        }
                    }

                    // Send values to trending
                    if (ScadaService.trendingCallback != null)
                        ScadaService.trendingCallback.SendNewValue(diTag.TagName, "digital", valueFromDriver);
                }

                WriteTagValueToDatabase(diTag.TagName, valueFromDriver);

                Thread.Sleep(diTag.ScanTime * 1000);
            }
        }

        private void ProcessDigitalOutput(object tag)
        {
            // Digital output can be connected only to the simulation driver
            DigitalOutput doTag = (DigitalOutput)tag;
            ScadaService.simulationDriver.WriteValue(doTag.IOAddress, doTag.InitValue);

            if (ScadaService.trendingCallback != null)
                ScadaService.trendingCallback.SendNewValue(doTag.TagName, "digital", doTag.InitValue);

            WriteTagValueToDatabase(doTag.TagName, doTag.InitValue);
        }

        private void ProcessAnalogInput(object tag)
        {
            AnalogInput aiTag = (AnalogInput)tag;

            while (true)
            {
                float valueFromDriver = 0.0f;

                // Only analog input can be connected to the real time driver
                if (aiTag.Driver == "Simulation driver")
                    valueFromDriver = ScadaService.simulationDriver.ReadValue(aiTag.IOAddress);
                else
                    valueFromDriver = ScadaService.realTimeDriver.ReadValue(aiTag.IOAddress);

                if (aiTag.ManualMode && aiTag.Driver == "Simulation driver")
                {
                    valueFromDriver = aiTag.ManualValue;
                    ScadaService.simulationDriver.WriteValue(aiTag.IOAddress, valueFromDriver);
                }

                if (aiTag.EnableScan)
                {
                    foreach (Alarm alarm in aiTag.Alarms)
                    {
                        if (valueFromDriver < alarm.LowLimit || valueFromDriver > alarm.HighLimit)
                        {
                            alarm.AlarmDateTime = DateTime.Now;
                            ScadaService.alarmDisplayCallback.PrintAlarmInfo(alarm, aiTag.TagName, valueFromDriver);
                        }
                    }

                    if (ScadaService.trendingCallback != null)
                        ScadaService.trendingCallback.SendNewValue(aiTag.TagName, "analog", valueFromDriver);
                }

                WriteTagValueToDatabase(aiTag.TagName, valueFromDriver);

                Thread.Sleep(aiTag.ScanTime * 1000);
            }
        }

        private void ProcessAnalogOutput(object tag)
        {
            // Analog output can be only connected to the simulation driver
            AnalogOutput aoTag = (AnalogOutput)tag;
            ScadaService.simulationDriver.WriteValue(aoTag.IOAddress, aoTag.InitValue);

            if (ScadaService.trendingCallback != null)
                ScadaService.trendingCallback.SendNewValue(aoTag.TagName, "analog", aoTag.InitValue);

            WriteTagValueToDatabase(aoTag.TagName, aoTag.InitValue);
        }
    }
}