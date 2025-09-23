using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Zozan2DG
{
    public static class Decryptor
    {
        private static readonly string SABIT_KEY = "Xn3Lp9ZkQ1hB6yRj2Fv7Gc8Ma4Ts0uWd5PzY8xV3bN7mK2jH9gC1fD0eE6rI5oP4l";

        private static bool DecryptAllFiles(string folderPath, string userPassword)
        {
            foreach (string file in Directory.GetFiles(folderPath, "*.zoz"))
            {
                try
                {
                    byte[] content = File.ReadAllBytes(file);

                    byte[] layer1 = AES.Decrypt(content, SABIT_KEY);

                    byte[] decrypted = AES.Decrypt(layer1, userPassword);

                    string originalPath = file.Substring(0, file.Length - 4);
                    File.WriteAllBytes(originalPath, decrypted);
                    File.Delete(file);
                }
                catch (CryptographicException)
                {
                    MessageBox.Show("Girilen parola yanlış veya dosya bozulmuş!", "Şifre Hatası",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Şifre çözme sırasında hata oluştu:\n" + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            foreach (string sub in Directory.GetDirectories(folderPath))
            {
                bool result = DecryptAllFiles(sub, userPassword);
                if (!result) return false;
            }

            return true;
        }

        public static void DecryptFolder(string folderPath, string userPassword)
        {
            using (LoadingForm loading = new LoadingForm("Şifre çözülüyor, lütfen bekleyin..."))
            {
                Task.Run(() =>
                {
                    Thread.Sleep(200);

                    try
                    {
                        bool success = DecryptAllFiles(folderPath, userPassword);
                        if (!success)
                        {
                            loading.Invoke((MethodInvoker)(() => loading.Close()));
                            return;
                        }
                    }
                    finally
                    {
                        loading.Invoke((MethodInvoker)(() => loading.Close()));
                    }
                });

                loading.ShowDialog();
            }
        }
    }
}
