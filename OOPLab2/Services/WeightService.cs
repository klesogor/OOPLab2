using OOPLab2.Entities;
using OOPLab2.IO;
using OOPLab2.Storage;
using OOPLab2.Storage.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Services
{
    class WeightService : IWeightService
    {
        private readonly IRepository<Animal> _repository;
        private readonly ILogger _logger;

        public WeightService(ILogger logger, IRepository<Animal> animals)
        {
            _repository = animals;
            _logger = logger;
        }

        public float AvgWeight()
        {
            var weight = _GetAveregeFromEnumerable(_repository.GetAll());
            _logger.Log($"Averege weight:{weight}");

            return weight;
        }

        public float AvgWeightByAnimalType(Type type)
        {
            var weight = _GetAveregeFromEnumerable(_repository.GetBySpecification(new AnimalTypeSpecification(type)));
            _logger.Log($"Averege weight:{weight}");

            return weight;
        }

        private float _GetAveregeFromEnumerable(IEnumerable<Animal> animals)
        {
            if (animals.Count() == 0) return 0;
            float temp = 0;
            foreach (var animal in animals)
            {
                temp += animal.Weight;
            }
            return temp / animals.Count();
        }
    }
}
