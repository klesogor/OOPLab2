using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Storage.Specifications
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _spec1;

        private readonly ISpecification<T> _spec2;

        public AndSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            _spec1 = spec1;
            _spec2 = spec2;
        }

        public bool SatisfiedBy(T item)
        {
            return _spec1.SatisfiedBy(item) && _spec2.SatisfiedBy(item);
        }
    }
}
