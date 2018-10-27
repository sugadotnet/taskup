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
    public class BloodtypeDS
    {
        private DBMAINContext db;
        public IQueryable<BloodtypeVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<BloodtypeVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public BloodtypeDS() { this.db = new DBMAINContext(); } //End Constructor BloodtypeDS
        //Constructor 2
        public BloodtypeDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<BloodtypeVM> fieldAll()
        {
            IQueryable<BloodtypeVM> vReturn;

            var oQRY = from tb in this.db.Bloodtype_infos
                       select new BloodtypeVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BLOODTYPE_CODE = tb.BLOODTYPE_CODE,
                           BLOODTYPE_SHORTDESC = tb.BLOODTYPE_SHORTDESC,
                           BLOODTYPE_DESC = tb.BLOODTYPE_DESC,
                           BLOODTYPE_SEQNO = tb.BLOODTYPE_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<BloodtypeVM> fieldLookup()
        {
            IQueryable<BloodtypeVM> vReturn;

            var oQRY = from tb in this.db.Bloodtype_infos
                       select new BloodtypeVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BLOODTYPE_CODE = tb.BLOODTYPE_CODE,
                           BLOODTYPE_SHORTDESC = tb.BLOODTYPE_SHORTDESC,
                           BLOODTYPE_DESC = tb.BLOODTYPE_DESC,
                           BLOODTYPE_SEQNO = tb.BLOODTYPE_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<BloodtypeVM> fieldIndex()
        {
            IQueryable<BloodtypeVM> vReturn;

            var oQRY = from tb in this.db.Bloodtype_infos
                       select new BloodtypeVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BLOODTYPE_CODE = tb.BLOODTYPE_CODE,
                           BLOODTYPE_SHORTDESC = tb.BLOODTYPE_SHORTDESC,
                           BLOODTYPE_DESC = tb.BLOODTYPE_DESC,
                           BLOODTYPE_SEQNO = tb.BLOODTYPE_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<BloodtypeVM> getDatalist(IQueryable<BloodtypeVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<BloodtypeVM> getDatalist_lookup(IQueryable<BloodtypeVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public BloodtypeVM getData(int? id, IQueryable<BloodtypeVM> poFieldsToselect = null)
        {
            IQueryable<BloodtypeVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
