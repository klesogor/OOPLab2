using InputParser;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class AllMakeVoiceCommand : ICommand
    {
        private readonly IZooVoiceService _service;

        public AllMakeVoiceCommand(IZooVoiceService service)
        {
            _service = service;
        }

        public void Execute()
        {
            _service.AllZooMakeSound();
        }
    }
}
