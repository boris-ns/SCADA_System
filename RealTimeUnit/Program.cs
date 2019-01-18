using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace RealTimeUnit
{
    class Program
    {
        private const string EXPORT_FOLDER = @"C:\public_keys";

        private static ServiceReference.RealTimeUnitClient rtuService;
        private static CspParameters csp;
        private static RSACryptoServiceProvider rsa;

        private static void ExportPublicKey(string pathToKey)
        {
            if (!Directory.Exists(EXPORT_FOLDER))
            {
                Directory.CreateDirectory(EXPORT_FOLDER);
            }

            using (StreamWriter writer = new StreamWriter(pathToKey))
            {
                writer.Write(rsa.ToXmlString(false));
            }
        }

        private static byte[] SignMessage(string message)
        {
            byte[] hashVal = null;

            using (SHA256 sha = SHA256Managed.Create())
            {
                hashVal = sha.ComputeHash(Encoding.UTF8.GetBytes(message));
            }

            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(rsa);
            formatter.SetHashAlgorithm("SHA256");

            return formatter.CreateSignature(hashVal);
        }

        private static void GenerateValues(string rtuName)
        {
            Random random = new Random();

            while (true)
            {
                float value = (float)random.NextDouble();
                string message = value.ToString();
                byte[] digitalSignature = SignMessage(message);

                bool success = rtuService.SendValue(rtuName, message, digitalSignature);

                if (success)
                    Console.WriteLine("RTU: " + rtuName + " sent value of " + message + " to the service.");
                else
                    Console.WriteLine("RTU: " + rtuName + " failed to send a value to the service.");

                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            rtuService = new ServiceReference.RealTimeUnitClient();
            csp = new CspParameters();
            rsa = new RSACryptoServiceProvider(csp);

            string rtuName = null;
            int ioAddress = 0;

            do
            {
                Console.Write("Enter RTU name (id): ");
                rtuName = Console.ReadLine();
            } while (!rtuService.IsRTUNameAvailable(rtuName));

            do
            {
                Console.Write("Enter I/O Address: ");
                ioAddress = int.Parse(Console.ReadLine());
            } while (!rtuService.IsIOAddressAvailable(ioAddress));

            string pathToKey = Path.Combine(EXPORT_FOLDER, rtuName + ".txt");

            ExportPublicKey(pathToKey);
            rtuService.InitRealTimeUnit(rtuName, ioAddress, pathToKey);
            GenerateValues(rtuName);
        }
    }
}
