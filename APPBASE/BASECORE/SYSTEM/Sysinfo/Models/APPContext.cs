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
        //Timeline
        public DbSet<Sysinfo_info> Sysinfo_infos { get; set; }
    } //End public class DBMAINContext : DbContext
} //End namespace APPBASE.Models