using System.Drawing;
using System.Security;
using System.Windows.Forms;

namespace SPIDERS_UMBRELLA_CORPORATION.UI
{
    public class PasswordDialog : Form
    {
        private readonly TextBox txtPassword;
        private readonly Button btnOk;
        private readonly Button btnCancel;
        public SecureString Password { get; private set; }

        public PasswordDialog()
        {
            // Visual Design: Matches Umbrella Theme
            this.Text = "SECURITY CLEARANCE";
            this.BackColor = Color.Black;
            this.ForeColor = Color.Red;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(400, 180);
            this.ControlBox = false;
            this.TopMost = true;

            var lblPrompt = new Label
            {
                Text = "ENTER AUTHORIZATION CODE:",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red
            };

            txtPassword = new TextBox
            {
                Location = new Point(20, 50),
                Width = 340,
                PasswordChar = '*',
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                Font = new Font("Consolas", 12)
            };

            btnOk = new Button
            {
                Text = "AUTHENTICATE",
                Location = new Point(140, 100),
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DarkRed,
                ForeColor = Color.White,
                Width = 120
            };
            btnOk.FlatAppearance.BorderSize = 0;

            btnCancel = new Button
            {
                Text = "ABORT",
                Location = new Point(270, 100),
                DialogResult = DialogResult.Cancel,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White
            };

            this.Controls.Add(lblPrompt);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;

            this.FormClosing += PasswordDialog_FormClosing;
        }

        private void PasswordDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Password = new SecureString();
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    foreach (char c in txtPassword.Text) Password.AppendChar(c);
                }
                Password.MakeReadOnly();
            }

            // AGGRESSIVE SECURITY: Wipe the plaintext buffer immediately
            txtPassword.Text = string.Empty;
        }
    }
}