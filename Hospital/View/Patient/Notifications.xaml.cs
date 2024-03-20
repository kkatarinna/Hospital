using Hospital.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Window
    {
        public int HoursBeforeNotification;
        public ObservableCollection<PatientNotification> PatientNotifications;
        public Notifications(ObservableCollection<PatientNotification> patientNotifications)
        {
            InitializeComponent();
            HoursBeforeNotification = 3;
            PatientNotifications = patientNotifications;
        }

        public void ChooseNotificationHours(object sender, RoutedEventArgs eventArgs)
        {
            NotificationHourChoice notificationHourChoice = new NotificationHourChoice();
            notificationHourChoice.ShowDialog();
            HoursBeforeNotification = notificationHourChoice.HoursBeforeNotification;
        }

        public void CreateNotification_Click(object sender, RoutedEventArgs eventArgs)
        {
            CreateNotification createNotification = new CreateNotification(PatientNotifications);
            createNotification.ShowDialog();
            PatientNotifications.Add(new PatientNotification(createNotification.NotificationTime, createNotification.NotificationContent));
            
        }

        public void ListNotifications_Click(object sender, RoutedEventArgs eventArgs)
        {
            NotificationsOverview notificationsOverview = new NotificationsOverview(PatientNotifications);
            notificationsOverview.Show();
        }
    }
}
