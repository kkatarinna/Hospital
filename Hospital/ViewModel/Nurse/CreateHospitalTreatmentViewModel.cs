using Hospital.Commands;
using Hospital.Commands.Appointments;
using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Model.Enum;
using System.Collections.Generic;
using System.Windows.Input;

namespace Hospital.ViewModel.Nurse
{
    public class CreateHospitalTreatmentViewModel : ViewModelBase
    {
        public List<string> FreeRoomsNumbers { get; set; }

        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }
        public Patient SelectedPatient { get; set; }
        public string SelectedRoom { get; set;  }
        public CreateHospitalTreatmentViewModel(Patient selectedPatient)
        {
            SelectedPatient = selectedPatient;
            CreateCommand = new CreateHospitalTreatmentCommand(this);
            CancelCommand = new CancelCommand(this);
            FreeRoomsNumbers = new List<string>();
            AddRooms();
            SelectedRoom = FreeRoomsNumbers[0];
        }
        private void AddRooms()
        {
            RoomDAO roomDAO = RoomDAO.Instance;
            List<Room> freeRooms = roomDAO.GetRoomsByPurpose(RoomPurpose.patient);
            foreach (Room room in freeRooms)
            {
                FreeRoomsNumbers.Add(room.number);
            }
        }
    }
}
