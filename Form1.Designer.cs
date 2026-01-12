namespace SPIDERS_UMBRELLA_CORPORATION.UI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.consoleList = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            // Custom Controls
            this.dnaSpinner = new SPIDERS_UMBRELLA_CORPORATION.UI.Controls.DnaHelixSpinner();
            this.sonarRadar = new SPIDERS_UMBRELLA_CORPORATION.UI.Controls.SonarRadar();
            this.ekgMonitor = new SPIDERS_UMBRELLA_CORPORATION.UI.Controls.EkgMonitor();
            this.btnEncrypt = new SPIDERS_UMBRELLA_CORPORATION.UI.Controls.UmbrellaButton();
            this.btnDecrypt = new SPIDERS_UMBRELLA_CORPORATION.UI.Controls.UmbrellaButton();

            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // Header Panel
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 40);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Header_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Header_MouseUp);

            // Title Label
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "UMBRELLA CORP :: HIVE TERMINAL";

            // Close Button
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.Location = new System.Drawing.Point(960, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);

            // Console ListBox
            this.consoleList.BackColor = System.Drawing.Color.Black;
            this.consoleList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleList.Font = new System.Drawing.Font("Consolas", 9F);
            this.consoleList.ForeColor = System.Drawing.Color.LimeGreen;
            this.consoleList.FormattingEnabled = true;
            this.consoleList.ItemHeight = 14;
            this.consoleList.Location = new System.Drawing.Point(20, 60);
            this.consoleList.Name = "consoleList";
            this.consoleList.Size = new System.Drawing.Size(500, 400);
            this.consoleList.TabIndex = 1;

            // DNA Spinner
            this.dnaSpinner.BackColor = System.Drawing.Color.Black;
            this.dnaSpinner.HelixColor = System.Drawing.Color.Red;
            this.dnaSpinner.Location = new System.Drawing.Point(850, 60);
            this.dnaSpinner.Name = "dnaSpinner";
            this.dnaSpinner.Size = new System.Drawing.Size(130, 500);
            this.dnaSpinner.TabIndex = 2;

            // Sonar Radar
            this.sonarRadar.BackColor = System.Drawing.Color.Black;
            this.sonarRadar.Location = new System.Drawing.Point(540, 60);
            this.sonarRadar.Name = "sonarRadar";
            this.sonarRadar.Size = new System.Drawing.Size(200, 200);
            this.sonarRadar.TabIndex = 3;

            // EKG Monitor
            this.ekgMonitor.BackColor = System.Drawing.Color.Black;
            this.ekgMonitor.Location = new System.Drawing.Point(540, 280);
            this.ekgMonitor.Name = "ekgMonitor";
            this.ekgMonitor.Size = new System.Drawing.Size(290, 100);
            this.ekgMonitor.TabIndex = 4;

            // Encrypt Button
            this.btnEncrypt.BackColor = System.Drawing.Color.DarkRed;
            this.btnEncrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncrypt.FlatAppearance.BorderSize = 0;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnEncrypt.ForeColor = System.Drawing.Color.White;
            this.btnEncrypt.Location = new System.Drawing.Point(20, 480);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(350, 50);
            this.btnEncrypt.TabIndex = 5;
            this.btnEncrypt.Text = "DEPLOY T-VIRUS (LOCK)";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.BtnEncrypt_Click);

            // Decrypt Button
            this.btnDecrypt.BackColor = System.Drawing.Color.Navy;
            this.btnDecrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecrypt.FlatAppearance.BorderSize = 0;
            this.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrypt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnDecrypt.ForeColor = System.Drawing.Color.White;
            this.btnDecrypt.Location = new System.Drawing.Point(390, 480);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(350, 50);
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "INJECT ANTI-VIRUS (UNLOCK)";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.BtnDecrypt_Click);

            // Form Properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.ekgMonitor);
            this.Controls.Add(this.sonarRadar);
            this.Controls.Add(this.dnaSpinner);
            this.Controls.Add(this.consoleList);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox consoleList;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private SPIDERS_UMBRELLA_CORPORATION.UI.Controls.DnaHelixSpinner dnaSpinner;
        private SPIDERS_UMBRELLA_CORPORATION.UI.Controls.SonarRadar sonarRadar;
        private SPIDERS_UMBRELLA_CORPORATION.UI.Controls.EkgMonitor ekgMonitor;
        private SPIDERS_UMBRELLA_CORPORATION.UI.Controls.UmbrellaButton btnEncrypt;
        private SPIDERS_UMBRELLA_CORPORATION.UI.Controls.UmbrellaButton btnDecrypt;
    }
}