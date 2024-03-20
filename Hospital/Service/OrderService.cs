using Hospital.Model.DAO;
using Hospital.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Service
{
    public class OrderService
    {
        private OrderBaseDAO _orderDAO;
      
        public OrderService() {
            _orderDAO = OrderBaseDAO.Instance;
        }


        public string CheckOrders() {
            
            List<OrderBase> orders = _orderDAO.GetAll();
            List<OrderBase> ordersDone = new List<OrderBase>();
            string error = "";

            foreach (OrderBase order in orders)
            {
                if(order.ArrivalDate.Date<=DateTime.Now.Date) {
                    try {
                        ((IOrder)order).CompleteOrder(order);
                        ordersDone.Add(order);
                    }
                    catch (Exception e)
                    {
                        error += e.Message + "\n";
                    }
                }
            }

            foreach (OrderBase order in ordersDone)
            {
                _orderDAO.Remove(order);
            }

            return error;
        }
    }
}
