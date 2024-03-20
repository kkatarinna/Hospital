using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.Service;
using Hospital.View.Admin.Pages.Request;
using Hospital.View.Admin.Pages.UserControls;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdminMain : Window
    {

        private EquipmentController _controllerEquipment;
        private RoomController _controllerRoom;
        private OrderController _controllerOrder;
        private ReorganizationController _controllerReorganization;
        private RenovationController _controllerRenovation;
        private List<StartupNotification> _startupNotifications;

        public AdminMain()
        {
            InitializeComponent();
            _controllerEquipment = new EquipmentController();
            _controllerRoom = new RoomController();
            _controllerOrder = new OrderController();
            _controllerReorganization = new ReorganizationController();
            _controllerRenovation = new RenovationController();
            checkDueTasks();
           

            FilterControl filterTab = new FilterControl(_controllerEquipment,_controllerRoom);
            OrderControl orderTab = new OrderControl(_controllerEquipment,_controllerRoom,_controllerOrder);
            ReorganizationControl reorganizationTab = new ReorganizationControl(_controllerRoom,_controllerEquipment, _controllerReorganization);
            RenovationControl renovationControl = new RenovationControl(_controllerRoom, _controllerRenovation);
            RequestView requestView = new RequestView();
            RequestViewModel vm= new RequestViewModel();
            requestView.DataContext= vm;


            this.FilterTab.Content= filterTab;
            this.OrderTab.Content= orderTab;
            this.ReorganizeTab.Content= reorganizationTab;
            this.RenovationTab.Content= renovationControl;
            this.RequestsTab.Content = requestView;


        }

        void checkDueTasks()
        {
            ShowError(_controllerOrder.CheckOrders());

            ShowError(_controllerReorganization.CheckReorganizations());

            ShowError( _controllerRenovation.CheckRenovations());

        }

        void ShowError(string errMessage)
        {
            if (errMessage != "") {

                MessageBox.Show(errMessage);

            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
