using InputParser;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class CreateNewConcreteAnimal : ICommand
    {
        private readonly IAnimalCRUDService _service;
        private string _name;
        private string _type;
        private float _weight;

        public CreateNewConcreteAnimal(IAnimalCRUDService service, string name, string type, float weight)
        {
            _service = service;
            _name = name;
            _type = type;
            _weight = weight;
        }

        public void Execute()
        {
            _service.GenerateAnimalByType(_type, _name, _weight);
        }
    }
}
