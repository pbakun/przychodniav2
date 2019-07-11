using QueueSystem.QueueClient.Model;
using QueueSystem.QueueClient.View.ViewData;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QueueSystem.QueueClient.View.UserControls
{
    /// <summary>
    /// Interaction logic for MessageBar.xaml
    /// </summary>
    public partial class MessageBar : UserControl
    {



        public QueueViewData DisplayQueueInfo
        {
            get { return (QueueViewData)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register("DisplayQueueInfo", typeof(QueueViewData), typeof(MessageBar), new PropertyMetadata(null, SetVaules));

        private static void SetVaules(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBar queueInfo = d as MessageBar;

            if(queueInfo != null)
            {
                queueInfo.messageTextBlock.Text = (e.NewValue as QueueViewData).AdditionalMessage;
            }
        }

        public MessageBar()
        {
            InitializeComponent();
            
                 
        }
    }
}
