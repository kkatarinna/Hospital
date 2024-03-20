using Hospital.Controller;
using Hospital.Model;
using Hospital.Model.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for OrderMedicine.xaml
    /// </summary>
    public partial class OrderMedicineView : Window
    {
        private TherapyController _therapyController;
        private OrderController _orderController;
        private List<Medicine> _medicines;

        public List<int> Quantities = new List<int>();

        public ObservableCollection<Medicine> Medicines { get; set; }
        public OrderMedicineView()
        {
            InitializeComponent();
            DataContext = this;
            _therapyController = new TherapyController();
            _orderController = new OrderController();
            _medicines = _therapyController.GetAllMedcicines();
            Medicines = new ObservableCollection<Medicine>(_medicines);
            Quantities = new List<int>(new int[_medicines.Count()]);
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Change value of text to int
            if (int.TryParse(((TextBox)sender).Text, out int value))
            {
                // get index of textbox
                int index = OrderDataGrid.Items.IndexOf(((TextBox)sender).DataContext);

                // update value in list
                Quantities[index] = value;
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i< Quantities.Count();i++)
            {
                if(Quantities[i] != 0)
                {
                    _orderController.Create(
                        new OrderMedicine(DateTime.Now.AddDays(1), Quantities[i], Medicines[i].Name, Medicines[i].Id));
                }
            }
            Close();
            return;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
