using Hospital.Controller;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for CreateTherapy.xaml
    /// </summary>
    public partial class CreateTherapy : Window, INotifyPropertyChanged
    {
        public Therapy CreatedTherapy { get; set; }

        private TherapyController _therapyController;

        public Patient Patient { get; set; }

        private PatientController _patientController;
        public CreateTherapy(Therapy therapy, PatientController controller, Patient patient)
        {
            InitializeComponent();
            DataContext = this;

            CreatedTherapy = therapy;
            Patient = patient;
            _therapyController = new TherapyController();
            _patientController = controller;

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            //CreatedTherapy.Start = null;

            CreatedTherapy.PatientId = Patient.Id; 
            _therapyController.Create(CreatedTherapy);
            Close();
            Patient.MedicalRecord.Therapy = CreatedTherapy.Id;
            if (Patient.IsValid)
            {

                _patientController.Update();
                Close();
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
