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
    [Table("MST01CFG_SUBUNIT")]
    public partial class Subunit : CRUD
    {
        public int? DTA_STS { get; set; }
        public string SUBUNIT_CODE { get; set; }
        public string SUBUNIT_SHORTDESC { get; set; }
        public string SUBUNIT_DESC { get; set; }
        public int? SUBUNIT_SEQNO { get; set; }
        public int? UNIT_ID { get; set; }
    } //End public partial class Subunit : CRUD
} //End namespace APPBASE.Models
