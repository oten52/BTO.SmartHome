using BTO.SmartHomeModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Entities
{
    public class t_IActionResults:BaseEntities
    {
        [MaxLength(50)]
        public string ControlName { get; set; }
        [MaxLength(50)]
        public string ActionName { get; set; }

    }
}
