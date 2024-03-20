using Hospital.Controller;
using Hospital.Model;
using Hospital.View.Doctor;
using Hospital.ViewModel.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Commands.Visits
{
    public class VisitsPatient : CommandBase
    {
        private Patient _patient;

        private PatientController _patientController;
        public VisitsPatient(VisitsPatientListViewModel visitPatientVM) 
        {
            _patientController = new PatientController();
            _patient = _patientController.GetPatient(visitPatientVM.SelectedTreatment.PatientId);
        }
        public override void Execute(object? parameter)
        {
            VisitEdit ve = new VisitEdit(_patient);
            ve.Show();
        }
    }
}
