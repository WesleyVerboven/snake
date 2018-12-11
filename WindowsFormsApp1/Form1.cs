using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Canvas : Form
    {
        Snake head;
        List<Snake> Body = new List<Snake>();
        int Bodysize = 0;
        Timer update = new Timer();
        public Canvas()
        {
            InitializeComponent();
            head = new Snake(Bodysize);
            head.Paint(this);
           
            
        }



        private void Update1_Tick(object sender, EventArgs e)
        {
            head.update();
            for (int i = 0; i < Body.Count; i++)
            {
                Body[i].update();
                if (Body[i].CheckPosition() && head.turn != Body[i].turn )
                {
                    if (i == 0)
                    {
                        if (Body[i].turn != head.turn)
                        {
                            Body[i].turn = head.turn;
                            Body[i].VChangespeed = head.VChangespeed;
                            Body[i].HChangespeed = head.HChangespeed;
                        }
                    }
                    else if (Body[i].turn != Body[i - 1].turn)
                    {
                        Body[i].turn = Body[i - 1].turn;
                        Body[i].VChangespeed = Body[i - 1].VChangespeed;
                        Body[i].HChangespeed = Body[i - 1].HChangespeed;
                    }
                }
             
            }

             
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            head.changeSpeed(e);
        }

       
        public void Form1_Click(object sender, EventArgs e)
        {
            Bodysize++;
            Body.Add(new Snake(Bodysize,head));
            Body[Bodysize-1].Paint(this);
            
        }
    }
}
