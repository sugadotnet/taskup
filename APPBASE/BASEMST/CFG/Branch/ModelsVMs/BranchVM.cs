﻿using System;
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
    public partial class BranchVM
    {
        public int? ID { get; set; }
        public int? DTA_STS { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BRANCH_SHORTDESC { get; set; }
        public string BRANCH_DESC { get; set; }
        public int? BRANCH_SEQNO { get; set; }
        public int? BRANCH_TYPE { get; set; }
    } //End public partial class BranchVM
} //End namespace APPBASE.Models
