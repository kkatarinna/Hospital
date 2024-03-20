using Hospital.Model.Orders;
using Hospital.Model.Refferals;
using Hospital.Serializer;
using Hospital.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO
{
    public class OrderBaseDAO
    {

        public List<OrderBase> orders;

        private OrderStorage _storage;

        private static OrderBaseDAO instance = null;
        public static OrderBaseDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderBaseDAO();
                }
                return instance;
            }
        }

        private OrderBaseDAO()
        {
            _storage = new OrderStorage(new JSONSerializer<OrderBase>());
            orders = _storage.Load();

        }

        public List<OrderBase> GetOrderByType(Type type)
        {
            List<OrderBase> typeOrders = new List<OrderBase>();
            foreach(OrderBase order in orders)
            {
                if(order.GetType() == type)
                {
                    typeOrders.Add(order);
                }
            }
            return typeOrders;
        }
        public int NextId()
        {
            if (orders.Count() == 0)
                return 1;
            return orders.Max(s => s.orderNumber) + 1;
        }

        public List<OrderBase> GetAll()
        {
            return orders;
        }

        public void Add(OrderBase order)
        {
            order.orderNumber = NextId();
            orders.Add(order);
            _storage.Save(orders);
        }

        public void Remove(OrderBase order)
        {
            orders.Remove(order);
            _storage.Save(orders);
        }
    }
}
