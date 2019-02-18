using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Bullet:BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X=Pos.X+7;
        }

        //public override void Reset()
        //{
        //    Random rnd = new Random();
        //    Pos.X = rnd.Next(0, 10);
        //    Pos.Y = rnd.Next(0, Game.Height);
        //}
    }
}
