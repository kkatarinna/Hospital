using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Model.DAO;

namespace Hospital.Service
{
    public class StartupNotificationService
    {

        StartupNotificationDAO _dao;

        public StartupNotificationService()
        {
            _dao = StartupNotificationDAO.Instance;
        }
        public void MakeCanceledAppointmenNotification(Appointment appointment)
        {
            string message = "Your appointment"+" at " + appointment.TimeSlot.Start.ToString() + " has been canceled.";
            StartupNotification notification = new StartupNotification(appointment.Id,message);
            _dao.Add(notification);

        }

        public List<StartupNotification> GetAndDeleteUserNotifications(int id)
        {
            List<StartupNotification> notifications = _dao.GetByUserID(id);
            RemoveNotificaitons(notifications);
            return notifications;
        }

        void RemoveNotificaitons(List<StartupNotification> notifications)
        {

            foreach (StartupNotification notification in notifications)
            {
                _dao.Remove(notification);
            }

        }

    }
}
