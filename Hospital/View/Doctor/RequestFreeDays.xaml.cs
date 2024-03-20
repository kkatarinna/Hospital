using Hospital.ViewModel.Doctor;
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

namespace Hospital.View.Doctor
{
    /// <summary>
    /// Interaction logic for RequestFreeDays.xaml
    /// </summary>
    public partial class RequestFreeDays : Window
    {
        public RequestFreeDays(Model.Doctor activeDoctor)
        {
            InitializeComponent();
            DataContext = new RequestFreeDaysViewModel(activeDoctor);
        }
    }
}
