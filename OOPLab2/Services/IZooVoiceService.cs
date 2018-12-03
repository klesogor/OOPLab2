using OOPLab2.Services.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Services
{
    interface IZooVoiceService:IBusinessService
    {
        IVoiceStrategy VoiceStrategy { get; set; }

        void AllZooMakeSound();

        void MakeSoundByAnimal(Guid id);

        void MakeSoundByAnimal(string name);
    }
}
