using DoctorsView.Models;
using SQLite;
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
using DoctorsView.Utility;

namespace DoctorsView
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;
            loginTextBox.Focus();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginSubmitButton_Click(sender, new RoutedEventArgs());
            }
        }

        private void CancelSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            
        }

        private void LoginSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                Login = loginTextBox.Text,
                Password = passwordTextBox.Text //do hash password
            };

            //authentication TBD
            using (SQLiteConnection connection = new SQLiteConnection(StaticDetails.userDatabasePath))
            {
                connection.CreateTable<User>();
                var loggingUser = connection.Table<User>().Where(u => u.Login == user.Login && u.Password == user.Password && u.isActive).FirstOrDefault();

                if (loggingUser != null)
                {
                    user = loggingUser;
                }
                else
                {
                    loginTextBox.Clear();
                    passwordTextBox.Clear();
                    MessageBox.Show("Podano nieprawidłowe dane do logowania!", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            //if (user.Id != 0)
            //{
            //DoctorsWindow doctorsWindow = new DoctorsWindow(user.Id);
            DoctorsWindow doctorsWindow = new DoctorsWindow(1);
            doctorsWindow.Show();
                this.Close();
            //}
        }

    }
}
