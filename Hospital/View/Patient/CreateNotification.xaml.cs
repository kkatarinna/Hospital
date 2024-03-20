using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for CreateNotification.xaml
    /// </summary>
    public partial class CreateNotification : Window
    {
        public DateTime NotificationTime { get; set; }
        public string NotificationContent { get; set; }
        public ObservableCollection<PatientNotification> Notifications;
        public CreateNotification(ObservableCollection<PatientNotification> notifications)
        {
            InitializeComponent();
            DataContext = this;
            NotificationTime = DateTime.Now;
            Notifications = notifications;
        }
        public void CreatePatientNotification_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Notification: " + NotificationContent + "\nTime: " + NotificationTime);
            Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
