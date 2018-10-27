using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcapp;

namespace APPBASE.Models
{
    [Table("TSK01CFG_PROJECT")]
    public partial class Project : CRUD
    {
        public int? DTA_STS { get; set; }
        public string PROJECT_CODE { get; set; }
        public string PROJECT_SHORTDESC { get; set; }
        public string PROJECT_DESC { get; set; }
        public int? PROJECT_MAIN { get; set; }
        public int? PROJECT_SEQNO { get; set; }
    } //End public partial class Project : CRUD
} //End namespace APPBASE.Models
