using DoctorsView.Commands;
using DoctorsView.Interfaces;
using DoctorsView.Models;
using DoctorsView.Models.Authenticaton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoctorsView.ViewModels
{
    public class LoginVM : IViewModel, INotifyPropertyChanged
    {
        public User User4View { get; set; }
        private readonly IAuthenticationService _authenticationService;

        private readonly DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand { get { return _loginCommand; } }

        private readonly DelegateCommand _logoutCommand;
        public DelegateCommand LogoutCommand { get { return _logoutCommand; } }

        private readonly DelegateCommand _showViewCommand;
        public DelegateCommand ShowViewCommand { get { return _showViewCommand; } }

        private readonly DelegateCommand _registerCommand;
        public DelegateCommand RegisterCommand
        {
            get { return _registerCommand; }

        }


        public bool IsAuthenticated
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.IsAuthenticated;
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChange(nameof(Status));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginVM(IAuthenticationService authenticationService)
        {
            User4View = new User();

            _authenticationService = authenticationService;

            _loginCommand = new DelegateCommand(Login, CanLogin);
            _logoutCommand = new DelegateCommand(Logout, CanLogout);
            _showViewCommand = new DelegateCommand(ShowView, null);
            _registerCommand = new DelegateCommand(Register, CanRegister);
        }

        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                        Thread.CurrentPrincipal.Identity.Name,
                        Thread.CurrentPrincipal.IsInRole("Administrators") ? "You are an administrator!" : "You are NOT a member of administrators group");

                return "Not authenticated";
            }
        }

        private void Login(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;

            try
            {
                //Validate user with authentication service
                User user = _authenticationService.AuthenticateUser(User4View.Login, clearTextPassword);

                //Get the current principal object
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup");

                //Authenticate the user
                customPrincipal.Identity = new CustomIdentity(user.Login, user.Email, user.Roles);

                //Update the UI
                OnPropertyChange(nameof(AuthenticatedUser));
                OnPropertyChange(nameof(IsAuthenticated));
                _loginCommand.RaiseCanExecuteChanged();
                _logoutCommand.RaiseCanExecuteChanged();
                User4View.Login = string.Empty;
                passwordBox.Password = string.Empty;
                Status = string.Empty;

            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login faile! Please provide some valid credentials!";
            }
            catch (Exception ex)
            {
                Status = string.Format("Error: {0}", ex.Message);
            }
        }

        private bool CanLogin(object parameter)
        {
            return !IsAuthenticated;
        }

        private void Logout(object parameter)
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                customPrincipal.Identity = new AnonymousIdentity(string.Empty, string.Empty, new string[] { });

                //Update UI
                OnPropertyChange(nameof(AuthenticatedUser));
                OnPropertyChange(nameof(IsAuthenticated));
                _loginCommand.RaiseCanExecuteChanged();
                _logoutCommand.RaiseCanExecuteChanged();
                Status = string.Empty;
            }
        }

        private bool CanLogout(object parameter)
        {
            return IsAuthenticated;
        }



        private void ShowView(object parameter)
        {
            try
            {
                Status = string.Empty;
                IView view;
                if (parameter == null)
                {
                    //show window for regular user
                }
                else
                {
                    //show window for admin
                }
            }
            catch (SecurityException)
            {
                Status = "You are not authorized";
            }
        }

        private void Register(object parameter)
        {
            object[] array = parameter as object[];
            PasswordBox passwordBox = array[0] as PasswordBox;
            PasswordBox confirmPassowrdBox = array[1] as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            string clearTextConfirmPassword = confirmPassowrdBox.Password;

            if (clearTextConfirmPassword.Equals(clearTextPassword))
            {
                User newUser = User4View;
                newUser.Password = clearTextPassword;
                _authenticationService.RegisterUser(newUser);
                Login(passwordBox);
            }


        }

        private bool CanRegister(object parameter)
        {
            if (parameter != null)
            {
                var values = (object[])parameter;
                var passwordBox1 = values[0] as PasswordBox;
                var passwordBox2 = values[1] as PasswordBox;
                var password1 = passwordBox1.Password;
                var password2 = passwordBox2.Password;

                if (password1 == password2 && password1.Length >= 4 && !IsAuthenticated)
                    return true;
            }

            return false;
        }

        public void WindowClosing()
        {
            throw new NotImplementedException();
        }
    }
}
