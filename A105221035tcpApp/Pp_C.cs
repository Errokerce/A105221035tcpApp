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
    public partial class Pp_C : Form
    {
        public Pp_C()
        {
            InitializeComponent();
            PanalSetup();
            DoubleBuffered = true;
        }

        #region Var
        int speed = 4;
        bool isFirst, isClicking = false;
        bool isConnecting = false;
        bool IsConnect;
        byte[] data = new byte[10024];
        string enemy = "";
        string statusFormat = " {1,-16} {3} : {2} {0,16}";// {0}:player {1}:enemy {2}:PlayerPoint {3}:EnemyPoint
        delegate void deleBallMove(int x, int y);
        Point displayPoint = new Point(185, 245);
        Point outerSpace = new Point(2000, 2000);
        Point ballLoc,enemyLoc,playerLoc;
        Socket socketClient;
        Thread listenThread;
        IPEndPoint EP;
        Random rnd = new Random();
        System.Timers.Timer Btimer = new System.Timers.Timer(1);
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
                        break;
                    case "Ask":
                        try
                        {
                            if (!isConnecting)
                            {
                                isConnecting = true;
                                enemy = pt[1];
                                string input = string.Format("玩家{0} 邀請你進行遊戲。", enemy);
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
                        break;
                    case "Cencel":
                        isConnecting = false;
                        if (pt[2] == "1")
                            MsgShow("對方拒絕了遊戲邀請");
                        if (pt[2] == "2")
                            MsgShow("對方目前忙線中");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region FormEvent
        private void onlineList_LB_DoubleClick(object sender, EventArgs e)
        {
            if (onlineList_LB.SelectedIndex == -1)
                return;
            if ((enemy = onlineList_LB.GetItemText(onlineList_LB.SelectedItem)) == nickname_TB.Text)
                return;
            if (isConnecting)
                return;
            enemy = onlineList_LB.GetItemText(onlineList_LB.SelectedItem);
            isFirst = true;
            isConnecting = true;
            socketSend(string.Format("B,Ask,{0},{1},", nickname_TB.Text, enemy));
        }
        private void Pp_C_Load(object sender, EventArgs e)
        {
            Btimer.Elapsed += new System.Timers.ElapsedEventHandler(BallTimer_Elapsed);
            BallStart();
        }
        #endregion
        #region GameMethod
        int x;
        int y;
        private void BallStart()
        {
            x = rnd.Next(1, 2) * (rnd.Next(2) == 0 ? -1 : 1);
            y = rnd.Next(1, 4) * (rnd.Next(2) == 0 ? -1 : 1);
            Btimer.Start();
        }
        private void BallMove(int x,int y)
        {
            ballLoc.X += x*speed;
            ballLoc.Y += y*speed;
            if(ballLoc.Y<enemyPb.Bottom)
            {
                if (ballLoc.X< enemyPb.Right && ballLoc.X+ballPb.Width > enemyPb.Left)
                    this.y = Math.Abs(y);
                if (ballLoc.X + ballPb.Width / 2 > enemyPb.Right && ballLoc.X < enemyPb.Right)
                    this.x = x > 0 ? x : -x;
                if (ballLoc.X + ballPb.Width / 2 < enemyPb.Left && ballLoc.X > enemyPb.Left)
                    this.x = x < 0 ? x : -x;
            }
            else if (ballLoc.Y+ballPb.Height > playerPb.Top)
            {
                if (ballLoc.X < playerPb.Right && ballLoc.X + ballPb.Width > playerPb.Left)
                    this.y = y<0? y :-y;
                if (ballLoc.X + ballPb.Width / 2 > playerPb.Right && ballLoc.X < playerPb.Right)
                    this.x = x > 0 ? x : -x;
                if (ballLoc.X + ballPb.Width / 2 < playerPb.Left && ballLoc.X > playerPb.Left)
                    this.x = x < 0 ? x : -x;
            }
            if (ballLoc.X < 0)
            {
                ballLoc.X = Math.Abs(ballLoc.X);
                this.x = Math.Abs(x);
            }
            else if (ballLoc.X+ballPb.Width > gPanel.Width)
            {
                ballLoc.X = ballLoc.X - (ballLoc.X+ballPb.Width-gPanel.Width);
                this.x= -x;
            }
            if (ballLoc.Y < 0)
            {
                this.y = Math.Abs(y);
                ballLoc.Y = Math.Abs(ballLoc.Y);
            }
            else if (ballLoc.Y + ballPb.Height > gPanel.Height)
            {
                this.y = y * -1;
                ballLoc.Y = ballLoc.Y - (ballLoc.Y + ballPb.Height - gPanel.Height);
            }
            ballPb.Location = ballLoc;

        }
        void BallTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            deleBallMove D = new deleBallMove(BallMove);
            this.Invoke(D, new object[] { x,y });
        }
        #endregion
        #region PanelMethod
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

        private void playerPb_MouseMove(object sender, MouseEventArgs e)
        {
            if(isClicking)
                playerPb.Location = new Point(playerPb.Location.X+e.X-playerPb.Width/2, gPanel.Height - (30 + playerPb.Height));
        }

        private void playerPb_MouseDown(object sender, MouseEventArgs e)
        {
            isClicking = true;
        }

        private void playerPb_MouseUp(object sender, MouseEventArgs e)
        {
            isClicking = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Location = outerSpace;
        }
        private void pbtnT_Click(object sender, EventArgs e)
        {
            if (sender == pbtnT)
            {
                socketSend(string.Format("B,Accept,{0},", enemy));
            }
            else
            {
                socketSend(string.Format("B,Cencel,{0},{1},", enemy, 1));
                isConnecting = false;
            }
            panel1.Location = outerSpace;
        }
        private void PanalSetup()
        {
            playerPb.Location = new Point((gPanel.Width - playerPb.Width) / 2, gPanel.Height - ( 30+ playerPb.Height));
            enemyPb.Location = new Point((gPanel.Width - enemyPb.Width) / 2, 30);
            ballLoc =new Point((gPanel.Width - ballPb.Width) / 2, (gPanel.Height - ballPb.Height) / 2);
            ballPb.Location = ballLoc;
            panel1.Location = outerSpace;
            panel2.Location = outerSpace;
            //gStatus.Text = string.Format(statusFormat, "player0300", "pla0",3,1);
            gStatus.Text = Math.Abs(-1).ToString();
        }
        #endregion
    }
}
