using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_4_2
{
    class MyCollection
    {

        public static void A()
        {
            List<object> col = new List<object>() { 1, "1", 1.15, 3, "3", 3.15, "2", 2, 2.15, "0" };

            foreach (var e in col) Console.WriteLine(e.GetType());

            #region Linq
            var report = col.Where(v => v.GetType() ==typeof(Int32));
            foreach (var e in report.ToList()) Console.WriteLine(e);
            Console.WriteLine("Number of integer is: {0}", report.Count());
            #endregion
        }
    }
}
