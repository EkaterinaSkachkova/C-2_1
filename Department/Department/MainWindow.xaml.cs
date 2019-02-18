using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Department
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Fillist();

            var connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter adapter1 = new SqlDataAdapter();


            SqlCommand command = new SqlCommand(
                       "SELECT FIO, Age, Salary, Department FROM Employee", connection);
            adapter.SelectCommand = command;
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            Workers.ItemsSource = datatable.DefaultView;

            SqlCommand command1 = new SqlCommand(
           "SELECT Id, Department_name FROM Department", connection);
            adapter1.SelectCommand = command1;
            DataTable datatable1 = new DataTable();
            adapter1.Fill(datatable1);

            Департамент.ItemsSource = datatable1.DefaultView;


            btnSelectListItem.Click += (sender, args) =>
              {
              };


            //btnDeleteListItem1.Click += (sender, args) =>
            //  {
            //  };
        }

        //public ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        //public ObservableCollection<Depart> departments = new ObservableCollection<Depart>();

        //public void Fillist()
        //{
        //    employees.Add(new Employee() { Name = "Безобразов Алексей Борисович", Age = 63, Salary = 400000.00, Department = "Администрация" });
        //    employees.Add(new Employee() { Name = "Панайотова Ирина Алексеевна", Age = 36, Salary = 220000.00, Department = "Администрация" });
        //    employees.Add(new Employee() { Name = "Поспелов Андрей Александрович", Age = 51, Salary = 315000.00, Department = "Администрация" });
        //    employees.Add(new Employee() { Name = "Скачков Александр Викторович", Age = 49, Salary = 180000.00, Department = "Администрация" });
        //    employees.Add(new Employee() { Name = "Грюнталь Наталья Викторовна", Age = 48, Salary = 220000.00, Department = "Бухгалтерия" });
        //    employees.Add(new Employee() { Name = "Скачкова Елена Борисовна", Age = 48, Salary = 87000.00, Department = "Бухгалтерия" });
        //    employees.Add(new Employee() { Name = "Шаулова Наталья Сергеевна", Age = 41, Salary = 87000.00, Department = "Бухгалтерия" });
        //    employees.Add(new Employee() { Name = "Голубев Александр Анатольевич", Age = 25, Salary = 65000.00, Department = "СТО" });
        //    employees.Add(new Employee() { Name = "Сахаров Петр Борисович", Age = 35, Salary = 45000.00, Department = "СТО" });
        //    employees.Add(new Employee() { Name = "Артамонов Сергей Сергеевич", Age = 33, Salary = 95000.00, Department = "Отдел продаж" });
        //    employees.Add(new Employee() { Name = "Безобразов Алексей Алексеевич", Age = 31, Salary = 150000.00, Department = "Отдел продаж" });
        //    employees.Add(new Employee() { Name = "Борисов Алексей Геннадьевич", Age = 28, Salary = 110000.00, Department = "Отдел продаж" });
        //    employees.Add(new Employee() { Name = "Панайотов Сергей Алексеевич", Age = 42, Salary = 150000.00, Department = "Отдел продаж" });
        //    Workers.ItemsSource = employees.OrderBy(employee => employee.Name);

        //    departments.Add(new Depart() { Dep = "Администрация" });
        //    departments.Add(new Depart() { Dep = "Бухгалтерия" });
        //    departments.Add(new Depart() { Dep = "СТО" });
        //    departments.Add(new Depart() { Dep = "Отдел продаж" });
        //    Департамент.ItemsSource = departments.OrderBy(dep => dep.Dep);
        //}


        //private void btnAddListItem_Click(object sender, RoutedEventArgs e)
        //{
        //    //Проверяем введен ли текст, который нужно добавить
        //    if (textBox.Text.Length == 0) { MessageBox.Show("Введите текст для добавления.", "Предупреждение"); }
        //    else
        //    {
        //        // Добавляем текст
        //        Depart item = new Depart();
        //        item.Dep = textBox.Text;
        //        departments.Add(item);
        //        textBox.Clear();
        //        textBox.Focus();
        //        Департамент.ItemsSource = departments.OrderBy(dep => dep.Dep);
        //    }
        //}

        //private void btnDeleteListItem_Click(object sender, RoutedEventArgs e)
        //{
        //    // Проверяем выделен ли хотя бы один элемент списка
        //    if (Департамент.SelectedItems.Count == 0) { MessageBox.Show("Выделите текст для удаления из списка.", "Предупреждение"); }
        //    else
        //    {
        //        if ((Департамент.SelectedItems.Count > 0)&&(MessageBox.Show("При удалении Департамента будут удалены все сотрудники этого Департамента. Хотите удалить Департамент?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
        //        {
        //            //for (int k = employees.Count - 1; k == 0; k--)
        //            //{
        //            //    if (employees[k].Department == Департамент.SelectedItem.ToString())
        //            //        employees.RemoveAt(k);
        //            //}
        //            Workers.ItemsSource=null;
        //            departments.RemoveAt(Департамент.SelectedIndex);
        //            Департамент.ItemsSource = departments.OrderBy(dep => dep.Dep);
        //        }
        //    }
        //}

        //private void btnSelect_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Департамент.SelectedItems.Count == 0) { MessageBox.Show("Выделите Департемент из списка.", "Предупреждение"); }
        //    else
        //    {
        //        if (Департамент.SelectedItems.Count > 0)
        //        {
        //            var connectionString =
        //                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //            SqlConnection connection = new SqlConnection(connectionString);

        //            SqlCommand command =
        //                new SqlCommand("DELETE FROM Employee WHERE Department=d", connection);

        //            SqlParameter parameter =
        //                command.Parameters.Add("d", SqlDbType.NChar, 128, Департамент.SelectedItem.ToString());
                    
                    
                    //var spisok = from d in employees
                    //             where d.Department == Департамент.SelectedItem.ToString()
                    //             select d;
                    //var sp = new ObservableCollection<Employee>(spisok);
                    //Workers.ItemsSource = sp.OrderBy(name => name.Name);
        //        }
        //    }
        //}

        //private void btnAddListItem1_Click(object sender, RoutedEventArgs e)
        //{
        //    NewEmployee newEmployee = new NewEmployee(Департамент.SelectedItem.ToString());
        //    newEmployee.Owner = this;
        //    newEmployee.ShowDialog();
            //if ((newEmployee.DialogResult == true)&&(newEmployee.ReturnData()!=null))
            //{
            //    newEmployee.ReturnData().Department = Департамент.SelectedItem.ToString();
            //    employees.Add(newEmployee.ReturnData());
            //    var spisok = from d in employees
            //                 where d.Department == Департамент.SelectedItem.ToString()
            //                 select d;
            //    var sp = new ObservableCollection<Employee>(spisok);
            //    Workers.ItemsSource = sp.OrderBy(name => name.Name);
            //}
        }

        //private void btnDeleteListItem1_Click(object sender, RoutedEventArgs e)
        //{
        //    // Проверяем выделен ли хотя бы один элемент списка
        //    if (Workers.SelectedItems.Count == 0) { MessageBox.Show("Выделите текст для удаления из списка.", "Предупреждение"); }
        //    else
        //    {
        //        if (Workers.SelectedItems.Count > 0)
        //        {
        //            //for (int k = employees.Count - 1; k == 0; k--)
        //            //{
        //            //    if (employees[k].Name == FIO.Text.ToString())
        //            //        employees.RemoveAt(k);
        //            //}

        //            var connectionString =
        //                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //            SqlConnection connection = new SqlConnection(connectionString);

        //            SqlCommand command =
        //                new SqlCommand("DELETE FROM Employee WHERE Department=d", connection);

        //            SqlParameter parameter =
        //                command.Parameters.Add("d", SqlDbType.NChar, 128, Департамент.SelectedItem.ToString());

        //        }
        //    }
        //}

    }


