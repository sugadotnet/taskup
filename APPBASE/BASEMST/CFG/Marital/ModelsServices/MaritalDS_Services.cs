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
    public class MaritalDS
    {
        private DBMAINContext db;
        public IQueryable<MaritalVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<MaritalVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public MaritalDS() { this.db = new DBMAINContext(); } //End Constructor MaritalDS
        //Constructor 2
        public MaritalDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<MaritalVM> fieldAll()
        {
            IQueryable<MaritalVM> vReturn;

            var oQRY = from tb in this.db.Marital_infos
                       select new MaritalVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           MARITAL_CODE = tb.MARITAL_CODE,
                           MARITAL_SHORTDESC = tb.MARITAL_SHORTDESC,
                           MARITAL_DESC = tb.MARITAL_DESC,
                           MARITAL_SEQNO = tb.MARITAL_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<MaritalVM> fieldLookup()
        {
            IQueryable<MaritalVM> vReturn;

            var oQRY = from tb in this.db.Marital_infos
                       select new MaritalVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           MARITAL_CODE = tb.MARITAL_CODE,
                           MARITAL_SHORTDESC = tb.MARITAL_SHORTDESC,
                           MARITAL_DESC = tb.MARITAL_DESC,
                           MARITAL_SEQNO = tb.MARITAL_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<MaritalVM> fieldIndex()
        {
            IQueryable<MaritalVM> vReturn;

            var oQRY = from tb in this.db.Marital_infos
                       select new MaritalVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           MARITAL_CODE = tb.MARITAL_CODE,
                           MARITAL_SHORTDESC = tb.MARITAL_SHORTDESC,
                           MARITAL_DESC = tb.MARITAL_DESC,
                           MARITAL_SEQNO = tb.MARITAL_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<MaritalVM> getDatalist(IQueryable<MaritalVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<MaritalVM> getDatalist_lookup(IQueryable<MaritalVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public MaritalVM getData(int? id, IQueryable<MaritalVM> poFieldsToselect = null)
        {
            IQueryable<MaritalVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
