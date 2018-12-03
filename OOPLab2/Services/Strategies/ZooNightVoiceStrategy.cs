using OOPLab2.Entities;
using OOPLab2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Services.Strategies
{
    class ZooNightVoiceStrategy: IVoiceStrategy
    {
        private readonly ILogger _logger;

        private const string message = "Sorry, animals are asleep. You can ask specific animal to make voice and it will obey";

        public string Description => "night strategy. Animals will not respond for global voice calls";

        public ZooNightVoiceStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public void MakeVoiceAllAnimals(IEnumerable<Animal> animals)
        {
            _logger.Log(message);
        }
    }
}
