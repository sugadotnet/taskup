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
    public class CountryDS
    {
        private DBMAINContext db;
        public IQueryable<CountryVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<CountryVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public CountryDS() { this.db = new DBMAINContext(); } //End Constructor CountryDS
        //Constructor 2
        public CountryDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<CountryVM> fieldAll()
        {
            IQueryable<CountryVM> vReturn;

            var oQRY = from tb in this.db.Country_infos
                       select new CountryVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           COUNTRY_CODE = tb.COUNTRY_CODE,
                           COUNTRY_SHORTDESC = tb.COUNTRY_SHORTDESC,
                           COUNTRY_DESC = tb.COUNTRY_DESC,
                           COUNTRY_SEQNO = tb.COUNTRY_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<CountryVM> fieldLookup()
        {
            IQueryable<CountryVM> vReturn;

            var oQRY = from tb in this.db.Country_infos
                       select new CountryVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           COUNTRY_CODE = tb.COUNTRY_CODE,
                           COUNTRY_SHORTDESC = tb.COUNTRY_SHORTDESC,
                           COUNTRY_DESC = tb.COUNTRY_DESC,
                           COUNTRY_SEQNO = tb.COUNTRY_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<CountryVM> fieldIndex()
        {
            IQueryable<CountryVM> vReturn;

            var oQRY = from tb in this.db.Country_infos
                       select new CountryVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           COUNTRY_CODE = tb.COUNTRY_CODE,
                           COUNTRY_SHORTDESC = tb.COUNTRY_SHORTDESC,
                           COUNTRY_DESC = tb.COUNTRY_DESC,
                           COUNTRY_SEQNO = tb.COUNTRY_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<CountryVM> getDatalist(IQueryable<CountryVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<CountryVM> getDatalist_lookup(IQueryable<CountryVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public CountryVM getData(int? id, IQueryable<CountryVM> poFieldsToselect = null)
        {
            IQueryable<CountryVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
