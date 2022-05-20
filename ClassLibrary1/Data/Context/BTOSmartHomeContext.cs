using BTO.SmartHomeComon.Base;
using BTO.SmartHomeModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeData.Data.Context
{
    public class BTOSmartHomeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=PC_ORCUNTEN; Initial Catalog=dbSmartHome; Persist Security Info=True; Integrated Security=SSPI;pooling=true;");

        }


        public DbSet<t_Pins> t_Pins { get; set; }
        public DbSet<t_Cards> t_Cards { get; set; }
        public DbSet<t_Users> t_Users { get; set; }
        public DbSet<t_ConnectLogs> t_ConnectLogs { get; set; }
        public DbSet<t_ExceptionLogs> t_ExceptionLogs { get; set; }
        public DbSet<t_IActionResults> t_IActionResults { get; set; }
        public DbSet<t_IActionResultAuthenticationMaps> t_IActionResultAuthenticationMaps { get; set; }


    }
}
