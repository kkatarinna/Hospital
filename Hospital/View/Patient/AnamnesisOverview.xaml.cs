using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.Enum;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View
{

    public partial class AnamnesisOverview : Window
    {

        private AppointmentController _controller;
        public Patient ActivePatient { get; set; }
        public ObservableCollection<Appointment> Appointments { get; set; }
        public AnamnesisSortOption SelectedSortOption { get; set; }

        public AnamnesisOverview()
        {
            InitializeComponent();
            DataContext = this;

            ActivePatient = new Patient(2, "novo", "ime", 0, 0);
            _controller = new AppointmentController();
            Appointments = new ObservableCollection<Appointment>(_controller.GetPastAppointments(ActivePatient.Id));
        }
        private void SearchAnamnesis(object sender, TextChangedEventArgs e)
        {
            Appointments = new ObservableCollection<Appointment>(_controller.GetPastAppointments(ActivePatient.Id)
                .Where(a => a.Anamnesis.Contains(AnamnesisTxt.Text))
                .ToList());
            DataGrid dg = (DataGrid)FindName("AnamnesisDataGrid");
                dg.ItemsSource = Appointments;
        }
        private void OrderAnamnesis(object sender, SelectionChangedEventArgs e)
        {
            switch (SelectedSortOption)
            {
                case AnamnesisSortOption.Time:
                    Appointments = new ObservableCollection<Appointment>(Appointments.OrderBy(a => a.TimeSlot.Start).ToList());
                    break;
                case AnamnesisSortOption.Doctor:
                    Appointments = new ObservableCollection<Appointment>(Appointments.OrderBy(a => a.IdDoctor).ToList());
            break;
                case AnamnesisSortOption.Specialization:
                    Appointments = new ObservableCollection<Appointment>(Appointments.OrderBy(a => a.Specialization).ToList());
            break;
        }
            DataGrid dg = (DataGrid)FindName("AnamnesisDataGrid");
            dg.ItemsSource = Appointments;
        }
    }
}
