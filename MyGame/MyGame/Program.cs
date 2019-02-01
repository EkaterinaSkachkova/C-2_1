using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            {
                form.Width = Screen.PrimaryScreen.Bounds.Width;
                form.Height = Screen.PrimaryScreen.Bounds.Height;
            }
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}
