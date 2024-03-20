using Hospital.Model;
using Hospital.Model.Service;
using Hospital.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Hospital.Model.Orders;

namespace Hospital.Controller
{
    public class OrderController
    {
        private OrderBaseDAO _orderItemDAO;
        private OrderService _orderService;



        public OrderController()
        {
            _orderItemDAO = OrderBaseDAO.Instance;
            _orderService = new OrderService();
        }

        public string CheckOrders()
        {
            return _orderService.CheckOrders();
        }

        public void Create(OrderBase order)
        {
            _orderItemDAO.Add(order);
        }

        public OrderBaseDAO GetDAO()
        {
           return _orderItemDAO;
        }
    }


  
}
