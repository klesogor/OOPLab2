using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2
{
    class Program// next time I will 100% use DI container since it will really help and no singletons will be needed
    {
        static void Main(string[] args)
        {
            var interactionObj = new InteractionObject();
            interactionObj.Run();
        }
    }
}
