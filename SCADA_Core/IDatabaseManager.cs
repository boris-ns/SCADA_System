using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_Core
{
    [ServiceContract]
    public interface IDatabaseManager
    {
        [OperationContract]
        ListOfTags GetTags();

        [OperationContract]
        void AddDigitalInput(string tagName, string description, string driver, string ioAddress,
                            float scanTime, bool enableScan, bool manualMode);

        [OperationContract]
        void AddDigitalOutput(string tagName, string description, string driver, string ioAddress, float initValue);

        [OperationContract]
        void AddAnalogInput(string tagName, string description, string driver, string ioAddress,
                            float scanTime, bool enableScan, bool manualMode,
                            float lowLimit, float highLimit, string units);

        [OperationContract]
        void AddAnalogOutput(string tagName, string description, string driver, string ioAddress, float initValue,
                            float lowLimit, float highLimit, string units);

        [OperationContract]
        void RemoveTag(string tagName);

        [OperationContract]
        void AddAlarm(string tagName, string alarmType, DateTime dateTimeActivated);

        [OperationContract]
        void RemoveAlarm(string tagName, string alarmId);
    }
}
