using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPLab2.Entities;
using OOPLab2.IO;

namespace OOPLab2.Services.Strategies
{
    class ZooDayVoiceStrategy : IVoiceStrategy
    {
        public string Description => "day strategy. Now animals will respond to global calls";

        public void MakeVoiceAllAnimals(IEnumerable<Animal> animals)
        {
            foreach (var animal in animals)
            {
                animal.MakeSound();
            }
        }
    }
}
