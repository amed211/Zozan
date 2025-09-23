using System.IO;

namespace Zozan2DG
{
    public static class Security
    {
        public static bool IsEncryptedFolder(string folderPath)
        {
            return File.Exists(Path.Combine(folderPath, "Ok.zoz"));
        }

        public static void OnExit(string folder)
        {
            string password = PasswordStore.Retrieve(folder);
            if (!string.IsNullOrEmpty(password))
            {
                Encryptor.EncryptFolder(folder, password);
                PasswordStore.Wipe(folder);
            }
        }
    }
}
