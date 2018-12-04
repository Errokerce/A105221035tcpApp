namespace A105221035tcpApp
{
    partial class Chat_C
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
            this.nickname_Lab = new System.Windows.Forms.Label();
            this.nickname_TB = new System.Windows.Forms.TextBox();
            this.entry_Btn = new System.Windows.Forms.Button();
            this.port_Lab = new System.Windows.Forms.Label();
            this.serverIP_Lab = new System.Windows.Forms.Label();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.serverIP_TB = new System.Windows.Forms.TextBox();
            this.chatlist = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.debug = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // onlineList_LB
            // 
            this.onlineList_LB.FormattingEnabled = true;
            this.onlineList_LB.ItemHeight = 12;
            this.onlineList_LB.Location = new System.Drawing.Point(16, 104);
            this.onlineList_LB.Margin = new System.Windows.Forms.Padding(2);
            this.onlineList_LB.Name = "onlineList_LB";
            this.onlineList_LB.Size = new System.Drawing.Size(88, 316);
            this.onlineList_LB.TabIndex = 34;
            this.onlineList_LB.SelectedIndexChanged += new System.EventHandler(this.onlineList_LB_SelectedIndexChanged);
            // 
            // nickname_Lab
            // 
            this.nickname_Lab.AutoSize = true;
            this.nickname_Lab.Location = new System.Drawing.Point(14, 68);
            this.nickname_Lab.Name = "nickname_Lab";
            this.nickname_Lab.Size = new System.Drawing.Size(58, 12);
            this.nickname_Lab.TabIndex = 33;
            this.nickname_Lab.Text = "Nickname :";
            this.nickname_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nickname_TB
            // 
            this.nickname_TB.Location = new System.Drawing.Point(73, 65);
            this.nickname_TB.Name = "nickname_TB";
            this.nickname_TB.Size = new System.Drawing.Size(100, 22);
            this.nickname_TB.TabIndex = 32;
            // 
            // entry_Btn
            // 
            this.entry_Btn.Location = new System.Drawing.Point(227, 56);
            this.entry_Btn.Name = "entry_Btn";
            this.entry_Btn.Size = new System.Drawing.Size(84, 31);
            this.entry_Btn.TabIndex = 31;
            this.entry_Btn.Text = "Enter";
            this.entry_Btn.UseVisualStyleBackColor = true;
            this.entry_Btn.Click += new System.EventHandler(this.entry_Btn_Click);
            // 
            // port_Lab
            // 
            this.port_Lab.AutoSize = true;
            this.port_Lab.Location = new System.Drawing.Point(186, 26);
            this.port_Lab.Name = "port_Lab";
            this.port_Lab.Size = new System.Drawing.Size(30, 12);
            this.port_Lab.TabIndex = 30;
            this.port_Lab.Text = "Port :";
            this.port_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverIP_Lab
            // 
            this.serverIP_Lab.AutoSize = true;
            this.serverIP_Lab.Location = new System.Drawing.Point(14, 25);
            this.serverIP_Lab.Name = "serverIP_Lab";
            this.serverIP_Lab.Size = new System.Drawing.Size(54, 12);
            this.serverIP_Lab.TabIndex = 29;
            this.serverIP_Lab.Text = "Server IP :";
            this.serverIP_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(222, 22);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(100, 22);
            this.port_TB.TabIndex = 28;
            this.port_TB.Text = "5236";
            // 
            // serverIP_TB
            // 
            this.serverIP_TB.Location = new System.Drawing.Point(73, 22);
            this.serverIP_TB.Name = "serverIP_TB";
            this.serverIP_TB.Size = new System.Drawing.Size(100, 22);
            this.serverIP_TB.TabIndex = 27;
            this.serverIP_TB.Text = "127.0.0.1";
            // 
            // chatlist
            // 
            this.chatlist.FormattingEnabled = true;
            this.chatlist.ItemHeight = 12;
            this.chatlist.Location = new System.Drawing.Point(108, 104);
            this.chatlist.Margin = new System.Windows.Forms.Padding(2);
            this.chatlist.Name = "chatlist";
            this.chatlist.Size = new System.Drawing.Size(214, 316);
            this.chatlist.TabIndex = 34;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 441);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 22);
            this.textBox1.TabIndex = 35;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown_1);
            // 
            // debug
            // 
            this.debug.FormattingEnabled = true;
            this.debug.ItemHeight = 12;
            this.debug.Location = new System.Drawing.Point(358, 22);
            this.debug.Margin = new System.Windows.Forms.Padding(2);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(533, 436);
            this.debug.TabIndex = 34;
            // 
            // Chat_C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 481);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.chatlist);
            this.Controls.Add(this.onlineList_LB);
            this.Controls.Add(this.nickname_Lab);
            this.Controls.Add(this.nickname_TB);
            this.Controls.Add(this.entry_Btn);
            this.Controls.Add(this.port_Lab);
            this.Controls.Add(this.serverIP_Lab);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.serverIP_TB);
            this.Name = "Chat_C";
            this.Text = "Chat_C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_C_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox onlineList_LB;
        private System.Windows.Forms.Label nickname_Lab;
        private System.Windows.Forms.TextBox nickname_TB;
        private System.Windows.Forms.Button entry_Btn;
        private System.Windows.Forms.Label port_Lab;
        private System.Windows.Forms.Label serverIP_Lab;
        private System.Windows.Forms.TextBox port_TB;
        private System.Windows.Forms.TextBox serverIP_TB;
        private System.Windows.Forms.ListBox chatlist;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox debug;
    }
}