using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Exceptions
{
    public class AnimalNotFoundException:Exception
    {
        public override string Message => "Sorry, no animals found by provided criterias";
    }
}
