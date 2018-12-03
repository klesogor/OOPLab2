using Moq;
using NUnit.Framework;
using OOPLab2.Entities;
using OOPLab2.IO;
using OOPLab2.Services;
using OOPLab2.Services.Strategies;
using OOPLab2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Tests
{
    public class VoiceServiceTest
    {
        public class CrudServiceTest
        {
            private IRepository<Animal> _repository;
            private ILogger _stub;
            private Animal _existingAnimal;
            private Animal _existingAnimal2;
            private Animal _bear1;
            private Mock<ILogger> _mock;
            private IZooVoiceService _service;
            private StrategyFactory _factory;
            private int _callCount;

            [SetUp]
            public void SetUp()
            {
                _repository = AnimalRepository.GetInstance();

                _callCount = 0;
                _mock = new Mock<ILogger>();
                _mock.Setup(m => m.Log(It.IsAny<string>())).Callback(() => _callCount += 1);
                _stub = _mock.Object;//empty mock, no logic

                _existingAnimal = new Giraffe("Giraffe 1", 100.0f, _stub);
                _existingAnimal2 = new Giraffe("Giraffe 2", 50.0f, _stub);
                _bear1 = new Bear("Bear 1", 150.0f, _stub);

                _repository.AddItem(_existingAnimal);
                _repository.AddItem(_existingAnimal2);
                _repository.AddItem(_bear1);

                _factory = new StrategyFactory(_stub);

                _service = new ZooVoiceService(_factory.CreateDayStrategy());
            }

            [TearDown]
            public void TearDown()
            {
                _repository.ClearRepository();
            }

            [Test]
            public void TestAllSayDay()
            {
                _service.AllZooMakeSound();
                Assert.AreEqual(3, _callCount);
            }

            [Test]
            public void TestNameSayDay()
            {
                _service.MakeSoundByAnimal(_bear1.Name);
                Assert.AreEqual(1, _callCount);
            }

            [Test]
            public void TestNameSayNight()
            {
                _service.VoiceStrategy = _factory.CreateNightStrategy();
                _service.MakeSoundByAnimal(_bear1.Name);
                Assert.AreEqual(1, _callCount);//message from animal + time change notification
            }

            [Test]
            public void TestNameSayNights()
            {
                _service.VoiceStrategy = _factory.CreateNightStrategy();
                _service.AllZooMakeSound();
                Assert.AreEqual(1, _callCount);// notificate that no one will make sound
            }
        }
    }
}
