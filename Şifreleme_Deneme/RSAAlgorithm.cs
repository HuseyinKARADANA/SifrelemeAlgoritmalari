using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Şifreleme_Deneme
{
    public class RSAAlgorithm
    {
        public (string privateKey, string publicKey) GenerateKeyPair()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                string privateKey = rsa.ToXmlString(true);
                string publicKey = rsa.ToXmlString(false);
                return (privateKey, publicKey);
            }
        }

        public string Encrypt(string plainText, string publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(publicKey);
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] cipherBytes = rsa.Encrypt(plainBytes, false);
                return Convert.ToBase64String(cipherBytes);
            }
        }

        public string Decrypt(string cipherText, string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(privateKey);
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] plainBytes = rsa.Decrypt(cipherBytes, false);
                return Encoding.UTF8.GetString(plainBytes);
            }

        }
    }
}
