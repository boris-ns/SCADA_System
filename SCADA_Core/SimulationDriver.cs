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

        private const float amplitude = 100;
        private Thread thread;

        public SimulationDriver(int milliseconds)
        {
            ValuesOnAddresses = new Dictionary<int, float>();
            ValuesOnAddresses[0] = 0.0f; // Sine
            ValuesOnAddresses[1] = 0.0f; // Cosine
            ValuesOnAddresses[2] = 0.0f; // Ramp
            ValuesOnAddresses[3] = 0.0f; // Triangle
            ValuesOnAddresses[4] = 0.0f; // Rectangle

            thread = new Thread(new ParameterizedThreadStart(StartSimulation));
            thread.Start(milliseconds);
        }

        private void StartSimulation(object param)
        {
            int milliseconds = (int)param;

            while (true)
            {
                ValuesOnAddresses[0] = Sine();
                ValuesOnAddresses[1] = Cosine();
                ValuesOnAddresses[2] = Ramp();
                ValuesOnAddresses[3] = Triangle();
                ValuesOnAddresses[4] = Rectangle();

                Thread.Sleep(milliseconds);
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