using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Department
{
    /// <summary>
    /// Логика взаимодействия для NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : Window
    {
        public NewEmployee(string a)
        {
            InitializeComponent();
            Департамент.ItemsSource = a;
        }

        private void btnAddListItem_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

        }

        public Employee item = new Employee();

        public Employee ReturnData()
        {
            //Проверяем введен ли текст, который нужно добавить
            if ((FIO.Text.Length == 0) || (Age.Text.Length == 0) || (Salary.Text.Length == 0))
            {
                MessageBox.Show("Введите текст для добавления.", "Предупреждение");
                item = null;
            }
            else
            {
                // Добавляем текст
                item.Name = FIO.Text;
                item.Age = Convert.ToInt32(Age.Text);
                item.Salary = Convert.ToDouble(Salary.Text);
            }
            return item;
        }

        private void btnCancelListItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
