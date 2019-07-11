using SQLite;
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
                if(QueueNo > 0 && !isBreak)
                {
                    return UserInitials + QueueNo.ToString();
                }
                else if(isBreak)
                {
                    return "Przerwa";
                }
                return string.Empty;
                
            }
            set
            {

            }
        }

        public string UserInitials { get; set; }

        public DateTime Timestamp { get; set; }

        public int RoomNo { get; set; }

        public string AdditionalMessage { get; set; }

        public bool isBreak { get; set; }

        public string Owner { get; set; }

        public bool isSenderActive { get; set; }

        [PrimaryKey]
        public int UserId { get; set; }
    }
}
