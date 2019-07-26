using DoctorsView.Interfaces;
using DoctorsView.ViewModels;
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

namespace DoctorsView.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IView
    {
        public IViewModel VM
        {
            get
            {
                return DataContext as IViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        public LoginWindow(LoginVM vm)
        {
            VM = vm;
            InitializeComponent();
        }

        private void NoAccountButton_Click(object sender, RoutedEventArgs e)
        {
            loginStackPanel.Visibility = Visibility.Collapsed;
            registerStackPanel.Visibility = Visibility.Visible;
            Application.Current.MainWindow.Height = 440;
        }

        private void HaveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            registerStackPanel.Visibility = Visibility.Collapsed;
            loginStackPanel.Visibility = Visibility.Visible;
            Application.Current.MainWindow.Height = 240;
        }

        #region Compare and check passwords //  show adequate info
        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordsNotMatchTextBlock.Visibility = Converter(CheckPasswordsMatch());
            passwordToShortTextBlock.Visibility = Converter(CheckPasswordLenght());
        }

        private bool CheckPasswordsMatch()
        {
            var newPassword = newPasswordBox.Password;
            var confirmPassword = confirmPasswordBox.Password;
            if (confirmPassword.Length > 0)
            {
                if(newPassword != confirmPassword)
                    return true;
            }
            return false;
        }

        private bool CheckPasswordLenght()
        {
            var newPassword = newPasswordBox.Password;
            var confirmPassword = confirmPasswordBox.Password;
            if(confirmPassword.Length > 0)
            {
                if (newPassword.Length < 4)
                    return true;
            }
            return false;
        }

        private Visibility Converter(bool value)
        {
            if (value)
                return Visibility.Visible;

            return Visibility.Collapsed;
        }
        #endregion
    }
}
