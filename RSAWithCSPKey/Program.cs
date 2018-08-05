using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAWithCSPKey
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsaCsp = new RSAWithCSPKey();
            const string message = "Message tp Encrypt";

            rsaCsp.AssignNewKey();

            var encrypted = rsaCsp.EncryptData(Encoding.UTF8.GetBytes(message));
            var decrypted = rsaCsp.DecryptData(encrypted);

            rsaCsp.DeleteKeyInCSP();

            Console.WriteLine("RSA CSP Based Key");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Message text : {message}");
            Console.WriteLine($"Encrypted data : {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Decrypted data : {Encoding.Default.GetString(decrypted)}");
        }
    }
}
