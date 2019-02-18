using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    public class Depart:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _dep;

        public string Dep
        {
            get => _dep;
            set
            {
                _dep = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Dep)));
            }
        }



        public override string ToString()
        {
            return $"{Dep}";
        }
    }
}
