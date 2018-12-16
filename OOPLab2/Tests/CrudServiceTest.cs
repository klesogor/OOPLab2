using Moq;
using NUnit.Framework;
using OOPLab2.Entities;
using OOPLab2.Exceptions;
using OOPLab2.IO;
using OOPLab2.Services;
using OOPLab2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Tests
{
    public class CrudServiceTest
    {
        private IRepository<Animal> _repository;
        private ILogger _stub;
        private Animal _existingAnimal;
        private IAnimalCRUDService _service;

        [SetUp]
        public void SetUp()
        {
            _repository = new AnimalRepository();


            _stub = new Mock<ILogger>().Object;

            var giraffe = new Giraffe("Giraffe 1", 100.1f, _stub);
            _existingAnimal = giraffe;

            _service = new AnimalCRUDService(new AnimalFactoryRandomizer(_stub), _stub, _repository);
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public void TestAddAnimalSuccess()
        {
            var name = "Fake animal name";
            var weight = 150.9f;
            var animal = _service.GenerateRandomAnimal(name, weight);
            Assert.AreEqual(name, animal.Name);
            Assert.AreEqual(weight, animal.Weight);
        }

        [Test]
        public void TestAddAnimalIncorrectName()
        {
            var name = "Fake animal name";
            var weight = 150.9f;
            _service.GenerateRandomAnimal(name, weight);
            Assert.Throws<DuplicatedNameOrIdException>(() => _service.GenerateRandomAnimal(name, weight));
        }

        [Test]
        public void TestAddAnimalIncorrectWeight()
        {
            var name = "Fake animal name";
            var weight = 0f;
            Assert.Throws<ZeroOrNegativeAnimalWeightException>(() => _service.GenerateRandomAnimal(name, weight));
            weight = -1f;
            Assert.Throws<ZeroOrNegativeAnimalWeightException>(() => _service.GenerateRandomAnimal(name, weight));
        }
    }
}
