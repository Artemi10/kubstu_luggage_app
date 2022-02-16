using System.Collections.Generic;
using System.Linq;
using luggage_app.back_end;
using NUnit.Framework;

namespace luggage_app.test.back_end
{
    public class LuggageContainerTest
    {
        private Dictionary<int, Luggage> _initialData;
        private LuggageContainer _luggageContainer;
        private LuggageContainer _emptyLuggageContainer;

        private Dictionary<int, Luggage> InitDictionary()
        {
            return new()
            {
                [0] = new Luggage("Иванов", "qwerty1", 23, 89.0), //
                [1] = new Luggage("Петров", "qwerty2", 2, 4.2),
                [2] = new Luggage("Петров", "qwerty3", 9, 8.4),
                [3] = new Luggage("Кисляков", "qwerty4", 5, 9.7), //
                [4] = new Luggage("Иванов", "qwerty5", 9, 9.2),
                [5] = new Luggage("Богданов", "qwerty6", 15, 7.5) //
            };
        }

        [SetUp]
        public void SetUp()
        {
            _initialData = InitDictionary();
            _luggageContainer = new LuggageContainer(_initialData);
            _emptyLuggageContainer = new LuggageContainer();
        }

        [Test]
        public void DataDeepCloneTest()
        {
            foreach (var (id, luggage) in _luggageContainer.Data)
            {
                var expected = _initialData[id];
                Assert.AreEqual(expected, luggage);
                Assert.AreNotSame(expected, luggage);
            }
        }

        [Test]
        public void SetMaxWeightTest()
        {
            Assert.AreEqual(15.0, _luggageContainer.MaxWeight);
            _luggageContainer.MaxWeight = 10.0;
            Assert.AreEqual(10.0, _luggageContainer.MaxWeight);
        }

        [Test]
        public void Throw_Exception_When_MaxWeight_Is_Zero()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggageContainer.MaxWeight = 0);
            Assert.AreEqual("Максимальный вес багажа должен быть больше нуля", exception.Message);
        }
        
        [Test]
        public void Throw_Exception_When_MaxWeight_Is_Negative()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggageContainer.MaxWeight = -9.3);
            Assert.AreEqual("Максимальный вес багажа должен быть больше нуля", exception.Message);
        }

        [Test]
        public void GetItemsAmountTest()
        {
            Assert.AreEqual(63, _luggageContainer.ItemsAmount);
            Assert.AreEqual(0, _emptyLuggageContainer.ItemsAmount);
        }
        
        [Test]
        public void GetAverageItemWeightTest()
        {
            Assert.That(_luggageContainer.AverageItemWeight, Is.EqualTo(2.03).Within(0.01));
            Assert.AreEqual(0, _emptyLuggageContainer.AverageItemWeight);
        }
        
        [Test]
        public void GetLuggageListTest()
        {
            var luggageList = _luggageContainer.LuggageList;
            foreach (var (id, luggage) in luggageList)
            {
                var expected = _initialData[id];
                Assert.AreEqual(expected, luggage);
                Assert.AreNotSame(expected, luggage);
            }
            Assert.AreEqual(_initialData.Count, luggageList.Count);
        }

        [Test]
        public void ValidLuggageAddTest()
        {
            var luggageToAdd = new Luggage("Иванов", "qwerty5", 10, 7.2);
            _luggageContainer.Add(luggageToAdd);
            var luggageList = _luggageContainer.LuggageList
                .Select(pair => pair.Item2).ToList();
            Assert.True(luggageList.Contains(luggageToAdd));
        }
        
        [Test]
        public void Throw_Exception_When_Add_Invalid_Luggage()
        {
            var invalidLuggage = new Luggage("", "qwerty5", 0, -9.2);
            var exception = Assert.Throws<LuggageException>(() => _luggageContainer.Add(invalidLuggage));
            Assert.AreEqual("Данные введены неверно", exception.Message);
        }
        
        [Test]
        public void ValidLuggageUpdateTest()
        {
            var luggage = new Luggage("Иванова", "qwerty0", 10, 7.2);
            _luggageContainer.Update(0, luggage);
            Assert.True(_luggageContainer.LuggageList.Contains((0, luggage)));
        }
        
        [Test]
        public void Throw_Exception_When_Update_Invalid_Luggage()
        {
            var invalidLuggage = new Luggage("", "qwerty5", 0, -9.2);
            Assert.Throws<LuggageException>(() => _luggageContainer.Update(0, invalidLuggage));
        }
        
        [Test]
        public void Throw_Exception_When_Update_Nonexistent_Luggage()
        {
            var luggage = new Luggage("Иванова", "qwerty0", 10, 7.2);
            var exception = Assert.Throws<LuggageException>(() => _luggageContainer.Update(54, luggage));
            Assert.AreEqual("Багаж с id=54 не найден", exception.Message);
        }
        
        [Test]
        public void LuggageRemoveTest()
        {
            var luggage = new Luggage("Иванов", "qwerty1", 23, 89.0);
            _luggageContainer.Remove(0);
            Assert.False(_luggageContainer.LuggageList.Contains((0, luggage)));
        }
        
        [Test]
        public void Throw_Exception_When_Remove_Nonexistent_Luggage()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggageContainer.Remove(54));
            Assert.AreEqual("Багаж с id=54 не найден", exception.Message);
        }

        [Test]
        public void RemoveOverWeightTest()
        {
            _luggageContainer.RemoveOverWeight();
            var data = _luggageContainer.Data;
            Assert.True(data.ContainsKey(1));
            Assert.True(data.ContainsKey(2));
            Assert.True(data.ContainsKey(3));
            Assert.True(data.ContainsKey(4));
            Assert.True(data.ContainsKey(5));
            Assert.False(data.ContainsKey(0));
        }

        [Test]
        public void GetPassengerAmountWithMaxItemsAmountTest()
        {
            Assert.AreEqual(3, _luggageContainer.GetPassengerAmountWithMaxItemsAmount());
            _luggageContainer.Remove(5);
            Assert.AreEqual(2, _luggageContainer.GetPassengerAmountWithMaxItemsAmount());
        }
        
        [Test]
        public void GetLuggageWhereAverageWeightInRangeTest()
        {
            var result = _luggageContainer.GetLuggageWhereAverageWeightInRange(1.5);
            Assert.False(result.Contains((0, _initialData[0])));
            Assert.False(result.Contains((5, _initialData[5])));
            Assert.True(result.Contains((1, _initialData[1])));
            Assert.True(result.Contains((2, _initialData[2])));
            Assert.True(result.Contains((3, _initialData[3])));
            Assert.True(result.Contains((4, _initialData[4])));
        }
    }
}