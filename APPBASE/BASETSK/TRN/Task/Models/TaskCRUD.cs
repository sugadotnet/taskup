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
    [Table("TSK01TRN_TASK")]
    public partial class Task : CRUD
    {
        public int? DTA_STS { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public int? MONTH_ID { get; set; }
        public int? UNIT_ID { get; set; }
        public int? SUBUNIT_ID { get; set; }
        public int? RES_ID { get; set; }
        public int? RESBOS_ID { get; set; }
        public int? RESOWNER_ID { get; set; }
        public int? TASK_STS { get; set; }
        public int? TASK_NO { get; set; }
        public DateTime? TASK_DT { get; set; }
        public int? TASK_YEAR { get; set; }
        public int? TASK_MONTH { get; set; }
        public string TASK_DESC { get; set; }
        public DateTime? TASK_PRINTDT { get; set; }
        public string CACHE_YEAR_CODE { get; set; }
        public string CACHE_YEAR_SHORTDESC { get; set; }
        public string CACHE_YEAR_DESC { get; set; }
        public DateTime? CACHE_YEAR_FROM { get; set; }
        public DateTime? CACHE_YEAR_TO { get; set; }
    } //End public partial class Task : CRUD
} //End namespace APPBASE.Models
