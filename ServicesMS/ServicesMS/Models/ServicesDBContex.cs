using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ServicesMS.Models
{
    public class ServicesDBContex:DbContext
    {
        public DbSet<Service> Services { get; set; }
    }
}