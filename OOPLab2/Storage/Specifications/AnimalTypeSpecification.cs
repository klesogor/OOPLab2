using OOPLab2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Storage.Specifications
{
    public class AnimalTypeSpecification : ISpecification<Animal>
    {
        private readonly Type _type;

        public AnimalTypeSpecification(Type type)
        {
            _type = type;
        }

        public bool SatisfiedBy(Animal item)
        {
            return item.GetType() == _type;
        }
    }
}
