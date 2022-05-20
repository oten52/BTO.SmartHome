using BTO.ComonComon.Extentions;
using BTO.SmartHomeModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Entities
{
    public class t_Users : BaseEntities
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string Mail { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(36)]
        public string UserName { get; set; }
        [MaxLength(15)]
        public string Password { get; set; }
        public virtual List<t_IActionResultAuthenticationMaps> t_IActionResultAuthenticationMaps { get; set; }
    }
}
