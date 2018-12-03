using OOPLab2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Storage.Specifications
{
    public class ByIdSpecification : ISpecification<Animal>
    {
        private readonly Guid id;

        public ByIdSpecification(Guid id)
        {
            this.id = id;
        }

        public bool SatisfiedBy(Animal item)
        {
            return item.ID == id;
        }
    }
}
