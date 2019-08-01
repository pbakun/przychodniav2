using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.Contract
{
    [ServiceContract(
        Name = "Contract",
        Namespace = "QueueSystem.Contract",
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IQueueMessageCallback))]
    public interface IQueueMessageInbound
    {

        [OperationContract]
        int Connect(int userId, int roomNo, string userName, bool isSender = false);

        [OperationContract(IsOneWay = true)]
        void ReceiveQueueNo(int userId, int queueNo, string userInitials);

        [OperationContract(IsOneWay = true)]
        void ReceiveAdditionalMessage(int userId, string additionalMessage);

        [OperationContract]
        int Disconnect(int userId, string userName);

        [OperationContract]
        void GetQueueData(int? userId = null, int? roomNo = null);

        [OperationContract]
        void Livebit(bool bit);
    }
}
