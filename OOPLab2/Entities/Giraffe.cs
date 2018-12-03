using OOPLab2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Entities
{
    public class Giraffe : Animal
    {
        public Giraffe(string name, float weight, ILogger logger) : base(name, weight, logger)
        {
        }

        public override string GetAnimalTypeName() => "giraffe";

        public override void MakeSound()
        {
            _logger.Log($"The Giraffe {Name} says: I don't know what giraffes say, I'm sorry");
        }
    }
}
