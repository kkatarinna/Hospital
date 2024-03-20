using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Hospital.Controller;
using Hospital.ViewModel;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for MessengerView.xaml
    /// </summary>
    public partial class MessengerView : Window
    {
        public MessengerView(DoctorController doctorController, NurseController nurseController, Model.Nurse nurse)
        {
            InitializeComponent();
            DataContext = new MessengerViewModel(doctorController, nurseController, nurse);
        }
    }
}
