using System;
using System.Collections.Generic;
using System.Linq;

namespace luggage_app.back_end
{
    interface ILuggageContainer
    {
        void Add(Luggage luggage);
        void Update(int id, Luggage luggage);
        void Remove(int id);
        int GetPassengerAmountWithMaxItemsAmount();
        List<(int, Luggage)> GetLuggageWhereAverageWeightInRange(double delta);
    }
    
    public class LuggageContainer : ILuggageContainer
    {
        private int _maxItemsAmount;
        private double _maxWeight;
        private int _currentIndex;
        readonly Dictionary<int, Luggage> _luggageContainer;

        public LuggageContainer()
        {
            _maxItemsAmount = 5;
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
        
        public int MaxItemsAmount
        {
            set
            {
                if (value > 0) _maxItemsAmount = value;
                else throw new LuggageException("Максимальное количество вещей должно быть больше нуля");
            }
            get => _maxItemsAmount;
        }

        private int ItemsAmount
        {
            get
            {
                if (_luggageContainer.Count != 0)
                {
                    return _luggageContainer
                        .Select(pair => pair.Value.ItemsAmount)
                        .Aggregate(0, (acc, amount) => acc + amount);
                }
                return 0;
            }
        }

        public double AverageItemWeight
        {
            get
            {
                if (_luggageContainer.Count != 0)
                {
                    return _luggageContainer
                        .Select(pair => pair.Value.Weight)
                        .Aggregate(0.0, (acc, weight) => acc + weight) / ItemsAmount;
                }
                return 0;
            }
        }

        public List<(int, Luggage)> LuggageList
        {
            get
            {
                return _luggageContainer
                    .Select(pair => (pair.Key, pair.Value)).ToList();
            }
        }
        
        public List<(int, Luggage)> LuggageWithOverWeight
        {
            get
            {
                return LuggageList.FindAll(pair => pair.Item2.Weight > MaxWeight);
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
        
        public void RemoveOverWeight()
        {
            foreach (var pair in LuggageWithOverWeight)
            {
                Remove(pair.Item1);
            }
        }

        public int GetPassengerAmountWithMaxItemsAmount()
        {
            var userItemsMap = new Dictionary<String, int>();
            foreach (var pair in _luggageContainer)
            {
                var surname = pair.Value.PassengerSurname;
                if (userItemsMap.ContainsKey(surname))
                {
                    userItemsMap[surname] = userItemsMap[surname] + pair.Value.ItemsAmount;
                }
                else
                {
                    userItemsMap[surname] = pair.Value.ItemsAmount;
                }
            }

            return userItemsMap
                .Select(pair => pair.Value)
                .Count(amount => amount > MaxItemsAmount);
        }

        public List<(int, Luggage)> GetLuggageWhereAverageWeightInRange(double delta)
        {
            return _luggageContainer.Where(pair => 
            {
                var averageWeight = pair.Value.AverageItemWeight;
                if (averageWeight > AverageItemWeight)
                    return averageWeight - delta <= AverageItemWeight;
                if (averageWeight < AverageItemWeight)  
                    return averageWeight + delta >= AverageItemWeight;
                return true;
            }).Select(pair => (pair.Key, pair.Value)).ToList();
        }
    }
}