using luggage_app.back_end;
using NUnit.Framework;

namespace luggage_app.test.back_end
{
    public class LuggageTest
    {
        private Luggage _luggage;
        private Luggage _emptyLuggage;
        private Luggage _unknownLuggage;
        private Luggage _emptyItemsLuggage;
        private Luggage _emptyWeightLuggage;

        [SetUp]
        public void SetUp()
        {
            _luggage = new Luggage("Иванов", "qwerty54", 44, 91.5);
            _emptyLuggage = new Luggage("Иванов", "qwerty54", 0, 0);
            _unknownLuggage = new Luggage("", "qwerty54", 44, 91.5);
            _emptyItemsLuggage = new Luggage("Иванов", "qwerty54", 0, 91.5);
            _emptyWeightLuggage = new Luggage("Иванов", "qwerty54", 44, 0);
        }

        [Test]
        public void AverageItemWeightTest()
        {
            Assert.That(_luggage.AverageItemWeight, Is.EqualTo(2.08).Within(0.01));
            Assert.AreEqual(0, _emptyLuggage.AverageItemWeight);
            Assert.AreEqual(0, _emptyItemsLuggage.AverageItemWeight);
            Assert.AreEqual(0, _emptyWeightLuggage.AverageItemWeight);
        }

        [Test]
        public void SetPassengerSurnameTest()
        {
            _luggage.PassengerSurname = "Петров";
            Assert.AreEqual("Петров", _luggage.PassengerSurname);
        }
        
        [Test]
        public void Throw_LuggageException_When_Surname_Is_Null()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggage.PassengerSurname = null);
            Assert.AreEqual("Имя пользователя не может быть пустым", exception.Message);
        }
        
        [Test]
        public void Throw_LuggageException_When_Surname_Is_Empty()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggage.PassengerSurname = "");
            Assert.AreEqual("Имя пользователя не может быть пустым", exception.Message);
            exception = Assert.Throws<LuggageException>(() => _luggage.PassengerSurname = "    ");
            Assert.AreEqual("Имя пользователя не может быть пустым", exception.Message);
        }
        
        [Test]
        public void SetWeightTest()
        {
            _luggage.Weight = 98.5;
            Assert.AreEqual(98.5, _luggage.Weight);
        }
        
        [Test]
        public void Throw_LuggageException_When_Weight_Is_Zero()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggage.Weight = 0);
            Assert.AreEqual("Вес багажа должен быть положительным", exception.Message);
        }
        
        [Test]
        public void Throw_LuggageException_When_Weight_Is_Negative()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggage.Weight = -8.7);
            Assert.AreEqual("Вес багажа должен быть положительным", exception.Message);
        }
        
        [Test]
        public void SetCodeTest()
        {
            _luggage.Code = "qwerty";
            Assert.AreEqual("qwerty", _luggage.Code);
        }
        
        [Test]
        public void SetItemsAmount()
        {
            _luggage.ItemsAmount = 44;
            Assert.AreEqual(44, _luggage.ItemsAmount);
        }
        
        [Test]
        public void Throw_LuggageException_When_ItemsAmount_Is_Zero()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggage.ItemsAmount = 0);
            Assert.AreEqual("Количество вещей должно быть больше нуля", exception.Message);
        }
        
        [Test]
        public void Throw_LuggageException_When_ItemsAmount_Is_Negative()
        {
            var exception = Assert.Throws<LuggageException>(() => _luggage.ItemsAmount = -8);
            Assert.AreEqual("Количество вещей должно быть больше нуля", exception.Message);
        }

        [Test]
        public void IsValidTest()
        {
            Assert.True(_luggage.IsValid);
            Assert.False(_emptyLuggage.IsValid);
            Assert.False(_unknownLuggage.IsValid);
            Assert.False(_emptyItemsLuggage.IsValid);
            Assert.False(_emptyWeightLuggage.IsValid);
        }

        [Test]
        public void CloneTest()
        {
            var cloned = _luggage.Clone();
            Assert.AreEqual(cloned, _luggage);
            Assert.AreNotSame(cloned, _luggage);
        }
    }
}