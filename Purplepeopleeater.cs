using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mousemove
{
    public partial class Purplepeopleeater : Form
    {
        //I found most of this code on a youtube video and changed a few things to suit my needs.
        ListViewItem lv;
        int a;
        int b;

        public Purplepeopleeater()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //stop record timer/stop play timer
            timer1.Stop();
            timer2.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //start recording
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //start play
            timer2.Start();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //record mouse movement
            lv = new ListViewItem(Cursor.Position.X.ToString());
            lv.SubItems.Add(Cursor.Position.Y.ToString());
            listView1.Items.Add(lv);
            b++;
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
             //both timer interval set to 10
            //play recorded mouse movement
            
            if (a != b )
            {
                Cursor.Position = new Point(int.Parse(listView1.Items[a].SubItems[0].Text), int.Parse(listView1.Items[a].SubItems[1].Text));
                a++; //at first I was trying to wrap this code in a loop.
            }
            else //found I needed to add this else statement to keep looping what was recorded
            {
                a = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //added this button to 
            //clear what was recorded to start a new one
            listView1.Clear();
            b = 0;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //couldnt stop mouse playback with the mouse so I needed a keypress to stop
            if (e.KeyCode == Keys.S) //not sure why, but wont let me use keys like enter or space.
            {
                timer2.Stop();
                timer1.Stop();
            }
        }
    }
}
