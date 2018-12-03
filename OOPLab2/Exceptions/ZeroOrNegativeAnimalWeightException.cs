using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Exceptions
{
    public class ZeroOrNegativeAnimalWeightException: Exception
    {
        public override string Message => "Animal can't weight nothing or even less than nothing";
    }
}
