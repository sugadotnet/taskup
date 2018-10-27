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
    public class TaskreportDS
    {
        //DBContext
        private DBMAINContext db;
        //DATA
        private TaskVM oData;
        private List<TaskVM> oData_list;
        //DS
        private TaskDS oDS;
        private TaskdDS oDSDetail;

        //Constructor 1
        public TaskreportDS() {
            this.db = new DBMAINContext();
            this.oDS = new TaskDS(this.db);
            this.oDSDetail = new TaskdDS(this.db);
        } //End Constructor TaskreportDS
        //Constructor 2
        public TaskreportDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
            this.oDS = new TaskDS(this.db);
            this.oDSDetail = new TaskdDS(this.db);
        } //End Constructor
        //Constructor 3
        public TaskreportDS(DBMAINContext poDBMAINContext, TaskDS poDS, TaskdDS poDSDetail)
        {
            this.db = poDBMAINContext;
            this.oDS = poDS;
            this.oDSDetail = poDSDetail;
        } //End Constructor
        private IQueryable<TaskreportVM> fieldAll()
        {
            IQueryable<TaskreportVM> vReturn = null;

            //var oQRY = from tb in this.db.Taskreport_infos
            //           select new TaskreportVM
            //           {
            //           };
            //vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<TaskreportVM> fieldLookup()
        {
            IQueryable<TaskreportVM> vReturn = null;

            //var oQRY = from tb in this.db.Taskreport_infos
            //           select new TaskreportVM
            //           {
            //           };
            //vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<TaskreportVM> fieldIndex()
        {
            IQueryable<TaskreportVM> vReturn = null;

            //var oQRY = from tb in this.db.Taskreport_infos
            //           select new TaskreportVM
            //           {
            //           };
            //vReturn = oQRY;

            return vReturn;
        } //End Method

        public TaskVM getData(int? id, IQueryable<TaskVM> poFieldsToselect = null)
        {
            TaskVM oQRY = null;

            this.oData = this.oDS.getDataFirst_byRES_ID(id);
            if (this.oData != null) {
                this.oData.DETAIL = this.oDSDetail.getDatalist_byRES_ID(id);
                if ((hlpConfig.SessionInfo.getAppRoleId() == valROLE.ROLEID_LEADER) &&
                    (hlpConfig.SessionInfo.getAppResId() != id))
                {
                    this.oData.DETAIL = this.oData.DETAIL.Where(fld => fld.ASSIGNEE_ID == hlpConfig.SessionInfo.getAppResId()).ToList();
                } //end if

                if (this.oData.DETAIL == null) this.oData = null;
                else if (this.oData.DETAIL.Count == 0) this.oData = null;
            } //end if

            oQRY = this.oData;
            return oQRY;
        } //End Method
    } //End Class
} //End namespace
