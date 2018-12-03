using InputParser;
using OOPLab2.Entities;
using OOPLab2.Exceptions;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class GetAverageWieghtByTypeCommand : ICommand
    {
        private readonly IWeightService _service;
        private string _type;

        public GetAverageWieghtByTypeCommand(IWeightService service, string type)
        {
            _service = service;
            _type = type;
        }

        public void Execute()
        {
            _service.AvgWeightByAnimalType(TypeFromString(_type));
        }

        private Type TypeFromString(string type)
        {
            switch (type)
            {
                case "wolf":
                    return typeof(Wolf);
                case "bear":
                    return typeof(Bear);
                case "giraffe":
                    return typeof(Giraffe);
                default:
                    throw new CommandException();
            }
        }
    }
}
