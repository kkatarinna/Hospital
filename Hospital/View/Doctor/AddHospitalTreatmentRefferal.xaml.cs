using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.Refferals;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddHospitalTreatmentRefferal.xaml
    /// </summary>
    public partial class AddHospitalTreatmentRefferal : Window
    {
        private PatientController _patientController;

        private RefferalController _refferalController;

        private PatientService _patientService;
        public HospitalTreatmentRefferal CreatedHospitalTreatmentRefferal { get; set; }

        public Patient SelectedPatient { get; set; }
        public AddHospitalTreatmentRefferal(PatientController controller, Patient patient)
        {
            InitializeComponent();
            DataContext = this;
            _patientController = controller;
            _refferalController = new RefferalController();
            _patientService = new PatientService("");
            CreatedHospitalTreatmentRefferal = new HospitalTreatmentRefferal();
            SelectedPatient = patient;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OpenAddPresription_Click(object sender, RoutedEventArgs e)
        {
            AddPrescription therapy = new AddPrescription(_patientController, SelectedPatient);
            therapy.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddRefferal_Click(object sender, RoutedEventArgs e)
        {
            CreatedHospitalTreatmentRefferal.TherapyID = SelectedPatient.MedicalRecord.Therapy;
            CreatedHospitalTreatmentRefferal.PatientID = SelectedPatient.Id;
            _refferalController.Create(CreatedHospitalTreatmentRefferal);
            Close();

            SelectedPatient.MedicalRecord.Refferal = CreatedHospitalTreatmentRefferal.Id;
            if (SelectedPatient.IsValid)
            {
                _patientController.Update();
                Close();
            }
        }
    }
}
