using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class RealTimeDriver
    {
        // key is RTU's name(ID), value is ioAddress where it is writing values
        public Dictionary<string, int> SubscribedRTUs { get; set; }

        // key is ioAddress, value is values that RTU is writing
        public Dictionary<int, float> ValuesOnAddresses { get; set; }

        public RealTimeDriver()
        {
            SubscribedRTUs = new Dictionary<string, int>();
            ValuesOnAddresses = new Dictionary<int, float>();
        }

        public void RegisterRTU(string rtuName, int address)
        {
            if (SubscribedRTUs.ContainsKey(rtuName))
                return;

            lock (SubscribedRTUs)
            {
                SubscribedRTUs[rtuName] = address;
            }

            lock (ValuesOnAddresses)
            {
                ValuesOnAddresses[address] = 0.0f;
            }
        }

        public float ReadValue(int address)
        {
            if (!ValuesOnAddresses.ContainsKey(address))
                return 0.0f;

            return ValuesOnAddresses[address];
        }

        public void WriteValue(string rtuName, float value)
        {
            int address = SubscribedRTUs[rtuName];
            
            lock (ValuesOnAddresses)
            {
                ValuesOnAddresses[address] = value;
            }
        }
    }
}