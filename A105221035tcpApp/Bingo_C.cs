using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A105221035tcpApp
{
    public partial class Bingo_C : Form
    {
        public Bingo_C()
        {
            InitializeComponent();
        }
        public Bingo_C(string playerName)
        {
            InitializeComponent();
            nickname_TB.Text = playerName;
        }
        #region Var
        Button[,] btns = new Button[5, 5];
        bool isFirst, isShow = false;
        bool isConnecting = false;
        string player = "";
        Socket socketClient;
        Thread listenThread;
        IPEndPoint EP;
        bool IsConnect;
        byte[] data = new byte[10024];
        Point displayPoint = new Point(185, 245);
        Point outerSpace = new Point(2000, 2000);
        int winpoint = 2;
        #endregion

        #region FormEvent
        private void Form_Load(object sender, EventArgs e)
        {
            btnInit();
            //MsgShow("sssssss");
            //panalInti("ssssssss", "sdad", "asdsad");
            panel1.Location = outerSpace;
            panel2.Location = outerSpace;
        }
        private void btnC(object sender, EventArgs e)
        {
            if (isFirst)
            {
                (sender as Button).Enabled = false;
                socketSend(string.Format("B,C,{0},{1},", player, (sender as Button).Text));
                isFirst = false;
                if (Check() == winpoint)
                {
                    socketSend(string.Format("B,Win,{0},{1}.", player, nickname_TB.Text));
                    foreach (Button btn in btns) btn.Click -= new EventHandler(btnC);
                    MsgShow("您以獲勝");
                    isConnecting = false;
                }
                //udpSend("C," + (sender as Button).Text);
                //listBox1.Items.Add("Local clicked " + (sender as Button).Tag + " ,now line " + Check());
            }
        }
        private void entry_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (serverIP_TB.Text != "" && port_TB.Text != "" && nickname_TB.Text != "")      //checking TB != ""
                {
                    socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    EP = new IPEndPoint(IPAddress.Parse(serverIP_TB.Text), int.Parse(port_TB.Text));
                    socketClient.Connect(EP);
                    listenThread = new Thread(socketReceive);
                    listenThread.IsBackground = true;
                    listenThread.Start();
                    IsConnect = true;
                    socketSend("login," + nickname_TB.Text + ",");

                    serverIP_TB.Enabled = false;
                    port_TB.Enabled = false;
                    nickname_TB.Enabled = false;
                    entry_Btn.Enabled = false;
                }
                else
                {
                    MessageBox.Show("請輸入完整資訊");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pbtnT_Click(object sender, EventArgs e)
        {
            if (sender == pbtnT)
            {
                socketSend(string.Format("B,Accept,{0},", player));
                btnRnd();
            }
            else
            {
                socketSend(string.Format("B,Cencel,{0},{1},", player, 1));
                isConnecting = false;
            }
            panel1.Location = outerSpace;
        }
        private void Chat_C_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                socketSend("logout," + nickname_TB.Text);
            }
            catch { }
            //Application.Exit();
        }
        #endregion
        #region Socket
        public void socketReceive()
        {
            int recvLength = 0;
            try
            {
                do
                {
                    recvLength = socketClient.Receive(data);
                    if (recvLength > 0)
                    {
                        Receive(Encoding.Default.GetString(data).Trim());       //將接收到的 byte 資料 轉換成 string 並呼叫 receive 方法
                        Array.Clear(data, 0, data.Length);
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void socketSend(string sendData)
        {
            if (IsConnect)
            {
                try
                {
                    socketClient.Send(Encoding.Default.GetBytes(sendData));     //將要傳送的 string 資料 轉換成 byte 傳送出去
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {

            }
        }
        public void Receive(string recvData) //接收並判斷資料
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            try
            {
                char token = ',';
                string[] pt = recvData.Split(token);        //將接收資料用 , 切割並存入陣列
                debug.Items.Add(recvData);
                switch (pt[0])      //使用陣列中第一筆資料溝通
                {
                    case "deny":
                        MsgShow("[System] : 暱稱重複，請重新輸入");
                        serverIP_TB.Enabled = true;
                        port_TB.Enabled = true;
                        nickname_TB.Enabled = true;
                        entry_Btn.Enabled = true;
                        break;
                    case "list":
                        onlineList_LB.Items.Clear();
                        for (int i = 2; i < 2 + int.Parse(pt[1]); i++)
                        {
                            onlineList_LB.Items.Add(pt[i]);
                        }
                        break;
                    case "logout":
                        onlineList_LB.Items.Remove(pt[1]);
                        if (pt[1] == player)
                        {
                            MsgShow("您的對手離開了遊戲，請尋找新對手");
                            isConnecting = false;
                        }

                        break;
                    case "Ask":
                        try
                        {
                            if (!isConnecting)
                            {
                                isConnecting = true;
                                player = pt[1];
                                string input = string.Format("玩家{0} 邀請你進行遊戲。", player);
                                PanalInti(input);
                            }
                            else
                                socketSend(string.Format("B,Cencel,{0},{1},", pt[1], 2));
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    case "Accept":
                        foreach (Button btn in btns) btn.Click += new EventHandler(btnC);
                        btnRnd();
                        break;
                    case "Cencel":
                        isConnecting = false;
                        if (pt[2] == "1")
                            MsgShow("對方拒絕了遊戲邀請");
                        if (pt[2] == "2")
                            MsgShow("對方目前忙線中");
                        break;
                    case "C":
                        foreach (Button btn in btns)
                            if (btn.Text.Equals(pt[2]))
                                btn.Enabled = false;
                        if (Check() == winpoint)
                        {
                            socketSend(string.Format("B,Win,{0},{1}.",player, nickname_TB.Text));
                            foreach (Button btn in btns) btn.Click -= new EventHandler(btnC);
                            MsgShow("您以獲勝");
                            isConnecting = false;
                        }
                        //udpSend("W");
                        isFirst = true;
                        break;
                    case "Win":
                        foreach (Button btn in btns) btn.Click -= new EventHandler(btnC);
                        MsgShow(string.Format("玩家{0} 以獲勝", player));
                        isConnecting = false;
                        break;
                }
                pt = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Method
        private void PanalInti(string Ls)
        {
            try
            {
                pLb.Text = Ls;
                panel1.Location = displayPoint;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e.ToString());
            }
        }
        private void MsgShow(string s)
        {
            label1.Text = s;
            panel2.Location = displayPoint;
        }
        private void btnInit()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    btns[i, j] = new Button()
                    {
                        Text = "",
                        Tag = i + "," + j,
                        Location = new Point(10 + 115 * i, 10 + 115 * j),
                        Size = new Size(100, 100),
                        Enabled = false
                    };

                    this.Controls.Add(btns[i, j]);
                }
            }
        }
        private void btnRnd()
        {
            foreach (Button btn in btns)
            {
                btn.Text = "0";
                btn.Click += new EventHandler(btnC);
            }
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 1; i <= 25; i++)
            {
                int bi, bj;
                do
                {
                    bi = rnd.Next(5);
                    bj = rnd.Next(5);
                } while (btns[bi, bj].Text != "0");
                btns[bi, bj].Text = i.ToString();
                btns[bi, bj].Enabled = true;
            }

        }
        private void ReceiveProcess(String ss)
        {
            string[] args = ss.Split(',');

            switch (args[0])
            {
                case "C":
                    foreach (Button btn in btns)
                        if (btn.Text == args[1])
                            btn.Enabled = false;
                    if (Check() == 5)
                        socketSend("B,w," + nickname_TB.Text + ",");
                    //udpSend("W");
                    isFirst = true;
                    break;
                case "W":
                    foreach (Button btn in btns) btn.Click -= new EventHandler(btnC);
                    if (Check() == 5 && isShow == false)
                        MessageBox.Show(this.Text + "You Win!!!!!");
                    else
                        MessageBox.Show(this.Text + "You Lose....");
                    isShow = true;
                    break;
                case "cl":
                    btnRnd();
                    isShow = false;
                    break;
                case "CF":
                    isFirst = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Location = outerSpace;
        }

        private void onlineList_LB_DoubleClick(object sender, EventArgs e)
        {
            if (onlineList_LB.SelectedIndex == -1)
                return;
            if ((player = onlineList_LB.GetItemText(onlineList_LB.SelectedItem)) == nickname_TB.Text)
                return;
            if (isConnecting)
                return;
            player = onlineList_LB.GetItemText(onlineList_LB.SelectedItem);
            isFirst = true;
            isConnecting = true;
            socketSend(string.Format("B,Ask,{0},{1},", nickname_TB.Text, player));
        }

        private int Check()
        {
            int line = 0, p3 = 0, p4 = 0;
            for (int i = 0; i < 5; i++)
            {
                int p1 = 0, p2 = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (!btns[i, j].Enabled)
                    {
                        p1++;
                    }
                    if (!btns[j, i].Enabled)
                    {
                        p2++;
                    }
                }
                if (p1 == 5)
                    line++;
                if (p2 == 5)
                    line++;
                if (!btns[i, i].Enabled)
                    p3++;
                if (!btns[i, 4 - i].Enabled)
                    p4++;
            }
            if (p3 == 5)
                line++;
            if (p4 == 5)
                line++;
            return line;
        }
        #endregion
    }
}
