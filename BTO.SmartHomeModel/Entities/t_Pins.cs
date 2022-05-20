using BTO.SmartHomeModel.Base;
using BTO.SmartHomeModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Entities
{
    public class t_Pins : BaseEntities
    {
        [MaxLength(20)]
        public string PinName { get; set; }
        public int PinNumber { get; set; }
        public enPinType InputOrOutput { get; set; }
        public enStatus Status { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        
        [ForeignKey("t_Card")]
        public int CardId { get; set; }
        public virtual t_Cards t_Card { get; set; }
    }
}
