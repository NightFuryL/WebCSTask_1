namespace MulticastServer
{
    partial class FormServer
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
            label2 = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            txtLog = new TextBox();
            label1 = new Label();
            cmbType = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(3, 0, 72);
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(14, 19);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "Message:";
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.FromArgb(3, 0, 72);
            txtMessage.ForeColor = Color.Yellow;
            txtMessage.Location = new Point(127, 12);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Type something...";
            txtMessage.Size = new Size(759, 27);
            txtMessage.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(3, 0, 72);
            btnSend.ForeColor = Color.Yellow;
            btnSend.Location = new Point(14, 79);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(873, 29);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.FromArgb(3, 0, 72);
            txtLog.ForeColor = Color.Yellow;
            txtLog.Location = new Point(14, 114);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(872, 324);
            txtLog.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(3, 0, 72);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(12, 53);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 8;
            label1.Text = "Message type:";
            // 
            // cmbType
            // 
            cmbType.BackColor = Color.FromArgb(3, 0, 72);
            cmbType.ForeColor = Color.Yellow;
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(127, 45);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(759, 28);
            cmbType.TabIndex = 7;
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(3, 0, 72);
            ClientSize = new Size(900, 450);
            Controls.Add(label1);
            Controls.Add(cmbType);
            Controls.Add(txtLog);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(label2);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.Yellow;
            Name = "FormServer";
            Text = "FormServer";
            Load += FormServer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtMessage;
        private Button btnSend;
        private TextBox txtLog;
        private Label label1;
        private ComboBox cmbType;
    }
}