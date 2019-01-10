using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_Core
{
    public interface IAlarmDisplayCallback
    {
        [OperationContract]
        void PrintAlarmsInfo(List<Alarm> alarms);
    }

    [ServiceContract(CallbackContract = typeof(IAlarmDisplayCallback))]
    public interface IAlarmDisplay
    {
        [OperationContract]
        void AlarmDisplayClientInit();
    }
}
