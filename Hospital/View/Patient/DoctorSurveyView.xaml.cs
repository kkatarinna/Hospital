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
using Hospital.Controller;
using Hospital.ViewModel;
using Hospital.Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for DoctorSurveyView.xaml
    /// </summary>
    public partial class DoctorSurveyView : Window
    {
        public DoctorSurveyView(Model.Doctor doctor, DoctorSurveyController doctorSurveyController, Appointment selectedAppointment)
        {
            InitializeComponent();
            DataContext = new DoctorSurveyViewModel(doctor, doctorSurveyController, selectedAppointment);
        }
    }
}
