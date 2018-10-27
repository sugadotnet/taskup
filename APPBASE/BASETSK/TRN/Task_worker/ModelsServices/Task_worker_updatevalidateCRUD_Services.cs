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
using Omu.ValueInjecter;

namespace APPBASE.Models
{
    public partial class Task_workerCRUD
    {
        public void Update_validate(TaskdVM poViewModel)
        {
            try
            {
                this.oVM_detail = poViewModel;
                this.oData_detail = this.oDSDetail.getData(oVM_detail.ID);
                this.mapModel_detail_validate();
                this.oCRUD_detail.Update(this.oVM_detail);
                this.oCRUD_detail.Commit();
                this.ID = this.oVM_detail.TASK_ID;
                this.DETAIL_ID = this.oCRUD_detail.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update

        private void mapModel_detail_validate()
        {
            this.oData_detail.TASKD_VALIDATESTS = this.oVM_detail.TASKD_VALIDATESTS;
            this.oData_detail.TASKD_VALIDATENOTES = this.oVM_detail.TASKD_VALIDATENOTES;
            this.oVM_detail = this.oData_detail;
        } //End map
        
    } //End public class Task_workerCRUD
} //End namespace APPBASE.Models
