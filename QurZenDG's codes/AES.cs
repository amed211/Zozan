using System.IO;
using System.Security.Cryptography;

namespace Zozan2DG
{
    public static class AES
    {
        public static byte[] Encrypt(byte[] data, string password)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] key = SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                aes.Key = key;
                aes.IV = new byte[16]; // sabit IV, daha sonra rastgele yapılabilir
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.Close();
                    return ms.ToArray();
                }
            }
        }

        public static byte[] Decrypt(byte[] data, string password)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] key = SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                aes.Key = key;
                aes.IV = new byte[16];
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.Close();
                    return ms.ToArray();
                }
            }
        }
    }
} 
