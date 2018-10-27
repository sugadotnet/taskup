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
    public partial class Taskd_summaryVM
    {
        public int? ID { get; set; }
        public int? DTA_STS { get; set; }
        public int? ASSIGNEE_ID { get; set; }
        public int? RES_ID { get; set; }
        public int? RESBOS_ID { get; set; }
        public int? RESOWNER_ID { get; set; }
        public int? QTY_OPEN { get; set; }
        public int? QTY_ONPROGRESS { get; set; }
        public int? QTY_FINISH { get; set; }
        public int? QTY_VALIDATED { get; set; }
    } //End public partial class Taskd_summaryVM
} //End namespace APPBASE.Models
