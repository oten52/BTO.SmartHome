using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.ComonComon.Extentions
{
    public static class ObjectExtentions
    {
        public static bool IsNull(this Object obj)
        {
            return obj == null ? true : false;
        }
    }
}
