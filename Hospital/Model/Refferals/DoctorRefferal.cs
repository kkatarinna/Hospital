using Hospital.Model.DAO;
using Hospital.Model.Enum;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Refferals
{
    public class DoctorRefferal : Refferal, INotifyPropertyChanged, IRefferal //, IDataErrorInfo
    {

        private int _searchNextHours = 72;
        private int _appointmentDuration = 15;
        private int _doctorID;

        public int DoctorID
        {
            get => _doctorID;
            set
            {
                if (value != _doctorID)
                {
                    _doctorID = value;
                    OnPropertyChanged();
                }
            }
        }

        public DoctorRefferal(int ID, int patientId, int doctorID) : base(patientId)
        {
            DoctorID = doctorID;
        }

        public DoctorRefferal() : base()
        {
            Id = 0;
            DoctorID = 0;
            PatientId = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        public Appointment CreateAppointment(IRefferal refferal, Patient patient)
        {
            DoctorRefferal dotorRefferal = (DoctorRefferal)refferal;
            Doctor refferedDoctor = DoctorDAO.Instance.GetDoctor(dotorRefferal.DoctorID);
            List<Room> CheckUpRooms = RoomDAO.Instance.GetRoomsByPurpose(RoomPurpose.checkup);
            TimeSlot? timeSlot = new TimeSlot();
            foreach (Room specializedRoom in CheckUpRooms)
            {
                FreeTimeSlotService _freeTimeSlotService = new FreeTimeSlotService();
                timeSlot = _freeTimeSlotService.FindFreeTimeSlot(refferedDoctor.Id,
                    specializedRoom.number,
                    _appointmentDuration,
                    _searchNextHours);
                if (timeSlot != null)
                {
                    Appointment refferalAppointment = new Appointment(dotorRefferal.DoctorID,
                        dotorRefferal.PatientId,
                        false,
                        timeSlot,
                        "",
                        refferedDoctor.Specialization,
                        specializedRoom.number);
                    return refferalAppointment;
                }
            }
            throw new Exception("Not Able To Make An Appointment");
        }
    }
}
