using OOPLab2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Services
{
    interface IAnimalCRUDService: IBusinessService
    {
        Animal GenerateRandomAnimal(string name, float weight);

        Animal GenerateAnimalByType(string type, string name, float weight);

        void DeleteAnimal(string name);

        void ListAllAnimals();
    }
}
