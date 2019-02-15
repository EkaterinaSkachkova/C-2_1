using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Asteroid:BaseObject
    {
        public int Power { get; set; }

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {            
        }

        //public override void Reset()
        //{
        //    Random rnd = new Random();
        //    Pos.X = rnd.Next(0, Game.Width);
        //    Pos.Y = rnd.Next(0, 10);
        //}
    }
}
