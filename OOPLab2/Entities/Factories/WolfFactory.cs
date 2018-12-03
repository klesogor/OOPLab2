using OOPLab2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Entities.Factories
{
    public class WolfFactory : AnimalFactory
    {
        public WolfFactory(ILogger logger) : base(logger)
        {

        }

        public override Animal Create(string name, float weight) => new Wolf(name, weight, _logger);
    }
}
