using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Exceptions
{
    public class CommandException: Exception
    {
        public override string Message => "Invalid command or arguments";
    }
}
