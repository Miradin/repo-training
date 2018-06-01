using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    static class Game
    {
        private static BufferedGraphicsContext context;
        public static BufferedGraphics buffer;
        public static int Width { get; set; }
        public static int Heigth { get; set; }

        public static BaseObject[] objs;
        public static Background[] stars_back;
        public static ShinyStar[] stars_static;

        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;
            context = BufferedGraphicsManager.Current;
            Load();

            g = form.CreateGraphics();

            Width = form.Width;
            Heigth = form.Height;

            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Heigth));

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            //buffer.Graphics.Clear(Color.Black);
            //buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //buffer.Render();

            buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in objs)
            {
                obj.Draw();
            }
            foreach (Background obj in stars_back)
            {
                obj.Draw();
            }
            foreach (ShinyStar obj in stars_static)
            {
                obj.Draw();
            }
            buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in objs)
            {
                obj.Update();
            }
            foreach (Background obj in stars_back)
            {
                obj.Update();
            }
            foreach (ShinyStar obj in stars_static)
            {
                obj.Update();
            }
        }

        public static void Load()
        {
            Random r = new Random();
            objs = new BaseObject[30];
            for (var i = 0; i < objs.Length/3; i++)
            {
                objs[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(30, 30));
            }
            for (var i = objs.Length / 3; i < objs.Length; i++)
            {
                objs[i] = new Star(new Point(600, i * 20), new Point(- i, 0), new Size(5, 5));
            }

            stars_back = new Background[20];
            for (var i = 0; i < stars_back.Length; i++)
            {
                stars_back[i] = new Background(new Point(r.Next(800), r.Next(600)), new Point(r.Next(5, 15), 0), 16);
            }

            stars_static = new ShinyStar[5];
            for (var i = 0; i < stars_static.Length; i++)
            {
                stars_static[i] = new ShinyStar(new Point(r.Next(800), r.Next(600)), r.Next(5, 20));
            }

        }
    }
}
