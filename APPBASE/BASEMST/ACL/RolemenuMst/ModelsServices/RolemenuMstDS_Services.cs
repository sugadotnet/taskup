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
    public partial class RolemenuMstDS: RolemenuCoreDS
    {
        protected List<int?> _DataMenuMst_list;

        //Constructor 1
        public RolemenuMstDS(): base() {
            this._DataMenuMst_list = new List<int?>();
        } //End Constructor
        //Constructor 2
        public RolemenuMstDS(List<RolemenuVM> Data_list, List<int?> DataMenuCore_list,
            List<int?> DataRole_list, List<int?> DataMenuMst_list):
            base(Data_list, DataMenuCore_list, DataRole_list) {
                this._DataMenuMst_list = DataMenuMst_list;
        } //End Constructor
        //Init Core Menu
        protected virtual void initDataMenu()
        {
            //Init Base Data Menu
            base.initDataMenu();
            //MST COMPANY - 2010
            this._DataMenuMst_list.Add(valMENU.MST);
            this._DataMenuMst_list.Add(valMENU.MST_COMPANY);
            this._DataMenuMst_list.Add(valMENU.MST_COMPANY_INDEX);
            this._DataMenuMst_list.Add(valMENU.MST_COMPANY_DETAILS);
            this._DataMenuMst_list.Add(valMENU.MST_COMPANY_CREATE);
            this._DataMenuMst_list.Add(valMENU.MST_COMPANY_EDIT);
            this._DataMenuMst_list.Add(valMENU.MST_COMPANY_DELETE);
            //MST DEPARTEMENT - 2020
            this._DataMenuMst_list.Add(valMENU.MST_DEPT);
            this._DataMenuMst_list.Add(valMENU.MST_DEPT_INDEX);
            this._DataMenuMst_list.Add(valMENU.MST_DEPT_DETAILS);
            this._DataMenuMst_list.Add(valMENU.MST_DEPT_CREATE);
            this._DataMenuMst_list.Add(valMENU.MST_DEPT_EDIT);
            this._DataMenuMst_list.Add(valMENU.MST_DEPT_DELETE);
            //MST UNIT - 2030
            this._DataMenuMst_list.Add(valMENU.MST_UNIT);
            this._DataMenuMst_list.Add(valMENU.MST_UNIT_INDEX);
            this._DataMenuMst_list.Add(valMENU.MST_UNIT_DETAILS);
            this._DataMenuMst_list.Add(valMENU.MST_UNIT_CREATE);
            this._DataMenuMst_list.Add(valMENU.MST_UNIT_EDIT);
            this._DataMenuMst_list.Add(valMENU.MST_UNIT_DELETE);
            //MST SUBUNIT - 2040
            this._DataMenuMst_list.Add(valMENU.MST_SUBUNIT);
            this._DataMenuMst_list.Add(valMENU.MST_SUBUNIT_INDEX);
            this._DataMenuMst_list.Add(valMENU.MST_SUBUNIT_DETAILS);
            this._DataMenuMst_list.Add(valMENU.MST_SUBUNIT_CREATE);
            this._DataMenuMst_list.Add(valMENU.MST_SUBUNIT_EDIT);
            this._DataMenuMst_list.Add(valMENU.MST_SUBUNIT_DELETE);
            //MST JOBTITLE - 2050
            this._DataMenuMst_list.Add(valMENU.MST_JOBTITLE);
            this._DataMenuMst_list.Add(valMENU.MST_JOBTITLE_INDEX);
            this._DataMenuMst_list.Add(valMENU.MST_JOBTITLE_DETAILS);
            this._DataMenuMst_list.Add(valMENU.MST_JOBTITLE_CREATE);
            this._DataMenuMst_list.Add(valMENU.MST_JOBTITLE_EDIT);
            this._DataMenuMst_list.Add(valMENU.MST_JOBTITLE_DELETE);
            //MST EMPLOYEE - 2060
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEE);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEE_INDEX);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEE_DETAILS);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEE_CREATE);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEE_EDIT);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEE_DELETE);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEE_ENABLE);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEE_DISABLE);
            //MST EMPLOYEEUSER - 2070
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEEUSER);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEEUSER_INDEX);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEEUSER_DETAILS);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEEUSER_CREATE);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEEUSER_EDIT);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEEUSER_DELETE);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEEUSER_ENABLE);
            this._DataMenuMst_list.Add(valMENU.MST_EMPLOYEEUSER_DISABLE);
        } //end method
    } //End public partial class
} //End namespace
