namespace WinFormsClientTask
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSend = new Button();
            label1 = new Label();
            txtLog = new TextBox();
            txtNumber = new TextBox();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(0, 2, 98);
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.Yellow;
            btnSend.Location = new Point(12, 45);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(776, 29);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 1;
            label1.Text = "Number:";
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.FromArgb(0, 2, 98);
            txtLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtLog.ForeColor = Color.Yellow;
            txtLog.Location = new Point(12, 80);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(776, 358);
            txtLog.TabIndex = 3;
            // 
            // txtNumber
            // 
            txtNumber.BackColor = Color.FromArgb(0, 2, 98);
            txtNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtNumber.ForeColor = Color.Yellow;
            txtNumber.Location = new Point(84, 12);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(704, 27);
            txtNumber.TabIndex = 5;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 2, 98);
            ClientSize = new Size(800, 450);
            Controls.Add(txtNumber);
            Controls.Add(txtLog);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Name = "Client";
            Text = "Client";
            FormClosing += Client_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private Label label1;
        private TextBox txtLog;
        private TextBox txtNumber;
    }
}