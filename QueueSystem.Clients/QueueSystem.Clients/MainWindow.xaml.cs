using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace QueueSystem.Clients
{
    [CallbackBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        UseSynchronizationContext = false)]
    public partial class MainWindow : Window, QueueSystemHostReference.ContractCallback
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        #region IQueueMessageCallback implementation

        public void NotifyClientDisconnected(string userName)
        {
            throw new NotImplementedException();
        }

        public void NotifyOfEstablishedConnection(string userName)
        {
            throw new NotImplementedException();
        }

        public void NotifyOfReceivedAdditionalMessage(string additionalMessage)
        {
            throw new NotImplementedException();
        }

        public void NotifyOfReceivedQueueNo(string queueNo)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
