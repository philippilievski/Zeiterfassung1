using System;
using System.Collections.Generic;
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
using Zeiterfassung1.Logic;
using Zeiterfassung1.Model;

namespace Zeiterfassung1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataLogic dataLogic = new DataLogic();
        Employee employee = new Employee();
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string username)
        {
            InitializeComponent();
            lblEmployee.Content = username;
            cmbBoxActivity.ItemsSource = dataLogic.GetActivities();
            cmbBoxProject.ItemsSource = dataLogic.GetProjects();
            dgZeiterfassung.ItemsSource = dataLogic.GetEmployeeActivities();
            employee = dataLogic.GetEmployeeFromUsername(username);
            lblHoursSum.Content = "Total hours: " + dataLogic.SumOfHours();
        }
        private void cmbBoxProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbBoxActivity.ItemsSource = dataLogic.GetActivities((Project)cmbBoxProject.SelectedItem);
        }

        private void cmbBoxActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddCustomerActivity_Click(object sender, RoutedEventArgs e)
        {
            EmployeeActivity employeeActivity = new EmployeeActivity();
            employeeActivity.Employee = employee;
            employeeActivity.ActivityDate = (DateTime)datePickerDate.SelectedDate;
            employeeActivity.Activity = (Activity)cmbBoxActivity.SelectedItem;
            employeeActivity.Activity.Project = (Project)cmbBoxProject.SelectedItem;
            employeeActivity.Hours = Convert.ToInt32(txtBoxHours.Text);
            dataLogic.AddEmployeeActivity(employeeActivity);

            dgZeiterfassung.ItemsSource = dataLogic.GetEmployeeActivities();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditEmplActWin editEmplActWin = new EditEmplActWin((EmployeeActivity)dgZeiterfassung.SelectedItem, dataLogic);
            editEmplActWin.ShowDialog();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            dgZeiterfassung.ItemsSource = dataLogic.GetEmployeeActivitiesBetweenDates(datePickerFilterStartDate.SelectedDate ?? DateTime.Now, datePickerFilterEndDate.SelectedDate ?? DateTime.Now);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            dataLogic.DeleteEmployeeActivity((EmployeeActivity)dgZeiterfassung.SelectedItem);
            dgZeiterfassung.ItemsSource = dataLogic.GetEmployeeActivities();
        }
    }
}
