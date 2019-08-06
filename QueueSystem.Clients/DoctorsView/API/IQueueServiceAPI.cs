using System.ComponentModel;
using DoctorsView.Models;

namespace DoctorsView.API
{
    public interface IQueueServiceAPI
    {
        void CloseConnection();
        void Disconnect(bool connectionStatus = false);
        void EstablishConnection();
        void ForceNewQueueNo(string number);
        void NextPerson();
        void SetData(QueueData queueData, User user);
        void PreviousPerson();
        void SendAdditionalMessage(string additionalMessage);
    }
}