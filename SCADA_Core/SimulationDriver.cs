using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SCADA_Core
{
    public class SimulationDriver
    {
        // key - ioAddress, value - value that SimDriver will write
        public Dictionary<int, float> ValuesOnAddresses { get; set; }
        public Dictionary<int, bool> ValueOverriden { get; set; }

        private Thread thread;
        private const float amplitude = 100;

        public SimulationDriver()
        {
            ValuesOnAddresses = new Dictionary<int, float>();
            ValueOverriden = new Dictionary<int, bool>();

            ValuesOnAddresses[0] = 0.0f; // Sine
            ValueOverriden[0] = false;
            ValuesOnAddresses[1] = 0.0f; // Cosine
            ValueOverriden[1] = false;
            ValuesOnAddresses[2] = 0.0f; // Ramp
            ValueOverriden[2] = false;
            ValuesOnAddresses[3] = 0.0f; // Triangle
            ValueOverriden[3] = false;
            ValuesOnAddresses[4] = 0.0f; // Rectangle
            ValueOverriden[4] = false;

            thread = new Thread(new ParameterizedThreadStart(StartSimulation));
            thread.Start(1000);
        }

        private void StartSimulation(object param)
        {
            while (true)
            {
                if (!ValueOverriden[0]) ValuesOnAddresses[0] = Sine();
                if (!ValueOverriden[1]) ValuesOnAddresses[1] = Cosine();
                if (!ValueOverriden[2]) ValuesOnAddresses[2] = Ramp();
                if (!ValueOverriden[3]) ValuesOnAddresses[3] = Triangle();
                if (!ValueOverriden[4]) ValuesOnAddresses[4] = Rectangle();
                
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            thread.Abort();
        }

        public float ReadValue(int ioAddress)
        {
            if (!ValuesOnAddresses.ContainsKey(ioAddress))
                return 0.0f;

            return ValuesOnAddresses[ioAddress];
        }

        public void WriteValue(int ioAddress, float newValue)
        {
            ValueOverriden[ioAddress] = true;
            ValuesOnAddresses[ioAddress] = newValue;
        }

        private float Sine()
        {
            return (float) (amplitude * Math.Sin((float)DateTime.Now.Second / 60 * Math.PI));
        }

        private float Cosine()
        {
            return (float) (amplitude * Math.Cos((float)DateTime.Now.Second / 60 * Math.PI));
        }

        private float Ramp()
        {
            return (float) amplitude * DateTime.Now.Second / 60;
        }

        private float Triangle()
        {
            return (float) (((2 * amplitude) / Math.PI) * Math.Asin(Math.Sin(2 * Math.PI * DateTime.Now.Second / 60.0)));
        }

        private float Rectangle()
        {
            return (float) (amplitude * Math.Sign(Math.Sin((DateTime.Now.Second % 10) / 5.0)));
        }
    }
}