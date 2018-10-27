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
    [Table("MST01RES_EMPLOYEE")]
    public partial class Employee : CRUD
    {
        public int? DTA_STS { get; set; }
        public string NAME { get; set; }
        public string NICKNAME { get; set; }
        public int? SEX_ID { get; set; }
        public int? BLOOD_TYPE_ID { get; set; }
        public int? MARITAL_ID { get; set; }
        public int? RELIGION_ID { get; set; }
        public int? NATIONALITY_ID { get; set; }
        public string NATIONALITY_OTHER { get; set; }
        public string LANGUAGE { get; set; }
        public string ETHNIC { get; set; }
        public string NIP { get; set; }
        public string KTP { get; set; }
        public string NPWP { get; set; }
        public string POB { get; set; }
        public DateTime? DOB { get; set; }
        public int? ADDR_COUNTRY_ID { get; set; }
        public string ADDR_COUNTRY_OTHER { get; set; }
        public string ADDR_CITY { get; set; }
        public string ADDR_KEC { get; set; }
        public string ADDR_KEL { get; set; }
        public string ADDR_ZIP { get; set; }
        public string ADDR_STREET1 { get; set; }
        public string ADDR_STREET2 { get; set; }
        public string HOME_PHONE { get; set; }
        public string CELL_PHONE { get; set; }
        public string EMAIL { get; set; }
        public DateTime? JOIN_DT { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? DEPT_ID { get; set; }
        public int? UNIT_ID { get; set; }
        public int? SUBUNIT_ID { get; set; }
        public int? JOBTITLE_ID { get; set; }
        public int? EMPLSTS_ID { get; set; }
        public int? ACTIVESTS_ID { get; set; }
        public string EMPLOYEE_IMG { get; set; }
        public int? SUPERIOR_ID { get; set; }
    } //End public partial class Employee : CRUD
} //End namespace APPBASE.Models
