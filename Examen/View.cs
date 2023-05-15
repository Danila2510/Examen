using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Examen
{
    public partial class View : Form
    {
        Thread time;
        Button[] buttons;
        static Controller controller;
        string text;
        static int time_count = 0;
        int mistake = 0, correct = 0;
        static bool end = false;
        static Label label_time = null;
        public View()
        {
            InitializeComponent();
            buttons = new Button[] { button2, button3, button4, button5, button6, 
            button7, button8, button9, button10, button11, button12,
            button13, button14, button15, button16, button17, button18, 
            button19, button20, button21, button22, button23, button24, button25,
            button26, button27, button28};
            label_time = label4;
            controller = new Controller(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (button1.Enabled == false)
            {
                if (e.KeyData.ToString() == "Space")
                {
                    controller.TapCheck(' ');
                }
                else
                {
                    controller.TapCheck(Convert.ToChar(e.KeyValue + 32));
                }
            }
            foreach (Button x in buttons)
            {
                if (x.Text == e.KeyData.ToString())
                {
                    x.BackColor = Color.LightBlue;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Button x in buttons)
            {
                x.BackColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = controller.SetText() + "\n";
            text = label1.Text;
            button1.Enabled = false;
            time = new Thread(Timer);
            time.Start();
        }
        public void Correct()
        {
            correct++;
            label1.Text = text.Substring(correct);
        }
        public void Mistake()
        {
            mistake++;
            label6.Text = mistake.ToString();
        }
        private static void Timer()
        {
            while (!end)
            {
                Thread.Sleep(1000);
                time_count++;
                label_time.Text = time_count.ToString() + "c";
            }
        }
        public void EndText()
        {
            end = true;
            time.Abort();
            MessageBox.Show($"Ошибок: {mistake}\nВремя: {time_count}", "Результат");
            Close();
        }
    }
}
