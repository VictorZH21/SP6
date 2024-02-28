using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace СП6
{
    public partial class Form1 : Form
    {
        private int keystrokesCounnt = 0;
        private string Path = @"C:\Users\CoFFey\source\repos\СП6\События.txt";

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox2.Clear();
            textBox2.AppendText($"Alt: {(e.Alt ? "Yes" : "No")}\n");
            textBox2.AppendText($"Shift: {(e.Shift ? "Yes" : "No")}\n");
            textBox2.AppendText($"Ctrl: {(e.Control ? "Yes" : "No")}\n");
            textBox2.AppendText($"Код клавиши: {e.KeyCode}\nKeyData: {e.KeyData}\nKeyValue: {e.KeyValue}");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.Text = e.KeyChar.ToString();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                using (StreamWriter sw = File.AppendText(Path))
                {
                    sw.WriteLineAsync(DateTime.Now.ToShortTimeString());
                    sw.WriteLineAsync(textBox1.Text);
                    sw.WriteLineAsync(textBox2.Text);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            keystrokesCounnt++;
            label3.Text = keystrokesCounnt.ToString();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            timer1.Stop();
        }
    }
}
