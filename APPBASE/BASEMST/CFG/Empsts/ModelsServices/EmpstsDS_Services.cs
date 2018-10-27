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
    public class EmpstsDS
    {
        private DBMAINContext db;
        public IQueryable<EmpstsVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<EmpstsVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public EmpstsDS() { this.db = new DBMAINContext(); } //End Constructor EmpstsDS
        //Constructor 2
        public EmpstsDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<EmpstsVM> fieldAll()
        {
            IQueryable<EmpstsVM> vReturn;

            var oQRY = from tb in this.db.Empsts_infos
                       select new EmpstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           EMPSTS_CODE = tb.EMPSTS_CODE,
                           EMPSTS_SHORTDESC = tb.EMPSTS_SHORTDESC,
                           EMPSTS_DESC = tb.EMPSTS_DESC,
                           EMPSTS_SEQNO = tb.EMPSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<EmpstsVM> fieldLookup()
        {
            IQueryable<EmpstsVM> vReturn;

            var oQRY = from tb in this.db.Empsts_infos
                       select new EmpstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           EMPSTS_CODE = tb.EMPSTS_CODE,
                           EMPSTS_SHORTDESC = tb.EMPSTS_SHORTDESC,
                           EMPSTS_DESC = tb.EMPSTS_DESC,
                           EMPSTS_SEQNO = tb.EMPSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<EmpstsVM> fieldIndex()
        {
            IQueryable<EmpstsVM> vReturn;

            var oQRY = from tb in this.db.Empsts_infos
                       select new EmpstsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           EMPSTS_CODE = tb.EMPSTS_CODE,
                           EMPSTS_SHORTDESC = tb.EMPSTS_SHORTDESC,
                           EMPSTS_DESC = tb.EMPSTS_DESC,
                           EMPSTS_SEQNO = tb.EMPSTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<EmpstsVM> getDatalist(IQueryable<EmpstsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<EmpstsVM> getDatalist_lookup(IQueryable<EmpstsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public EmpstsVM getData(int? id, IQueryable<EmpstsVM> poFieldsToselect = null)
        {
            IQueryable<EmpstsVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
