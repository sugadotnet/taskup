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
    public class TaskstsDS
    {
        private DBMAINContext db;
        public IQueryable<TaskstsVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<TaskstsVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public TaskstsDS() { this.db = new DBMAINContext(); } //End Constructor TaskstsDS
        //Constructor 2
        public TaskstsDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<TaskstsVM> fieldAll()
        {
            IQueryable<TaskstsVM> vReturn;

            var oQRY = from tb in this.db.Tasksts_infos
                       select new TaskstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           TASKSTS_CODE = tb.TASKSTS_CODE,
                           TASKSTS_SHORTDESC = tb.TASKSTS_SHORTDESC,
                           TASKSTS_DESC = tb.TASKSTS_DESC,
                           TASKSTS_SEQNO = tb.TASKSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<TaskstsVM> fieldLookup()
        {
            IQueryable<TaskstsVM> vReturn;

            var oQRY = from tb in this.db.Tasksts_infos
                       select new TaskstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           TASKSTS_CODE = tb.TASKSTS_CODE,
                           TASKSTS_SHORTDESC = tb.TASKSTS_SHORTDESC,
                           TASKSTS_DESC = tb.TASKSTS_DESC,
                           TASKSTS_SEQNO = tb.TASKSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<TaskstsVM> fieldIndex()
        {
            IQueryable<TaskstsVM> vReturn;

            var oQRY = from tb in this.db.Tasksts_infos
                       select new TaskstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           TASKSTS_CODE = tb.TASKSTS_CODE,
                           TASKSTS_SHORTDESC = tb.TASKSTS_SHORTDESC,
                           TASKSTS_DESC = tb.TASKSTS_DESC,
                           TASKSTS_SEQNO = tb.TASKSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<TaskstsVM> getDatalist(IQueryable<TaskstsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<TaskstsVM> getDatalist_lookup(IQueryable<TaskstsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public TaskstsVM getData(int? id, IQueryable<TaskstsVM> poFieldsToselect = null)
        {
            IQueryable<TaskstsVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
