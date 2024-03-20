using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Medicine : INotifyPropertyChanged
    {
        public int Id { get; set; }

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

        private int _boxQuantity;
        public int BoxQuantity
        {
            get => _boxQuantity;
            set
            {
                if (value != _boxQuantity)
                {
                    _boxQuantity = value;
                    OnPropertyChanged();
                }
            }
        }

        private string[] _components;
        public string[] Components
        {
            get => _components;
            set
            {
                if (value != _components)
                {
                    _components = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
