using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorker
{
    public abstract class BasicWorker
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public BasicWorker(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public abstract double AverageSalary(double a);

        public override string ToString()
        {
            return $"{this.Name} {this.Age} ";
        }

    }
}
