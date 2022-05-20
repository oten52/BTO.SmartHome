using BTO.ComonComon.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Dtos
{
    public class RequestItem<T>
        where T : new()
    {

        public T Object { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
