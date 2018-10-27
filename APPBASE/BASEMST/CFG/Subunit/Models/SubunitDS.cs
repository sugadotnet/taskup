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
    [Table("VWMST01CFG_SUBUNIT_INFO")]
    public partial class Subunit_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public int? DTA_STS { get; set; }
        public string SUBUNIT_CODE { get; set; }
        public string SUBUNIT_SHORTDESC { get; set; }
        public string SUBUNIT_DESC { get; set; }
        public int? SUBUNIT_SEQNO { get; set; }
        public int? UNIT_ID { get; set; }
        public string UNIT_CODE { get; set; }
        public string UNIT_SHORTDESC { get; set; }
        public string UNIT_DESC { get; set; }
        public int? UNIT_SEQNO { get; set; }
    } //End public partial class Subunit_info
} //End namespace APPBASE.Models
