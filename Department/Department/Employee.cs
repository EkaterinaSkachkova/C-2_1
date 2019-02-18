using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    public class Employee:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        private int _age;
        public int Age
        {
            get =>_age;
            set
            {
                _age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Age)));
            }
        }

        private double _salary;
        public double Salary
        {
            get =>_salary;
            set
            {
                _salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Salary)));
            }
        }

        private string _department;
        public string Department
        {
            get=>_department;
            set
            {
                _department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Department)));
            }
        }

        public override string ToString()
        {
            return $"{Name}, Возраст: {Age}, Зарплата: {Salary} руб.";
        }
    }
}

