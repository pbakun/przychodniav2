using DoctorsView.API;
using DoctorsView.Interfaces;
using DoctorsView.Models;
using DoctorsView.QueueSystemServiceReference;
using DoctorsView.Utility;
using DoctorsView.View;
using DoctorsView.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace DoctorsView
{

    public partial class DoctorsWindow : Window, IView
    {
        private readonly User _user;



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

        public DoctorsWindow(DoctorsWindowVM vm)
        {
            InitializeComponent();
            VM = vm;
            using (SQLiteConnection connection = new SQLiteConnection(StaticDetails.userDatabasePath))
            {
                // _user = connection.Table<User>().Where(u => u.Id == id).FirstOrDefault();
                // userInfoLabel.Content = "Witaj " + _user.FirstName + " " + _user.LastName;
                //_queueData.UserInitials = _user.FirstName.FirstOrDefault().ToString() + _user.LastName.FirstOrDefault();
            }
            //VM = this.Resources["vm"] as DoctorsWindowVM;
            //container.DataContext = VM;

            this.Closing += DoctorsWindow_Closing;
        }

        private void DoctorsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // VM.WindowClosing();
        }

        //PrevievInputText event handler - passes only numeric input
        private void NumberValidation_PreviewTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //Creates list of elements for Options context menu;
        //Elements taken from UI ContextMenu
        private void Show_Options_ContextMenu(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = this.FindResource("OptionsContextMenu") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

        private void OptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
        }
    }
}