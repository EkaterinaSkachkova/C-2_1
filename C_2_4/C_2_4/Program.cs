using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                {"one",1 },
                {"three",3 },
            };

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });

            //Свернуть с использованием лямбда выражения
            //var d = dict.OrderBy(pair=> pair.Value);

            //Развернуть с использованием делегата
            //Func<KeyValuePair<string, int>, int> MyDelegate = delegate (KeyValuePair<string, int> pair) { return pair.Value; };
            //var d = dict.OrderBy(MyDelegate);

            foreach (var pair in d)
            {
                Console.WriteLine("{0}-{1}", pair.Key, pair.Value);
            }
        }
    }
}
