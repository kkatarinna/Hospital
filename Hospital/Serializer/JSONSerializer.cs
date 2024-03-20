using System.Collections.Generic;
using System.IO;

using System;
using System.Text;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Hospital.Model;
using Hospital.Model.DAO;
using System.Text.Json.Serialization;

namespace Hospital.Serializer
{
    class JSONSerializer<T>:ISerializer<T> where T : class
    {

        DateTimeConverter dateTimeConverter=new DateTimeConverter("dd-MM-yyyyTHH:mm:ss");
        public List<T> GetFromFile(string fileName)
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            options.Converters.Add(dateTimeConverter);
            string jsonData = File.ReadAllText(fileName);
            return System.Text.Json.JsonSerializer.Deserialize<List<T>>(jsonData, options);
        }

        public void WriteToFile(string fileName, List<T> _data)
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            options.Converters.Add(dateTimeConverter);
            string json = System.Text.Json.JsonSerializer.Serialize(_data, options);
            File.WriteAllText(fileName, json);
        }

    }

}
