using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Diamond:BaseObject
    {
        public Diamond(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X+Size.Width, Pos.Y+Size.Height, Pos.X + Size.Width*2, Pos.Y);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width * 2, Pos.Y, Pos.X + Size.Width, Pos.Y - Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y - Size.Height, Pos.X, Pos.Y);

        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y - Dir.Y;

            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            if (Pos.Y < 0) Pos.Y = Game.Height + Size.Height;
        }
    }
}
