using Hospital.Controller;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for CreateTherapy.xaml
    /// </summary>
    public partial class AddPrescription : Window, INotifyPropertyChanged
    {
        private PatientController _patientController;
        public Medicine SelectedMedicine { get; set; }

        private TherapyController _therapyController;

        private PatientService _patientService;

        private Therapy _therapy;

        private Patient SelectedPatient { get; set; }

        public Prescription CreatedPrescription { get; set; }

        private TextBox _textBox;

        public AddPrescription(PatientController controller, Patient patient)
        {
            InitializeComponent();
            DataContext = this;
            _therapyController = new TherapyController();
            _patientController = controller;
            _patientService = new PatientService("");
            List<Medicine> medicines = _therapyController.GetAllMedcicines();


            MedicinesCB.ItemsSource = medicines;
            MedicinesCB.SelectedIndex = 0;

            _therapy = new Therapy();
            SelectedPatient = patient;
            _textBox = (TextBox)FindName("InstructionsTextBox");

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreateTherapy_Click(object sender, RoutedEventArgs e)
        {
            Close();
            CreateTherapy createTherapy = new CreateTherapy(_therapy, _patientController, SelectedPatient);
            createTherapy.Show();
        }

        private void AddMedicine_Click(object sender, RoutedEventArgs e)
        {
            CreatedPrescription = new Prescription();
            CreatedPrescription.MedicineID = SelectedMedicine.Id;
            CreatedPrescription.Instructions = _textBox.Text;

            bool isAllergic = _patientService.isPatientAllergic(SelectedMedicine.Components, SelectedPatient);
            if (isAllergic)
            {
                string title = "Warning";
                string message = "Patient is allergic on " + SelectedMedicine.Name + "\nDo you still want to add it?";
                MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _therapy.Prescriptions.Add(CreatedPrescription);
                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Medicine is not added");
                }
            }
            else
            {
                _therapy.Prescriptions.Add(CreatedPrescription);
                MessageBox.Show("successfully added " + SelectedMedicine.ToString());
            }
        }
    }
}
