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

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right();
        }

        private static Timer _timer = new Timer();

        public static Random rnd = new Random();

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
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

            form.KeyDown += Form_KeyDown;
            Load();

            //Timer timer = new Timer { Interval = 100 };
            _timer.Start();
            _timer.Tick += Timer_Tick;

            void Timer_Tick(object sender, EventArgs e)
            {
                Draw();
                Update();
            }

            Ship.MessageDie += Finish;

            Ship.Damage += p => { var s = new System.IO.StreamWriter("log.txt", true); s.WriteLine(p); s.Close(); };
            Ship.Damage += p=>Console.WriteLine(p);
            Ship.Healing += p => { var s = new System.IO.StreamWriter("log.txt", true); s.WriteLine(p); s.Close(); };
            Ship.Healing += p => Console.WriteLine(p);
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
                obj?.Draw();
            }

            foreach (FirstAidKit obj in _firstaidkits)
            {
                obj?.Draw();
            }

            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Score:" + _ship.Score, SystemFonts.DefaultFont, Brushes.White, 0, 30);
            }
            Buffer.Render();
        }


        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static FirstAidKit[] _firstaidkits;
        private static Ship _ship = new Ship(new Point(600, 400), new Point(5, 5), new Size(10, 10));

        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[3];
            _firstaidkits = new FirstAidKit[5];
            var rnd = new Random();

            for (int i=0; i<_objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(-3, 3));
            }

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(-r/5, r), new Size(r, r));
            }

            for (int i = 0; i < _firstaidkits.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _firstaidkits[i] = new FirstAidKit(new Point(rnd.Next(0,Game.Width), rnd.Next(0,Game.Height)), new Point(-r / 5, r), new Size(r, r));
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

            for (int i=0; i<_asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    _ship?.CountScore();
                    continue;
                }

                if (!_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                _ship?.Harm();
                if (_ship.Energy <= 0) _ship?.Die();
            }


            for (int i = 0; i < _firstaidkits.Length; i++)
            {
                if (_firstaidkits[i] == null) continue;
                _firstaidkits[i].Update();
                if (_ship != null && _ship.Collision(_firstaidkits[i]))
                {
                    var rnd = new Random();
                    _ship?.EnergyHigh(rnd.Next(1, 10));
                    System.Media.SystemSounds.Hand.Play();
                    _firstaidkits[i] = null;
                    _ship.Curing();
                    if (_ship.Energy > 100) _ship.Energy = 100;
                    continue;
                }
            }

                //foreach (Asteroid obj in _asteroids)
                //{
                //    obj.Update();
                //    if (obj.Collision(_bullet))
                //    {
                //        //регенерация астероида и пули в других частях экрана
                //        obj.Reset();
                //        _bullet.Reset();
                //    }
                //}

                _bullet?.Update();
        }
    }
}
