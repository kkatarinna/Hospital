using Hospital.Controller;
using Hospital.Model;
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
    /// Interaction logic for ChooseRefferalToAdd.xaml
    /// </summary>
    public partial class ChooseRefferalToAdd : Window
    {
        private PatientController _patientController;

        public Patient SelectedPatient { get; set; }
        public ChooseRefferalToAdd(PatientController controller, Patient patient)
        {
            InitializeComponent();
            DataContext = this;

            _patientController = controller;
            SelectedPatient = patient;


        }

        private void CreateDoctor_Refferal(object sender, RoutedEventArgs e)
        {
            Close();
            AddDoctorRefferal createRefferaly = new AddDoctorRefferal(_patientController, SelectedPatient);
            createRefferaly.Show();
        }

        private void CreateSpecialization_Refferal(object sender, RoutedEventArgs e)
        {
            Close();
            AddSpecializationRefferal createRefferaly = new AddSpecializationRefferal(_patientController, SelectedPatient);
            createRefferaly.Show();
        }

        private void CreateHositalTreatment_Refferal(object sender, RoutedEventArgs e)
        {
            Close();
            AddHospitalTreatmentRefferal createRefferaly = new AddHospitalTreatmentRefferal(_patientController, SelectedPatient);
            createRefferaly.Show();
        }

    }
}
