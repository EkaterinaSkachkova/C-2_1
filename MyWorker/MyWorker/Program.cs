using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            #region IComparable

            Random r = new Random();

            List<BasicWorker> workers = new List<BasicWorker>();

            for (int i = 0; i < 5; i++)
            {
                workers.Add(new WorkerFix($"Имя_{i}", r.Next(20, 50), r.Next(60000, 150000)));
            }

            for (int i = 5; i < 10; i++)
            {
                workers.Add(new WorkerHour($"Имя_{i}", r.Next(20, 50), r.Next(300, 1000)));
            }

            foreach (var el in workers) Console.WriteLine(el);

            //предполагаю, что не работает, потому что коллекция типа BasicWorker. Как исправить код, не знаю.
            workers.Sort();

            Console.WriteLine();

            foreach (var el in workers) Console.WriteLine(el);

            #endregion

            Console.ReadKey();
        }
    }
}
