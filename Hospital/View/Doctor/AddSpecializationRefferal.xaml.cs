using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.Enum;
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
    /// Interaction logic for AddSpecializationRefferal.xaml
    /// </summary>
    public partial class AddSpecializationRefferal : Window
    {
        private PatientController _patientController;

        private RefferalController _refferalController;

        private SpecializationRefferal _specializationRefferal;

        public Patient SelectedPatient { get; set; }

        public Specialization SelectedSpecialization { get; set; }
        public AddSpecializationRefferal(PatientController controller, Patient patient)
        {
            InitializeComponent();
            DataContext = this;

            _refferalController = new RefferalController();
            _patientController = controller;
            SelectedPatient = patient;
            

            _specializationRefferal = new SpecializationRefferal();

            SpecializationCB.ItemsSource = Enum.GetValues(typeof(Specialization));
            SpecializationCB.SelectedIndex = 0;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddRefferal_Click(object sender, RoutedEventArgs e)
        {
            _specializationRefferal.Specialization = (Specialization)SpecializationCB.SelectedIndex;
            _specializationRefferal.PatientId = SelectedPatient.Id;
            _refferalController.Create(_specializationRefferal);
            Close();
        }
    }
}
