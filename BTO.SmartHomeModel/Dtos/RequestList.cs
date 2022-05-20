using BTO.SmartHomeModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Dtos
{
    public class RequestList
    {
        public enDeleteType IsDeleted { get; set; }
        public bool Relations { get; set; }
        public bool OrderByID { get; set; }

    }
}
