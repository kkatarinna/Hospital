using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.View;

namespace Hospital.Service
{
    public class NotificationService
    {
        public List<Notification> Notifications;
        private MedicineService _medicineService;
        private MedicineDAO _medicines;
        private TherapyDAO _therapies;

        public NotificationService(int patientId) 
        { 
            Notifications= new List<Notification>();
            _medicines = MedicineDAO.Instance;
            _therapies = TherapyDAO.Instance;
            _medicineService = new MedicineService();
        }

        public List<Notification> GetNotifications(int patientId)
        {
            foreach(Therapy therapy in _therapies.GetPatientTherapies(patientId))
            {
                foreach(Prescription prescription in therapy.Prescriptions)
                {
                    Notifications.Add(new Notification(therapy.Start, _medicineService.GetMedicine(prescription.MedicineID), prescription.Instructions));
                }
            }
            return Notifications;
        }
        
        public void ShowNotifications(int HoursBeforeTherapy, List<PatientNotification> patientNotifications)
        {
            DateTime currentTime = DateTime.Now;
            foreach(Notification notification in Notifications)
            {
                if (currentTime.AddHours(HoursBeforeTherapy) > notification.TimeOfUse){
                    MessageBox.Show(notification.ToString());
                }
            }
            foreach(PatientNotification patientNotification in patientNotifications)
            {
                if (currentTime.AddHours(HoursBeforeTherapy) > patientNotification.NotificationTime)
                {
                    MessageBox.Show(patientNotification.ToString());
                }
            }
        }
    }
}
