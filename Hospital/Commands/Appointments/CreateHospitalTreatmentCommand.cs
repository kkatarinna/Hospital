using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Model.Refferals;
using Hospital.Service;
using Hospital.Service.Appointment_Service;
using Hospital.ViewModel.Nurse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Commands.Appointments
{
    public class CreateHospitalTreatmentCommand : CommandBase
    {
        CreateHospitalTreatmentViewModel _createHospitalTreatmentViewModel;
        private MakeHospitalTreatmentService _makeHospitalTreatmentService;
        private FreeTimeSlotService _FreeTimeSlotService;
        private Patient _selectedPatient;
        private TimeSlot? _timeSlot;
        public CreateHospitalTreatmentCommand(CreateHospitalTreatmentViewModel createHospitalTreatmentViewModel)
        {
            _createHospitalTreatmentViewModel = createHospitalTreatmentViewModel;
            _selectedPatient = createHospitalTreatmentViewModel.SelectedPatient;
        }
        public override void Execute(object? parameter)
        {
            string roomNumber = _createHospitalTreatmentViewModel.SelectedRoom;

            try { 
                HospitalTreatmentRefferal hospitalTreatmentRefferal = (HospitalTreatmentRefferal)RefferalDAO.Instance.GetRefferal(_selectedPatient.MedicalRecord.Refferal);
                int treatmentDuration = hospitalTreatmentRefferal.Duration;

                _FreeTimeSlotService = new FreeTimeSlotService();

                _timeSlot = _FreeTimeSlotService.FindFreeTreatmentTimeSlot(roomNumber, treatmentDuration);
                if (_timeSlot == null)
                {
                    MessageBox.Show("Unable to find free time slot");
                    return;
                }

                _makeHospitalTreatmentService = new MakeHospitalTreatmentService(_selectedPatient, roomNumber, _timeSlot);
                HospitalTreatment hospitalTreatment = _makeHospitalTreatmentService.GetHospitalTreatment();
                if (hospitalTreatment == null)
                {
                    MessageBox.Show("Unable to make hospital treatment");
                    return;
                }

                var result = MessageBox.Show("CreateHospital Treatment?" + "\n"
                    + "Room: " + _createHospitalTreatmentViewModel.SelectedRoom + "\n"
                    + "Time: " + _timeSlot, "confirmation", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    HospitalTreatmentDAO hospitalTreatmentDAO = HospitalTreatmentDAO.Instance;
                    hospitalTreatmentDAO.Add(hospitalTreatment);
                    _selectedPatient.MedicalRecord.Refferal = -1;
                    _selectedPatient.MedicalRecord.Therapy = hospitalTreatmentRefferal.TherapyID;
                    PatientDAO patientDAO = PatientDAO.Instance;
                    patientDAO.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
