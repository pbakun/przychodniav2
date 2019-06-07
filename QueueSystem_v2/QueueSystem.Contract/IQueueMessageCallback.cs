using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.Contract
{
    public interface IQueueMessageCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyOfEstablishedConnection(string userName);

        [OperationContract(IsOneWay = true)]
        void NotifyOfReceivedQueueNo(string queueNo);

        [OperationContract(IsOneWay = true)]
        void NotifyOfReceivedAdditionalMessage(string additionalMessage);

        [OperationContract(IsOneWay = true)]
        void NotifyClientDisconnected(string userName);
    }
}
