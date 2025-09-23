using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zozan2DG
{
    public static class Encryptor
    {
        // 64 karakterlik sabit anahtar (her derlemede değiştirilmeli)
        private static readonly string SABIT_KEY = "Xn3Lp9ZkQ1hB6yRj2Fv7Gc8Ma4Ts0uWd5PzY8xV3bN7mK2jH9gC1fD0eE6rI5oP4l";

        public static void EncryptFile(string filePath, string userPassword)
        {
            if (!File.Exists(filePath)) return;

            byte[] original = File.ReadAllBytes(filePath);

            // 1. Katman: sabit anahtarla şifrele
            byte[] step1 = AES.Encrypt(original, userPassword);

            // 2. Katman: kullanıcı şifresiyle şifrele
            byte[] final = AES.Encrypt(step1, SABIT_KEY);

            File.WriteAllBytes(filePath + ".zoz", final);
            File.Delete(filePath); // orijinal dosya siliniyor
        }

        private static void EncryptAllFiles(string folderPath, string userPassword)
        {
            foreach (var file in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                if (!file.EndsWith(".zoz"))
                {
                    EncryptFile(file, userPassword);
                }
            }
        }

        public static void EncryptFolder(string folderPath, string userPassword)
        {
            using (LoadingForm loading = new LoadingForm("Klasör şifreleniyor, lütfen bekleyin..."))
            {
                Task.Run(() =>
                {
                    Thread.Sleep(200); // pencere düzgün yüklensin
                    EncryptAllFiles(folderPath, userPassword);
                    loading.Invoke((MethodInvoker)(() => loading.Close()));
                });

                loading.ShowDialog();
            }
        }
    }
}
