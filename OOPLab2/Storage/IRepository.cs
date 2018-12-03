using OOPLab2.Entities;
using OOPLab2.Storage.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Storage
{
    public interface IRepository<T>
    {
        void AddItem(T item);

        void DeleteItem(T item);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetBySpecification(ISpecification<T> spec);

        void ClearRepository();
    }
}
