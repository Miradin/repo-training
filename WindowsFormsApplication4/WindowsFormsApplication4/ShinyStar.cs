using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class ShinyStar
    {
        protected Point Pos;
        protected float Size;
        Random r = new Random();
        float growthDir=1;

        public ShinyStar(Point pos, float size)
        {
            Pos = pos;
            Size = size;
            
        }

        public void Draw()
        {
            Font drawFont = new Font("Arial", Size);
            SolidBrush drawBrush = new SolidBrush(Color.Blue);
            Game.buffer.Graphics.DrawString("*", drawFont, drawBrush, Pos.X, Pos.Y);
            
        }

        public virtual void Update()
        {
            Size = Size + growthDir;
            if (Size > 30)     
            {
                growthDir = -2;
            }
            if (Size < 2)
            {
                growthDir = 1;
            }
        }
    }
}
