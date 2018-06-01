using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        Image myImage = Image.FromFile("smile.jpg");

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            Game.buffer.Graphics.DrawImage(myImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            Dir.X = (Pos.X < 0 || Pos.X > Game.Width) ? -Dir.X : Dir.X;
            Dir.Y = (Pos.Y < 0 || Pos.Y > Game.Heigth) ? -Dir.Y : Dir.Y;
        }

    }
}
