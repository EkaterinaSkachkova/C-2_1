using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {
        }

        public static void Init(Form form)
        {
            try
            {
                Graphics g;
                _context = BufferedGraphicsManager.Current;
                g = form.CreateGraphics();
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
                Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            }

            catch (ArgumentOutOfRangeException) when ((Width<0)||(Width>1000)||(Height<0)||(Height>1000))
            {
                Console.WriteLine("Размер экрана задан неверно");
            }

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            void Timer_Tick(object sender, EventArgs e)
            {
                Draw();
                Update();
            }
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }

            foreach (Asteroid obj in _asteroids)
            {
                obj.Draw();
            }

            _bullet.Draw();
            Buffer.Render();
        }


        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;

        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[3];
            var rnd = new Random();

            for (int i=0; i<_objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(-3, 3));
            }

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(500, rnd.Next(0, Game.Height)), new Point(-r/5, r), new Size(r, r));
            }

            for (int i = _objs.Length / 3; i < _objs.Length; i++)
            {
                _objs[i] = new Diamond(new Point(i, i ), new Point(i, i), new Size(i/5, i/5));
            }

            for (int i = 27; i < 29; i++)
            {
                _objs[i] = new Rocket(new Point(i, i), new Point(i, i), new Size(i / 2, i / 2));
            }

        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }

            foreach (Asteroid obj in _asteroids)
            {
                obj.Update();
                if (obj.Collision(_bullet))
                {
                    //регенерация астероида и пули в других частях экрана
                    obj.Reset();
                    _bullet.Reset();
                }
            }

            _bullet.Update();
        }
    }
}
