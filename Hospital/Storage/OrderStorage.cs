using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Serializer;
using Hospital.Model;
using Hospital.Model.Orders;

namespace Hospital.Storage
{
    class OrderStorage
    {

        private const string StoragePath = "../../../../Hospital/Data/orders.json";

        private ISerializer<OrderBase> _serializer;


        public OrderStorage(ISerializer<OrderBase> serializer)
        {
            _serializer = serializer;
        }

        public List<OrderBase> Load()
        {

            return _serializer.GetFromFile(StoragePath);
        }

        public void Save(List<OrderBase>orders)
        {
            _serializer.WriteToFile(StoragePath, orders);
        }


    }
}
