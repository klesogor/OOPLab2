using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Storage.Specifications
{
    public static class SpecificationAggregatesExtension
    {
        public static ISpecification<T> And<T>(this ISpecification<T> orig, ISpecification<T> composite)
        {
            return new AndSpecification<T>(orig, composite);
        }
    }
}
