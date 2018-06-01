//Homework. Alexander Zhigunov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static Splash splashForm = null;

        [STAThread]
        static void Main()
        {
            var form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            Game.Draw();
            //Application.Run(new Splash());
            Thread splashThread = new Thread(new ThreadStart(
                delegate
                    {
                        splashForm = new Splash();
                        Application.Run(splashForm);
                    }
                    ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            Application.Run(form);
        }

    }
}
