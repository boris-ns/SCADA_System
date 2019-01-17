using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_Core
{
    [ServiceContract]
    public interface IRealTimeUnit
    {
        [OperationContract]
        bool IsRTUNameAvailable(string name);

        [OperationContract]
        void InitRealTimeUnit(string rtuName, string publicKeyPath);

        [OperationContract]
        bool SendValue(string rtuName, string message, byte[] signature);

        [OperationContract]
        void DisconnectRTU(string rtuName);
    }
}
