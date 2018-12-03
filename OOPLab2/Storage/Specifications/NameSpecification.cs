using OOPLab2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Storage.Specifications
{
    public class NameSpecification : ISpecification<Animal>
    {
        private readonly string _name;

        public NameSpecification(string name)
        {
            _name = name;
        }

        public bool SatisfiedBy(Animal item)
        {
            return item.Name == _name;
        }
    }
}
