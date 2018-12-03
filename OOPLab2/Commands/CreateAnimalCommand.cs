using InputParser;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class CreateAnimalCommand: ICommand
    {
        private readonly IAnimalCRUDService _service;
        private string _name;
        private float _weight;

        public CreateAnimalCommand(string name, float weight, IAnimalCRUDService service)
        {
            _name = name;
            _weight = weight;
            _service = service;
        }

        public void Execute()
        {
            _service.GenerateRandomAnimal(_name, _weight);
        }
    }
}
