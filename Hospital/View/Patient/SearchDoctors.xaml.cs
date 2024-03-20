using Hospital.Controller;
using Hospital.Model;
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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for SearchDoctors.xaml
    /// </summary>
    public partial class SearchDoctors : Window
    {
        private DoctorController _controller;
        public ObservableCollection<Model.Doctor> Doctors { get; set; }
        public DoctorSortOption SelectedSortOption { get; set; }
        public Model.Doctor SelectedDoctor { get; set; }

        public SearchDoctors(DoctorController doctorController)
        {
            InitializeComponent();
            DataContext = this;

            _controller = doctorController;
            Doctors = new ObservableCollection<Model.Doctor>(_controller.GetAll());
        }
        private void SearchDoctor(object sender, TextChangedEventArgs e)
        {
            Doctors = new ObservableCollection<Model.Doctor>(_controller.GetAll()
                .Where(d => d.Specialization.ToString().Contains(doctorsTxt.Text) || 
                            d.FirstName.Contains(doctorsTxt.Text) ||
                            d.LastName.Contains(doctorsTxt.Text))
                .ToList());

            DataGrid dg = (DataGrid)FindName("DoctorDataGrid");
            dg.ItemsSource = Doctors;
        }
        private void OrderAnamnesis(object sender, SelectionChangedEventArgs e)
        {
            switch (SelectedSortOption)
            {
                case DoctorSortOption.FirstName:
                    Doctors = new ObservableCollection<Model.Doctor>(Doctors.OrderBy(d => d.FirstName).ToList());
                    break;
                case DoctorSortOption.LastName:
                    Doctors = new ObservableCollection<Model.Doctor>(Doctors.OrderBy(d => d.LastName).ToList());
                    break;
                case DoctorSortOption.Specialization:
                    Doctors = new ObservableCollection<Model.Doctor>(Doctors.OrderBy(d => d.Specialization).ToList());
                    break;
                case DoctorSortOption.Rating:
                    Doctors = new ObservableCollection<Model.Doctor>(Doctors.OrderByDescending(d => d.Rating).ToList());
                    break;
            }
            DataGrid dg = (DataGrid)FindName("DoctorDataGrid");
            dg.ItemsSource = Doctors;
        }

        private void ChooseDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedDoctor == null)
            {
                MessageBox.Show("Doctor not selected!");
            }
            MessageBox.Show("You selected: " + SelectedDoctor.ToString());
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

}
