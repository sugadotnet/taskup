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
    public class SexDS
    {
        private DBMAINContext db;
        public IQueryable<SexVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<SexVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public SexDS() { this.db = new DBMAINContext(); } //End Constructor SexDS
        //Constructor 2
        public SexDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<SexVM> fieldAll()
        {
            IQueryable<SexVM> vReturn;

            var oQRY = from tb in this.db.Sex_infos
                       select new SexVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           SEX_CODE = tb.SEX_CODE,
                           SEX_SHORTDESC = tb.SEX_SHORTDESC,
                           SEX_DESC = tb.SEX_DESC,
                           SEX_SEQNO = tb.SEX_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<SexVM> fieldLookup()
        {
            IQueryable<SexVM> vReturn;

            var oQRY = from tb in this.db.Sex_infos
                       select new SexVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           SEX_CODE = tb.SEX_CODE,
                           SEX_SHORTDESC = tb.SEX_SHORTDESC,
                           SEX_DESC = tb.SEX_DESC,
                           SEX_SEQNO = tb.SEX_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<SexVM> fieldIndex()
        {
            IQueryable<SexVM> vReturn;

            var oQRY = from tb in this.db.Sex_infos
                       select new SexVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           SEX_CODE = tb.SEX_CODE,
                           SEX_SHORTDESC = tb.SEX_SHORTDESC,
                           SEX_DESC = tb.SEX_DESC,
                           SEX_SEQNO = tb.SEX_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<SexVM> getDatalist(IQueryable<SexVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<SexVM> getDatalist_lookup(IQueryable<SexVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public SexVM getData(int? id, IQueryable<SexVM> poFieldsToselect = null)
        {
            IQueryable<SexVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
