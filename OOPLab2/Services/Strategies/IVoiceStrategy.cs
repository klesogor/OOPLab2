using OOPLab2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Services.Strategies
{
    interface IVoiceStrategy
    {
        void MakeVoiceAllAnimals(IEnumerable<Animal> animals);

        string Description { get;}
    }
}
