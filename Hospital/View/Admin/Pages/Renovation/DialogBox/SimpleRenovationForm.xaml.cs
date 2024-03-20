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
using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.Enum;
using Hospital.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital.View.Admin.Pages.DialogBox
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    
    public partial class SimpleRenovationForm : Window
    {
        RoomController _controllerRoom;

        RenovationController _controllerRenovation;
        public List<Room> roomChoices { get; set; }
        public SimpleRenovationForm(RoomController roomController, RenovationController controllerRenovation)
        {
            _controllerRoom = roomController;
            _controllerRenovation = controllerRenovation;

            InitializeComponent();

            roomChoices = _controllerRoom.GetAll();

            DataContext = this;
            
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            if (!checkFields()) return;

            string err = FormRenovation();

            if (err != "")
            {
                MessageBox.Show(err);
                return;
            }

            this.Close();

        }

        string FormRenovation()
        {
            List<string> underRenovation = new List<string>();
            List<string> renovated = new List<string>();
            List<RoomPurpose> renovatedPurposes = new List<RoomPurpose>();

            string roomName= this.cbMainRoom.SelectedItem.ToString();

            underRenovation.Add(roomName);

            renovated.Add(roomName);
            
            renovatedPurposes.Add(_controllerRoom.GetRoomByNumber(roomName).purpose);

            DateTime begin = (DateTime)this.dpBegin.SelectedDate;
            DateTime end = (DateTime)this.dpEnd.SelectedDate;

            string err = _controllerRenovation.Create(underRenovation, renovated, renovatedPurposes, begin, end);

            return err;
        }

        bool checkFields()
        {

            if (this.cbMainRoom.SelectedItem == null)
            {
                MessageBox.Show("You must select a main room!");
                return false;
            }

            return checkDates();

        }

        bool checkDates()
        {
            DateTime begin= (DateTime)this.dpBegin.SelectedDate;
            DateTime end= (DateTime)this.dpEnd.SelectedDate;

            if (begin == null)
            {
                MessageBox.Show("You must select a start date!");
                return false;
            }

            if (end == null)
            {
                MessageBox.Show("You must select an end date!");
                return false;
            }

            if (DateUtils.IsDateRangeValid(begin,end))
            {
                MessageBox.Show("Date range isnt valid!");
                return false;
            }

            return true;

        }
    }

   
}
    