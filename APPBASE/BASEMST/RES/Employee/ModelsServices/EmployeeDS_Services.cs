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
    public class EmployeeDS
    {
        private DBMAINContext db;
        public IQueryable<EmployeeVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<EmployeeVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public EmployeeDS() { this.db = new DBMAINContext(); } //End Constructor EmployeeDS
        //Constructor 2
        public EmployeeDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<EmployeeVM> fieldAll()
        {
            IQueryable<EmployeeVM> vReturn;

            var oQRY = from tb in this.db.Employee_infos
                       select new EmployeeVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           NAME = tb.NAME,
                           NICKNAME = tb.NICKNAME,
                           SEX_ID = tb.SEX_ID,
                           BLOOD_TYPE_ID = tb.BLOOD_TYPE_ID,
                           MARITAL_ID = tb.MARITAL_ID,
                           RELIGION_ID = tb.RELIGION_ID,
                           NATIONALITY_ID = tb.NATIONALITY_ID,
                           NATIONALITY_OTHER = tb.NATIONALITY_OTHER,
                           LANGUAGE = tb.LANGUAGE,
                           ETHNIC = tb.ETHNIC,
                           NIP = tb.NIP,
                           KTP = tb.KTP,
                           NPWP = tb.NPWP,
                           POB = tb.POB,
                           DOB = tb.DOB,
                           ADDR_COUNTRY_ID = tb.ADDR_COUNTRY_ID,
                           ADDR_COUNTRY_OTHER = tb.ADDR_COUNTRY_OTHER,
                           ADDR_CITY = tb.ADDR_CITY,
                           ADDR_KEC = tb.ADDR_KEC,
                           ADDR_KEL = tb.ADDR_KEL,
                           ADDR_ZIP = tb.ADDR_ZIP,
                           ADDR_STREET1 = tb.ADDR_STREET1,
                           ADDR_STREET2 = tb.ADDR_STREET2,
                           HOME_PHONE = tb.HOME_PHONE,
                           CELL_PHONE = tb.CELL_PHONE,
                           EMAIL = tb.EMAIL,
                           JOIN_DT = tb.JOIN_DT,
                           BRANCH_ID = tb.BRANCH_ID,
                           DEPT_ID = tb.DEPT_ID,
                           UNIT_ID = tb.UNIT_ID,
                           SUBUNIT_ID = tb.SUBUNIT_ID,
                           JOBTITLE_ID = tb.JOBTITLE_ID,
                           EMPLSTS_ID = tb.EMPLSTS_ID,
                           ACTIVESTS_ID = tb.ACTIVESTS_ID,
                           EMPLOYEE_IMG = tb.EMPLOYEE_IMG,
                           SUPERIOR_ID = tb.SUPERIOR_ID,
                           SEX_CODE = tb.SEX_CODE,
                           SEX_SHORTDESC = tb.SEX_SHORTDESC,
                           SEX_DESC = tb.SEX_DESC,
                           SEX_SEQNO = tb.SEX_SEQNO,
                           BLOODTYPE_CODE = tb.BLOODTYPE_CODE,
                           BLOODTYPE_SHORTDESC = tb.BLOODTYPE_SHORTDESC,
                           BLOODTYPE_DESC = tb.BLOODTYPE_DESC,
                           BLOODTYPE_SEQNO = tb.BLOODTYPE_SEQNO,
                           MARITAL_CODE = tb.MARITAL_CODE,
                           MARITAL_SHORTDESC = tb.MARITAL_SHORTDESC,
                           MARITAL_DESC = tb.MARITAL_DESC,
                           MARITAL_SEQNO = tb.MARITAL_SEQNO,
                           RELIGION_CODE = tb.RELIGION_CODE,
                           RELIGION_SHORTDESC = tb.RELIGION_SHORTDESC,
                           RELIGION_DESC = tb.RELIGION_DESC,
                           RELIGION_SEQNO = tb.RELIGION_SEQNO,
                           NATIONALITY_CODE = tb.NATIONALITY_CODE,
                           NATIONALITY_SHORTDESC = tb.NATIONALITY_SHORTDESC,
                           NATIONALITY_DESC = tb.NATIONALITY_DESC,
                           NATIONALITY_SEQNO = tb.NATIONALITY_SEQNO,
                           ADDR_COUNTRY_CODE = tb.ADDR_COUNTRY_CODE,
                           ADDR_COUNTRY_SHORTDESC = tb.ADDR_COUNTRY_SHORTDESC,
                           ADDR_COUNTRY_DESC = tb.ADDR_COUNTRY_DESC,
                           ADDR_COUNTRY_SEQNO = tb.ADDR_COUNTRY_SEQNO,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           SUBUNIT_DESC = tb.SUBUNIT_DESC,
                           SUBUNIT_SEQNO = tb.SUBUNIT_SEQNO,
                           JOBTITLE_CODE = tb.JOBTITLE_CODE,
                           JOBTITLE_SHORTDESC = tb.JOBTITLE_SHORTDESC,
                           JOBTITLE_DESC = tb.JOBTITLE_DESC,
                           JOBTITLE_SEQNO = tb.JOBTITLE_SEQNO,
                           EMPSTS_CODE = tb.EMPSTS_CODE,
                           EMPSTS_SHORTDESC = tb.EMPSTS_SHORTDESC,
                           EMPSTS_DESC = tb.EMPSTS_DESC,
                           EMPSTS_SEQNO = tb.EMPSTS_SEQNO,
                           EMPACTIVESTS_CODE = tb.EMPACTIVESTS_CODE,
                           EMPACTIVESTS_SHORTDESC = tb.EMPACTIVESTS_SHORTDESC,
                           EMPACTIVESTS_DESC = tb.EMPACTIVESTS_DESC,
                           EMPACTIVESTS_SEQNO = tb.EMPACTIVESTS_SEQNO,
                           SUPERIOR_NAME = tb.SUPERIOR_NAME,
                           SUPERIOR_SEXID = tb.SUPERIOR_SEXID,
                           SUPERIOR_BRANCHID = tb.SUPERIOR_BRANCHID,
                           SUPERIOR_DEPTID = tb.SUPERIOR_DEPTID,
                           SUPERIOR_UNITID = tb.SUPERIOR_UNITID,
                           SUPERIOR_SUBUNITID = tb.SUPERIOR_SUBUNITID,
                           SUPERIOR_JOBTITLEID = tb.SUPERIOR_JOBTITLEID,
                           SUPERIOR_EMPLSTSID = tb.SUPERIOR_EMPLSTSID,
                           SUPERIOR_ACTIVESTSID = tb.SUPERIOR_ACTIVESTSID,
                           SUPERIOR_IMG = tb.SUPERIOR_IMG,
                           SUPERIOR_SEXCODE = tb.SUPERIOR_SEXCODE,
                           SUPERIOR_SEXSHORTDESC = tb.SUPERIOR_SEXSHORTDESC,
                           SUPERIOR_SEXDESC = tb.SUPERIOR_SEXDESC,
                           SUPERIOR_UNITCODE = tb.SUPERIOR_UNITCODE,
                           SUPERIOR_UNITSHORTDESC = tb.SUPERIOR_UNITSHORTDESC,
                           SUPERIOR_UNITDESC = tb.SUPERIOR_UNITDESC,
                           SUPERIOR_JOBTITLECODE = tb.SUPERIOR_JOBTITLECODE,
                           SUPERIOR_JOBTITLESHORTDESC = tb.SUPERIOR_JOBTITLESHORTDESC,
                           SUPERIOR_JOBTITLEDESC = tb.SUPERIOR_JOBTITLEDESC
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<EmployeeVM> fieldLookup()
        {
            IQueryable<EmployeeVM> vReturn;

            var oQRY = from tb in this.db.Employee_infos
                       select new EmployeeVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           NAME = tb.NAME,
                           NICKNAME = tb.NICKNAME,
                           EMAIL = tb.EMAIL,
                           BRANCH_ID = tb.BRANCH_ID,
                           DEPT_ID = tb.DEPT_ID,
                           UNIT_ID = tb.UNIT_ID,
                           SUBUNIT_ID = tb.SUBUNIT_ID,
                           JOBTITLE_ID = tb.JOBTITLE_ID,
                           EMPLSTS_ID = tb.EMPLSTS_ID,
                           ACTIVESTS_ID = tb.ACTIVESTS_ID,
                           EMPLOYEE_IMG = tb.EMPLOYEE_IMG,
                           SUPERIOR_ID = tb.SUPERIOR_ID,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           JOBTITLE_CODE = tb.JOBTITLE_CODE,
                           JOBTITLE_SHORTDESC = tb.JOBTITLE_SHORTDESC,
                           EMPSTS_CODE = tb.EMPSTS_CODE,
                           EMPSTS_SHORTDESC = tb.EMPSTS_SHORTDESC,
                           EMPACTIVESTS_CODE = tb.EMPACTIVESTS_CODE,
                           EMPACTIVESTS_SHORTDESC = tb.EMPACTIVESTS_SHORTDESC,
                           SUPERIOR_NAME = tb.SUPERIOR_NAME,
                           SUPERIOR_BRANCHID = tb.SUPERIOR_BRANCHID,
                           SUPERIOR_DEPTID = tb.SUPERIOR_DEPTID,
                           SUPERIOR_UNITID = tb.SUPERIOR_UNITID,
                           SUPERIOR_SUBUNITID = tb.SUPERIOR_SUBUNITID,
                           SUPERIOR_JOBTITLEID = tb.SUPERIOR_JOBTITLEID,
                           SUPERIOR_EMPLSTSID = tb.SUPERIOR_EMPLSTSID,
                           SUPERIOR_ACTIVESTSID = tb.SUPERIOR_ACTIVESTSID,
                           SUPERIOR_IMG = tb.SUPERIOR_IMG,
                           SUPERIOR_UNITCODE = tb.SUPERIOR_UNITCODE,
                           SUPERIOR_UNITSHORTDESC = tb.SUPERIOR_UNITSHORTDESC,
                           SUPERIOR_JOBTITLECODE = tb.SUPERIOR_JOBTITLECODE,
                           SUPERIOR_JOBTITLESHORTDESC = tb.SUPERIOR_JOBTITLESHORTDESC,
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<EmployeeVM> fieldIndex()
        {
            IQueryable<EmployeeVM> vReturn;

            var oQRY = from tb in this.db.Employee_infos
                       select new EmployeeVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           NAME = tb.NAME,
                           NICKNAME = tb.NICKNAME,
                           SEX_ID = tb.SEX_ID,
                           BLOOD_TYPE_ID = tb.BLOOD_TYPE_ID,
                           MARITAL_ID = tb.MARITAL_ID,
                           RELIGION_ID = tb.RELIGION_ID,
                           NATIONALITY_ID = tb.NATIONALITY_ID,
                           NATIONALITY_OTHER = tb.NATIONALITY_OTHER,
                           LANGUAGE = tb.LANGUAGE,
                           ETHNIC = tb.ETHNIC,
                           NIP = tb.NIP,
                           KTP = tb.KTP,
                           NPWP = tb.NPWP,
                           POB = tb.POB,
                           DOB = tb.DOB,
                           ADDR_COUNTRY_ID = tb.ADDR_COUNTRY_ID,
                           ADDR_COUNTRY_OTHER = tb.ADDR_COUNTRY_OTHER,
                           ADDR_CITY = tb.ADDR_CITY,
                           ADDR_KEC = tb.ADDR_KEC,
                           ADDR_KEL = tb.ADDR_KEL,
                           ADDR_ZIP = tb.ADDR_ZIP,
                           ADDR_STREET1 = tb.ADDR_STREET1,
                           ADDR_STREET2 = tb.ADDR_STREET2,
                           HOME_PHONE = tb.HOME_PHONE,
                           CELL_PHONE = tb.CELL_PHONE,
                           EMAIL = tb.EMAIL,
                           JOIN_DT = tb.JOIN_DT,
                           BRANCH_ID = tb.BRANCH_ID,
                           DEPT_ID = tb.DEPT_ID,
                           UNIT_ID = tb.UNIT_ID,
                           SUBUNIT_ID = tb.SUBUNIT_ID,
                           JOBTITLE_ID = tb.JOBTITLE_ID,
                           EMPLSTS_ID = tb.EMPLSTS_ID,
                           ACTIVESTS_ID = tb.ACTIVESTS_ID,
                           EMPLOYEE_IMG = tb.EMPLOYEE_IMG,
                           SUPERIOR_ID = tb.SUPERIOR_ID,
                           SEX_CODE = tb.SEX_CODE,
                           SEX_SHORTDESC = tb.SEX_SHORTDESC,
                           SEX_DESC = tb.SEX_DESC,
                           SEX_SEQNO = tb.SEX_SEQNO,
                           BLOODTYPE_CODE = tb.BLOODTYPE_CODE,
                           BLOODTYPE_SHORTDESC = tb.BLOODTYPE_SHORTDESC,
                           BLOODTYPE_DESC = tb.BLOODTYPE_DESC,
                           BLOODTYPE_SEQNO = tb.BLOODTYPE_SEQNO,
                           MARITAL_CODE = tb.MARITAL_CODE,
                           MARITAL_SHORTDESC = tb.MARITAL_SHORTDESC,
                           MARITAL_DESC = tb.MARITAL_DESC,
                           MARITAL_SEQNO = tb.MARITAL_SEQNO,
                           RELIGION_CODE = tb.RELIGION_CODE,
                           RELIGION_SHORTDESC = tb.RELIGION_SHORTDESC,
                           RELIGION_DESC = tb.RELIGION_DESC,
                           RELIGION_SEQNO = tb.RELIGION_SEQNO,
                           NATIONALITY_CODE = tb.NATIONALITY_CODE,
                           NATIONALITY_SHORTDESC = tb.NATIONALITY_SHORTDESC,
                           NATIONALITY_DESC = tb.NATIONALITY_DESC,
                           NATIONALITY_SEQNO = tb.NATIONALITY_SEQNO,
                           ADDR_COUNTRY_CODE = tb.ADDR_COUNTRY_CODE,
                           ADDR_COUNTRY_SHORTDESC = tb.ADDR_COUNTRY_SHORTDESC,
                           ADDR_COUNTRY_DESC = tb.ADDR_COUNTRY_DESC,
                           ADDR_COUNTRY_SEQNO = tb.ADDR_COUNTRY_SEQNO,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           SUBUNIT_DESC = tb.SUBUNIT_DESC,
                           SUBUNIT_SEQNO = tb.SUBUNIT_SEQNO,
                           JOBTITLE_CODE = tb.JOBTITLE_CODE,
                           JOBTITLE_SHORTDESC = tb.JOBTITLE_SHORTDESC,
                           JOBTITLE_DESC = tb.JOBTITLE_DESC,
                           JOBTITLE_SEQNO = tb.JOBTITLE_SEQNO,
                           EMPSTS_CODE = tb.EMPSTS_CODE,
                           EMPSTS_SHORTDESC = tb.EMPSTS_SHORTDESC,
                           EMPSTS_DESC = tb.EMPSTS_DESC,
                           EMPSTS_SEQNO = tb.EMPSTS_SEQNO,
                           EMPACTIVESTS_CODE = tb.EMPACTIVESTS_CODE,
                           EMPACTIVESTS_SHORTDESC = tb.EMPACTIVESTS_SHORTDESC,
                           EMPACTIVESTS_DESC = tb.EMPACTIVESTS_DESC,
                           EMPACTIVESTS_SEQNO = tb.EMPACTIVESTS_SEQNO,
                           SUPERIOR_NAME = tb.SUPERIOR_NAME,
                           SUPERIOR_SEXID = tb.SUPERIOR_SEXID,
                           SUPERIOR_BRANCHID = tb.SUPERIOR_BRANCHID,
                           SUPERIOR_DEPTID = tb.SUPERIOR_DEPTID,
                           SUPERIOR_UNITID = tb.SUPERIOR_UNITID,
                           SUPERIOR_SUBUNITID = tb.SUPERIOR_SUBUNITID,
                           SUPERIOR_JOBTITLEID = tb.SUPERIOR_JOBTITLEID,
                           SUPERIOR_EMPLSTSID = tb.SUPERIOR_EMPLSTSID,
                           SUPERIOR_ACTIVESTSID = tb.SUPERIOR_ACTIVESTSID,
                           SUPERIOR_IMG = tb.SUPERIOR_IMG,
                           SUPERIOR_SEXCODE = tb.SUPERIOR_SEXCODE,
                           SUPERIOR_SEXSHORTDESC = tb.SUPERIOR_SEXSHORTDESC,
                           SUPERIOR_SEXDESC = tb.SUPERIOR_SEXDESC,
                           SUPERIOR_UNITCODE = tb.SUPERIOR_UNITCODE,
                           SUPERIOR_UNITSHORTDESC = tb.SUPERIOR_UNITSHORTDESC,
                           SUPERIOR_UNITDESC = tb.SUPERIOR_UNITDESC,
                           SUPERIOR_JOBTITLECODE = tb.SUPERIOR_JOBTITLECODE,
                           SUPERIOR_JOBTITLESHORTDESC = tb.SUPERIOR_JOBTITLESHORTDESC,
                           SUPERIOR_JOBTITLEDESC = tb.SUPERIOR_JOBTITLEDESC
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<EmployeeVM> getDatalist(IQueryable<EmployeeVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<EmployeeVM> getDatalist_lookup(IQueryable<EmployeeVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public EmployeeVM getData(int? id, IQueryable<EmployeeVM> poFieldsToselect = null)
        {
            IQueryable<EmployeeVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method

        public List<EmployeeVM> getDatalist_lookupBySeperiorId(int? pnSuperiorId, IQueryable<EmployeeVM> poFieldsToselect = null)
        {
            IQueryable<EmployeeVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();
            oQRY = oQRY.Where(fld => fld.SUPERIOR_ID == pnSuperiorId);
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return oQRY.ToList();
        } //End Method
    } //End Class
} //End namespace
