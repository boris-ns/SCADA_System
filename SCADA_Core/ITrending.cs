using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_Core
{
    public interface ITrendingCallback
    {
        [OperationContract]
        void SendNewValue(string tagName, string tagType, float value);
    }

    [ServiceContract(CallbackContract = typeof(ITrendingCallback))]
    public interface ITrending
    {
        [OperationContract]
        void TrendingClientInit();
    }
}
