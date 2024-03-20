
using System.Collections.ObjectModel;
using System.Windows;
using Hospital.Model;
using Hospital.Controller;
using Hospital.Observer;
using Hospital.Model.Orders;
using Hospital.View.Nurse;
using System;
using Hospital.Model.Refferals;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for PatientOverview.xaml
    /// </summary>
    public partial class PatientOverview : Window, IObserver
    {
        private PatientController _patientController;
        private AppointmentController _appointmentController;
        private RoomController _roomController;
        private DoctorController _doctorController;
        private NurseController _nurseController;
        private TherapyController _therapyController;
        private RefferalController _refferalController;
        private Model.Nurse activeNurse;
        public ObservableCollection<Patient> Patients { get; set; }
        public Patient SelectedPatient { get; set; }

        public PatientOverview()
        {
            InitializeComponent();
            DataContext = this;

            _refferalController = new RefferalController();
            _patientController = new PatientController();
            _patientController.Subscribe(this);
            _appointmentController = new AppointmentController();
            _roomController = new RoomController();
            _doctorController = new DoctorController();
            _nurseController = new NurseController();
            _therapyController = new TherapyController();
            activeNurse = new Model.Nurse(1, "Sestra", "Prva");

            Patients = new ObservableCollection<Patient>(_patientController.GetAllPatients());
        }

        private void ShowCreatePatientWindow_Click(object sender, RoutedEventArgs e)
        {
            CreatePatient createPatient = new CreatePatient(_patientController);
            createPatient.Show();
        }
        private void ShowUpdatePatientWindow_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedPatient != null)
            {
                UpdatePatient updatePatient = new UpdatePatient(_patientController, SelectedPatient);
                updatePatient.Show();
            }
            else
            {

                MessageBox.Show("Pick patient to update.");
            }
        }
        private void ShowRecievePatientWindow_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null) 
            { 
                MessageBox.Show("Pick patient to recieve.");
                return;
            }
            Appointment patientReception = _appointmentController.GetPatientReception(SelectedPatient.Id);
            if (patientReception != null)
            {
                RecievePatient recievePatient = new RecievePatient(_patientController, SelectedPatient,_appointmentController, patientReception);
                recievePatient.Show();

            }
            else
            {
                MessageBox.Show("Patient doesn't have any appointments to be recieved to.");
                return;
            }
        }
        private void ShowEmergencyAppointmentWindow_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Pick patient for appointment.");
                return;
            }
            CreateEmergencyAppointment createEmergencyAppointment = new CreateEmergencyAppointment(SelectedPatient, _appointmentController,_roomController,_doctorController);
            createEmergencyAppointment.Show();
        }
        private void IssuingMedicine_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Pick patient for Issuing of Medicines.");
                return;
            }
            try 
            { 
                _therapyController.IssueMedicine(SelectedPatient);
                if (MessageBox.Show("Make An Appointment?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Appointment CheckUpAppointmnet = _appointmentController.GetCheckUpAppointment(SelectedPatient.Id);
                    _appointmentController.Create(CheckUpAppointmnet);
                    MessageBox.Show("Refferal Appointment Created: \n " +
                        "Date and Time: " + CheckUpAppointmnet.TimeSlot.Start + "\n" +
                        "Doctor: " + _doctorController.GetDoctorFullName(CheckUpAppointmnet.IdDoctor) + "\n" +
                        "Room:" + CheckUpAppointmnet.RoomNumber);
                }
                else
                {
                    MessageBox.Show("Succsesfull");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateRefferalAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Pick patient for appointment.");
                return;
            }
            try {
                Refferal refferal = _refferalController.GetRefferal(SelectedPatient.MedicalRecord.Refferal);
                if(refferal.GetType() == typeof(HospitalTreatmentRefferal))
                {
                    CreateHospitalTreatmentView createHospitalTreatmentView = new CreateHospitalTreatmentView(SelectedPatient);
                    createHospitalTreatmentView.Show(); 
                }
                else
                {
                    Appointment refferalAppointment = _appointmentController.GetRefferalAppointment(SelectedPatient);
                    _appointmentController.Create(refferalAppointment);
                    _patientController.Update();
                    MessageBox.Show("Refferal Appointment Created: \n " +
                        "Date and Time: " + refferalAppointment.TimeSlot.Start + "\n" +
                        "Doctor: " + _doctorController.GetDoctorFullName(refferalAppointment.IdDoctor) + "\n" +
                        "Room:" + refferalAppointment.RoomNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowMedicalRecord_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
            {
                MedicalRecordView medicalRecordView = new MedicalRecordView(SelectedPatient);
                medicalRecordView.Show();
            }
        }
        private void ShowOrderMedicine_Click(object sender,RoutedEventArgs e)
        {
            OrderMedicineView orderMedicineView= new OrderMedicineView();
            orderMedicineView.Show();
        }
        private void Chat_Click(object sender, RoutedEventArgs e)
        {
            MessengerView view = new MessengerView(_doctorController, _nurseController, activeNurse);
            view.Show();
        }
        private void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
            {
                MessageBoxResult result = ConfirmPatientDeletion();

                if (result == MessageBoxResult.Yes)
                    _patientController.Delete(SelectedPatient);
            }
            else
            {

                MessageBox.Show("Pick patient to delete.");
            }
        }

        private MessageBoxResult ConfirmPatientDeletion()
        {
            string sMessageBoxText = $"Are you sure you want to delete Patient: \n{SelectedPatient}";
            string sCaption = "Confirm delete";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private void UpdatePatientList()
        {
            Patients.Clear();
            foreach (var patient in _patientController.GetAllPatients())
            {
                Patients.Add(patient);
            }
        }

        public void Update()
        {
            UpdatePatientList();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
