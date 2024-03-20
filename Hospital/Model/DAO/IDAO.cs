using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.DAO
{
    interface IDAO<T>
    {
        public void Add(T obj);
        public void Remove(T obj);
        public void Update(T obj);
        public void Save();
        public List<T> GetAll();
    }
}
