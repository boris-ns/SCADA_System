using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AlarmDisplay
{
    class Program
    {
        private static ServiceReference.AlarmDisplayClient alarmDisplayService;

        static void Main(string[] args)
        {
            InstanceContext instanceContext = new InstanceContext(new AlarmDisplayHandler());
            alarmDisplayService = new ServiceReference.AlarmDisplayClient(instanceContext);

            alarmDisplayService.AlarmDisplayClientInit();

            Console.ReadKey();
        }
    }
}
