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
    public partial class JsonVM {
        //Header
        public Object result { get; set; }
        public Object result_template { get; set; }
        //Detail
        public Object result_detail { get; set; }
        public Object result_detail_template { get; set; }
    } //End public partial class JsonVM
} //End namespace APPBASE.Models
