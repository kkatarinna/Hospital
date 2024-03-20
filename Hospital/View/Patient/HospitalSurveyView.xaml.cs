﻿using Hospital.Controller;
using Hospital.ViewModel;
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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for HospitalSurvey.xaml
    /// </summary>
    public partial class HospitalSurveyView : Window
    {
        public HospitalSurveyView(HospitalSurveyController controller)
        {
            InitializeComponent();
            DataContext = new HospitalSurveyViewModel(controller);
        }
    }
}
