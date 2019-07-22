using DoctorsView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.API
{
    public interface IQueueService
    {
    
        void CloseConnection();

        void EstablishConnection();

        void Disconnect(bool connectionStatus = false);

        void NextPerson();

        void PreviousPerson();

        void ForceNewQueueNo(string number);

        void SendAdditionalMessage(string additionalMessage);
    }
}
