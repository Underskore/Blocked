using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Blocked
{
    public partial class frm : Form
    {
        public frm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IO.get get = new IO.get();
            get.objects("test.txt");
            for (int i = 0; i < get.objs.Count; i++)
            {
                textBox1.Text += get.objs[i].oname + "\r\n";
                textBox1.Text += "    * class: " + get.objs[i].oclass + "\r\n";
                textBox1.Text += "    * text: " + get.objs[i].otext + "\r\n";
                textBox1.Text += "    * size: " + get.objs[i].osize + "\r\n";
                textBox1.Text += "    * position: " + get.objs[i].opoint + "\r\n";
            
            }
                
        }
    }
}