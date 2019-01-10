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

        private static void GenerateValues()
        {
            Random random = new Random();

            while (true)
            {
                float value = (float)random.NextDouble();
                string message = value.ToString();
                byte[] digitalSignature = SignMessage(message);

                rtuService.SendValue(message, digitalSignature);

                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            rtuService = new ServiceReference.RealTimeUnitClient();
            csp = new CspParameters();
            rsa = new RSACryptoServiceProvider(csp);

            string rtuName = null;

            do
            {
                Console.WriteLine("Input RTU name (id): ");
                rtuName = Console.ReadLine();
            } while (!rtuService.IsRTUNameAvailable(rtuName));

            string pathToKey = Path.Combine(EXPORT_FOLDER, rtuName + ".txt");

            ExportPublicKey(pathToKey);
            rtuService.InitRealTimeUnit(rtuName, pathToKey);
            GenerateValues();
        }
    }
}
