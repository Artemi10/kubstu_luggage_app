
using System;

namespace luggage_app.back_end
{
    public class Luggage : ICloneable 
    {
        private string _passengerSurname;
        private string _code;
        private double _weight;
        private int _itemsAmount;
     
        public Luggage(string passengerSurname, string code, int itemsAmount, double weight)
        { 
            _passengerSurname = passengerSurname;
            _code = code;
            _itemsAmount = itemsAmount;
            _weight = weight;
        }
        
        public double AverageItemWeight
        {
            get
            {
                if (_itemsAmount != 0)
                {
                    return _weight / _itemsAmount;
                }
                return 0;
            }
        }

        public string PassengerSurname 
        { 
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _passengerSurname = value;
                else throw new LuggageException("Имя пользователя не может быть пустым");
            }
            get => _passengerSurname;
        }
        
        public double Weight 
        { 
            set 
            { 
                if (value > 0.0) _weight = value;
                else throw new LuggageException("Вес багажа должен быть положительным");
            }
            get => _weight;
        }

        public string Code
        {
            set => _code = value;
            get => _code;
        }

        public int ItemsAmount
        {
            set
            {
                if (value > 0) _itemsAmount = value;
                else throw new LuggageException("Количество вещей должно быть больше нуля");
            }
            get => _itemsAmount;
        }

        public bool IsValid => 
            !string.IsNullOrEmpty(_passengerSurname) 
            && _weight > 0.0 && _itemsAmount > 0;

        protected bool Equals(Luggage other)
        {
            return _passengerSurname == other._passengerSurname && _code == other._code && _weight.Equals(other._weight) && _itemsAmount == other._itemsAmount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Luggage) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_passengerSurname, _code, _weight, _itemsAmount);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

    