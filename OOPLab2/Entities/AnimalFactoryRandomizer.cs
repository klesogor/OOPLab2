using OOPLab2.Entities.Factories;
using OOPLab2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Entities
{
    public class AnimalFactoryRandomizer
    {
        public WolfFactory WolfFactory { get; private set; }
        public BearFactory BearFactory { get; private set; }
        public GiraffeFactory GiraffeFactory { get; private set; }

        public AnimalFactoryRandomizer(ILogger logger)
        {
            WolfFactory = new WolfFactory(logger);
            BearFactory = new BearFactory(logger);
            GiraffeFactory = new GiraffeFactory(logger);
        }

        public AnimalFactory RandomizeFactory()
        {
            var rand = new Random();
            int random = rand.Next(0, 101);
            if (random <= 20)
                return GiraffeFactory;
            else if (random <= 60)
                return BearFactory;
            else
                return WolfFactory;
        }

    }
}
