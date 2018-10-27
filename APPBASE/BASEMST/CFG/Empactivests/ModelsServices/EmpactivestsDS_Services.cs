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
    public class EmpactivestsDS
    {
        private DBMAINContext db;
        public IQueryable<EmpactivestsVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<EmpactivestsVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public EmpactivestsDS() { this.db = new DBMAINContext(); } //End Constructor EmpactivestsDS
        //Constructor 2
        public EmpactivestsDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<EmpactivestsVM> fieldAll()
        {
            IQueryable<EmpactivestsVM> vReturn;

            var oQRY = from tb in this.db.Empactivests_infos
                       select new EmpactivestsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           EMPACTIVESTS_CODE = tb.EMPACTIVESTS_CODE,
                           EMPACTIVESTS_SHORTDESC = tb.EMPACTIVESTS_SHORTDESC,
                           EMPACTIVESTS_DESC = tb.EMPACTIVESTS_DESC,
                           EMPACTIVESTS_SEQNO = tb.EMPACTIVESTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<EmpactivestsVM> fieldLookup()
        {
            IQueryable<EmpactivestsVM> vReturn;

            var oQRY = from tb in this.db.Empactivests_infos
                       select new EmpactivestsVM
                       {

                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           EMPACTIVESTS_CODE = tb.EMPACTIVESTS_CODE,
                           EMPACTIVESTS_SHORTDESC = tb.EMPACTIVESTS_SHORTDESC,
                           EMPACTIVESTS_DESC = tb.EMPACTIVESTS_DESC,
                           EMPACTIVESTS_SEQNO = tb.EMPACTIVESTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<EmpactivestsVM> fieldIndex()
        {
            IQueryable<EmpactivestsVM> vReturn;

            var oQRY = from tb in this.db.Empactivests_infos
                       select new EmpactivestsVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           EMPACTIVESTS_CODE = tb.EMPACTIVESTS_CODE,
                           EMPACTIVESTS_SHORTDESC = tb.EMPACTIVESTS_SHORTDESC,
                           EMPACTIVESTS_DESC = tb.EMPACTIVESTS_DESC,
                           EMPACTIVESTS_SEQNO = tb.EMPACTIVESTS_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<EmpactivestsVM> getDatalist(IQueryable<EmpactivestsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<EmpactivestsVM> getDatalist_lookup(IQueryable<EmpactivestsVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public EmpactivestsVM getData(int? id, IQueryable<EmpactivestsVM> poFieldsToselect = null)
        {
            IQueryable<EmpactivestsVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
