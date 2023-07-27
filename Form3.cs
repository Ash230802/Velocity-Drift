using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VelocityDrift
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void START_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void START_MouseLeave(object sender, EventArgs e)
        {
            START.BackColor = Color.Black; 
        }

        private void START_MouseEnter(object sender, EventArgs e)
        {
            START.BackColor = Color.Red;
        }

        private void QUIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QUIT_MouseEnter(object sender, EventArgs e)
        {
            QUIT.BackColor = Color.Red;
        }

        private void QUIT_MouseLeave(object sender, EventArgs e)
        {
            QUIT.BackColor = Color.Black; 
        }
    }
}
