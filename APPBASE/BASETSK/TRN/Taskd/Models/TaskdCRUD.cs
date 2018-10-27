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
    [Table("TSK01TRN_TASKD")]
    public partial class Taskd : CRUD
    {
        public int? DTA_STS { get; set; }
        public int? ASSIGNEE_ID { get; set; }
        public int? PROJECT_ID { get; set; }
        public string TASKD_PLANDESC { get; set; }
        public DateTime? TASKD_PLANSTARTDT { get; set; }
        public DateTime? TASKD_PLANENDDT { get; set; }
        public int? TASKD_PLANDURATION { get; set; }
        public Byte? TASKD_PROGRESSSTS { get; set; }
        public Byte? TASKD_PROGRESSPCT { get; set; }
        public DateTime? TASKD_PROGRESSDT { get; set; }
        public DateTime? TASKD_PROGRESSFINISHDT { get; set; }
        public int? TASKD_PROGRESSDURATION { get; set; }
        public string TASKD_PROGRESSNOTES { get; set; }
        public int? TASKD_VALIDATESTS { get; set; }
        public string TASKD_VALIDATENOTES { get; set; }
        public int? TASK_ID { get; set; }
    } //End public partial class Taskd : CRUD
} //End namespace APPBASE.Models
