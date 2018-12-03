using OOPLab2.Exceptions;
using OOPLab2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Entities
{
    public abstract class Animal//Should have used visitor for MakeVoice()
    {
        protected readonly ILogger _logger;
        private float _weight;

        protected Animal(string name, float weight, ILogger logger)
        {
            ID = Guid.NewGuid();
            Name = name;
            Weight = weight;
            _logger = logger;
        }

        public readonly Guid ID;

        public string Name { get; protected set; }

        public float Weight {
            get { return _weight; }
            protected set {
                if (value <= 0) throw new ZeroOrNegativeAnimalWeightException();
                _weight = value;
            }
        }

        abstract public void MakeSound(); //Probably should moved this to other class

        abstract public string GetAnimalTypeName();
    }
}
