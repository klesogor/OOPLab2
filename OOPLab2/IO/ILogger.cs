using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.IO
{
    public interface ILogger
    {
        void Log(string message);

        void LogError(string error);
    }
}
