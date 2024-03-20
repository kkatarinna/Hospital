using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Documents;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Service;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private UserController _userController;
        public string Username { get; set; }
        public string Password { get; set; }
        private List<StartupNotification> _startupNotifications { get; set; }
        private StartupNotificationService _startupNotificationService { get; set; }
        private AdminMain adminWindow {get;set;}
        private ChooseDate showAppointment { get; set; }
        private PatientAppointmentsOverview patientAppointmentsOverview { get; set; }
        private PatientOverview showPatient { get; set; }


        
        public StartWindow()
        {
            _userController = new UserController();
            _startupNotificationService = new StartupNotificationService();
            InitializeComponent();
            DataContext = this;

            adminWindow = new AdminMain();
            showAppointment = new ChooseDate();
            patientAppointmentsOverview = new PatientAppointmentsOverview();
            showPatient = new PatientOverview();


        }

        private void Log_In_Click(object sender, RoutedEventArgs e)
        {
            bool validInfo = _userController.CheckCredentials(Username, Password);
            
            if (!validInfo)
            {
                MessageBox.Show("Wrong username or password");
                this.Show();
                return;
            }
            else
            {
                this.Hide();
                User user = _userController.GetUser(Username);
                DisplayNotifications(user.Id);
                StartUserWindow(user);
                this.Show();
            }
        }

        void StartUserWindow(User user)
        {
            Role role = user.Role;
            switch (role)
            {
                case Role.Admin:
                    adminWindow.ShowDialog();
                    break;
                case Role.Doctor:
                    showAppointment.ShowDialog();
                    break;
                case Role.Patient:
                    patientAppointmentsOverview.ShowDialog();
                    break;
                case Role.Nurse:
                    showPatient.ShowDialog();
                    break;
            }
            this.Show();
        }

        void DisplayNotifications(int id)
        {
            _startupNotifications = _startupNotificationService.GetAndDeleteUserNotifications(id);

            foreach(StartupNotification notification in _startupNotifications)
            {
                MessageBox.Show(notification.ToString());
            }
        }

        private void myWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseApplication();
            System.Windows.Application.Current.Shutdown();

        }

        private void CloseApplication()
        {
            adminWindow.Close();
            showAppointment.Close();
            patientAppointmentsOverview.Close();
            showPatient.Close();
        }
    }
}
