using OOPLab2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Entities.Factories
{
   public  abstract class AnimalFactory
    {
        protected readonly ILogger _logger;

        protected AnimalFactory(ILogger logger)
        {
            _logger = logger;
        }

        public abstract Animal Create(string name, float weight);
    }
}
