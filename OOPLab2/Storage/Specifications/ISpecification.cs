using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Storage.Specifications
{

    public interface ISpecification<T>
    {
        bool SatisfiedBy(T item);
    }
}
