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
    public class TaskdDS
    {
        private DBMAINContext db;
        private TaskdVM oData;
        private List<TaskdVM> oDatalist;

        public IQueryable<TaskdVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<TaskdVM> FIELD_INDEX { get { return this.fieldIndex(); } }

        private int? getDuration(DateTime? dStartDate, DateTime? dEndDate) {
            int? vReturn = 0;
            if ((dStartDate != null) && (dEndDate != null)) {
                if (dEndDate >= dStartDate) {
                    vReturn = (dEndDate.Value.Date - dStartDate.Value.Date).Days;
                } //End if
            } //End if
            return vReturn;
        } //End method
        private void dataMutation_unused() {
            this.oData.TASKD_PLANDURATION = this.getDuration(this.oData.TASKD_PLANSTARTDT, this.oData.TASKD_PLANENDDT);
        } //End private method
        private void dataListMutation() {
            foreach (var item in this.oDatalist) {
                item.TASKD_PLANDURATION = this.getDuration(item.TASKD_PLANSTARTDT, item.TASKD_PLANENDDT);
                item.TASKD_PLANSTARTDT_STRING = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(item.TASKD_PLANSTARTDT);
                item.TASKD_PLANENDDT_STRING = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(item.TASKD_PLANENDDT);
                item.TASKD_PROGRESSDT_STRING = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(item.TASKD_PROGRESSDT);
                item.TASKD_PROGRESSFINISHDT_STRING = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(item.TASKD_PROGRESSFINISHDT);
            } //End loop
        } //End private method
        private void dataMutation()
        {
            this.oData.TASKD_PLANDURATION = this.getDuration(this.oData.TASKD_PLANSTARTDT, this.oData.TASKD_PLANENDDT);
            this.oData.TASKD_PLANSTARTDT_STRING = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(this.oData.TASKD_PLANSTARTDT);
            this.oData.TASKD_PLANENDDT_STRING = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(this.oData.TASKD_PLANENDDT);
            this.oData.TASKD_PROGRESSDT_STRING = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(this.oData.TASKD_PROGRESSDT);
            this.oData.TASKD_PROGRESSFINISHDT_STRING = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(this.oData.TASKD_PROGRESSFINISHDT);
        } //End private method

        //Constructor 1
        public TaskdDS() { this.db = new DBMAINContext(); } //End Constructor TaskdDS
        //Constructor 2
        public TaskdDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<TaskdVM> fieldAll()
        {
            IQueryable<TaskdVM> vReturn;

            var oQRY = from tb in this.db.Taskd_infos
                       select new TaskdVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           ASSIGNEE_ID = tb.ASSIGNEE_ID,
                           PROJECT_ID = tb.PROJECT_ID,
                           TASKD_PLANDESC = tb.TASKD_PLANDESC,
                           TASKD_PLANSTARTDT = tb.TASKD_PLANSTARTDT,
                           TASKD_PLANENDDT = tb.TASKD_PLANENDDT,
                           TASKD_PLANDURATION = tb.TASKD_PLANDURATION,
                           TASKD_PROGRESSSTS = tb.TASKD_PROGRESSSTS,
                           TASKD_PROGRESSPCT = tb.TASKD_PROGRESSPCT,
                           TASKD_PROGRESSDT = tb.TASKD_PROGRESSDT,
                           TASKD_PROGRESSFINISHDT = tb.TASKD_PROGRESSFINISHDT,
                           TASKD_PROGRESSDURATION = tb.TASKD_PROGRESSDURATION,
                           TASKD_PROGRESSNOTES = tb.TASKD_PROGRESSNOTES,
                           TASKD_VALIDATESTS = tb.TASKD_VALIDATESTS,
                           TASKD_VALIDATENOTES = tb.TASKD_VALIDATENOTES,
                           TASK_ID = tb.TASK_ID,
                           TASK_DTA_STS = tb.TASK_DTA_STS,
                           BRANCH_ID = tb.BRANCH_ID,
                           YEAR_ID = tb.YEAR_ID,
                           MONTH_ID = tb.MONTH_ID,
                           UNIT_ID = tb.UNIT_ID,
                           SUBUNIT_ID = tb.SUBUNIT_ID,
                           RES_ID = tb.RES_ID,
                           RESBOS_ID = tb.RESBOS_ID,
                           RESOWNER_ID = tb.RESOWNER_ID,
                           TASK_STS = tb.TASK_STS,
                           TASK_NO = tb.TASK_NO,
                           TASK_DT = tb.TASK_DT,
                           TASK_YEAR = tb.TASK_YEAR,
                           TASK_MONTH = tb.TASK_MONTH,
                           TASK_DESC = tb.TASK_DESC,
                           TASK_PRINTDT = tb.TASK_PRINTDT,
                           CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                           CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                           CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                           CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                           CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                           BRANCH_CODE = tb.BRANCH_CODE,
                           BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           BRANCH_SEQNO = tb.BRANCH_SEQNO,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           YEAR_CODE = tb.YEAR_CODE,
                           YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                           YEAR_DESC = tb.YEAR_DESC,
                           YEAR_FROM = tb.YEAR_FROM,
                           YEAR_TO = tb.YEAR_TO,
                           YEAR_NUM = tb.YEAR_NUM,
                           MONTH_CODE = tb.MONTH_CODE,
                           MONTH_SHORTDESC = tb.MONTH_SHORTDESC,
                           MONTH_DESC = tb.MONTH_DESC,
                           MONTH_NUM = tb.MONTH_NUM,
                           MONTH_SEQNO = tb.MONTH_SEQNO,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           SUBUNIT_DESC = tb.SUBUNIT_DESC,
                           SUBUNIT_SEQNO = tb.SUBUNIT_SEQNO,
                           RES_NAME = tb.RES_NAME,
                           RES_NICKNAME = tb.RES_NICKNAME,
                           RES_SEX_ID = tb.RES_SEX_ID,
                           RES_NIP = tb.RES_NIP,
                           RES_KTP = tb.RES_KTP,
                           RES_EMAIL = tb.RES_EMAIL,
                           RES_BRANCH_ID = tb.RES_BRANCH_ID,
                           RES_DEPT_ID = tb.RES_DEPT_ID,
                           RES_UNIT_ID = tb.RES_UNIT_ID,
                           RES_SUBUNIT_ID = tb.RES_SUBUNIT_ID,
                           RES_JOBTITLE_ID = tb.RES_JOBTITLE_ID,
                           RES_EMPLOYEE_IMG = tb.RES_EMPLOYEE_IMG,
                           RES_UNITCODE = tb.RES_UNITCODE,
                           RES_UNITSHORTDESC = tb.RES_UNITSHORTDESC,
                           RES_SUBUNITCODE = tb.RES_SUBUNITCODE,
                           RES_SUBUNITSHORTDESC = tb.RES_SUBUNITSHORTDESC,
                           RES_JOBTITLECODE = tb.RES_JOBTITLECODE,
                           RES_JOBTITLESHORTDESC = tb.RES_JOBTITLESHORTDESC,
                           RESBOS_NAME = tb.RESBOS_NAME,
                           RESBOS_NICKNAME = tb.RESBOS_NICKNAME,
                           RESBOS_EMAIL = tb.RESBOS_EMAIL,
                           RESBOS_BRANCH_ID = tb.RESBOS_BRANCH_ID,
                           RESBOS_DEPT_ID = tb.RESBOS_DEPT_ID,
                           RESBOS_UNIT_ID = tb.RESBOS_UNIT_ID,
                           RESBOS_SUBUNIT_ID = tb.RESBOS_SUBUNIT_ID,
                           RESBOS_JOBTITLE_ID = tb.RESBOS_JOBTITLE_ID,
                           RESBOS_EMPLOYEE_IMG = tb.RESBOS_EMPLOYEE_IMG,
                           RESBOS_UNITCODE = tb.RESBOS_UNITCODE,
                           RESBOS_UNITSHORTDESC = tb.RESBOS_UNITSHORTDESC,
                           RESBOS_SUBUNITCODE = tb.RESBOS_SUBUNITCODE,
                           RESBOS_SUBUNITSHORTDESC = tb.RESBOS_SUBUNITSHORTDESC,
                           RESBOS_JOBTITLECODE = tb.RESBOS_JOBTITLECODE,
                           RESBOS_JOBTITLESHORTDESC = tb.RESBOS_JOBTITLESHORTDESC,
                           RESOWNER_NAME = tb.RESOWNER_NAME,
                           RESOWNER_NICKNAME = tb.RESOWNER_NICKNAME,
                           RESOWNER_EMAIL = tb.RESOWNER_EMAIL,
                           RESOWNER_BRANCH_ID = tb.RESOWNER_BRANCH_ID,
                           RESOWNER_DEPT_ID = tb.RESOWNER_DEPT_ID,
                           RESOWNER_UNIT_ID = tb.RESOWNER_UNIT_ID,
                           RESOWNER_SUBUNIT_ID = tb.RESOWNER_SUBUNIT_ID,
                           RESOWNER_JOBTITLE_ID = tb.RESOWNER_JOBTITLE_ID,
                           RESOWNER_EMPLOYEE_IMG = tb.RESOWNER_EMPLOYEE_IMG,
                           RESOWNER_UNITCODE = tb.RESOWNER_UNITCODE,
                           RESOWNER_UNITSHORTDESC = tb.RESOWNER_UNITSHORTDESC,
                           RESOWNER_SUBUNITCODE = tb.RESOWNER_SUBUNITCODE,
                           RESOWNER_SUBUNITSHORTDESC = tb.RESOWNER_SUBUNITSHORTDESC,
                           RESOWNER_JOBTITLECODE = tb.RESOWNER_JOBTITLECODE,
                           RESOWNER_JOBTITLESHORTDESC = tb.RESOWNER_JOBTITLESHORTDESC,
                           ASSIGNEE_NAME = tb.ASSIGNEE_NAME,
                           ASSIGNEE_EMAIL = tb.ASSIGNEE_EMAIL,
                           ASSIGNEE_JOIN_DT = tb.ASSIGNEE_JOIN_DT,
                           ASSIGNEE_BRANCH_ID = tb.ASSIGNEE_BRANCH_ID,
                           ASSIGNEE_DEPT_ID = tb.ASSIGNEE_DEPT_ID,
                           ASSIGNEE_UNIT_ID = tb.ASSIGNEE_UNIT_ID,
                           ASSIGNEE_SUBUNIT_ID = tb.ASSIGNEE_SUBUNIT_ID,
                           ASSIGNEE_JOBTITLE_ID = tb.ASSIGNEE_JOBTITLE_ID,
                           ASSIGNEE_EMPLOYEE_IMG = tb.ASSIGNEE_EMPLOYEE_IMG,
                           ASSIGNEE_UNIT_CODE = tb.ASSIGNEE_UNIT_CODE,
                           ASSIGNEE_UNIT_SHORTDESC = tb.ASSIGNEE_UNIT_SHORTDESC,
                           ASSIGNEE_SUBUNIT_CODE = tb.ASSIGNEE_SUBUNIT_CODE,
                           ASSIGNEE_SUBUNIT_SHORTDESC = tb.ASSIGNEE_SUBUNIT_SHORTDESC,
                           ASSIGNEE_JOBTITLE_CODE = tb.ASSIGNEE_JOBTITLE_CODE,
                           ASSIGNEE_JOBTITLE_SHORTDESC = tb.ASSIGNEE_JOBTITLE_SHORTDESC,
                           PROGRESSSTS_CODE = tb.PROGRESSSTS_CODE,
                           PROGRESSSTS_SHORTDESC = tb.PROGRESSSTS_SHORTDESC,
                           PROGRESSSTS_DESC = tb.PROGRESSSTS_DESC,
                           VALIDATESTS_CODE = tb.VALIDATESTS_CODE,
                           VALIDATESTS_SHORTDESC = tb.VALIDATESTS_SHORTDESC,
                           VALIDATESTS_DESC = tb.VALIDATESTS_DESC,
                           PROJECT_CODE = tb.PROJECT_CODE,
                           PROJECT_SHORTDESC = tb.PROJECT_SHORTDESC,
                           PROJECT_DESC = tb.PROJECT_DESC
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<TaskdVM> fieldLookup()
        {
            IQueryable<TaskdVM> vReturn;

            var oQRY = from tb in this.db.Taskd_infos
                       select new TaskdVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           ASSIGNEE_ID = tb.ASSIGNEE_ID,
                           PROJECT_ID = tb.PROJECT_ID,
                           TASKD_PLANDESC = tb.TASKD_PLANDESC,
                           TASKD_PLANSTARTDT = tb.TASKD_PLANSTARTDT,
                           TASKD_PLANENDDT = tb.TASKD_PLANENDDT,
                           TASKD_PLANDURATION = tb.TASKD_PLANDURATION,
                           TASKD_PROGRESSSTS = tb.TASKD_PROGRESSSTS,
                           TASKD_PROGRESSPCT = tb.TASKD_PROGRESSPCT,
                           TASKD_PROGRESSDT = tb.TASKD_PROGRESSDT,
                           TASKD_PROGRESSFINISHDT = tb.TASKD_PROGRESSFINISHDT,
                           TASKD_PROGRESSDURATION = tb.TASKD_PROGRESSDURATION,
                           TASKD_PROGRESSNOTES = tb.TASKD_PROGRESSNOTES,
                           TASKD_VALIDATESTS = tb.TASKD_VALIDATESTS,
                           TASKD_VALIDATENOTES = tb.TASKD_VALIDATENOTES,
                           TASK_ID = tb.TASK_ID,
                           TASK_DTA_STS = tb.TASK_DTA_STS,
                           BRANCH_ID = tb.BRANCH_ID,
                           YEAR_ID = tb.YEAR_ID,
                           MONTH_ID = tb.MONTH_ID,
                           UNIT_ID = tb.UNIT_ID,
                           SUBUNIT_ID = tb.SUBUNIT_ID,
                           RES_ID = tb.RES_ID,
                           RESBOS_ID = tb.RESBOS_ID,
                           RESOWNER_ID = tb.RESOWNER_ID,
                           TASK_STS = tb.TASK_STS,
                           TASK_NO = tb.TASK_NO,
                           TASK_DT = tb.TASK_DT,
                           TASK_YEAR = tb.TASK_YEAR,
                           TASK_MONTH = tb.TASK_MONTH,
                           TASK_DESC = tb.TASK_DESC,
                           TASK_PRINTDT = tb.TASK_PRINTDT,
                           CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                           CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                           CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                           CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                           CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                           BRANCH_CODE = tb.BRANCH_CODE,
                           BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           BRANCH_SEQNO = tb.BRANCH_SEQNO,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           YEAR_CODE = tb.YEAR_CODE,
                           YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                           YEAR_DESC = tb.YEAR_DESC,
                           YEAR_FROM = tb.YEAR_FROM,
                           YEAR_TO = tb.YEAR_TO,
                           YEAR_NUM = tb.YEAR_NUM,
                           MONTH_CODE = tb.MONTH_CODE,
                           MONTH_SHORTDESC = tb.MONTH_SHORTDESC,
                           MONTH_DESC = tb.MONTH_DESC,
                           MONTH_NUM = tb.MONTH_NUM,
                           MONTH_SEQNO = tb.MONTH_SEQNO,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           SUBUNIT_DESC = tb.SUBUNIT_DESC,
                           SUBUNIT_SEQNO = tb.SUBUNIT_SEQNO,
                           RES_NAME = tb.RES_NAME,
                           RES_NICKNAME = tb.RES_NICKNAME,
                           RES_SEX_ID = tb.RES_SEX_ID,
                           RES_NIP = tb.RES_NIP,
                           RES_KTP = tb.RES_KTP,
                           RES_EMAIL = tb.RES_EMAIL,
                           RES_BRANCH_ID = tb.RES_BRANCH_ID,
                           RES_DEPT_ID = tb.RES_DEPT_ID,
                           RES_UNIT_ID = tb.RES_UNIT_ID,
                           RES_SUBUNIT_ID = tb.RES_SUBUNIT_ID,
                           RES_JOBTITLE_ID = tb.RES_JOBTITLE_ID,
                           RES_EMPLOYEE_IMG = tb.RES_EMPLOYEE_IMG,
                           RES_UNITCODE = tb.RES_UNITCODE,
                           RES_UNITSHORTDESC = tb.RES_UNITSHORTDESC,
                           RES_SUBUNITCODE = tb.RES_SUBUNITCODE,
                           RES_SUBUNITSHORTDESC = tb.RES_SUBUNITSHORTDESC,
                           RES_JOBTITLECODE = tb.RES_JOBTITLECODE,
                           RES_JOBTITLESHORTDESC = tb.RES_JOBTITLESHORTDESC,
                           RESBOS_NAME = tb.RESBOS_NAME,
                           RESBOS_NICKNAME = tb.RESBOS_NICKNAME,
                           RESBOS_EMAIL = tb.RESBOS_EMAIL,
                           RESBOS_BRANCH_ID = tb.RESBOS_BRANCH_ID,
                           RESBOS_DEPT_ID = tb.RESBOS_DEPT_ID,
                           RESBOS_UNIT_ID = tb.RESBOS_UNIT_ID,
                           RESBOS_SUBUNIT_ID = tb.RESBOS_SUBUNIT_ID,
                           RESBOS_JOBTITLE_ID = tb.RESBOS_JOBTITLE_ID,
                           RESBOS_EMPLOYEE_IMG = tb.RESBOS_EMPLOYEE_IMG,
                           RESBOS_UNITCODE = tb.RESBOS_UNITCODE,
                           RESBOS_UNITSHORTDESC = tb.RESBOS_UNITSHORTDESC,
                           RESBOS_SUBUNITCODE = tb.RESBOS_SUBUNITCODE,
                           RESBOS_SUBUNITSHORTDESC = tb.RESBOS_SUBUNITSHORTDESC,
                           RESBOS_JOBTITLECODE = tb.RESBOS_JOBTITLECODE,
                           RESBOS_JOBTITLESHORTDESC = tb.RESBOS_JOBTITLESHORTDESC,
                           RESOWNER_NAME = tb.RESOWNER_NAME,
                           RESOWNER_NICKNAME = tb.RESOWNER_NICKNAME,
                           RESOWNER_EMAIL = tb.RESOWNER_EMAIL,
                           RESOWNER_BRANCH_ID = tb.RESOWNER_BRANCH_ID,
                           RESOWNER_DEPT_ID = tb.RESOWNER_DEPT_ID,
                           RESOWNER_UNIT_ID = tb.RESOWNER_UNIT_ID,
                           RESOWNER_SUBUNIT_ID = tb.RESOWNER_SUBUNIT_ID,
                           RESOWNER_JOBTITLE_ID = tb.RESOWNER_JOBTITLE_ID,
                           RESOWNER_EMPLOYEE_IMG = tb.RESOWNER_EMPLOYEE_IMG,
                           RESOWNER_UNITCODE = tb.RESOWNER_UNITCODE,
                           RESOWNER_UNITSHORTDESC = tb.RESOWNER_UNITSHORTDESC,
                           RESOWNER_SUBUNITCODE = tb.RESOWNER_SUBUNITCODE,
                           RESOWNER_SUBUNITSHORTDESC = tb.RESOWNER_SUBUNITSHORTDESC,
                           RESOWNER_JOBTITLECODE = tb.RESOWNER_JOBTITLECODE,
                           RESOWNER_JOBTITLESHORTDESC = tb.RESOWNER_JOBTITLESHORTDESC,
                           ASSIGNEE_NAME = tb.ASSIGNEE_NAME,
                           ASSIGNEE_EMAIL = tb.ASSIGNEE_EMAIL,
                           ASSIGNEE_JOIN_DT = tb.ASSIGNEE_JOIN_DT,
                           ASSIGNEE_BRANCH_ID = tb.ASSIGNEE_BRANCH_ID,
                           ASSIGNEE_DEPT_ID = tb.ASSIGNEE_DEPT_ID,
                           ASSIGNEE_UNIT_ID = tb.ASSIGNEE_UNIT_ID,
                           ASSIGNEE_SUBUNIT_ID = tb.ASSIGNEE_SUBUNIT_ID,
                           ASSIGNEE_JOBTITLE_ID = tb.ASSIGNEE_JOBTITLE_ID,
                           ASSIGNEE_EMPLOYEE_IMG = tb.ASSIGNEE_EMPLOYEE_IMG,
                           ASSIGNEE_UNIT_CODE = tb.ASSIGNEE_UNIT_CODE,
                           ASSIGNEE_UNIT_SHORTDESC = tb.ASSIGNEE_UNIT_SHORTDESC,
                           ASSIGNEE_SUBUNIT_CODE = tb.ASSIGNEE_SUBUNIT_CODE,
                           ASSIGNEE_SUBUNIT_SHORTDESC = tb.ASSIGNEE_SUBUNIT_SHORTDESC,
                           ASSIGNEE_JOBTITLE_CODE = tb.ASSIGNEE_JOBTITLE_CODE,
                           ASSIGNEE_JOBTITLE_SHORTDESC = tb.ASSIGNEE_JOBTITLE_SHORTDESC,
                           PROGRESSSTS_CODE = tb.PROGRESSSTS_CODE,
                           PROGRESSSTS_SHORTDESC = tb.PROGRESSSTS_SHORTDESC,
                           PROGRESSSTS_DESC = tb.PROGRESSSTS_DESC,
                           VALIDATESTS_CODE = tb.VALIDATESTS_CODE,
                           VALIDATESTS_SHORTDESC = tb.VALIDATESTS_SHORTDESC,
                           VALIDATESTS_DESC = tb.VALIDATESTS_DESC,
                           PROJECT_CODE = tb.PROJECT_CODE,
                           PROJECT_SHORTDESC = tb.PROJECT_SHORTDESC,
                           PROJECT_DESC = tb.PROJECT_DESC
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<TaskdVM> fieldIndex()
        {
            IQueryable<TaskdVM> vReturn;

            var oQRY = from tb in this.db.Taskd_infos
                       select new TaskdVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           ASSIGNEE_ID = tb.ASSIGNEE_ID,
                           PROJECT_ID = tb.PROJECT_ID,
                           TASKD_PLANDESC = tb.TASKD_PLANDESC,
                           TASKD_PLANSTARTDT = tb.TASKD_PLANSTARTDT,
                           TASKD_PLANENDDT = tb.TASKD_PLANENDDT,
                           TASKD_PLANDURATION = tb.TASKD_PLANDURATION,
                           TASKD_PROGRESSSTS = tb.TASKD_PROGRESSSTS,
                           TASKD_PROGRESSPCT = tb.TASKD_PROGRESSPCT,
                           TASKD_PROGRESSDT = tb.TASKD_PROGRESSDT,
                           TASKD_PROGRESSFINISHDT = tb.TASKD_PROGRESSFINISHDT,
                           TASKD_PROGRESSDURATION = tb.TASKD_PROGRESSDURATION,
                           TASKD_PROGRESSNOTES = tb.TASKD_PROGRESSNOTES,
                           TASKD_VALIDATESTS = tb.TASKD_VALIDATESTS,
                           TASKD_VALIDATENOTES = tb.TASKD_VALIDATENOTES,
                           TASK_ID = tb.TASK_ID,
                           TASK_DTA_STS = tb.TASK_DTA_STS,
                           BRANCH_ID = tb.BRANCH_ID,
                           YEAR_ID = tb.YEAR_ID,
                           MONTH_ID = tb.MONTH_ID,
                           UNIT_ID = tb.UNIT_ID,
                           SUBUNIT_ID = tb.SUBUNIT_ID,
                           RES_ID = tb.RES_ID,
                           RESBOS_ID = tb.RESBOS_ID,
                           RESOWNER_ID = tb.RESOWNER_ID,
                           TASK_STS = tb.TASK_STS,
                           TASK_NO = tb.TASK_NO,
                           TASK_DT = tb.TASK_DT,
                           TASK_YEAR = tb.TASK_YEAR,
                           TASK_MONTH = tb.TASK_MONTH,
                           TASK_DESC = tb.TASK_DESC,
                           TASK_PRINTDT = tb.TASK_PRINTDT,
                           CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                           CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                           CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                           CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                           CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                           BRANCH_CODE = tb.BRANCH_CODE,
                           BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           BRANCH_SEQNO = tb.BRANCH_SEQNO,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           YEAR_CODE = tb.YEAR_CODE,
                           YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                           YEAR_DESC = tb.YEAR_DESC,
                           YEAR_FROM = tb.YEAR_FROM,
                           YEAR_TO = tb.YEAR_TO,
                           YEAR_NUM = tb.YEAR_NUM,
                           MONTH_CODE = tb.MONTH_CODE,
                           MONTH_SHORTDESC = tb.MONTH_SHORTDESC,
                           MONTH_DESC = tb.MONTH_DESC,
                           MONTH_NUM = tb.MONTH_NUM,
                           MONTH_SEQNO = tb.MONTH_SEQNO,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           SUBUNIT_DESC = tb.SUBUNIT_DESC,
                           SUBUNIT_SEQNO = tb.SUBUNIT_SEQNO,
                           RES_NAME = tb.RES_NAME,
                           RES_NICKNAME = tb.RES_NICKNAME,
                           RES_SEX_ID = tb.RES_SEX_ID,
                           RES_NIP = tb.RES_NIP,
                           RES_KTP = tb.RES_KTP,
                           RES_EMAIL = tb.RES_EMAIL,
                           RES_BRANCH_ID = tb.RES_BRANCH_ID,
                           RES_DEPT_ID = tb.RES_DEPT_ID,
                           RES_UNIT_ID = tb.RES_UNIT_ID,
                           RES_SUBUNIT_ID = tb.RES_SUBUNIT_ID,
                           RES_JOBTITLE_ID = tb.RES_JOBTITLE_ID,
                           RES_EMPLOYEE_IMG = tb.RES_EMPLOYEE_IMG,
                           RES_UNITCODE = tb.RES_UNITCODE,
                           RES_UNITSHORTDESC = tb.RES_UNITSHORTDESC,
                           RES_SUBUNITCODE = tb.RES_SUBUNITCODE,
                           RES_SUBUNITSHORTDESC = tb.RES_SUBUNITSHORTDESC,
                           RES_JOBTITLECODE = tb.RES_JOBTITLECODE,
                           RES_JOBTITLESHORTDESC = tb.RES_JOBTITLESHORTDESC,
                           RESBOS_NAME = tb.RESBOS_NAME,
                           RESBOS_NICKNAME = tb.RESBOS_NICKNAME,
                           RESBOS_EMAIL = tb.RESBOS_EMAIL,
                           RESBOS_BRANCH_ID = tb.RESBOS_BRANCH_ID,
                           RESBOS_DEPT_ID = tb.RESBOS_DEPT_ID,
                           RESBOS_UNIT_ID = tb.RESBOS_UNIT_ID,
                           RESBOS_SUBUNIT_ID = tb.RESBOS_SUBUNIT_ID,
                           RESBOS_JOBTITLE_ID = tb.RESBOS_JOBTITLE_ID,
                           RESBOS_EMPLOYEE_IMG = tb.RESBOS_EMPLOYEE_IMG,
                           RESBOS_UNITCODE = tb.RESBOS_UNITCODE,
                           RESBOS_UNITSHORTDESC = tb.RESBOS_UNITSHORTDESC,
                           RESBOS_SUBUNITCODE = tb.RESBOS_SUBUNITCODE,
                           RESBOS_SUBUNITSHORTDESC = tb.RESBOS_SUBUNITSHORTDESC,
                           RESBOS_JOBTITLECODE = tb.RESBOS_JOBTITLECODE,
                           RESBOS_JOBTITLESHORTDESC = tb.RESBOS_JOBTITLESHORTDESC,
                           RESOWNER_NAME = tb.RESOWNER_NAME,
                           RESOWNER_NICKNAME = tb.RESOWNER_NICKNAME,
                           RESOWNER_EMAIL = tb.RESOWNER_EMAIL,
                           RESOWNER_BRANCH_ID = tb.RESOWNER_BRANCH_ID,
                           RESOWNER_DEPT_ID = tb.RESOWNER_DEPT_ID,
                           RESOWNER_UNIT_ID = tb.RESOWNER_UNIT_ID,
                           RESOWNER_SUBUNIT_ID = tb.RESOWNER_SUBUNIT_ID,
                           RESOWNER_JOBTITLE_ID = tb.RESOWNER_JOBTITLE_ID,
                           RESOWNER_EMPLOYEE_IMG = tb.RESOWNER_EMPLOYEE_IMG,
                           RESOWNER_UNITCODE = tb.RESOWNER_UNITCODE,
                           RESOWNER_UNITSHORTDESC = tb.RESOWNER_UNITSHORTDESC,
                           RESOWNER_SUBUNITCODE = tb.RESOWNER_SUBUNITCODE,
                           RESOWNER_SUBUNITSHORTDESC = tb.RESOWNER_SUBUNITSHORTDESC,
                           RESOWNER_JOBTITLECODE = tb.RESOWNER_JOBTITLECODE,
                           RESOWNER_JOBTITLESHORTDESC = tb.RESOWNER_JOBTITLESHORTDESC,
                           ASSIGNEE_NAME = tb.ASSIGNEE_NAME,
                           ASSIGNEE_EMAIL = tb.ASSIGNEE_EMAIL,
                           ASSIGNEE_JOIN_DT = tb.ASSIGNEE_JOIN_DT,
                           ASSIGNEE_BRANCH_ID = tb.ASSIGNEE_BRANCH_ID,
                           ASSIGNEE_DEPT_ID = tb.ASSIGNEE_DEPT_ID,
                           ASSIGNEE_UNIT_ID = tb.ASSIGNEE_UNIT_ID,
                           ASSIGNEE_SUBUNIT_ID = tb.ASSIGNEE_SUBUNIT_ID,
                           ASSIGNEE_JOBTITLE_ID = tb.ASSIGNEE_JOBTITLE_ID,
                           ASSIGNEE_EMPLOYEE_IMG = tb.ASSIGNEE_EMPLOYEE_IMG,
                           ASSIGNEE_UNIT_CODE = tb.ASSIGNEE_UNIT_CODE,
                           ASSIGNEE_UNIT_SHORTDESC = tb.ASSIGNEE_UNIT_SHORTDESC,
                           ASSIGNEE_SUBUNIT_CODE = tb.ASSIGNEE_SUBUNIT_CODE,
                           ASSIGNEE_SUBUNIT_SHORTDESC = tb.ASSIGNEE_SUBUNIT_SHORTDESC,
                           ASSIGNEE_JOBTITLE_CODE = tb.ASSIGNEE_JOBTITLE_CODE,
                           ASSIGNEE_JOBTITLE_SHORTDESC = tb.ASSIGNEE_JOBTITLE_SHORTDESC,
                           PROGRESSSTS_CODE = tb.PROGRESSSTS_CODE,
                           PROGRESSSTS_SHORTDESC = tb.PROGRESSSTS_SHORTDESC,
                           PROGRESSSTS_DESC = tb.PROGRESSSTS_DESC,
                           VALIDATESTS_CODE = tb.VALIDATESTS_CODE,
                           VALIDATESTS_SHORTDESC = tb.VALIDATESTS_SHORTDESC,
                           VALIDATESTS_DESC = tb.VALIDATESTS_DESC,
                           PROJECT_CODE = tb.PROJECT_CODE,
                           PROJECT_SHORTDESC = tb.PROJECT_SHORTDESC,
                           PROJECT_DESC = tb.PROJECT_DESC
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<TaskdVM> getDatalist(IQueryable<TaskdVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) this.oDatalist = poFieldsToselect.ToList();
            this.oDatalist = this.fieldAll().ToList();
            this.dataListMutation();
            return this.oDatalist;
        } //End Method
        public List<TaskdVM> getDatalist_lookup(IQueryable<TaskdVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) this.oDatalist = poFieldsToselect.ToList();
            this.oDatalist = this.fieldLookup().ToList();
            this.dataListMutation();
            return this.oDatalist;
        } //End Method
        public TaskdVM getData(int? id, IQueryable<TaskdVM> poFieldsToselect = null)
        {
            IQueryable<TaskdVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            this.oData = oQRY.Where(fld => fld.ID == id).SingleOrDefault();
            //this.dataMutation();
            return this.oData;
        } //End Method

        public List<TaskdVM> getDatalist_byForeignId(int? ForaignId, IQueryable<TaskdVM> poFieldsToselect = null)
        {
            IQueryable<TaskdVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            this.oDatalist = oQRY.Where(fld => fld.TASK_ID == ForaignId).ToList();
            this.dataListMutation();
            return this.oDatalist;
        } //End Method
        public List<TaskdVM> getDatalist_byRES_ID(int? pnRES_ID, int? pnASSIGNEE_ID = null,
            IQueryable<TaskdVM> poFieldsToselect = null)
        {
            IQueryable<TaskdVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            oQRY = this.fieldAll();
            //RES_ID and ASSIGNEE_ID ( As Leader )
            if ((pnRES_ID != null) && (pnASSIGNEE_ID != null))
            {
                oQRY = oQRY.Where(fld => (fld.RES_ID == pnRES_ID) || (fld.ASSIGNEE_ID == pnASSIGNEE_ID));
            }
            else {
                //RES_ID
                if (pnRES_ID != null) oQRY = oQRY.Where(fld => fld.RES_ID == pnRES_ID);
                //ASSIGNEE_ID
                if (pnASSIGNEE_ID != null) oQRY = oQRY.Where(fld => fld.ASSIGNEE_ID == pnASSIGNEE_ID);
            } //endifelse
            
            this.oDatalist = oQRY.ToList();
            this.dataListMutation();
            return this.oDatalist;
        } //End Method
    } //End Class
} //End namespace
