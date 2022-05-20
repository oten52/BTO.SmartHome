using BTO.SmartHomeModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Entities
{
    public class t_IActionResultAuthenticationMaps:BaseEntities
    {
        [ForeignKey("t_Users")]
        public int t_UserID { get; set; }
        public virtual t_Users t_Users { get; set; }
       
        [ForeignKey("t_IActionResults")]
        public int t_IActionResultID { get; set; }
        public virtual t_IActionResults t_IActionResults { get; set; }


    }
}
