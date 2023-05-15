using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Examen
{
    internal class Model
    {
        int index = 0;
        string text;
        Controller controller;
        public Model(Controller controller) 
        { 
            this.controller = controller; 
        }

        public string SetText()
        {
            Random random = new Random();
            string temp = File.ReadAllText("text.txt");
            string[] temp_text = temp.Split('\n');
            text = temp_text[random.Next(0,2)];
            return text;
        }
        public void TextCheck(char a)
        {
            if (a == text[index])
            {
                index++;
                controller.Correct();
                if (text.Length - 1 == index)
                {
                    controller.End();
                }
            }
            else
            {
                controller.Mistake();
            }
        }
    }
}
