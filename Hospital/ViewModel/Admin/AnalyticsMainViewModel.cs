using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Hospital.View.Admin.Pages.Analytics;

namespace Hospital.ViewModel.Admin
{
    public class AnalyticsMainViewModel
    {
        private ICommand showAnalyticsCommand;
        public ICommand ShowAnalyticsCommand
        {
            get
            {
                if (showAnalyticsCommand == null)
                {
                    showAnalyticsCommand = new RelayCommand(showExecute, CanExecute);
                }
                return showAnalyticsCommand;
            }
            set
            {
                showAnalyticsCommand = value;
            }
        }
        private void showExecute(object parameter)
        {
            AnalyticsHospitalView hospitalView = new AnalyticsHospitalView();
            if (parameter.ToString() == "Hospital")
            {
                AnalyticsHospitalViewModel viewModel=new AnalyticsHospitalViewModel();
                hospitalView.DataContext = viewModel;
            }
            else
            {
                AnalyticsDoctorViewModel viewModel=new AnalyticsDoctorViewModel();
                hospitalView.DataContext = viewModel;

            }

            hospitalView.Show();


        }
        private bool CanExecute(object parameter)
        {
            return true;
        }

        public AnalyticsMainViewModel()
        {
        }
    }
}
