using BTO.SmartHomeModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Dtos
{
    public class ResultItem<T>
        where T : new()
    {
        public enState Status { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }
        public List<T> List { get; set; }
    }
}
