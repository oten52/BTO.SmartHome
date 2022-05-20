using BTO.SmartHomeModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Entities
{
    public class t_ConnectLogs: BaseEntities
    {
        [MaxLength(16)]
        [Required]
        public string IpAdress { get; set; }

        [MaxLength(50)]
        [Required]
        public string MethodName { get; set; }

        [MaxLength(20)]
        [Required]
        public string UserName { get; set; }
        
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

    }
}
