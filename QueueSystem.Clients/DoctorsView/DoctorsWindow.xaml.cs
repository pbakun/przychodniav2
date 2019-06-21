using DoctorsView.Interfaces;
using DoctorsView.Models;
using DoctorsView.QueueSystemServiceReference;
using DoctorsView.Utility;
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

    public partial class DoctorsWindow : Window
    {
        private readonly User _user;


        public DoctorsWindow(int id)
        {
            InitializeComponent();

            using (SQLiteConnection connection = new SQLiteConnection(StaticDetails.userDatabasePath))
            {
                _user = connection.Table<User>().Where(u => u.Id == id).FirstOrDefault();
                userInfoLabel.Content = "Witaj " + _user.FirstName + " " + _user.LastName;
                //_queueData.UserInitials = _user.FirstName.FirstOrDefault().ToString() + _user.LastName.FirstOrDefault();
            }

            //Initialize WCF Communication
            //this.ContentRendered += DoctorsWindow_ContentRendered;
            this.Closing += DoctorsWindow_Closing;
            

        }

        private void DoctorsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IClosing context = DataContext as IClosing;
            if(context != null)
            {
                e.Cancel = !context.OnClosing();
            }
        }


        //PrevievInputText event handler - passes only numeric input
        private void NumberValidation_PreviewTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //Send additional message to the service
        //private void SendAddMessageSubmitBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    //string additionalMessage = new TextRange(additionalMessageTextBox.Document.ContentStart, additionalMessageTextBox.Document.ContentEnd).Text;

        //    //if (_queueData.ConnectionEstablished)
        //    //{
        //    //    _queueData.AdditionalMessage = additionalMessage;
        //    //    _QueueMessage.ReceiveAdditionalMessage(_user.Id, _queueData.AdditionalMessage);
        //    //}
        //}

        //Clears additional message text box and sends empty string to service additional message
        //private void ClearAddMessageBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    additionalMessageTextBox.Document.Blocks.Clear();
        //}

        ////If cursor focused on forceQueueNoTextBox and Enter pressed send new queueNo to service
        //private void ForceQueueNoTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.Key == Key.Enter)
        //    {
        //        ForceQueueSubmitBtn_Click(sender, new RoutedEventArgs());
        //    }
        //}

        //Creates list of elements for Options context menu;
        //Elements taken from UI ContextMenu
        private void Show_Options_ContextMenu(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = this.FindResource("OptionsContextMenu") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

    }
}