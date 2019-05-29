using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    static class ExtensionMethod
    {
        public static bool IsNull(this object o)
        {
            return (o == null);
        }
    }
}
