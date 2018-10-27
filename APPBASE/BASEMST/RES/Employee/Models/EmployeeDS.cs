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
    [Table("VWMST01RES_EMPLOYEE_INFO")]
    public partial class Employee_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
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
        public string SEX_CODE { get; set; }
        public string SEX_SHORTDESC { get; set; }
        public string SEX_DESC { get; set; }
        public int? SEX_SEQNO { get; set; }
        public string BLOODTYPE_CODE { get; set; }
        public string BLOODTYPE_SHORTDESC { get; set; }
        public string BLOODTYPE_DESC { get; set; }
        public int? BLOODTYPE_SEQNO { get; set; }
        public string MARITAL_CODE { get; set; }
        public string MARITAL_SHORTDESC { get; set; }
        public string MARITAL_DESC { get; set; }
        public int? MARITAL_SEQNO { get; set; }
        public string RELIGION_CODE { get; set; }
        public string RELIGION_SHORTDESC { get; set; }
        public string RELIGION_DESC { get; set; }
        public int? RELIGION_SEQNO { get; set; }
        public string NATIONALITY_CODE { get; set; }
        public string NATIONALITY_SHORTDESC { get; set; }
        public string NATIONALITY_DESC { get; set; }
        public int? NATIONALITY_SEQNO { get; set; }
        public string ADDR_COUNTRY_CODE { get; set; }
        public string ADDR_COUNTRY_SHORTDESC { get; set; }
        public string ADDR_COUNTRY_DESC { get; set; }
        public int? ADDR_COUNTRY_SEQNO { get; set; }
        public string UNIT_CODE { get; set; }
        public string UNIT_SHORTDESC { get; set; }
        public string UNIT_DESC { get; set; }
        public int? UNIT_SEQNO { get; set; }
        public string SUBUNIT_CODE { get; set; }
        public string SUBUNIT_SHORTDESC { get; set; }
        public string SUBUNIT_DESC { get; set; }
        public int? SUBUNIT_SEQNO { get; set; }
        public string JOBTITLE_CODE { get; set; }
        public string JOBTITLE_SHORTDESC { get; set; }
        public string JOBTITLE_DESC { get; set; }
        public int? JOBTITLE_SEQNO { get; set; }
        public string EMPSTS_CODE { get; set; }
        public string EMPSTS_SHORTDESC { get; set; }
        public string EMPSTS_DESC { get; set; }
        public int? EMPSTS_SEQNO { get; set; }
        public string EMPACTIVESTS_CODE { get; set; }
        public string EMPACTIVESTS_SHORTDESC { get; set; }
        public string EMPACTIVESTS_DESC { get; set; }
        public int? EMPACTIVESTS_SEQNO { get; set; }
        public string SUPERIOR_NAME { get; set; }
        public int? SUPERIOR_SEXID { get; set; }
        public int? SUPERIOR_BRANCHID { get; set; }
        public int? SUPERIOR_DEPTID { get; set; }
        public int? SUPERIOR_UNITID { get; set; }
        public int? SUPERIOR_SUBUNITID { get; set; }
        public int? SUPERIOR_JOBTITLEID { get; set; }
        public int? SUPERIOR_EMPLSTSID { get; set; }
        public int? SUPERIOR_ACTIVESTSID { get; set; }
        public string SUPERIOR_IMG { get; set; }
        public string SUPERIOR_SEXCODE { get; set; }
        public string SUPERIOR_SEXSHORTDESC { get; set; }
        public string SUPERIOR_SEXDESC { get; set; }
        public string SUPERIOR_UNITCODE { get; set; }
        public string SUPERIOR_UNITSHORTDESC { get; set; }
        public string SUPERIOR_UNITDESC { get; set; }
        public string SUPERIOR_JOBTITLECODE { get; set; }
        public string SUPERIOR_JOBTITLESHORTDESC { get; set; }
        public string SUPERIOR_JOBTITLEDESC { get; set; }
    } //End public partial class Employee_info
} //End namespace APPBASE.Models
