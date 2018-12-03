using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPLab2.Entities;
using OOPLab2.Entities.Factories;
using OOPLab2.Exceptions;
using OOPLab2.IO;
using OOPLab2.Storage;
using OOPLab2.Storage.Specifications;

namespace OOPLab2.Services
{
    class AnimalCRUDService : IAnimalCRUDService
    {
        private readonly IRepository<Animal> _repostiory;
        private readonly AnimalFactoryRandomizer _randomizer;
        private readonly ILogger _logger;

        public AnimalCRUDService(AnimalFactoryRandomizer randomizer, ILogger logger)
        {
            _repostiory = AnimalRepository.GetInstance();
            _randomizer = randomizer;
            _logger = logger;
        }

        public void DeleteAnimal(string name)
        {
            var animal = _repostiory.GetBySpecification(new NameSpecification(name)).FirstOrDefault();
            if (animal == null) throw new AnimalNotFoundException();
            _repostiory.DeleteItem(animal);
            _logger.Log($"Animal {animal.Name} was deleted succesfully");
        }

        public Animal GenerateAnimalByType(string type, string name, float weight)
        {
            ValidateCanCreateAnimal(name);

            AnimalFactory factory = null;
            switch (type)
            {
                case "wolf":
                    factory = _randomizer.WolfFactory;
                    break;
                case "bear":
                    factory = _randomizer.BearFactory;
                    break;
                case "giraffe":
                    factory = _randomizer.GiraffeFactory;
                    break;
                default:
                    throw new CommandException();
            }

            var animal = factory.Create(name, weight);
            _logger.Log($"Animal {animal.Name} was added succesfully");
            _repostiory.AddItem(animal);
            return animal;
        }

        public Animal GenerateRandomAnimal(string name, float weight)
        {
            ValidateCanCreateAnimal(name);
            var animal = _randomizer.RandomizeFactory().Create(name, weight);
            _logger.Log($"Animal {animal.Name} was added succesfully");
            _repostiory.AddItem(animal);
            return animal;
        }

        public void ListAllAnimals()
        {
            foreach (Animal animal in _repostiory.GetAll())
                _logger.Log($"{animal.Name} the {animal.GetAnimalTypeName()}, weight: {animal.Weight}");
        }

        private void ValidateCanCreateAnimal(string name)
        {
            var oldAnimal = _repostiory.GetBySpecification(new NameSpecification(name)).FirstOrDefault();
            if (oldAnimal != null) throw new DuplicatedNameOrIdException();
        }
    }
}
