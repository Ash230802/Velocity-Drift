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
    public partial class Form4 : Form
    {
        private int _score;
        private int _elapsedSeconds;

        public Form4(int score, int elapsedSeconds)
        {
            InitializeComponent();
            _score = score;
            Score.Text = string.Format("Score: {0}", _score);
            _elapsedSeconds = elapsedSeconds;
            Timer.Text = $"Time: {GetFormattedTime(_elapsedSeconds)}";
        }

        private void Form4_Load(object sender, EventArgs e)
        {       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }
        private string GetFormattedTime(int seconds)
        {
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;
            return $"{minutes:00}:{remainingSeconds:00}";
        }
    }
}
