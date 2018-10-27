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
    public class ReligionDS
    {
        private DBMAINContext db;
        public IQueryable<ReligionVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<ReligionVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public ReligionDS() { this.db = new DBMAINContext(); } //End Constructor ReligionDS
        //Constructor 2
        public ReligionDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<ReligionVM> fieldAll()
        {
            IQueryable<ReligionVM> vReturn;

            var oQRY = from tb in this.db.Religion_infos
                       select new ReligionVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           RELIGION_CODE = tb.RELIGION_CODE,
                           RELIGION_SHORTDESC = tb.RELIGION_SHORTDESC,
                           RELIGION_DESC = tb.RELIGION_DESC,
                           RELIGION_SEQNO = tb.RELIGION_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<ReligionVM> fieldLookup()
        {
            IQueryable<ReligionVM> vReturn;

            var oQRY = from tb in this.db.Religion_infos
                       select new ReligionVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           RELIGION_CODE = tb.RELIGION_CODE,
                           RELIGION_SHORTDESC = tb.RELIGION_SHORTDESC,
                           RELIGION_DESC = tb.RELIGION_DESC,
                           RELIGION_SEQNO = tb.RELIGION_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<ReligionVM> fieldIndex()
        {
            IQueryable<ReligionVM> vReturn;

            var oQRY = from tb in this.db.Religion_infos
                       select new ReligionVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           RELIGION_CODE = tb.RELIGION_CODE,
                           RELIGION_SHORTDESC = tb.RELIGION_SHORTDESC,
                           RELIGION_DESC = tb.RELIGION_DESC,
                           RELIGION_SEQNO = tb.RELIGION_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<ReligionVM> getDatalist(IQueryable<ReligionVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<ReligionVM> getDatalist_lookup(IQueryable<ReligionVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public ReligionVM getData(int? id, IQueryable<ReligionVM> poFieldsToselect = null)
        {
            IQueryable<ReligionVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
