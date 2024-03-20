using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Observer;
using Hospital.Service;
using Hospital.ViewModel;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for StudentsOverview.xaml
    /// This is the view part of this application.
    /// It's responsible for previewing data to the user and
    /// for retrieving data from the user. It can also do
    /// some light Hospital. Everything else view delegates
    /// to the controller.
    /// </summary>
    public partial class PatientAppointmentsOverview : Window, IObserver
    {
        private AppointmentController _controller;
        private DoctorController _doctorController;
        private HospitalSurveyController _hospitalSurveyController;
        private DoctorSurveyController _doctorSurveyController;
        private DoctorSurveyService _doctorSurveyService;
        private Patient ActivePatient;
        private int HoursBeforeNotification;
        public ObservableCollection<Appointment> Appointments { get; set; }
        public NotificationService notificationService;
        public List<Notification> Notifications;
        public List<PatientNotification> PatientNotifications;
        public Appointment SelectedAppointment { get; set; }
        //public Patient ActiePatient;
        public PatientAppointmentsOverview()
        {
            InitializeComponent();
            DataContext = this;
            ActivePatient = new Patient(2, "novo", "ime", 0, 0);
            _doctorController = new DoctorController();
            _controller = new AppointmentController();
            _hospitalSurveyController = new HospitalSurveyController();
            _doctorSurveyController = new DoctorSurveyController();
            _doctorSurveyService = new DoctorSurveyService();
            PatientNotifications = new List<PatientNotification>();
            notificationService = new NotificationService(ActivePatient.Id);
            Notifications = new List<Notification>(notificationService.GetNotifications(ActivePatient.Id));
            HoursBeforeNotification = 3;
            _controller.Subscribe(this);
            Appointments = new ObservableCollection<Appointment>(_controller.GetPatientAppointments(ActivePatient.Id));
            
        }

        private void ShowCreateAppointmentWindow_Click(object sender, RoutedEventArgs e)
        {
            CreatePatientAppointment createAppointment = new CreatePatientAppointment(_controller, ActivePatient);
            createAppointment.Show();
        }

        private void ShowCreatePriorityAppointmentWindow_Click(object sender, RoutedEventArgs e)
        {
            CreatePriorityAppointment createPriorityAppointment = new CreatePriorityAppointment(_controller, _doctorController);
            createPriorityAppointment.Show();
        }

        private void HospitalSurvey(object sender, RoutedEventArgs e)
        {
            HospitalSurveyView hospitalSurvey = new HospitalSurveyView(_hospitalSurveyController);
            hospitalSurvey.Show();
            
        }

        private void DoDoctorSurvey(object sender, RoutedEventArgs e)
        {
            if (_doctorSurveyService.Validation(SelectedAppointment)) 
            { 
                DoctorSurveyView doctorSurvey = new DoctorSurveyView(_doctorController.GetDoctor(SelectedAppointment.IdDoctor), _doctorSurveyController, SelectedAppointment);
                doctorSurvey.Show();
            }
            else
            {
                MessageBox.Show("Already completed!");
            }

        }
        private void DeleteAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAppointment != null)
            {
                MessageBoxResult result = ConfirmAppointmentDeletion();

                if (result == MessageBoxResult.Yes)
                {
                    if (++ActivePatient.ChangedAppointmentsCount > 5)
                    {
                        ActivePatient.IsBlocked = true;
                    }
                    _controller.Delete(SelectedAppointment);
                }
                
            }
            else
            {

                MessageBox.Show("Choose appointment you want to delete");
            }
        }
        private void ShowAnamnesis_Click(object sender, RoutedEventArgs eventArgs)
        {
            AnamnesisOverview anamnesisOverview = new AnamnesisOverview();
            anamnesisOverview.Show();
        }
        private void ShowNotificationMenu(object sender, RoutedEventArgs eventArgs)
        {
            Notifications notifications = new Notifications(new ObservableCollection<PatientNotification>(PatientNotifications));
            notifications.ShowDialog();
            HoursBeforeNotification = notifications.HoursBeforeNotification;
            PatientNotifications = notifications.PatientNotifications.ToList();
        }
        private void ShowNotifications(object sender, RoutedEventArgs eventArgs)
        {
            notificationService.ShowNotifications(HoursBeforeNotification, PatientNotifications);
        }

        private void EditAppointmentButtonWindow_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAppointment != null)
            {
                EditAppointment createAppointment=new EditAppointment(_controller, SelectedAppointment, ActivePatient);
                createAppointment.Show();
                //MessageBox.Show(SelectedAppointment.Patient);

            }
            else
            {

                MessageBox.Show("Choose appointment you want to modify");
            }
        }
        private MessageBoxResult ConfirmAppointmentDeletion()
        {
            string sMessageBoxText = $"Are you sure you want to delete this appointment\n{SelectedAppointment}";
            string sCaption = "Yes";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            
            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private void UpdateAppointmentList()
        {
            Appointments.Clear();
            foreach (var appointment in _controller.GetPatientAppointments(ActivePatient.Id))
            {
                Appointments.Add(appointment);
            }
        }

        public void Update()
        {
            UpdateAppointmentList();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
