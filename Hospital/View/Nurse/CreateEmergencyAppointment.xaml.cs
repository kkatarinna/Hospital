using Hospital.Controller;
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
using Hospital.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Numerics;
using Hospital.Model.Enum;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for CreateEmergencyAppointment.xaml
    /// </summary>
    public partial class CreateEmergencyAppointment : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Appointment> ShowMovableAppointments { get; set; }

        private AppointmentController _appointmentController;
        private DoctorController _doctorController;
        private RoomController _roomController;
        public Patient SelectedPatient;
        public ObservableCollection<int> Hours { get; set; }
        public Appointment SelectedAppointment { get; set; }
        public int Postponment { get; set; }
        public int EmergencyTime { get; set; }
        public int Duration { get; set; }
        public bool IsOperation { get; set; }
        public Specialization SelectedSpecialization { get; set; }
        public CreateEmergencyAppointment(Patient selectedPatient,
                                          AppointmentController appointmentController,
                                          RoomController roomController,
                                          DoctorController doctorController)
        {
            InitializeComponent();
            DataContext = this;
            _appointmentController = appointmentController;
            _roomController = roomController;
            _doctorController = doctorController;
            SelectedPatient = selectedPatient;
            ShowMovableAppointments = new ObservableCollection<Appointment>(new List<Appointment>());
            Postponment = 72;
            EmergencyTime = 2;
            SelectedSpecialization = Specialization.Cardiologist;
        }

        

        
        private void CreateEmergancyAppointment_Click(object sender, RoutedEventArgs e)
        {
            Duration = 35;
            if (!IsOperation) {
                Duration = 15;
            }
            RoomPurpose roomPurpose = RoomPurpose.operation;
            if (!IsOperation)
                roomPurpose = RoomPurpose.checkup;

            Appointment? emergencyAppointment = _appointmentController.GetEmergancyAppointment(
                SelectedSpecialization,
                roomPurpose,
                Duration,
                SelectedPatient.Id,
                IsOperation);

            if(emergencyAppointment != null)
            {
                _appointmentController.Create(emergencyAppointment);
                MessageBox.Show("Emergency Appointment Created: \n " +
                    "Date and Time: " + emergencyAppointment.TimeSlot.Start + "\n"+
                    "Doctor: " + _doctorController.GetDoctorFullName(emergencyAppointment.IdDoctor)+"\n"+
                    "Room:" + emergencyAppointment.RoomNumber);
                Close();
                return;
            }
            if (emergencyAppointment == null)
            {
                List<Appointment> MovableAppointments = _appointmentController.GetMovableAppointments(
                    SelectedSpecialization,
                    roomPurpose,
                    Duration);
                UpdateAppointmentsDataGrid(MovableAppointments);
            }
        }

        private void UpdateAppointmentsDataGrid(List<Appointment> appointments)
        {
            ShowMovableAppointments.Clear();
            int i = 0;
            foreach (var appointment in appointments)
            {
                ShowMovableAppointments.Add(appointment);
                i++;
                if (i == 5)
                    break;
            }
        }

        private void MoveAppointment_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedAppointment == null)
            {
                return;
            }
            Model.Doctor usedDoctor = _doctorController.GetDoctor(SelectedAppointment.IdDoctor);
            Room usedRoom = _roomController.GetRoomByNumber(SelectedAppointment.RoomNumber);
            List<Model.Doctor> specializedDoctors = _doctorController.GetSpecializedDoctors(usedDoctor.Specialization);
            List<Room> specializedRooms = _roomController.GetRoomsByPurpose(usedRoom.purpose);
            foreach (Model.Doctor doctor in specializedDoctors)
            {
                foreach(Room room in specializedRooms)
                {
                    TimeSlot nextFreeTimeSlot = _appointmentController.FindFreeTimeSlot(doctor.Id, room.number, SelectedAppointment.TimeSlot.Duration, Postponment);
                    if (nextFreeTimeSlot != null)
                    {
                        CreateNewAppointment(nextFreeTimeSlot,room.number);
                        UpdateSelectedAppointment();
                        MessageBox.Show("Succsesfully moved appointment to: \n" + nextFreeTimeSlot.Start);
                        Close();
                        return;
                    }

                }
            }
            MessageBox.Show("Unable to move appointment please choose another appointment or increase time for moving");
        }

        private void UpdateSelectedAppointment()
        {
            SelectedAppointment.IdPatient = SelectedPatient.Id;
            SelectedAppointment.TimeSlot.Duration = Duration;
            SelectedAppointment.Anamnesis = "";
        }
        private void CreateNewAppointment(TimeSlot nextFreeTimeSlot,string roomNumber)
        {
            Appointment newAppointment = new Appointment(
                SelectedAppointment.IdDoctor,
                SelectedAppointment.IdPatient,
                SelectedAppointment.IsOperation,
                nextFreeTimeSlot,
                "",
                SelectedAppointment.Specialization,
                roomNumber
                );
            _appointmentController.Create(newAppointment);

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
