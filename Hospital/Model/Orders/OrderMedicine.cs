using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital.Model.Orders
{
    public class OrderMedicine : OrderBase
    {
        public int MedicineId { get; set; }
        public OrderMedicine() { }
        public OrderMedicine(DateTime arrivalDate, int quantity, string name,int medicineId) :base(arrivalDate,quantity,name)
        {
            MedicineId = medicineId;
        }

        public override void CompleteOrder(OrderBase order)
        {
            OrderMedicine orderMedicine = (OrderMedicine)order;
            MedicineDAO _medicineDAO = MedicineDAO.Instance;
            Medicine medicine = _medicineDAO.GetMedicine(orderMedicine.MedicineId);
            medicine.BoxQuantity += order.Quantity;
            _medicineDAO.Update();
        }
    }
}
