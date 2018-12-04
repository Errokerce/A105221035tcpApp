using System;
using System.Collections;
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
    public partial class Chat_S : Form
    {
        public Chat_S()
        {
            InitializeComponent();
        }
        #region Gglobal Variable
        TcpListener server;
        Hashtable HT = new Hashtable(); //宣告雜湊表
        Socket socketClient;            //建立 socket 物件
        Thread Th_Svr, Th_Clt;          //宣告兩個子執行續處理接聽
        #endregion

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Th_Svr = new Thread(ServerSub);
            Th_Svr.IsBackground = true;
            Th_Svr.Start();

            connectBtn.Enabled = false;
        }


        private void ServerSub()
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(ip_TB.Text), int.Parse(port_TB.Text));
            server = new TcpListener(EP);       //建立伺服器端接收器(總機)
            server.Start(100);

            while (true)
            {
                socketClient = server.AcceptSocket();
                Th_Clt = new Thread(listen);
                Th_Clt.IsBackground = true;
                Th_Clt.Start();
            }
        }

        private void listen()
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            Socket sck = socketClient;      //將此socket儲存起來
            Thread Th = Th_Clt;             //將此執行續儲存起來
            string id = null;               //宣告一個

            while (true)
            {
                try
                {
                    byte[] B = new byte[10024];
                    int inLen = sck.Receive(B);
                    string ss = Encoding.Default.GetString(B, 0, inLen);
                    listBox1.Items.Add(ss);
                    string[] Msg =ss.Split(',');
                    
                    switch (Msg[0])
                    {
                        case "login":
                            try
                            {
                                HT.Add(Msg[1], sck);
                                id = Msg[1];
                                onlineList_LB.Items.Add(Msg[1]);
                                sendAll(onlineList());
                                sendAll("jumpin," + Msg[1]+",");
                            }
                            catch
                            {
                                sendTo("deny,", sck);
                            }
                            break;
                        case "logout":
                            HT.Remove(Msg[1]);
                            onlineList_LB.Items.Remove(Msg[1]);
                            sendAll(string.Format("logout,{0},", Msg[1]));
                            Th.Abort();
                            break;
                        case "deny":
                            MessageBox.Show("ID重複");
                            break;
                        case "Msg":
                            sendAll(string.Format("Msg,{0},{1},", Msg[1], Msg[2]));
                            listBox1.Items.Add(string.Format("Msg, {0} : {1}", Msg[1], Msg[2]));
                            break;
                        case "Pv":
                            sendTo(string.Format("Pv,{0},{1},{2},", Msg[1], Msg[2], Msg[3]), (Socket)HT[Msg[2]]);
                            listBox1.Items.Add(string.Format("Pv, {0} > {1} : {2}", Msg[1], Msg[2], Msg[3]));
                            break;
                        case "B":
                            bingo(Msg);
                            break;
                    }
                    B = null;
                    Msg = null;
                }
                catch
                {
                    //sendAll("message," + id + "logout.");
                }
            }
        }

        private void bingo(string[] args)
        {
            switch (args[1])
            {
                case "Ask":
                    sendTo(string.Format("Ask,{0},", args[2]), (Socket)HT[args[3]]);
                    break;
                case "Accept":
                    sendTo(string.Format("Accept,{0},", args[2]), (Socket)HT[args[2]]);
                    break;
                case "Cencel":
                    sendTo(string.Format("Cencel,{0},{1},", args[2],args[3]), (Socket)HT[args[2]]);
                    break;
                case "C":
                    sendTo(string.Format("C,{0},{1},", args[2],args[3]), (Socket)HT[args[2]]);
                    break;

            }
        }
        private string onlineList()
        {
            string list = "list,";
            list += onlineList_LB.Items.Count.ToString() + ",";
            for (int i = 0; i < onlineList_LB.Items.Count; i++)
            {
                list += onlineList_LB.Items[i] + ",";
            }

            return list;
        }

        private void sendAll(string str)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            foreach (Socket s in HT.Values)
            {
                s.Send(B, 0, B.Length, SocketFlags.None);
            }
        }

        private void sendTo(string str, Socket sck)
        {
            byte[] B = Encoding.Default.GetBytes(str);
            sck.Send(B, 0, B.Length, SocketFlags.None);
        }
    }
}
