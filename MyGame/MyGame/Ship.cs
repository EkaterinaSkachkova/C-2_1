using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Ship: BaseObject
    {
        //private int _energy = 100;
        public int Energy { get; set; } =100;

        public void EnergyLow(int n)
        {
            Energy -= n;
        }

        public void EnergyHigh(int n)
        {
            Energy += n;
        }

        public int Score { get; set; } = 0;

        public void CountScore()
        {
            Score++;
        }
        
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.GreenYellow, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y <Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }

        public void Right()
        {
            if (Pos.X < Game.Width) Pos.X = Pos.X + Dir.X;
        }


        public void Die()
        {
            MessageDie?.Invoke();
        }

        public static event Message MessageDie;

        public static event Action<string> Healing;

        public void Curing()
        {
            Healing?.Invoke($"{DateTime.Now}: Energy is recovered");
        }

        public static event Action<string> Damage;

        public void Harm()
        {
            Damage?.Invoke($"{DateTime.Now}: Energy is dropped");
        }

    }
}
