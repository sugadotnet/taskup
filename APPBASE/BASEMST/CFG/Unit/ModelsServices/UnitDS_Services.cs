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
    public class UnitDS
    {
        private DBMAINContext db;
        public IQueryable<UnitVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<UnitVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public UnitDS() { this.db = new DBMAINContext(); } //End Constructor UnitDS
        //Constructor 2
        public UnitDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<UnitVM> fieldAll()
        {
            IQueryable<UnitVM> vReturn;

            var oQRY = from tb in this.db.Unit_infos
                       select new UnitVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<UnitVM> fieldLookup()
        {
            IQueryable<UnitVM> vReturn;

            var oQRY = from tb in this.db.Unit_infos
                       select new UnitVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<UnitVM> fieldIndex()
        {
            IQueryable<UnitVM> vReturn;

            var oQRY = from tb in this.db.Unit_infos
                       select new UnitVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<UnitVM> getDatalist(IQueryable<UnitVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<UnitVM> getDatalist_lookup(IQueryable<UnitVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public UnitVM getData(int? id, IQueryable<UnitVM> poFieldsToselect = null)
        {
            IQueryable<UnitVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
