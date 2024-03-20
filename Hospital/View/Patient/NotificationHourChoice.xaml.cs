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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for NotificationHourChoice.xaml
    /// </summary>
    public partial class NotificationHourChoice : Window
    {
        public int HoursBeforeNotification { get; set; }
        public NotificationHourChoice()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ChooseNotificationHour_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hours before notification set to " + HoursBeforeNotification.ToString()); 
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
