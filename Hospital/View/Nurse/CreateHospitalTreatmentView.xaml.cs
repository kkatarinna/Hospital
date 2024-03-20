using Hospital.Model;
using Hospital.ViewModel;
using Hospital.ViewModel.Nurse;

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

namespace Hospital.View.Nurse
{
    /// <summary>
    /// Interaction logic for CreateHospitalTreatmentView.xaml
    /// </summary>
    public partial class CreateHospitalTreatmentView : Window
    {
        public CreateHospitalTreatmentView(Patient selectedPatient)
        {
            InitializeComponent();
            DataContext = new CreateHospitalTreatmentViewModel(selectedPatient);
        }
    }
}
