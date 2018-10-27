using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using APPBASE.Helpers;
using APPBASE.Models;

namespace APPBASE.Models
{
    public partial class DBMAINContext : DbContext
    {
        //Marital
        public DbSet<Marital> Maritals { get; set; }
        public DbSet<Marital_info> Marital_infos { get; set; }
    } //End public class DBMAINContext : DbContext
} //End namespace APPBASE.Models