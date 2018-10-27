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
    public class ProgressstsDS
    {
        private DBMAINContext db;
        public IQueryable<ProgressstsVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<ProgressstsVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public ProgressstsDS() { this.db = new DBMAINContext(); } //End Constructor ProgressstsDS
        //Constructor 2
        public ProgressstsDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<ProgressstsVM> fieldAll()
        {
            IQueryable<ProgressstsVM> vReturn;

            var oQRY = from tb in this.db.Progresssts_infos
                       select new ProgressstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           PROGRESSSTS_CODE = tb.PROGRESSSTS_CODE,
                           PROGRESSSTS_SHORTDESC = tb.PROGRESSSTS_SHORTDESC,
                           PROGRESSSTS_DESC = tb.PROGRESSSTS_DESC,
                           PROGRESSSTS_SEQNO = tb.PROGRESSSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<ProgressstsVM> fieldLookup()
        {
            IQueryable<ProgressstsVM> vReturn;

            var oQRY = from tb in this.db.Progresssts_infos
                       select new ProgressstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           PROGRESSSTS_CODE = tb.PROGRESSSTS_CODE,
                           PROGRESSSTS_SHORTDESC = tb.PROGRESSSTS_SHORTDESC,
                           PROGRESSSTS_DESC = tb.PROGRESSSTS_DESC,
                           PROGRESSSTS_SEQNO = tb.PROGRESSSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<ProgressstsVM> fieldIndex()
        {
            IQueryable<ProgressstsVM> vReturn;

            var oQRY = from tb in this.db.Progresssts_infos
                       select new ProgressstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           PROGRESSSTS_CODE = tb.PROGRESSSTS_CODE,
                           PROGRESSSTS_SHORTDESC = tb.PROGRESSSTS_SHORTDESC,
                           PROGRESSSTS_DESC = tb.PROGRESSSTS_DESC,
                           PROGRESSSTS_SEQNO = tb.PROGRESSSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<ProgressstsVM> getDatalist(IQueryable<ProgressstsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<ProgressstsVM> getDatalist_lookup(IQueryable<ProgressstsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public ProgressstsVM getData(int? id, IQueryable<ProgressstsVM> poFieldsToselect = null)
        {
            IQueryable<ProgressstsVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
