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
using System.Windows.Shapes;
using Zeiterfassung1.Logic;
using Zeiterfassung1.Model;

namespace Zeiterfassung1
{
    /// <summary>
    /// Interaction logic for EditEmplActWin.xaml
    /// </summary>
    public partial class EditEmplActWin : Window
    {
        DataLogic dataLogic;
        EmployeeActivity employeeActivity;
        public EditEmplActWin()
        {
            InitializeComponent();

        }
        public EditEmplActWin(EmployeeActivity employeeActivity, DataLogic dataLogic)
        {
            InitializeComponent();

            this.employeeActivity = employeeActivity;
            this.dataLogic = dataLogic;
            cmbBoxProject.ItemsSource = dataLogic.GetProjects();
            cmbBoxActivity.ItemsSource = dataLogic.GetActivities();
            txtBoxHours.Text = Convert.ToString(employeeActivity.Hours);
            datePickerDate.SelectedDate = employeeActivity.ActivityDate;
        }

        private void btnUpdateCustomerActivity_Click(object sender, RoutedEventArgs e)
        {
            employeeActivity.Activity = (Activity)cmbBoxActivity.SelectedItem;
            employeeActivity.Activity.Project = (Project)cmbBoxProject.SelectedItem;
            employeeActivity.ActivityDate = (DateTime)datePickerDate.SelectedDate;
            employeeActivity.Hours = Convert.ToInt32(txtBoxHours.Text);
            dataLogic.UpdateEmployeeActivity(employeeActivity);

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbBoxActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbBoxProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbBoxActivity.ItemsSource = dataLogic.GetActivities((Project)cmbBoxProject.SelectedItem);
        }
    }
}
