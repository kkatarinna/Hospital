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
    public class SpecializationRefferal : Refferal, INotifyPropertyChanged, IRefferal //, IDataErrorInfo
    {
        private Specialization _specizalization;
        private int _searchNextHours = 72;
        private int _appointmentDuration = 15;

        public Specialization Specialization
        {
            get => _specizalization;
            set
            {
                if (value != _specizalization)
                {
                    _specizalization = value;
                    OnPropertyChanged();
                }
            }
        }

        public SpecializationRefferal(int ID, int patientId, Specialization specialization) : base(patientId)
        {
            Specialization = specialization;
        }

        public SpecializationRefferal() : base()
        {
            Id = 0;
            Specialization = 0;
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
            SpecializationRefferal specializationRefferal = (SpecializationRefferal)refferal;
            List<Doctor> refferedDoctors = DoctorDAO.Instance.GetSpecializedDoctors(specializationRefferal.Specialization);
            List<Room> CheckUpRooms = RoomDAO.Instance.GetRoomsByPurpose(RoomPurpose.checkup);
            TimeSlot? timeSlot = new TimeSlot();
            foreach (Doctor refferedDoctor in refferedDoctors)
            {
                foreach (Room specializedRoom in CheckUpRooms)
                {
                    FreeTimeSlotService _freeTimeSlotService = new FreeTimeSlotService();
                    timeSlot = _freeTimeSlotService.FindFreeTimeSlot(refferedDoctor.Id,
                        specializedRoom.number,
                        _appointmentDuration,
                        _searchNextHours);
                    if (timeSlot != null)
                    {
                        Appointment refferalAppointment = new Appointment(refferedDoctor.Id,
                            specializationRefferal.PatientId,
                            false,
                            timeSlot,
                            "",
                            refferedDoctor.Specialization,
                            specializedRoom.number);
                        patient.MedicalRecord.Refferal = -1;
                        return refferalAppointment;
                    }
                }
            }
            throw new Exception("Unable To Make An Appointment");
        }

    }
}
