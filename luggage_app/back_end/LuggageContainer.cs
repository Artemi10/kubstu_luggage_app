using System.Collections.Generic;
using System.Linq;

namespace luggage_app.back_end
{
    public class LuggageContainer : ILuggageContainer
    {
        private double _maxWeight;
        private int _currentIndex;
        readonly Dictionary<int, Luggage> _luggageContainer;

        public LuggageContainer()
        {
            _maxWeight = 15.0;
            _luggageContainer = new Dictionary<int, Luggage>();
        }

        public double MaxWeight
        {
            set
            {
                if (value > 0) _maxWeight = value;
                else throw new LuggageException("Максимальный вес багажа должен быть больше нуля");
            }
            get => _maxWeight;
        }

        public List<(int, Luggage)> LuggageList
        {
            get
            {
                return _luggageContainer
                    .Select(pair => (pair.Key, pair.Value)).ToList();
            }
        }

        public void Add(Luggage luggage)
        {
            if (luggage.IsValid())
            {
                _luggageContainer[_currentIndex] = luggage;
                _currentIndex++;
            }
            else throw new LuggageException("Данные введены неверно");
        }

        public void Update(int id, Luggage luggage)
        {
            var luggageToUpdate = _luggageContainer[id];
            if (luggageToUpdate != null)
            {
                luggageToUpdate.PassengerSurname = luggage.PassengerSurname;
                luggageToUpdate.Code = luggage.Code;
                luggageToUpdate.ItemsAmount = luggage.ItemsAmount;
                luggageToUpdate.Weight = luggage.Weight;
            }
            else throw new LuggageException($"Багаж с id={id} не найден");
        }

        public void Remove(int id)
        {
            if (_luggageContainer.ContainsKey(id))
            {
                _luggageContainer.Remove(id);
            }
            else throw new LuggageException($"Багаж с id={id} не найден");
        }
    }

    interface ILuggageContainer
    {
        void Add(Luggage luggage);
        void Update(int id, Luggage luggage);
        void Remove(int id);
    }
}