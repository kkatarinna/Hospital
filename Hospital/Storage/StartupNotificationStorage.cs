using Hospital.Model;
using Hospital.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Storage
{
    public class StartupNotificationStorage
    {

        private const string StoragePath = "../../../Data/startupNotifications.json";
        private ISerializer<StartupNotification> _serializer;

        public StartupNotificationStorage(ISerializer<StartupNotification> serializer)
        {
            _serializer = serializer;
        }

        public List<StartupNotification> Load()
        {
            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<StartupNotification> appointment)
        {
            _serializer.WriteToFile(StoragePath, appointment);
        }
    }
}
