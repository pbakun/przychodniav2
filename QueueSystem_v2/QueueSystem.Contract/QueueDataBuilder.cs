using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.Contract
{

    public class QueueDataBuilder
    {
        private int _queueNo;
        private string _userInitials;
        private int _roomNo;
        private DateTime _timestamp;
        private string _additionalMessage;
        private string _owner;

        public QueueDataBuilder()
        {
            setDefaults();
        }

        private void setDefaults()
        {
            _queueNo = 0;
            _userInitials = string.Empty;
            _roomNo = 0;
            _timestamp = DateTime.Now;
            _additionalMessage = string.Empty;
        }

        public QueueDataBuilder WithQueueNo(int queueNo)
        {
            _queueNo = queueNo;
            return this;
        }

        public QueueDataBuilder WithRoomNo(int roomNo)
        {
            _roomNo = roomNo;
            return this;
        }

        public QueueDataBuilder WithAdditionalMessage(string additionalMessage)
        {
            _additionalMessage = additionalMessage;
            return this;
        }

        public QueueDataBuilder WithOwner(string owner)
        {
            _owner = owner;
            return this;
        }

        public QueueDataBuilder WithUserInitials(string userInitials)
        {
            _userInitials = userInitials;
            return this;
        }

        public QueueData Build()
        {
            QueueData queueData = new QueueData()
            {
                QueueNo = _queueNo,
                UserInitials = _userInitials,
                RoomNo = _roomNo,
                Timestamp = _timestamp,
                AdditionalMessage = string.Empty,
                Owner = string.Empty
            };

            return queueData;
        }

    }
}
