using System.Windows.Forms;

namespace Zozan2DG
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = caption
            };
            Label lbl = new Label() { Text = text, Dock = DockStyle.Top };
            TextBox inputBox = new TextBox() { Dock = DockStyle.Top, UseSystemPasswordChar = true };
            Button confirmation = new Button() { Text = "OK", Dock = DockStyle.Bottom };
            confirmation.Click += (s, e) => { prompt.Close(); };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(lbl);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();
            return inputBox.Text;
        }
    }
}
