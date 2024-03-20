using Hospital.Model.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class ServiceCollection
    {
        public static Dictionary<Type, object> services = new Dictionary<Type, object>();
        public static void AddService(Type type, object service)
        {
            services.Add(type, service);
        }
        public static T GetService<T>()
        {
            return (T)services[typeof(T)];
        }

        public ServiceCollection()
        {
            PopulateDictionary();
        }

        void PopulateDictionary()
        {
            Equipment rs = new Equipment();
            AddService(typeof(Equipment),rs);
        }

    }
}
