namespace MulticastClient
{
    partial class FormClient
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
            clbTypes = new CheckedListBox();
            btnConnect = new Button();
            txtLog = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // clbTypes
            // 
            clbTypes.BackColor = Color.FromArgb(3, 0, 72);
            clbTypes.ForeColor = Color.Yellow;
            clbTypes.FormattingEnabled = true;
            clbTypes.Location = new Point(14, 35);
            clbTypes.Name = "clbTypes";
            clbTypes.Size = new Size(710, 70);
            clbTypes.TabIndex = 0;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(3, 0, 72);
            btnConnect.Location = new Point(14, 111);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(711, 29);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.FromArgb(3, 0, 72);
            txtLog.ForeColor = Color.Yellow;
            txtLog.Location = new Point(14, 150);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.PlaceholderText = "Messages...";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(710, 195);
            txtLog.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 3;
            label1.Text = "Message type:";
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(3, 0, 72);
            ClientSize = new Size(738, 357);
            Controls.Add(label1);
            Controls.Add(txtLog);
            Controls.Add(btnConnect);
            Controls.Add(clbTypes);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.Yellow;
            Name = "FormClient";
            Text = "FormClient";
            FormClosing += FormClient_FormClosing;
            Load += FormClient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox clbTypes;
        private Button btnConnect;
        private TextBox txtLog;
        private Label label1;
    }
}