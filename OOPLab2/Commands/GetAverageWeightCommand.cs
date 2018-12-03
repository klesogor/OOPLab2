using InputParser;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class GetAverageWeightCommand : ICommand
    {
        private readonly IWeightService _service;

        public GetAverageWeightCommand(IWeightService service)
        {
            _service = service;
        }

        public void Execute()
        {
            _service.AvgWeight();
        }
    }
}
