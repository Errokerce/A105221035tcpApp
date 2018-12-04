namespace A105221035tcpApp
{
    partial class Chat_S
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
            this.onlineList_LB = new System.Windows.Forms.ListBox();
            this.port_Lab = new System.Windows.Forms.Label();
            this.ip_Lab = new System.Windows.Forms.Label();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.ip_TB = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // onlineList_LB
            // 
            this.onlineList_LB.FormattingEnabled = true;
            this.onlineList_LB.ItemHeight = 12;
            this.onlineList_LB.Location = new System.Drawing.Point(20, 49);
            this.onlineList_LB.Margin = new System.Windows.Forms.Padding(2);
            this.onlineList_LB.Name = "onlineList_LB";
            this.onlineList_LB.Size = new System.Drawing.Size(124, 376);
            this.onlineList_LB.TabIndex = 22;
            // 
            // port_Lab
            // 
            this.port_Lab.AutoSize = true;
            this.port_Lab.Location = new System.Drawing.Point(157, 18);
            this.port_Lab.Name = "port_Lab";
            this.port_Lab.Size = new System.Drawing.Size(30, 12);
            this.port_Lab.TabIndex = 21;
            this.port_Lab.Text = "Port :";
            this.port_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ip_Lab
            // 
            this.ip_Lab.AutoSize = true;
            this.ip_Lab.Location = new System.Drawing.Point(18, 17);
            this.ip_Lab.Name = "ip_Lab";
            this.ip_Lab.Size = new System.Drawing.Size(21, 12);
            this.ip_Lab.TabIndex = 20;
            this.ip_Lab.Text = "IP :";
            this.ip_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(193, 14);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(100, 22);
            this.port_TB.TabIndex = 19;
            this.port_TB.Text = "5236";
            // 
            // ip_TB
            // 
            this.ip_TB.Location = new System.Drawing.Point(44, 14);
            this.ip_TB.Name = "ip_TB";
            this.ip_TB.Size = new System.Drawing.Size(100, 22);
            this.ip_TB.TabIndex = 18;
            this.ip_TB.Text = "127.0.0.1";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(330, 14);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(100, 22);
            this.connectBtn.TabIndex = 17;
            this.connectBtn.Text = "建立連線";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(159, 49);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(378, 376);
            this.listBox1.TabIndex = 22;
            // 
            // Chat_S
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 440);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.onlineList_LB);
            this.Controls.Add(this.port_Lab);
            this.Controls.Add(this.ip_Lab);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.ip_TB);
            this.Controls.Add(this.connectBtn);
            this.Name = "Chat_S";
            this.Text = "Chat_S";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox onlineList_LB;
        private System.Windows.Forms.Label port_Lab;
        private System.Windows.Forms.Label ip_Lab;
        private System.Windows.Forms.TextBox port_TB;
        private System.Windows.Forms.TextBox ip_TB;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.ListBox listBox1;
    }
}