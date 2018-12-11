using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A105221035tcpApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int clientAmount = 3;

            //Chat_C[] C = new Chat_C[3];
            //for (int i = 0; i < C.Length; i++)
            //{
            //    C[i] = new Chat_C();
            //    C[i].Show();
            //}

            //Bingo_C[] B = new Bingo_C[clientAmount];
            //for(int i = 0; i < clientAmount; i++)
            //{
            //    B[i] = new Bingo_C(string.Format("Player{0:0000}", Math.Abs(i*(int)DateTime.Now.Ticks%10000)));
            //    B[i].Show();
            //}

            //Chat_S Cs = new Chat_S();
            //Cs.Show();


            Pp_C P = new Pp_C();
            P.Show();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
