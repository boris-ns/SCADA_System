using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class SimulationDriver : Driver
    {
        private const double amplitude = 100;

        public SimulationDriver()
        {
        }

        public override float ReadValue(string tagName, string address)
        {
            // @TODO implement this !
            throw new NotImplementedException();
        }

        public static double Sine()
        {
            return amplitude * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
        }

        public static double Cosine()
        {
            return amplitude * Math.Cos((double)DateTime.Now.Second / 60 * Math.PI);
        }

        public static double Ramp()
        {
            return amplitude * DateTime.Now.Second / 60;
        }

        public static double Triangle()
        {
            return ((2 * amplitude) / Math.PI) * Math.Asin(Math.Sin(2 * Math.PI * DateTime.Now.Second / 60.0));
        }

        public static double Rectangle()
        {
            return amplitude * Math.Sign(Math.Sin((DateTime.Now.Second % 10) / 5.0));
        }
    }
}