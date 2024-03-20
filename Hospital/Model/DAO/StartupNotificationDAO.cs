using Hospital.Serializer;
using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO
{
    public class StartupNotificationDAO:IDAO<StartupNotification>
    {
        List<StartupNotification> _notifications;
        StartupNotificationStorage _storage;


        private static StartupNotificationDAO instance = null;
        public static StartupNotificationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StartupNotificationDAO();
                }
                return instance;
            }
        }
        private StartupNotificationDAO() {
            _storage = new StartupNotificationStorage(new JSONSerializer<StartupNotification>());
            _notifications=_storage.Load();
        }

        public void Add(StartupNotification obj)
        {
            _notifications.Add(obj);
            Save();
        }

        public void Remove(StartupNotification obj)
        {
            _notifications.Remove(obj);
            Save();
        }

        public void Update(StartupNotification obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _storage.Save(_notifications);
        }

        public List<StartupNotification> GetAll()
        {
            return _notifications;
        }



       public List<StartupNotification> GetByUserID(int id) { 

            List<StartupNotification> list = new List<StartupNotification>();
            
            foreach (StartupNotification obj in _notifications)
            {
                if (obj.UserID == id)
                {
                    list.Add(obj);
                }
            }
            return list;
        }
    }
}
