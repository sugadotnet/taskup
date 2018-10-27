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
    public class BranchDS
    {
        private DBMAINContext db;
        public IQueryable<BranchVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<BranchVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public BranchDS() { this.db = new DBMAINContext(); } //End Constructor BranchDS
        //Constructor 2
        public BranchDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<BranchVM> fieldAll()
        {
            IQueryable<BranchVM> vReturn;

            var oQRY = from tb in this.db.Branch_infos
                       select new BranchVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BRANCH_CODE = tb.BRANCH_CODE,
                           BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           BRANCH_SEQNO = tb.BRANCH_SEQNO,
                           BRANCH_TYPE = tb.BRANCH_TYPE
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<BranchVM> fieldLookup()
        {
            IQueryable<BranchVM> vReturn;

            var oQRY = from tb in this.db.Branch_infos
                       select new BranchVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BRANCH_CODE = tb.BRANCH_CODE,
                           BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           BRANCH_SEQNO = tb.BRANCH_SEQNO,
                           BRANCH_TYPE = tb.BRANCH_TYPE
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<BranchVM> fieldIndex()
        {
            IQueryable<BranchVM> vReturn;

            var oQRY = from tb in this.db.Branch_infos
                       select new BranchVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           BRANCH_CODE = tb.BRANCH_CODE,
                           BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           BRANCH_SEQNO = tb.BRANCH_SEQNO,
                           BRANCH_TYPE = tb.BRANCH_TYPE
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<BranchVM> getDatalist(IQueryable<BranchVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<BranchVM> getDatalist_lookup(IQueryable<BranchVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public BranchVM getData(int? id, IQueryable<BranchVM> poFieldsToselect = null)
        {
            IQueryable<BranchVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
