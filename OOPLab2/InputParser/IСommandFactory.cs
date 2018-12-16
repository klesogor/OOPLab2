using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputParser
{
    public interface ICommandFactory
    {
        ICommand Create(string command, params string[] args);
    }
}
