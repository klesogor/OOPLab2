using OOPLab2.Entities;
using OOPLab2.Storage.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Storage
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly List<Animal> _repository;

        public AnimalRepository(IEnumerable<Animal> animals = null)
        {
            _repository = new List<Animal>(animals);
        }

        public AnimalRepository()
        {
            _repository = new List<Animal>();
        }

        public void AddItem(Animal item)
        {
            _repository.Add(item);
        }

        public void DeleteItem(Animal item)
        {
            _repository.Remove(item);
        }

        public IEnumerable<Animal> GetAll()
        {
            return _repository;
        }

        public IEnumerable<Animal> GetBySpecification( ISpecification<Animal> spec)
        {
            return _repository.Where(x => spec.SatisfiedBy(x));
        }
    }
}
