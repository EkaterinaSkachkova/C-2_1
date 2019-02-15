using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorker
{
    class WorkerFix:BasicWorker, IComparable<WorkerFix>
    {
        public double Salary { get; set; }

        public WorkerFix(string Name, int Age, double Salary) : base(Name, Age)
        {
            this.Salary = AverageSalary(Salary);
        }

        public override double AverageSalary(double a)
        {
            double Salary = a;
            return Salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Salary} ";
        }

        public int CompareTo(WorkerFix obj)
        {
            return obj.Salary > this.Salary ? -1 : 1;
        }
    }
}
