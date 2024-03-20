using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.Refferals;
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

namespace Hospital.View.Doctor
{
    /// <summary>
    /// Interaction logic for AddDoctorRefferal.xaml
    /// </summary>
    public partial class AddDoctorRefferal : Window
    {
        private DoctorController _doctorController;

        private PatientController _patientController;

        private RefferalController _refferalController;

        private DoctorRefferal _doctorRefferal;

        public Patient SelectedPatient { get; set; }

        public Model.Doctor SelectedDoctor { get; set; }

        public AddDoctorRefferal(PatientController controller, Patient patient)
        {
            InitializeComponent();
            DataContext = this;

            _doctorController = new DoctorController();
            _refferalController = new RefferalController();
            _patientController = controller;
            SelectedPatient = patient;
            List<Model.Doctor> doctors = _doctorController.GetAll();

            _doctorRefferal = new DoctorRefferal();

            DoctorCB.ItemsSource = doctors;
            DoctorCB.SelectedIndex = 0;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddRefferal_Click(object sender, RoutedEventArgs e)
        {
            _doctorRefferal.DoctorID = SelectedDoctor.Id;
            _doctorRefferal.PatientId = SelectedPatient.Id;
            _refferalController.Create(_doctorRefferal);
            Close();

            SelectedPatient.MedicalRecord.Refferal = _doctorRefferal.Id;
            if (SelectedPatient.IsValid)
            {

                _patientController.Update();
                Close();
            }
        }
    }
}
