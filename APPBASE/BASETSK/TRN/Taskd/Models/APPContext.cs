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
        //Taskd
        public DbSet<Taskd> Taskds { get; set; }
        public DbSet<Taskd_info> Taskd_infos { get; set; }
        public DbSet<Taskd_summary_info> Taskd_summary_infos { get; set; }
    } //End public class DBMAINContext : DbContext
} //End namespace APPBASE.Models