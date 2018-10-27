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
    public class ProjectDS
    {
        private DBMAINContext db;
        public IQueryable<ProjectVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<ProjectVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public ProjectDS() { this.db = new DBMAINContext(); } //End Constructor ProjectDS
        //Constructor 2
        public ProjectDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<ProjectVM> fieldAll()
        {
            IQueryable<ProjectVM> vReturn;

            var oQRY = from tb in this.db.Project_infos
                       select new ProjectVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           PROJECT_CODE = tb.PROJECT_CODE,
                           PROJECT_SHORTDESC = tb.PROJECT_SHORTDESC,
                           PROJECT_DESC = tb.PROJECT_DESC,
                           PROJECT_MAIN = tb.PROJECT_MAIN,
                           PROJECT_SEQNO = tb.PROJECT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<ProjectVM> fieldLookup()
        {
            IQueryable<ProjectVM> vReturn;

            var oQRY = from tb in this.db.Project_infos
                       select new ProjectVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           PROJECT_CODE = tb.PROJECT_CODE,
                           PROJECT_SHORTDESC = tb.PROJECT_SHORTDESC,
                           PROJECT_DESC = tb.PROJECT_DESC,
                           PROJECT_MAIN = tb.PROJECT_MAIN,
                           PROJECT_SEQNO = tb.PROJECT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<ProjectVM> fieldIndex()
        {
            IQueryable<ProjectVM> vReturn;

            var oQRY = from tb in this.db.Project_infos
                       select new ProjectVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           PROJECT_CODE = tb.PROJECT_CODE,
                           PROJECT_SHORTDESC = tb.PROJECT_SHORTDESC,
                           PROJECT_DESC = tb.PROJECT_DESC,
                           PROJECT_MAIN = tb.PROJECT_MAIN,
                           PROJECT_SEQNO = tb.PROJECT_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<ProjectVM> getDatalist(IQueryable<ProjectVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<ProjectVM> getDatalist_lookup(IQueryable<ProjectVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public ProjectVM getData(int? id, IQueryable<ProjectVM> poFieldsToselect = null)
        {
            IQueryable<ProjectVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
