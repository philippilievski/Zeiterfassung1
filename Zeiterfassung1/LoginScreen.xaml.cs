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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public string username;
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            username = txtBoxUsername.Text;
            string hash = HashPw.Compute256Hash(pwdBoxPassword.Password);

            if(HashPw.Validation(username, hash))
            {
                MainWindow mainWindow = new MainWindow(username);
                this.Hide();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}
