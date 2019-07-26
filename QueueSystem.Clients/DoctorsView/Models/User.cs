using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Models
{
    public class User : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        private string login;
        [MaxLength(15)]
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChange(nameof(Login));
            }
        }


        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChange(nameof(FirstName));
            }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChange(nameof(LastName));
            }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChange(nameof(Password));
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChange(nameof(Email));
            }
        }


        public string[] Roles { get; set; }

        public bool isActive { get; set; }

        public bool isSendingData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
