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
    public class TaskDS
    {
        private DBMAINContext db;
        public IQueryable<TaskVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<TaskVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public TaskDS() { this.db = new DBMAINContext(); } //End Constructor TaskDS
        //Constructor 2
        public TaskDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<TaskVM> fieldAll()
        {
            IQueryable<TaskVM> vReturn;

            var oQRY = from tb in this.db.Task_infos
                       select new TaskVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
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
                           RES_JOIN_DT = tb.RES_JOIN_DT,
                           RES_BRANCH_ID = tb.RES_BRANCH_ID,
                           RES_DEPT_ID = tb.RES_DEPT_ID,
                           RES_UNIT_ID = tb.RES_UNIT_ID,
                           RES_SUBUNIT_ID = tb.RES_SUBUNIT_ID,
                           RES_JOBTITLE_ID = tb.RES_JOBTITLE_ID,
                           RES_EMPLSTS_ID = tb.RES_EMPLSTS_ID,
                           RES_ACTIVESTS_ID = tb.RES_ACTIVESTS_ID,
                           RES_EMPLOYEE_IMG = tb.RES_EMPLOYEE_IMG,
                           RES_UNITCODE = tb.RES_UNITCODE,
                           RES_UNITSHORTDESC = tb.RES_UNITSHORTDESC,
                           RES_SUBUNITCODE = tb.RES_SUBUNITCODE,
                           RES_SUBUNITSHORTDESC = tb.RES_SUBUNITSHORTDESC,
                           RES_JOBTITLECODE = tb.RES_JOBTITLECODE,
                           RES_JOBTITLESHORTDESC = tb.RES_JOBTITLESHORTDESC,
                           RESBOS_NAME = tb.RESBOS_NAME,
                           RESBOS_NICKNAME = tb.RESBOS_NICKNAME,
                           RESBOS_SEX_ID = tb.RESBOS_SEX_ID,
                           RESBOS_NIP = tb.RESBOS_NIP,
                           RESBOS_KTP = tb.RESBOS_KTP,
                           RESBOS_EMAIL = tb.RESBOS_EMAIL,
                           RESBOS_JOIN_DT = tb.RESBOS_JOIN_DT,
                           RESBOS_BRANCH_ID = tb.RESBOS_BRANCH_ID,
                           RESBOS_DEPT_ID = tb.RESBOS_DEPT_ID,
                           RESBOS_UNIT_ID = tb.RESBOS_UNIT_ID,
                           RESBOS_SUBUNIT_ID = tb.RESBOS_SUBUNIT_ID,
                           RESBOS_JOBTITLE_ID = tb.RESBOS_JOBTITLE_ID,
                           RESBOS_EMPLSTS_ID = tb.RESBOS_EMPLSTS_ID,
                           RESBOS_ACTIVESTS_ID = tb.RESBOS_ACTIVESTS_ID,
                           RESBOS_EMPLOYEE_IMG = tb.RESBOS_EMPLOYEE_IMG,
                           RESBOS_UNITCODE = tb.RESBOS_UNITCODE,
                           RESBOS_UNITSHORTDESC = tb.RESBOS_UNITSHORTDESC,
                           RESBOS_SUBUNITCODE = tb.RESBOS_SUBUNITCODE,
                           RESBOS_SUBUNITSHORTDESC = tb.RESBOS_SUBUNITSHORTDESC,
                           RESBOS_JOBTITLECODE = tb.RESBOS_JOBTITLECODE,
                           RESBOS_JOBTITLESHORTDESC = tb.RESBOS_JOBTITLESHORTDESC,
                           RESOWNER_NAME = tb.RESOWNER_NAME,
                           RESOWNER_NICKNAME = tb.RESOWNER_NICKNAME,
                           RESOWNER_SEX_ID = tb.RESOWNER_SEX_ID,
                           RESOWNER_NIP = tb.RESOWNER_NIP,
                           RESOWNER_KTP = tb.RESOWNER_KTP,
                           RESOWNER_EMAIL = tb.RESOWNER_EMAIL,
                           RESOWNER_JOIN_DT = tb.RESOWNER_JOIN_DT,
                           RESOWNER_BRANCH_ID = tb.RESOWNER_BRANCH_ID,
                           RESOWNER_DEPT_ID = tb.RESOWNER_DEPT_ID,
                           RESOWNER_UNIT_ID = tb.RESOWNER_UNIT_ID,
                           RESOWNER_SUBUNIT_ID = tb.RESOWNER_SUBUNIT_ID,
                           RESOWNER_JOBTITLE_ID = tb.RESOWNER_JOBTITLE_ID,
                           RESOWNER_EMPLSTS_ID = tb.RESOWNER_EMPLSTS_ID,
                           RESOWNER_ACTIVESTS_ID = tb.RESOWNER_ACTIVESTS_ID,
                           RESOWNER_EMPLOYEE_IMG = tb.RESOWNER_EMPLOYEE_IMG,
                           RESOWNER_UNITCODE = tb.RESOWNER_UNITCODE,
                           RESOWNER_UNITSHORTDESC = tb.RESOWNER_UNITSHORTDESC,
                           RESOWNER_SUBUNITCODE = tb.RESOWNER_SUBUNITCODE,
                           RESOWNER_SUBUNITSHORTDESC = tb.RESOWNER_SUBUNITSHORTDESC,
                           RESOWNER_JOBTITLECODE = tb.RESOWNER_JOBTITLECODE,
                           RESOWNER_JOBTITLESHORTDESC = tb.RESOWNER_JOBTITLESHORTDESC
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<TaskVM> fieldLookup()
        {
            IQueryable<TaskVM> vReturn;

            var oQRY = from tb in this.db.Task_infos
                       select new TaskVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
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
                           RES_JOIN_DT = tb.RES_JOIN_DT,
                           RES_BRANCH_ID = tb.RES_BRANCH_ID,
                           RES_DEPT_ID = tb.RES_DEPT_ID,
                           RES_UNIT_ID = tb.RES_UNIT_ID,
                           RES_SUBUNIT_ID = tb.RES_SUBUNIT_ID,
                           RES_JOBTITLE_ID = tb.RES_JOBTITLE_ID,
                           RES_EMPLSTS_ID = tb.RES_EMPLSTS_ID,
                           RES_ACTIVESTS_ID = tb.RES_ACTIVESTS_ID,
                           RES_EMPLOYEE_IMG = tb.RES_EMPLOYEE_IMG,
                           RES_UNITCODE = tb.RES_UNITCODE,
                           RES_UNITSHORTDESC = tb.RES_UNITSHORTDESC,
                           RES_SUBUNITCODE = tb.RES_SUBUNITCODE,
                           RES_SUBUNITSHORTDESC = tb.RES_SUBUNITSHORTDESC,
                           RES_JOBTITLECODE = tb.RES_JOBTITLECODE,
                           RES_JOBTITLESHORTDESC = tb.RES_JOBTITLESHORTDESC,
                           RESBOS_NAME = tb.RESBOS_NAME,
                           RESBOS_NICKNAME = tb.RESBOS_NICKNAME,
                           RESBOS_SEX_ID = tb.RESBOS_SEX_ID,
                           RESBOS_NIP = tb.RESBOS_NIP,
                           RESBOS_KTP = tb.RESBOS_KTP,
                           RESBOS_EMAIL = tb.RESBOS_EMAIL,
                           RESBOS_JOIN_DT = tb.RESBOS_JOIN_DT,
                           RESBOS_BRANCH_ID = tb.RESBOS_BRANCH_ID,
                           RESBOS_DEPT_ID = tb.RESBOS_DEPT_ID,
                           RESBOS_UNIT_ID = tb.RESBOS_UNIT_ID,
                           RESBOS_SUBUNIT_ID = tb.RESBOS_SUBUNIT_ID,
                           RESBOS_JOBTITLE_ID = tb.RESBOS_JOBTITLE_ID,
                           RESBOS_EMPLSTS_ID = tb.RESBOS_EMPLSTS_ID,
                           RESBOS_ACTIVESTS_ID = tb.RESBOS_ACTIVESTS_ID,
                           RESBOS_EMPLOYEE_IMG = tb.RESBOS_EMPLOYEE_IMG,
                           RESBOS_UNITCODE = tb.RESBOS_UNITCODE,
                           RESBOS_UNITSHORTDESC = tb.RESBOS_UNITSHORTDESC,
                           RESBOS_SUBUNITCODE = tb.RESBOS_SUBUNITCODE,
                           RESBOS_SUBUNITSHORTDESC = tb.RESBOS_SUBUNITSHORTDESC,
                           RESBOS_JOBTITLECODE = tb.RESBOS_JOBTITLECODE,
                           RESBOS_JOBTITLESHORTDESC = tb.RESBOS_JOBTITLESHORTDESC,
                           RESOWNER_NAME = tb.RESOWNER_NAME,
                           RESOWNER_NICKNAME = tb.RESOWNER_NICKNAME,
                           RESOWNER_SEX_ID = tb.RESOWNER_SEX_ID,
                           RESOWNER_NIP = tb.RESOWNER_NIP,
                           RESOWNER_KTP = tb.RESOWNER_KTP,
                           RESOWNER_EMAIL = tb.RESOWNER_EMAIL,
                           RESOWNER_JOIN_DT = tb.RESOWNER_JOIN_DT,
                           RESOWNER_BRANCH_ID = tb.RESOWNER_BRANCH_ID,
                           RESOWNER_DEPT_ID = tb.RESOWNER_DEPT_ID,
                           RESOWNER_UNIT_ID = tb.RESOWNER_UNIT_ID,
                           RESOWNER_SUBUNIT_ID = tb.RESOWNER_SUBUNIT_ID,
                           RESOWNER_JOBTITLE_ID = tb.RESOWNER_JOBTITLE_ID,
                           RESOWNER_EMPLSTS_ID = tb.RESOWNER_EMPLSTS_ID,
                           RESOWNER_ACTIVESTS_ID = tb.RESOWNER_ACTIVESTS_ID,
                           RESOWNER_EMPLOYEE_IMG = tb.RESOWNER_EMPLOYEE_IMG,
                           RESOWNER_UNITCODE = tb.RESOWNER_UNITCODE,
                           RESOWNER_UNITSHORTDESC = tb.RESOWNER_UNITSHORTDESC,
                           RESOWNER_SUBUNITCODE = tb.RESOWNER_SUBUNITCODE,
                           RESOWNER_SUBUNITSHORTDESC = tb.RESOWNER_SUBUNITSHORTDESC,
                           RESOWNER_JOBTITLECODE = tb.RESOWNER_JOBTITLECODE,
                           RESOWNER_JOBTITLESHORTDESC = tb.RESOWNER_JOBTITLESHORTDESC
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<TaskVM> fieldIndex()
        {
            IQueryable<TaskVM> vReturn;

            var oQRY = from tb in this.db.Task_infos
                       select new TaskVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
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
                           RES_JOIN_DT = tb.RES_JOIN_DT,
                           RES_BRANCH_ID = tb.RES_BRANCH_ID,
                           RES_DEPT_ID = tb.RES_DEPT_ID,
                           RES_UNIT_ID = tb.RES_UNIT_ID,
                           RES_SUBUNIT_ID = tb.RES_SUBUNIT_ID,
                           RES_JOBTITLE_ID = tb.RES_JOBTITLE_ID,
                           RES_EMPLSTS_ID = tb.RES_EMPLSTS_ID,
                           RES_ACTIVESTS_ID = tb.RES_ACTIVESTS_ID,
                           RES_EMPLOYEE_IMG = tb.RES_EMPLOYEE_IMG,
                           RES_UNITCODE = tb.RES_UNITCODE,
                           RES_UNITSHORTDESC = tb.RES_UNITSHORTDESC,
                           RES_SUBUNITCODE = tb.RES_SUBUNITCODE,
                           RES_SUBUNITSHORTDESC = tb.RES_SUBUNITSHORTDESC,
                           RES_JOBTITLECODE = tb.RES_JOBTITLECODE,
                           RES_JOBTITLESHORTDESC = tb.RES_JOBTITLESHORTDESC,
                           RESBOS_NAME = tb.RESBOS_NAME,
                           RESBOS_NICKNAME = tb.RESBOS_NICKNAME,
                           RESBOS_SEX_ID = tb.RESBOS_SEX_ID,
                           RESBOS_NIP = tb.RESBOS_NIP,
                           RESBOS_KTP = tb.RESBOS_KTP,
                           RESBOS_EMAIL = tb.RESBOS_EMAIL,
                           RESBOS_JOIN_DT = tb.RESBOS_JOIN_DT,
                           RESBOS_BRANCH_ID = tb.RESBOS_BRANCH_ID,
                           RESBOS_DEPT_ID = tb.RESBOS_DEPT_ID,
                           RESBOS_UNIT_ID = tb.RESBOS_UNIT_ID,
                           RESBOS_SUBUNIT_ID = tb.RESBOS_SUBUNIT_ID,
                           RESBOS_JOBTITLE_ID = tb.RESBOS_JOBTITLE_ID,
                           RESBOS_EMPLSTS_ID = tb.RESBOS_EMPLSTS_ID,
                           RESBOS_ACTIVESTS_ID = tb.RESBOS_ACTIVESTS_ID,
                           RESBOS_EMPLOYEE_IMG = tb.RESBOS_EMPLOYEE_IMG,
                           RESBOS_UNITCODE = tb.RESBOS_UNITCODE,
                           RESBOS_UNITSHORTDESC = tb.RESBOS_UNITSHORTDESC,
                           RESBOS_SUBUNITCODE = tb.RESBOS_SUBUNITCODE,
                           RESBOS_SUBUNITSHORTDESC = tb.RESBOS_SUBUNITSHORTDESC,
                           RESBOS_JOBTITLECODE = tb.RESBOS_JOBTITLECODE,
                           RESBOS_JOBTITLESHORTDESC = tb.RESBOS_JOBTITLESHORTDESC,
                           RESOWNER_NAME = tb.RESOWNER_NAME,
                           RESOWNER_NICKNAME = tb.RESOWNER_NICKNAME,
                           RESOWNER_SEX_ID = tb.RESOWNER_SEX_ID,
                           RESOWNER_NIP = tb.RESOWNER_NIP,
                           RESOWNER_KTP = tb.RESOWNER_KTP,
                           RESOWNER_EMAIL = tb.RESOWNER_EMAIL,
                           RESOWNER_JOIN_DT = tb.RESOWNER_JOIN_DT,
                           RESOWNER_BRANCH_ID = tb.RESOWNER_BRANCH_ID,
                           RESOWNER_DEPT_ID = tb.RESOWNER_DEPT_ID,
                           RESOWNER_UNIT_ID = tb.RESOWNER_UNIT_ID,
                           RESOWNER_SUBUNIT_ID = tb.RESOWNER_SUBUNIT_ID,
                           RESOWNER_JOBTITLE_ID = tb.RESOWNER_JOBTITLE_ID,
                           RESOWNER_EMPLSTS_ID = tb.RESOWNER_EMPLSTS_ID,
                           RESOWNER_ACTIVESTS_ID = tb.RESOWNER_ACTIVESTS_ID,
                           RESOWNER_EMPLOYEE_IMG = tb.RESOWNER_EMPLOYEE_IMG,
                           RESOWNER_UNITCODE = tb.RESOWNER_UNITCODE,
                           RESOWNER_UNITSHORTDESC = tb.RESOWNER_UNITSHORTDESC,
                           RESOWNER_SUBUNITCODE = tb.RESOWNER_SUBUNITCODE,
                           RESOWNER_SUBUNITSHORTDESC = tb.RESOWNER_SUBUNITSHORTDESC,
                           RESOWNER_JOBTITLECODE = tb.RESOWNER_JOBTITLECODE,
                           RESOWNER_JOBTITLESHORTDESC = tb.RESOWNER_JOBTITLESHORTDESC
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<TaskVM> getDatalist(IQueryable<TaskVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<TaskVM> getDatalist_lookup(IQueryable<TaskVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public TaskVM getData(int? id, IQueryable<TaskVM> poFieldsToselect = null)
        {
            IQueryable<TaskVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
        public TaskVM getDataFirst_byRES_ID(int? id, IQueryable<TaskVM> poFieldsToselect = null)
        {
            IQueryable<TaskVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.RES_ID == id).FirstOrDefault();
        } //End Method
        public List<TaskVM> getDatalist_excludeRES_ID(int? pnRES_ID, IQueryable<TaskVM> poFieldsToselect = null)
        {
            List<TaskVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect.ToList();
            else oQRY = this.fieldAll().ToList();

            return oQRY.Where(fld => fld.RES_ID != pnRES_ID).ToList();
        } //End Method
    } //End Class
} //End namespace
