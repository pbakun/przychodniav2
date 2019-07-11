using QueueSystem.Contract.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QueueSystem.Contract.DataHandling
{
    public class QueueDatabase
    {
        public static void AddQueue(QueueData queue)
        {
            using(SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                //create table if there isn't any
                conn.CreateTable<QueueData>();
                //check if there is a Queue with current's user id
                var data = conn.Table<QueueData>().Where(u => u.UserId == queue.UserId).FirstOrDefault();
                if(data != null)
                {
                    data.Owner = queue.Owner;
                    data.Timestamp = queue.Timestamp;
                    data.RoomNo = queue.RoomNo;
                    DatabaseHelper.Update(data);
                }
                //if not create new Queue in db
                else
                {
                    DatabaseHelper.Insert(queue);
                }
            }
            
        }

        public static void UpdateUsersQueue(QueueData queue)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                //find current queue update db
                var data = conn.Table<QueueData>().Where(u => u.UserId == queue.UserId);
                if (data != null)
                {
                    DatabaseHelper.Update(queue);
                }
            }
        }

        public static QueueData FindQueue(int? userId)
        {
            QueueData user = new QueueData();
            if(userId != null)
            {
                using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
                {
                    user = conn.Table<QueueData>().Where(u => u.UserId == userId).FirstOrDefault();
                }
            }
            return user;
        }

        public static QueueData FindQueueByRoomNo(int? roomNo)
        {
            QueueData user = new QueueData();
            if(roomNo != null)
            {
                using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
                {
                    user = conn.Table<QueueData>().Where(u => u.RoomNo == roomNo).OrderBy(t => t.Timestamp).FirstOrDefault();
                }
            }
            return user;
        }

        public static List<QueueData> ReadDatabase()
        {
            List<QueueData> user;
            using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
               
                user = conn.Table<QueueData>().ToList();
                //conn.Delete(user[1]);

            }
            return user;
        }
    }

}