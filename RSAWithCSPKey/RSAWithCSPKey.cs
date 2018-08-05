using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RSAWithCSPKey
{
    public class RSAWithCSPKey
    {
        const string ContainerName = "FarzadContainer";

        public void AssignNewKey()
        {
            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = ContainerName;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";

            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true };
        }

        public void DeleteKeyInCSP()
        {
            var cspParams = new CspParameters { KeyContainerName = ContainerName };
            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = false };

            rsa.Clear();
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherData;

            var cspParams = new CspParameters { KeyContainerName = ContainerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                cipherData = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherData;
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            var cspParams = new CspParameters { KeyContainerName = ContainerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                plain = rsa.Decrypt(dataToDecrypt, false);
            }

            return plain;
        }
    }
}
