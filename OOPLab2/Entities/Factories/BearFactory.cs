using OOPLab2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Entities.Factories
{
    public class BearFactory: AnimalFactory
    {
        public BearFactory(ILogger logger) : base(logger)
        {
        }

        public override Animal Create(string name, float weight) => new Bear(name, weight, _logger);
    }
}
