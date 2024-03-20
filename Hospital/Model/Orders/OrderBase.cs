using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hospital.Model.Orders
{
    [JsonDerivedType(typeof(OrderBase), typeDiscriminator: "base")]
    [JsonDerivedType(typeof(OrderEquipment), typeDiscriminator: "equipment")]
    [JsonDerivedType(typeof(OrderMedicine), typeDiscriminator: "medicine")]
    public class OrderBase: INotifyPropertyChanged,IOrder
    {
        public int orderNumber { get; set; }
        private DateTime _arrivalDate;
        public DateTime ArrivalDate
        {
            get => _arrivalDate;
            set
            {
                if (value != _arrivalDate)
                {
                    _arrivalDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }


        public OrderBase() { }


        public OrderBase(DateTime arrivalDate, int quantity, string name)
        {
            this.Quantity = quantity;
            this.ArrivalDate = arrivalDate;
            this.Name = name;
        }

        public override string ToString()
        {
            return "";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void CompleteOrder(OrderBase order)
        {
            throw new Exception("Not Implemented");
        }
    }
}
