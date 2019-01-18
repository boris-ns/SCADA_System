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
        bool IsIOAddressAvailable(int address);

        [OperationContract]
        void InitRealTimeUnit(string rtuName, int address, string publicKeyPath);

        [OperationContract]
        bool SendValue(string rtuName, string message, byte[] signature);
    }
}
