using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Application.Utils
{
    public class Criptografia
    {
        private readonly string aesKey = Environment.GetEnvironmentVariable("AES_SECRET");

        public Criptografia()
        {
        }

        public string EncryptString(string text)
        {
            var key = Convert.ToBase64String(Encoding.UTF8.GetBytes(aesKey));

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(Encoding.UTF8.GetBytes(key), aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.WriteAsync(text);
                        }

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[aesAlg.IV.Length + decryptedContent.Length];

                        Buffer.BlockCopy(aesAlg.IV, 0, result, 0, aesAlg.IV.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, aesAlg.IV.Length, decryptedContent.Length);
                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public async Task<string> DecryptString(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Convert.ToBase64String(Encoding.UTF8.GetBytes(aesKey));

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(Encoding.UTF8.GetBytes(key), iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = await srDecrypt.ReadToEndAsync();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}
