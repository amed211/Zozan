using System;
using System.Windows.Forms;
using System.Drawing;

namespace Zozan2DG
{
    public class LoadingForm : Form
    {
        private Label messageLabel;
        private ProgressBar spinner;

        public LoadingForm(string message)
        {
            this.Text = "Lütfen Bekleyin";
            this.Size = new Size(300, 120);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.TopMost = true;

            messageLabel = new Label()
            {
                Text = message,
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            spinner = new ProgressBar()
            {
                Style = ProgressBarStyle.Marquee,
                Dock = DockStyle.Bottom,
                Height = 20,
                MarqueeAnimationSpeed = 30
            };

            this.Controls.Add(messageLabel);
            this.Controls.Add(spinner);
        }
    }
}
