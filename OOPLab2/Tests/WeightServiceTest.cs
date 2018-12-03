using Moq;
using NUnit.Framework;
using OOPLab2.Entities;
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
    class WeightServiceTest
    {
        public class CrudServiceTest
        {
            private IRepository<Animal> _repository;
            private ILogger _stub;
            private Animal _existingAnimal;
            private Animal _existingAnimal2;
            private Animal _bear1;
            private IWeightService _service;

            [SetUp]
            public void SetUp()
            {
                _repository = AnimalRepository.GetInstance();

                _stub = new Mock<ILogger>().Object;//empty mock, no logic

                _existingAnimal = new Giraffe("Giraffe 1", 100.0f, _stub);
                _existingAnimal2 = new Giraffe("Giraffe 2", 50.0f, _stub);
                _bear1 = new Bear("Bear 1", 150.0f, _stub);

                _repository.AddItem(_existingAnimal);
                _repository.AddItem(_existingAnimal2);
                _repository.AddItem(_bear1);

                _service = new WeightService(_stub);
            }

            [TearDown]
            public void TearDown()
            {
                _repository.ClearRepository();
            }

            [Test]
            public void TestGetTotalAverage()
            {
                var weight = (
                    _bear1.Weight + 
                    _existingAnimal.Weight + 
                    _existingAnimal2.Weight
                    ) / 3;
                Assert.AreEqual(weight, _service.AvgWeight());
            }
            [Test]
            public void TestBearAverage()
            {
                Assert.AreEqual(
                    _bear1.Weight, 
                    _service.AvgWeightByAnimalType(typeof(Bear))
                   );
            }
            [Test]
            public void TestEmptyAverage()
            {
                Assert.AreEqual(
                  0f,
                   _service.AvgWeightByAnimalType(typeof(Wolf))
                  );
            }
        }
    }
}
