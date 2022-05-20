using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Base
{
    public class Singleton<T>
        where T : new()
    {
        public static T Object { get; set; }
        public static T Instance()
        {
            if (Object == null)
            {
                Object = new T();
            }
            return Object;
        }

    }
}
