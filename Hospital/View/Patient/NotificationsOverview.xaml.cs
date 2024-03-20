using Hospital.Model;
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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for NotificationsOverview.xaml
    /// </summary>
    public partial class NotificationsOverview : Window
    {
        public ObservableCollection<PatientNotification> PatientNotifications { get; set; }
        public NotificationsOverview(ObservableCollection<PatientNotification> patientNotifications)
        {
            InitializeComponent();
            PatientNotifications = patientNotifications;
            DataContext = this;
        }
    }
}
