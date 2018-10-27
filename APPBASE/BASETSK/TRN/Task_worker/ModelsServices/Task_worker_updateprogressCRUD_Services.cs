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
        public void Update_progres(TaskdVM poViewModel)
        {
            try
            {
                this.oVM_detail = poViewModel;
                this.oData_detail = this.oDSDetail.getData(oVM_detail.ID);
                this.mapModel_detail_progress();
                this.oCRUD_detail.Update(this.oVM_detail);
                this.oCRUD_detail.Commit();
                this.ID = this.oVM_detail.TASK_ID;
                this.DETAIL_ID = this.oCRUD_detail.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        private void mapModel_detail_progress()
        {
            this.oData_detail.TASKD_PROGRESSSTS = this.oVM_detail.TASKD_PROGRESSSTS;
            this.oData_detail.TASKD_PROGRESSPCT = this.oVM_detail.TASKD_PROGRESSPCT;
            this.oData_detail.TASKD_PROGRESSDT = this.oVM_detail.TASKD_PROGRESSDT;
            this.oData_detail.TASKD_PROGRESSFINISHDT = this.oVM_detail.TASKD_PROGRESSDT;
            this.oData_detail.TASKD_PROGRESSNOTES = this.oVM_detail.TASKD_PROGRESSNOTES;
            this.setProgressSts();


            this.oVM_detail = this.oData_detail;
        } //End map

        private int? getProgressSts(DateTime? plandDate, DateTime? ProgressDate)
        {
            int? vReturn = null;

            //LATE
            if (ProgressDate > plandDate)
                vReturn = valFLAG.FLAG_PROGRESSSTS_LATE;
            //ONTIME
            if (ProgressDate == plandDate)
                vReturn = valFLAG.FLAG_PROGRESSSTS_ONTIME;
            //FAST
            if (ProgressDate < plandDate)
                vReturn = valFLAG.FLAG_PROGRESSSTS_FAST;

            return vReturn;
        }
        private void setProgressSts()
        {
            this.oData_detail.TASKD_PROGRESSSTS = (byte?)this.getProgressSts(this.oData_detail.TASKD_PLANENDDT,
                this.oData_detail.TASKD_PROGRESSFINISHDT);
        }
    } //End public class Task_workerCRUD
} //End namespace APPBASE.Models
