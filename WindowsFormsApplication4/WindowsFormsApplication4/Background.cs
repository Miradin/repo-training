using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class Background
    {
        protected Point Pos;
        protected Point Dir;
        protected float Size;
        

        public Background(Point pos, Point dir, float size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public void Draw()
        {
            Font drawFont = new Font("Arial", Size);
            SolidBrush drawBrush = new SolidBrush(Color.GreenYellow);
            Game.buffer.Graphics.DrawString("*", drawFont, drawBrush, Pos.X, Pos.Y);
        }

        public virtual void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0)
            {
                Random r = new Random();
                Pos.X = Game.Width;
                Pos.Y = r.Next(0,600); 
                //WHY IT DOES NOT WORK?
                //Expected behavior: Y changes randomly for each object as it reach border. 
                //Result: Y is the same for every objects, after the object reaches the border.
            }
            

        }
    }
}
