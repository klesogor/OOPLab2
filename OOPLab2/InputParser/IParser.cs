using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputParser
{
    public interface IParser
    {
        ICommand Parse(string input);
    }
}
