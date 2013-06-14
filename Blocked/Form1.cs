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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IO.get get = new IO.get();
            string[] objects = get.objects("test.txt");
            foreach (string sr in objects)
                textBox1.Text += sr + "\r\n";
        }
    }
}


/*








[objects]
  
 


[/objects]



*/