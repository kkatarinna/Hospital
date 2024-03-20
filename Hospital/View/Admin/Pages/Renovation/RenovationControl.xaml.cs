using Hospital.View.Admin.Pages.DialogBox;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.View.Admin.Pages.DialogBox;
using Hospital.Controller;

namespace Hospital.View.Admin.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for RenovationControl.xaml
    /// </summary>
    public partial class RenovationControl : UserControl
    {
        RoomController _controllerRoom;

        RenovationController _controllerRenovation;
        public RenovationControl(RoomController controllerRoom, RenovationController controllerRenovation)
        {
            _controllerRoom = controllerRoom;
            _controllerRenovation = controllerRenovation;


            InitializeComponent();
        }

        private void complexRadio_Checked(object sender, RoutedEventArgs e)
        {
            this.complexPanel.Visibility = Visibility.Visible;
        }

        private void simpleRadio_Checked(object sender, RoutedEventArgs e)
        {
            this.complexPanel.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.complexRadio.IsChecked == true)
            {
                if (this.joinRadio.IsChecked == true)
                {
                    JoinRenovationForm joinDialog = new JoinRenovationForm(_controllerRoom,_controllerRenovation);
                    joinDialog.ShowDialog();

                }
                else
                {
                    SeparateRenovationForm separateDialog = new SeparateRenovationForm(_controllerRoom,_controllerRenovation);
                    separateDialog.ShowDialog();
                }
            }
            else
            {
                SimpleRenovationForm simpleDialog = new SimpleRenovationForm(_controllerRoom,_controllerRenovation);
                simpleDialog.ShowDialog();
            }
        }
    }
}
