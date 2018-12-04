namespace A105221035tcpApp
{
    partial class Bingo_C
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
            this.debug = new System.Windows.Forms.ListBox();
            this.nickname_Lab = new System.Windows.Forms.Label();
            this.nickname_TB = new System.Windows.Forms.TextBox();
            this.entry_Btn = new System.Windows.Forms.Button();
            this.port_Lab = new System.Windows.Forms.Label();
            this.serverIP_Lab = new System.Windows.Forms.Label();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.serverIP_TB = new System.Windows.Forms.TextBox();
            this.onlineList_LB = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pLb = new System.Windows.Forms.Label();
            this.pbtnT = new System.Windows.Forms.Button();
            this.pbtnF = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // debug
            // 
            this.debug.FormattingEnabled = true;
            this.debug.ItemHeight = 12;
            this.debug.Location = new System.Drawing.Point(694, 11);
            this.debug.Margin = new System.Windows.Forms.Padding(2);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(533, 580);
            this.debug.TabIndex = 42;
            // 
            // nickname_Lab
            // 
            this.nickname_Lab.AutoSize = true;
            this.nickname_Lab.Location = new System.Drawing.Point(582, 91);
            this.nickname_Lab.Name = "nickname_Lab";
            this.nickname_Lab.Size = new System.Drawing.Size(58, 12);
            this.nickname_Lab.TabIndex = 41;
            this.nickname_Lab.Text = "Nickname :";
            this.nickname_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nickname_TB
            // 
            this.nickname_TB.Location = new System.Drawing.Point(584, 106);
            this.nickname_TB.Name = "nickname_TB";
            this.nickname_TB.Size = new System.Drawing.Size(98, 22);
            this.nickname_TB.TabIndex = 40;
            // 
            // entry_Btn
            // 
            this.entry_Btn.Location = new System.Drawing.Point(584, 134);
            this.entry_Btn.Name = "entry_Btn";
            this.entry_Btn.Size = new System.Drawing.Size(98, 31);
            this.entry_Btn.TabIndex = 39;
            this.entry_Btn.Text = "Enter";
            this.entry_Btn.UseVisualStyleBackColor = true;
            this.entry_Btn.Click += new System.EventHandler(this.entry_Btn_Click);
            // 
            // port_Lab
            // 
            this.port_Lab.AutoSize = true;
            this.port_Lab.Location = new System.Drawing.Point(582, 51);
            this.port_Lab.Name = "port_Lab";
            this.port_Lab.Size = new System.Drawing.Size(30, 12);
            this.port_Lab.TabIndex = 38;
            this.port_Lab.Text = "Port :";
            this.port_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverIP_Lab
            // 
            this.serverIP_Lab.AutoSize = true;
            this.serverIP_Lab.Location = new System.Drawing.Point(582, 11);
            this.serverIP_Lab.Name = "serverIP_Lab";
            this.serverIP_Lab.Size = new System.Drawing.Size(54, 12);
            this.serverIP_Lab.TabIndex = 37;
            this.serverIP_Lab.Text = "Server IP :";
            this.serverIP_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(582, 66);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(100, 22);
            this.port_TB.TabIndex = 36;
            this.port_TB.Text = "5236";
            // 
            // serverIP_TB
            // 
            this.serverIP_TB.Location = new System.Drawing.Point(582, 26);
            this.serverIP_TB.Name = "serverIP_TB";
            this.serverIP_TB.Size = new System.Drawing.Size(100, 22);
            this.serverIP_TB.TabIndex = 35;
            this.serverIP_TB.Text = "127.0.0.1";
            // 
            // onlineList_LB
            // 
            this.onlineList_LB.FormattingEnabled = true;
            this.onlineList_LB.ItemHeight = 12;
            this.onlineList_LB.Location = new System.Drawing.Point(584, 170);
            this.onlineList_LB.Margin = new System.Windows.Forms.Padding(2);
            this.onlineList_LB.Name = "onlineList_LB";
            this.onlineList_LB.Size = new System.Drawing.Size(98, 424);
            this.onlineList_LB.TabIndex = 43;
            this.onlineList_LB.DoubleClick += new System.EventHandler(this.onlineList_LB_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.pLb);
            this.panel1.Controls.Add(this.pbtnT);
            this.panel1.Controls.Add(this.pbtnF);
            this.panel1.Location = new System.Drawing.Point(46, 605);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 115);
            this.panel1.TabIndex = 44;
            // 
            // pLb
            // 
            this.pLb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
            this.pLb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pLb.Location = new System.Drawing.Point(3, 10);
            this.pLb.Name = "pLb";
            this.pLb.Size = new System.Drawing.Size(251, 76);
            this.pLb.TabIndex = 1;
            this.pLb.Text = "label1";
            this.pLb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbtnT
            // 
            this.pbtnT.Location = new System.Drawing.Point(3, 89);
            this.pbtnT.Name = "pbtnT";
            this.pbtnT.Size = new System.Drawing.Size(123, 23);
            this.pbtnT.TabIndex = 0;
            this.pbtnT.Text = "同意";
            this.pbtnT.UseVisualStyleBackColor = true;
            this.pbtnT.Click += new System.EventHandler(this.pbtnT_Click);
            // 
            // pbtnF
            // 
            this.pbtnF.Location = new System.Drawing.Point(131, 89);
            this.pbtnF.Name = "pbtnF";
            this.pbtnF.Size = new System.Drawing.Size(123, 23);
            this.pbtnF.TabIndex = 0;
            this.pbtnF.Text = "拒絕";
            this.pbtnF.UseVisualStyleBackColor = true;
            this.pbtnF.Click += new System.EventHandler(this.pbtnT_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("新細明體", 12F);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(338, 605);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 115);
            this.panel2.TabIndex = 45;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 9F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(94, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Bingo_C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 598);
            this.Controls.Add(this.onlineList_LB);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.nickname_Lab);
            this.Controls.Add(this.nickname_TB);
            this.Controls.Add(this.entry_Btn);
            this.Controls.Add(this.port_Lab);
            this.Controls.Add(this.serverIP_Lab);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.serverIP_TB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Bingo_C";
            this.Text = "Bingo_C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_C_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox debug;
        private System.Windows.Forms.Label nickname_Lab;
        private System.Windows.Forms.TextBox nickname_TB;
        private System.Windows.Forms.Button entry_Btn;
        private System.Windows.Forms.Label port_Lab;
        private System.Windows.Forms.Label serverIP_Lab;
        private System.Windows.Forms.TextBox port_TB;
        private System.Windows.Forms.TextBox serverIP_TB;
        private System.Windows.Forms.ListBox onlineList_LB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label pLb;
        private System.Windows.Forms.Button pbtnT;
        private System.Windows.Forms.Button pbtnF;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}