using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    abstract class BaseObject:ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();

        //базовый метод регенарации
        public virtual void Reset()
        {
            Random rnd = new Random();
            Pos.X = rnd.Next(0, Game.Width);
            Pos.Y = rnd.Next(0, Game.Height);
        }
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
