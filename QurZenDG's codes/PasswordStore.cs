using System.IO;

namespace Zozan2DG
{
    public static class PasswordStore
    {
        private static string storeFile = "password.txt";
        private static string storeKey = "A89kdjASDçöxx21Ahfury75677495944uurjeoo4500947uoVzQxW";

        public static void Store(string folder, string password)
        {
            byte[] encrypted = AES.Encrypt(System.Text.Encoding.UTF8.GetBytes(password), storeKey);
            File.WriteAllBytes(Path.Combine(folder, storeFile), encrypted);
        }

        public static string Retrieve(string folder)
        {
            string path = Path.Combine(folder, storeFile);
            if (!File.Exists(path)) return null;
            byte[] data = File.ReadAllBytes(path);
            byte[] decrypted = AES.Decrypt(data, storeKey);
            return System.Text.Encoding.UTF8.GetString(decrypted);
        }

        public static bool CheckAccess(string folder, string password)
        {
            string stored = Retrieve(folder);
            return stored == null || stored == password;
        }

        public static void Wipe(string folder)
        {
            string path = Path.Combine(folder, storeFile);
            if (File.Exists(path))
            {
                File.WriteAllBytes(path, new byte[1024]);
                File.Delete(path);
            }
        }
    }
}
