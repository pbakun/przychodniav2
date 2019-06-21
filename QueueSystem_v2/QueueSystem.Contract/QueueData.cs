using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.Contract
{
    public class QueueData
    {
        public event EventHandler ValueChanged;

        protected virtual void OnValueChange(object value)
        {
            ValueChanged?.Invoke(this, EventArgs.Empty); 
        }
        
        public int QueueNo
        {
            get; set;
        }

        public string QueueNoMessage {
            get
            {
                if(QueueNo > 0)
                {
                    return UserInitials + QueueNo.ToString();
                }
                else if(QueueNo == -1)
                {
                    return "Przerwa";
                }
                return string.Empty;
                
            }
        }

        public string UserInitials { get; set; }

        public DateTime Timestamp { get; set; }

        public string RoomNo { get; set; }

        public string AdditionalMessage { get; set; }

        public string Owner { get; set; }
    }
}
