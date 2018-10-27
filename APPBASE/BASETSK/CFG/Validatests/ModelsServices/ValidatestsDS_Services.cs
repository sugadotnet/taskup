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
    public class ValidatestsDS
    {
        private DBMAINContext db;
        public IQueryable<ValidatestsVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<ValidatestsVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public ValidatestsDS() { this.db = new DBMAINContext(); } //End Constructor ValidatestsDS
        //Constructor 2
        public ValidatestsDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<ValidatestsVM> fieldAll()
        {
            IQueryable<ValidatestsVM> vReturn;

            var oQRY = from tb in this.db.Validatests_infos
                       select new ValidatestsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           VALIDATESTS_CODE = tb.VALIDATESTS_CODE,
                           VALIDATESTS_SHORTDESC = tb.VALIDATESTS_SHORTDESC,
                           VALIDATESTS_DESC = tb.VALIDATESTS_DESC,
                           VALIDATESTS_SEQNO = tb.VALIDATESTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<ValidatestsVM> fieldLookup()
        {
            IQueryable<ValidatestsVM> vReturn;

            var oQRY = from tb in this.db.Validatests_infos
                       select new ValidatestsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           VALIDATESTS_CODE = tb.VALIDATESTS_CODE,
                           VALIDATESTS_SHORTDESC = tb.VALIDATESTS_SHORTDESC,
                           VALIDATESTS_DESC = tb.VALIDATESTS_DESC,
                           VALIDATESTS_SEQNO = tb.VALIDATESTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<ValidatestsVM> fieldIndex()
        {
            IQueryable<ValidatestsVM> vReturn;

            var oQRY = from tb in this.db.Validatests_infos
                       select new ValidatestsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           VALIDATESTS_CODE = tb.VALIDATESTS_CODE,
                           VALIDATESTS_SHORTDESC = tb.VALIDATESTS_SHORTDESC,
                           VALIDATESTS_DESC = tb.VALIDATESTS_DESC,
                           VALIDATESTS_SEQNO = tb.VALIDATESTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<ValidatestsVM> getDatalist(IQueryable<ValidatestsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<ValidatestsVM> getDatalist_lookup(IQueryable<ValidatestsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public ValidatestsVM getData(int? id, IQueryable<ValidatestsVM> poFieldsToselect = null)
        {
            IQueryable<ValidatestsVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
