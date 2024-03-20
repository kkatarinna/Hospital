using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hospital.Serializer
{
    public interface ISerializer<T> where T : class
    {

        public List<T> GetFromFile(string fileName);


        public void WriteToFile(string fileName, List<T> _data);

    }
}
