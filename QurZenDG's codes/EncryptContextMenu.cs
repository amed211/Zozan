using System;
using System.IO;
using System.Windows.Forms;

namespace Zozan2DG
{
    public class EncryptContextMenu
    {
        public static void StartEncryption(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
            {
                MessageBox.Show("Seçilen yol geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = Prompt.ShowDialog("Lütfen şifre girin:", "Şifre Girişi");
            if (string.IsNullOrEmpty(password)) return;

            try
            {
                if (Directory.Exists(path))
                {
                    Encryptor.EncryptFolder(path, password);
                    MarkAsEncrypted(path); // ✅ klasörü işaretle
                }
                else if (File.Exists(path))
                {
                    Encryptor.EncryptFile(path, password);
                    MarkAsEncrypted(Path.GetDirectoryName(path)); // dosyanın bulunduğu klasörü işaretle
                }

                MessageBox.Show("Şifreleme tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void MarkAsEncrypted(string folder)
        {
            try
            {
                // Ana klasöre işaret bırak
                File.WriteAllText(Path.Combine(folder, "Ok.zoz"), "");

                // Alt klasörleri tara ve işaretle
                foreach (string sub in Directory.GetDirectories(folder, "*", SearchOption.AllDirectories))
                {
                    string okPath = Path.Combine(sub, "Ok.zoz");
                    if (!File.Exists(okPath))
                        File.WriteAllText(okPath, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ok.zoz dosyası yazılırken hata oluştu: " + ex.Message,
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
