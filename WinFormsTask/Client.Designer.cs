namespace WinFormsTask
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
            txtMessage = new TextBox();
            txtAsnwer = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(3, 0, 55);
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.Yellow;
            btnSend.Location = new Point(12, 78);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(776, 51);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.BackColor = Color.FromArgb(3, 0, 55);
            txtMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtMessage.ForeColor = Color.Yellow;
            txtMessage.Location = new Point(88, 12);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(700, 27);
            txtMessage.TabIndex = 1;
            // 
            // txtAsnwer
            // 
            txtAsnwer.BackColor = Color.FromArgb(3, 0, 55);
            txtAsnwer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtAsnwer.ForeColor = Color.Yellow;
            txtAsnwer.Location = new Point(88, 45);
            txtAsnwer.Name = "txtAsnwer";
            txtAsnwer.ReadOnly = true;
            txtAsnwer.Size = new Size(700, 27);
            txtAsnwer.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 3;
            label1.Text = "Message:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(3, 0, 55);
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 4;
            label2.Text = "Answer:";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(3, 0, 55);
            ClientSize = new Size(800, 141);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAsnwer);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private TextBox txtMessage;
        private TextBox txtAsnwer;
        private Label label1;
        private Label label2;
    }
}