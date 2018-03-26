using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace SercicesMS.Models
{
    public class ServiceDBContext:DbContext
    {
        static ServiceDBContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }
        public DbSet<Service> Services { get; set; }
    }
}