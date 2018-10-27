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
    [Table("VWTSK01TRN_TASK_INFO")]
    public partial class Task_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
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
        public string BRANCH_CODE { get; set; }
        public string BRANCH_SHORTDESC { get; set; }
        public string BRANCH_DESC { get; set; }
        public int? BRANCH_SEQNO { get; set; }
        public int? BRANCH_TYPE { get; set; }
        public string YEAR_CODE { get; set; }
        public string YEAR_SHORTDESC { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        public int? YEAR_NUM { get; set; }
        public string MONTH_CODE { get; set; }
        public string MONTH_SHORTDESC { get; set; }
        public string MONTH_DESC { get; set; }
        public Byte? MONTH_NUM { get; set; }
        public Byte? MONTH_SEQNO { get; set; }
        public string UNIT_CODE { get; set; }
        public string UNIT_SHORTDESC { get; set; }
        public string UNIT_DESC { get; set; }
        public int? UNIT_SEQNO { get; set; }
        public string SUBUNIT_CODE { get; set; }
        public string SUBUNIT_SHORTDESC { get; set; }
        public string SUBUNIT_DESC { get; set; }
        public int? SUBUNIT_SEQNO { get; set; }
        public string RES_NAME { get; set; }
        public string RES_NICKNAME { get; set; }
        public int? RES_SEX_ID { get; set; }
        public string RES_NIP { get; set; }
        public string RES_KTP { get; set; }
        public string RES_EMAIL { get; set; }
        public DateTime? RES_JOIN_DT { get; set; }
        public int? RES_BRANCH_ID { get; set; }
        public int? RES_DEPT_ID { get; set; }
        public int? RES_UNIT_ID { get; set; }
        public int? RES_SUBUNIT_ID { get; set; }
        public int? RES_JOBTITLE_ID { get; set; }
        public int? RES_EMPLSTS_ID { get; set; }
        public int? RES_ACTIVESTS_ID { get; set; }
        public string RES_EMPLOYEE_IMG { get; set; }
        public string RES_UNITCODE { get; set; }
        public string RES_UNITSHORTDESC { get; set; }
        public string RES_SUBUNITCODE { get; set; }
        public string RES_SUBUNITSHORTDESC { get; set; }
        public string RES_JOBTITLECODE { get; set; }
        public string RES_JOBTITLESHORTDESC { get; set; }
        public string RESBOS_NAME { get; set; }
        public string RESBOS_NICKNAME { get; set; }
        public int? RESBOS_SEX_ID { get; set; }
        public string RESBOS_NIP { get; set; }
        public string RESBOS_KTP { get; set; }
        public string RESBOS_EMAIL { get; set; }
        public DateTime? RESBOS_JOIN_DT { get; set; }
        public int? RESBOS_BRANCH_ID { get; set; }
        public int? RESBOS_DEPT_ID { get; set; }
        public int? RESBOS_UNIT_ID { get; set; }
        public int? RESBOS_SUBUNIT_ID { get; set; }
        public int? RESBOS_JOBTITLE_ID { get; set; }
        public int? RESBOS_EMPLSTS_ID { get; set; }
        public int? RESBOS_ACTIVESTS_ID { get; set; }
        public string RESBOS_EMPLOYEE_IMG { get; set; }
        public string RESBOS_UNITCODE { get; set; }
        public string RESBOS_UNITSHORTDESC { get; set; }
        public string RESBOS_SUBUNITCODE { get; set; }
        public string RESBOS_SUBUNITSHORTDESC { get; set; }
        public string RESBOS_JOBTITLECODE { get; set; }
        public string RESBOS_JOBTITLESHORTDESC { get; set; }
        public string RESOWNER_NAME { get; set; }
        public string RESOWNER_NICKNAME { get; set; }
        public int? RESOWNER_SEX_ID { get; set; }
        public string RESOWNER_NIP { get; set; }
        public string RESOWNER_KTP { get; set; }
        public string RESOWNER_EMAIL { get; set; }
        public DateTime? RESOWNER_JOIN_DT { get; set; }
        public int? RESOWNER_BRANCH_ID { get; set; }
        public int? RESOWNER_DEPT_ID { get; set; }
        public int? RESOWNER_UNIT_ID { get; set; }
        public int? RESOWNER_SUBUNIT_ID { get; set; }
        public int? RESOWNER_JOBTITLE_ID { get; set; }
        public int? RESOWNER_EMPLSTS_ID { get; set; }
        public int? RESOWNER_ACTIVESTS_ID { get; set; }
        public string RESOWNER_EMPLOYEE_IMG { get; set; }
        public string RESOWNER_UNITCODE { get; set; }
        public string RESOWNER_UNITSHORTDESC { get; set; }
        public string RESOWNER_SUBUNITCODE { get; set; }
        public string RESOWNER_SUBUNITSHORTDESC { get; set; }
        public string RESOWNER_JOBTITLECODE { get; set; }
        public string RESOWNER_JOBTITLESHORTDESC { get; set; }
    } //End public partial class Task_info
} //End namespace APPBASE.Models
