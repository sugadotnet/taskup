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
    public class Taskd_summaryDS
    {
        private DBMAINContext db;
        public IQueryable<Taskd_summaryVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<Taskd_summaryVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public Taskd_summaryDS() { this.db = new DBMAINContext(); } //End Constructor Taskd_summaryDS
        //Constructor 2
        public Taskd_summaryDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<Taskd_summaryVM> fieldAll()
        {
            IQueryable<Taskd_summaryVM> vReturn;

            var oQRY = from tb in this.db.Taskd_summary_infos
                       select new Taskd_summaryVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           ASSIGNEE_ID = tb.ASSIGNEE_ID,
                           RES_ID = tb.RES_ID,
                           RESBOS_ID = tb.RESBOS_ID,
                           RESOWNER_ID = tb.RESOWNER_ID,
                           QTY_OPEN = tb.QTY_OPEN,
                           QTY_ONPROGRESS = tb.QTY_ONPROGRESS,
                           QTY_FINISH = tb.QTY_FINISH,
                           QTY_VALIDATED = tb.QTY_VALIDATED
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<Taskd_summaryVM> fieldLookup()
        {
            IQueryable<Taskd_summaryVM> vReturn;

            var oQRY = from tb in this.db.Taskd_summary_infos
                       select new Taskd_summaryVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           ASSIGNEE_ID = tb.ASSIGNEE_ID,
                           RES_ID = tb.RES_ID,
                           RESBOS_ID = tb.RESBOS_ID,
                           RESOWNER_ID = tb.RESOWNER_ID,
                           QTY_OPEN = tb.QTY_OPEN,
                           QTY_ONPROGRESS = tb.QTY_ONPROGRESS,
                           QTY_FINISH = tb.QTY_FINISH,
                           QTY_VALIDATED = tb.QTY_VALIDATED
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<Taskd_summaryVM> fieldIndex()
        {
            IQueryable<Taskd_summaryVM> vReturn;

            var oQRY = from tb in this.db.Taskd_summary_infos
                       select new Taskd_summaryVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           ASSIGNEE_ID = tb.ASSIGNEE_ID,
                           RES_ID = tb.RES_ID,
                           RESBOS_ID = tb.RESBOS_ID,
                           RESOWNER_ID = tb.RESOWNER_ID,
                           QTY_OPEN = tb.QTY_OPEN,
                           QTY_ONPROGRESS = tb.QTY_ONPROGRESS,
                           QTY_FINISH = tb.QTY_FINISH,
                           QTY_VALIDATED = tb.QTY_VALIDATED
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<Taskd_summaryVM> getDatalist(IQueryable<Taskd_summaryVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<Taskd_summaryVM> getDatalist_lookup(IQueryable<Taskd_summaryVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public Taskd_summaryVM getData(int? id, IQueryable<Taskd_summaryVM> poFieldsToselect = null)
        {
            IQueryable<Taskd_summaryVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method

        public List<Taskd_summaryVM> getDatalist_byRES_ID(int? pnRES_ID=null, int? pnASSIGNEE_ID=null,
            IQueryable<Taskd_summaryVM> poFieldsToselect = null)
        {
            IQueryable<Taskd_summaryVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            oQRY = this.fieldAll();

            if ((pnRES_ID != null) && (pnASSIGNEE_ID != null))
            {
                oQRY = oQRY.Where(fld => (fld.RES_ID == pnRES_ID) || (fld.ASSIGNEE_ID == pnASSIGNEE_ID));
            }
            else {
                if (pnRES_ID != null) oQRY = oQRY.Where(fld => fld.RES_ID == pnRES_ID);
                if (pnASSIGNEE_ID != null) oQRY = oQRY.Where(fld => fld.ASSIGNEE_ID == pnASSIGNEE_ID);
            } //end ifelse
            return oQRY.ToList();
        } //End Method
    } //End Class
} //End namespace
