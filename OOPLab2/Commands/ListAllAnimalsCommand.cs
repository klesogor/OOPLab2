using InputParser;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class ListAllAnimalsCommand: ICommand
    {
        private readonly IAnimalCRUDService _service;

        public ListAllAnimalsCommand(IAnimalCRUDService service)
        {
            _service = service;
        }

        public void Execute()
        {
            _service.ListAllAnimals();
        }
    }
}
