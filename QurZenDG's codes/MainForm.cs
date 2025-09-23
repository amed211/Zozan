using System.Windows.Forms;

namespace Zozan2DG
{
    public class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "Zozan2DG - Dosya Gezgini";
            this.Width = 800;
            this.Height = 600;

            Explorer explorer = new Explorer();
            explorer.Dock = DockStyle.Fill;
            this.Controls.Add(explorer);
        }
    }
}
