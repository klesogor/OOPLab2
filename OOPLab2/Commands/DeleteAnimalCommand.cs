using InputParser;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class DeleteAnimalCommand : ICommand
    {
        private readonly IAnimalCRUDService _service;
        private string _name;

        public DeleteAnimalCommand(string name, IAnimalCRUDService service)
        {
            _service = service;
            _name = name;
        }

        public void Execute()
        {
            _service.DeleteAnimal(_name);
        }
    }
}
