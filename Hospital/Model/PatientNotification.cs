using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class PatientNotification
    {
        private DateTime _notificationTime;
        private string _notificationContent;

        public DateTime NotificationTime
        {
            get => _notificationTime;
            set
            {
                if(value !=  _notificationTime)
                {
                    _notificationTime = value;
                }
            }
        }
        public string NotificationContent
        {
            get => _notificationContent;
            set
            {
                if(value != _notificationContent)
                {
                    _notificationContent = value;
                }
            }
        }
        public PatientNotification() { }

        public PatientNotification(DateTime notificationTime, string notificationContent)
        {
            _notificationTime = notificationTime;
            _notificationContent = notificationContent;
        }

        public override string ToString()
        {
            return "Notification: " + NotificationContent + "\nTime: " + NotificationTime;
        }
    }
}
