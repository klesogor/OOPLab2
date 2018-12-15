using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using OOPLab2.Entities;
using OOPLab2.Exceptions;
using OOPLab2.IO;
using OOPLab2.Storage;
using OOPLab2.Storage.Specifications;

namespace OOPLab2.Tests
{
    public class RepositoryTest
    {
        private IRepository<Animal> _repository;
        private ILogger _stub;
        private Animal _existingAnimal;

        [SetUp]
        public void SetUp()
        {
            _repository = new AnimalRepository();

            _stub = new Mock<ILogger>().Object;//empty mock, no logic

            var giraffe = new Giraffe("Giraffe 1", 100.1f, _stub);
            var bear = new Bear("Bear 1", 200.5f, _stub);
            var wolf = new Wolf("Wolf 1", 150.1f, _stub);
            _repository.AddItem(giraffe);
            _repository.AddItem(bear);
            _repository.AddItem(wolf);
            _existingAnimal = giraffe;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TestRepositoryAdd()
        {
            var fakeAnimal = new AnimalFactoryRandomizer(_stub).RandomizeFactory().Create("Fake animal", 10.5f);
            _repository.AddItem(fakeAnimal);
            var retrivedAnimal = _repository.GetBySpecification(new ByIdSpecification(fakeAnimal.ID)).FirstOrDefault();
            Assert.AreEqual(fakeAnimal.Name, retrivedAnimal.Name);
            Assert.AreEqual(fakeAnimal.Weight, retrivedAnimal.Weight);
        }

        [Test]
        public void TestRepositoryGet()
        {
            var fakeAnimal = new AnimalFactoryRandomizer(_stub).RandomizeFactory().Create("Fake animal", 10.5f);
            _repository.AddItem(fakeAnimal);
            _repository.DeleteItem(fakeAnimal);
            var all = _repository.GetAll();
            foreach(var animal in all)
            {
                Assert.AreNotEqual(animal.Name, fakeAnimal.Name);//names are unique constraints
            }
        }
        [Test]
        public void TestRepositoryGetExisting()
        {
            var retrivedAnimal = _repository.GetBySpecification(new ByIdSpecification(_existingAnimal.ID)).FirstOrDefault();
            Assert.AreEqual(_existingAnimal.Name, retrivedAnimal.Name);
            Assert.AreEqual(_existingAnimal.Weight, retrivedAnimal.Weight);
        }
    }
}
