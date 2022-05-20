using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeModel.Base
{
    public abstract class BaseEntities
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectID { get; set; }

        [BindNever]
        public DateTime? CreateDate { get; set; }

        [BindNever]
        // [Column(TypeName = "datetime")]
        public DateTime? EditDate { get; set; }

        [BindNever]
        //[Column(TypeName = "datetime")]
        public DateTime? DeleteDate { get; set; }

        [BindNever]
        public bool IsDelete { get; set; }

    }
}
