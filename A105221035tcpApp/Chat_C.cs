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
    public partial class Chat_C : Form
    {
        public Chat_C()
        {
            InitializeComponent();
        }
        int hadSelect=-1;
        Socket socketClient;
        Thread listenThread;
        IPEndPoint EP;
        bool IsConnect;
        byte[] data = new byte[10024];


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
                        chatlist.Items.Add("[System] : 暱稱重複，請重新輸入");
                        serverIP_TB.Enabled = true;
                        port_TB.Enabled = true;
                        nickname_TB.Enabled = true;
                        entry_Btn.Enabled = true;
                        break;
                    case "list":
                        onlineList_LB.Items.Clear();
                        for (int i = 2; i < 2+int.Parse(pt[1]); i++)
                        {
                            onlineList_LB.Items.Add(pt[i]);
                        }
                        break;
                    case "Msg":
                        chatlist.Items.Add(string.Format("{0} : {1}", pt[1], pt[2]));
                        break;
                    case "Pv":
                        chatlist.Items.Add(string.Format("{0} > {1} : {2}", pt[1], pt[2], pt[3]));
                        break;
                    case "logout":
                        onlineList_LB.Items.Remove(pt[1]);
                        chatlist.Items.Add(pt[1] + " is leaving us.");
                        break;
                    case "jumpin":
                        chatlist.Items.Add(pt[1] + " Jump into this room.");
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
        
        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (onlineList_LB.SelectedIndex == -1)
                    socketSend(string.Format("Msg,{0},{1},", nickname_TB.Text, textBox1.Text));
                else
                {
                    socketSend(string.Format("Pv,{0},{1},{2},", nickname_TB.Text, onlineList_LB.GetItemText(onlineList_LB.SelectedItem), textBox1.Text));
                    chatlist.Items.Add(string.Format("{0} > {1} : {2}", nickname_TB.Text, onlineList_LB.GetItemText(onlineList_LB.SelectedItem), textBox1.Text));
                }
                textBox1.Text = null;
            }
        }

        private void onlineList_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onlineList_LB.SelectedIndex == hadSelect)
                onlineList_LB.SelectedIndex = -1;
            hadSelect = onlineList_LB.SelectedIndex;
        }

        private void Chat_C_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                socketSend("logout," + nickname_TB.Text);
            }
            catch { }
        }
    }
}
