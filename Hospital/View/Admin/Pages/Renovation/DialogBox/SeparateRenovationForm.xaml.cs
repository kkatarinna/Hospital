using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.Enum;
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

namespace Hospital.View.Admin.Pages.DialogBox
{
    /// <summary>
    /// Interaction logic for ComplesSeparateRenovationForm.xaml
    /// </summary>
    public partial class SeparateRenovationForm : Window
    {
        public List<Room> roomChoices { get; set; }
        public List<RoomPurpose> roomPurposeChoices { get; set; }
        RoomController _controllerRoom { get; set; }
        RenovationController _controllerRenovation { get; set; }
        public SeparateRenovationForm(RoomController roomController, RenovationController renovationController)
        {
            _controllerRoom = roomController;
            _controllerRenovation = renovationController;

            InitializeComponent();

            roomChoices = _controllerRoom.GetAll();
            roomPurposeChoices = Enum.GetValues(typeof(RoomPurpose)).Cast<RoomPurpose>().ToList();

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

            underRenovation.Add(this.cbMainRoom.SelectedItem.ToString());

            renovatedPurposes.Add((RoomPurpose)this.cbFirstPurpose.SelectedItem);
            renovatedPurposes.Add((RoomPurpose)this.cbSecondPurpose.SelectedItem);

            renovated.Add(this.tbFirstName.Text);
            renovated.Add(this.tbSecondName.Text);

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

            

            if (this.cbFirstPurpose.SelectedItem == null || this.cbSecondPurpose.SelectedItem == null)
            {
                MessageBox.Show("You must select a room purpose!");
                return false;
            }

            if (this.tbFirstName.Text == "" || this.tbSecondName.Text == "")
            {
                MessageBox.Show("You must enter new room names!");
                return false;
            }

            if (this.tbFirstName.Text == this.tbSecondName.Text)
            {
                MessageBox.Show("You must enter different new room names!");
                return false;
            }



            return checkDates();

        }

        bool checkDates()
        {

            if (this.dpBegin.SelectedDate == null)
            {
                MessageBox.Show("You must select a start date!");
                return false;
            }

            if (this.dpEnd.SelectedDate == null)
            {
                MessageBox.Show("You must select an end date!");
                return false;
            }

            if (this.dpBegin.SelectedDate > this.dpEnd.SelectedDate)
            {
                MessageBox.Show("Start date must be before end date!");
                return false;
            }

            if (this.dpBegin.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("You must select a time period in the future!");
                return false;
            }

            return true;

        }
    }
}
