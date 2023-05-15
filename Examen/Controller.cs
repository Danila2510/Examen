using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    internal class Controller
    {
        Model model;
        View view;
        public Controller(View view)
        {
            model = new Model(this);
            this.view = view;
        }
        public string SetText()
        {
            return model.SetText();
        }
        public void Mistake()
        {
            view.Mistake();
        }
        public void Correct()
        {
            view.Correct();
        }
        public void TapCheck(char a)
        {
            model.TextCheck(a);
        }
        public void End()
        {
            view.EndText();
        }
    }
}
