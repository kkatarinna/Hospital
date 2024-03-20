using Hospital.Commands.Visits;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.DAO;
using Hospital.Observer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital.ViewModel.Doctor
{
    public class VisitsPatientListViewModel : Window, IObserver
    {
        private HospitalTreatmentDAO _hospitalTreatmentDAO;
        public ObservableCollection<HospitalTreatment> PatientsInHospital { get; set; }

        private PatientController _patientController;

        //private Patient _selectedPatient;

        public HospitalTreatment SelectedTreatment { get; set; }

        public ICommand VisitPatient { get; }


        public VisitsPatientListViewModel() 
        {

            _hospitalTreatmentDAO = new HospitalTreatmentDAO();
            _patientController = new PatientController();
            PatientsInHospital = new ObservableCollection<HospitalTreatment>(_hospitalTreatmentDAO.GetAllForToday());
            VisitPatient = new VisitsPatient(this);
            //_selectedPatient = _patientController.GetPatient(SelectedTreatment.PatientId);

        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
