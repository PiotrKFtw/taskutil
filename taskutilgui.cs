using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskutil
{
    public partial class taskutilgui : Form
    {
        
        public taskutilgui(bool gui)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gfn gfn = new gfn();
            if (comboBox1.Text == "kill")
            {
                if (comboBox2.Text == "processname")
                {
                    gfn.ProcessKill(textBox1.Text);
                    MessageBox.Show("The Process was killed.");
                }
                if (comboBox2.Text == "pid")
                {
                    gfn.ProcessKillPID(textBox1.Text);
                    MessageBox.Show("The Process was killed.");
                }
            }
            if (comboBox1.Text == "suspend")
            {
                if (comboBox2.Text == "processname")
                {
                    gfn.ProcessSuspend(textBox1.Text);
                    MessageBox.Show("The Process was suspended.");
                }
                if (comboBox2.Text == "pid")
                {
                    gfn.ProcessSuspendPID(textBox1.Text);
                    MessageBox.Show("The Process was suspended.");
                }
            }
            if (comboBox1.Text == "resume")
            {
                if (comboBox2.Text == "processname")
                {
                    gfn.ProcessResume(textBox1.Text);
                    MessageBox.Show("The Process was resumed.");
                }
                if (comboBox2.Text == "pid")
                {
                    gfn.ProcessResumePID(textBox1.Text);
                    MessageBox.Show("The Process was resumed.");
                }
            }
        }
    }
}
