using QueueSystem.Contract.DataHandling;
using QueueSystem.Contract.Models;
using SQLite;
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
        public int Connect(int userId, int roomNo, string userName, bool isSender = false)
        {
            IQueueMessageCallback registeredUser = OperationContext.Current.GetCallbackChannel<IQueueMessageCallback>();
            Console.WriteLine("User {0} connected at {1}", userName, DateTime.Now.ToShortTimeString());

            //Add checking some credentails

            if (!_callbackList.Select(u => u.Id).Contains(userId))
            {
                var connectingUser = new ConnectedUser(userId, registeredUser);

                if (isSender)
                {
                    var queue = QueueDatabase.FindQueue(userId);
                    if(queue != null)
                    {
                        connectingUser.QueueData = queue;
                        connectingUser.QueueData.Timestamp = DateTime.Now;
                    }
                    connectingUser.QueueData.UserId = userId;
                    connectingUser.QueueData.RoomNo = roomNo;
                    connectingUser.QueueData.Owner = userName;

                    QueueDatabase.AddQueue(connectingUser.QueueData);
                }
                else
                {
                    //NOT TESTED
                    var queue = QueueDatabase.FindQueueByRoomNo(roomNo);
                    connectingUser.QueueData = queue;
                    connectingUser.RegisteredUser = registeredUser;
                }
                _callbackList.Add(connectingUser);
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
            
            if (_callbackList.Select(u => u.Id).Contains(userId))
            {
                var leavingUser = _callbackList.Where(u => u.Id == userId).FirstOrDefault();
                _callbackList.Remove(leavingUser);
                leavingUser.QueueData.Owner = string.Empty;
                QueueDatabase.UpdateUsersQueue(leavingUser.QueueData);
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

            var queueData = QueueDatabase.FindQueue(userId);

            queueData.AdditionalMessage = additionalMessage;
            QueueDatabase.UpdateUsersQueue(queueData);

            var connectedUsers = _callbackList.Where(u => u.QueueData.UserId == userId).ToList();
            foreach (var c in connectedUsers)
            {
                c.QueueData.AdditionalMessage = additionalMessage;
            }

            Console.WriteLine("Additional message: {0}", additionalMessage);

            try
            {
                _callbackList.Where(q => q.QueueData.RoomNo == queueData.RoomNo).Select(c => c.RegisteredUser).ToList().ForEach(
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

            var queueData = QueueDatabase.FindQueue(userId);

            //if queueNo > 0 update queueNo and turn off break, then update database
            if(queueNo > 0)
            {
                queueData.QueueNo = queueNo;
                queueData.isBreak = false;
            }
            //else if queueNo = -1 set break to true and keep do nothing with queueNo, then update database
            else if(queueNo == -1)
            {
                queueData.isBreak = true;
            }
            queueData.UserInitials = userInitials;

            QueueDatabase.UpdateUsersQueue(queueData);

            //update queue of each connected user containing same queue userid
            var connectedUsers = _callbackList.Where(u => u.QueueData.UserId == userId).ToList();
            foreach(var c in connectedUsers)
            {
                c.QueueData = queueData;
            }

            try
            {
                _callbackList.Where(q => q.QueueData.RoomNo == queueData.RoomNo).Select(c => c.RegisteredUser).ToList().ForEach(
                delegate (IQueueMessageCallback callback) {
                    callback.NotifyOfReceivedQueueNo(queueData.QueueNoMessage);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in callback NotifyOfReceivedQueueNo: ");
                Console.WriteLine(ex.Message);
            }
        }

        public void GetQueueData(int? userId = null, int? roomNo = null)
        {
            IQueueMessageCallback registeredUser = OperationContext.Current.GetCallbackChannel<IQueueMessageCallback>();
            var queueData = new QueueData();
            if (userId != null)
            {
                queueData = QueueDatabase.FindQueue(userId);
            }
            if(roomNo != null)
            {
                queueData = QueueDatabase.FindQueueByRoomNo(roomNo);
            }

            try
            {
                _callbackList.Where(q => q.QueueData.RoomNo == queueData.RoomNo).Select(c => c.RegisteredUser).ToList().ForEach(
                delegate (IQueueMessageCallback callback) {
                    callback.NotifyClientWithQueueData(queueData);
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
