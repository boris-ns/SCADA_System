using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class SimulationDriver
    {
        private const double amplitude = 100;

        public SimulationDriver()
        {
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
            // @TODO: implement this
            return 0;
        }

        public static double Rectangle()
        {
            // @TODO: implement this
            return 0;
        }
    }
}