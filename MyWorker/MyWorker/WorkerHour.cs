using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorker
{
    class WorkerHour:BasicWorker, IComparable<WorkerHour>
    {
        public double Salary { get; set; }

        public WorkerHour(string Name, int Age, double Salary):base(Name, Age)
        {
            this.Salary = AverageSalary(Salary);
        }
        
        public override double AverageSalary(double a)
        {
            double Salary=20.8*8*a;
            return Salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Salary} ";
        }

        public int CompareTo(WorkerHour obj)
        {
            return obj.Salary > this.Salary ? -1 : 1;
        }
    }
}
