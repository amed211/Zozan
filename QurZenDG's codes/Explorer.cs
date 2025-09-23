using System;
using System.IO;
using System.Windows.Forms;

namespace Zozan2DG
{
    public class Explorer : UserControl
    {
        private ListBox listBox;
        private Button backButton;
        private ContextMenuStrip contextMenu;
        private string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public Explorer()
        {
            listBox = new ListBox() { Dock = DockStyle.Fill };            
            listBox.DoubleClick += (s, e) => EnterSelectedItem();
            listBox.MouseDown += OnListBoxRightClick;

            backButton = new Button() { Text = "⬅ Geri", Dock = DockStyle.Top };
            backButton.Click += (s, e) => GoBack();

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Şifrele", null, OnEncryptClick);

            this.Controls.Add(listBox);
            this.Controls.Add(backButton);

            LoadFolder(currentPath);
        }

        private void LoadFolder(string path)
        {
            listBox.Items.Clear();
            currentPath = path;

            if (Security.IsEncryptedFolder(path))
            {
                string password = Prompt.ShowDialog("Bu klasör şifreli. Lütfen şifreyi girin:", "Şifre Girişi");
                if (!PasswordStore.CheckAccess(path, password))
                {
                    MessageBox.Show("Yanlış şifre!", "Erişim Reddedildi");
                    return;
                }

                PasswordStore.Store(path, password);
                Decryptor.DecryptFolder(path, password);
            }

            foreach (string dir in Directory.GetDirectories(path))
                listBox.Items.Add(dir);
            foreach (string file in Directory.GetFiles(path))
                listBox.Items.Add(file);
        }

        private void EnterSelectedItem()
        {
            if (listBox.SelectedItem == null) return;
            string selectedPath = listBox.SelectedItem.ToString();
            if (Directory.Exists(selectedPath))
            {
                Security.OnExit(currentPath);
                LoadFolder(selectedPath);
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", selectedPath);
            }
        }

        private void GoBack()
        {
            string parent = Directory.GetParent(currentPath)?.FullName;
            if (parent != null)
            {
                Security.OnExit(currentPath);
                LoadFolder(parent);
            }
        }

        private void OnListBoxRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBox.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    listBox.SelectedIndex = index;
                    contextMenu.Show(Cursor.Position);
                }
            }
        }

        private void OnEncryptClick(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            string selectedPath = listBox.SelectedItem.ToString();
            EncryptContextMenu.StartEncryption(selectedPath);
            LoadFolder(currentPath); // Yeniden yükle
        }
    }
}
