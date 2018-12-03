using InputParser;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class MakeVoiceByNameCommand:ICommand
    {
        private readonly IZooVoiceService _service;
        private string _name;

        public MakeVoiceByNameCommand(IZooVoiceService service, string name)
        {
            _service = service;
            _name = name;
        }

        public void Execute()
        {
            _service.MakeSoundByAnimal(_name);
        }
    }
}
