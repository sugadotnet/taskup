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
    public class DeptDS
    {
        private DBMAINContext db;
        public IQueryable<DeptVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<DeptVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public DeptDS() { this.db = new DBMAINContext(); } //End Constructor DeptDS
        //Constructor 2
        public DeptDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<DeptVM> fieldAll()
        {
            IQueryable<DeptVM> vReturn;

            var oQRY = from tb in this.db.Dept_infos
                       select new DeptVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           DEPT_CODE = tb.DEPT_CODE,
                           DEPT_SHORTDESC = tb.DEPT_SHORTDESC,
                           DEPT_DESC = tb.DEPT_DESC,
                           DEPT_SEQNO = tb.DEPT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<DeptVM> fieldLookup()
        {
            IQueryable<DeptVM> vReturn;

            var oQRY = from tb in this.db.Dept_infos
                       select new DeptVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           DEPT_CODE = tb.DEPT_CODE,
                           DEPT_SHORTDESC = tb.DEPT_SHORTDESC,
                           DEPT_DESC = tb.DEPT_DESC,
                           DEPT_SEQNO = tb.DEPT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<DeptVM> fieldIndex()
        {
            IQueryable<DeptVM> vReturn;

            var oQRY = from tb in this.db.Dept_infos
                       select new DeptVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           DEPT_CODE = tb.DEPT_CODE,
                           DEPT_SHORTDESC = tb.DEPT_SHORTDESC,
                           DEPT_DESC = tb.DEPT_DESC,
                           DEPT_SEQNO = tb.DEPT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<DeptVM> getDatalist(IQueryable<DeptVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<DeptVM> getDatalist_lookup(IQueryable<DeptVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public DeptVM getData(int? id, IQueryable<DeptVM> poFieldsToselect = null)
        {
            IQueryable<DeptVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
