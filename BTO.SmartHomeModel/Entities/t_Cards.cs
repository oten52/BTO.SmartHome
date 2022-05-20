using BTO.SmartHomeModel.Base;
using BTO.SmartHomeModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Entities
{
    public class t_Cards:BaseEntities
    {
        [MaxLength(20)]
        public string Name { get; set; }

        public Guid SensorGuid { get; set; }

        public enModeType ModeType { get; set; }

        public virtual List<t_Pins> t_Pins { get; set; }

    }
}
