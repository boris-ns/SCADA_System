using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_Core
{
    public abstract class Driver
    {
        public abstract float ReadValue(string tagName, string address);
    }
}
