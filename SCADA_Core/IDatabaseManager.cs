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
        List<DigitalInput> GetAllDigitalInputs();

        [OperationContract]
        List<DigitalOutput> GetAllDigitalOutputs();

        [OperationContract]
        List<AnalogInput> GetAllAnalogInputs();

        [OperationContract]
        List<AnalogOutput> GetAllAnalogOutputs();

        [OperationContract]
        void AddDigitalInput(string tagName, string description, string driver, string ioAddress,
                            float scanTime, bool enableScan, bool manualMode);
    }
}
