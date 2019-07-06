using QueueSystem.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.Contract
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single)]
    public class QueueMessageService : IQueueMessageInbound
    {
        
        private static List<ConnectedUser> _callbackList = new List<ConnectedUser>();

        int _registeredUsers;

        public static QueueData _queueData = new QueueDataBuilder().Build();

        //User is connecting to the service, add user to list of registered users
        public int Connect(int userId, string userName)
        {
            IQueueMessageCallback registeredUser = OperationContext.Current.GetCallbackChannel<IQueueMessageCallback>();
            Console.WriteLine("User {0} connected at {1}", userName, DateTime.Now.ToShortTimeString());

            //Add checking some credentails

            if (!_callbackList.Select(u => u.RegisteredUser).Contains(registeredUser))
            {
                _callbackList.Add(new ConnectedUser(userId, registeredUser));
                _queueData.Owner = userName;
            }

            try
            {
                _callbackList.Select(c => c.RegisteredUser).ToList().ForEach(
               delegate (IQueueMessageCallback callback) {
                   callback.NotifyOfEstablishedConnection(userName);
               });
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR in callback NotifyOfEstablishedConnection: ");
                Console.WriteLine(ex.Message);
            }

            return _registeredUsers++;
        }

        //User is disconnecting, remove user from list of registered users
        public int Disconnect(int userId, string userName)
        {
            IQueueMessageCallback registeredUser = OperationContext.Current.GetCallbackChannel<IQueueMessageCallback>();

            _queueData = new QueueDataBuilder().Build();

            if (_callbackList.Select(u => u.RegisteredUser).Contains(registeredUser))
            {
                _callbackList.Remove(_callbackList.Where(u => u.Id == userId).FirstOrDefault());
                Console.WriteLine("User {0} disconnected at {1}", userName, DateTime.Now.ToShortTimeString());
            }

            try
            {
                _callbackList.Select(c => c.RegisteredUser).ToList().ForEach(
                delegate (IQueueMessageCallback callback) {
                    callback.NotifyClientDisconnected(userName);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in callback NotifyClientDisconnected: ");
                Console.WriteLine(ex.Message);
            }

            return _registeredUsers--;
        }

        //Pass additional message and call it back to the user
        public void ReceiveAdditionalMessage(int userId, string additionalMessage)
        {
            IQueueMessageCallback registeredUser = OperationContext.Current.GetCallbackChannel<IQueueMessageCallback>();

            _queueData.AdditionalMessage = additionalMessage;

            Console.WriteLine("Additional message: {0}", additionalMessage);

            try
            {
                _callbackList.Select(c => c.RegisteredUser).ToList().ForEach(
                delegate (IQueueMessageCallback callback) {
                    callback.NotifyOfReceivedAdditionalMessage(additionalMessage);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in callback NotifyOfReceivedAdditionalMessage: ");
                Console.WriteLine(ex.Message);
            }
        }

        //Pass new queue number and call it back to the user
        public void ReceiveQueueNo(int userId, int queueNo, string userInitials)
        {
            IQueueMessageCallback registeredUser = OperationContext.Current.GetCallbackChannel<IQueueMessageCallback>();

            _queueData.QueueNo = queueNo;
            _queueData.UserInitials = userInitials;

            try
            {
                _callbackList.Select(c => c.RegisteredUser).ToList().ForEach(
                delegate (IQueueMessageCallback callback) {
                    callback.NotifyOfReceivedQueueNo(_queueData.QueueNoMessage);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in callback NotifyOfReceivedQueueNo: ");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
