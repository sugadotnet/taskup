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
    public class SubunitDS
    {
        private DBMAINContext db;
        public IQueryable<SubunitVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<SubunitVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public SubunitDS() { this.db = new DBMAINContext(); } //End Constructor SubunitDS
        //Constructor 2
        public SubunitDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<SubunitVM> fieldAll()
        {
            IQueryable<SubunitVM> vReturn;

            var oQRY = from tb in this.db.Subunit_infos
                       select new SubunitVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           SUBUNIT_DESC = tb.SUBUNIT_DESC,
                           SUBUNIT_SEQNO = tb.SUBUNIT_SEQNO,
                           UNIT_ID = tb.UNIT_ID,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<SubunitVM> fieldLookup()
        {
            IQueryable<SubunitVM> vReturn;

            var oQRY = from tb in this.db.Subunit_infos
                       select new SubunitVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           SUBUNIT_DESC = tb.SUBUNIT_DESC,
                           SUBUNIT_SEQNO = tb.SUBUNIT_SEQNO,
                           UNIT_ID = tb.UNIT_ID,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<SubunitVM> fieldIndex()
        {
            IQueryable<SubunitVM> vReturn;

            var oQRY = from tb in this.db.Subunit_infos
                       select new SubunitVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           SUBUNIT_CODE = tb.SUBUNIT_CODE,
                           SUBUNIT_SHORTDESC = tb.SUBUNIT_SHORTDESC,
                           SUBUNIT_DESC = tb.SUBUNIT_DESC,
                           SUBUNIT_SEQNO = tb.SUBUNIT_SEQNO,
                           UNIT_ID = tb.UNIT_ID,
                           UNIT_CODE = tb.UNIT_CODE,
                           UNIT_SHORTDESC = tb.UNIT_SHORTDESC,
                           UNIT_DESC = tb.UNIT_DESC,
                           UNIT_SEQNO = tb.UNIT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<SubunitVM> getDatalist(IQueryable<SubunitVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<SubunitVM> getDatalist_lookup(IQueryable<SubunitVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public SubunitVM getData(int? id, IQueryable<SubunitVM> poFieldsToselect = null)
        {
            IQueryable<SubunitVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
