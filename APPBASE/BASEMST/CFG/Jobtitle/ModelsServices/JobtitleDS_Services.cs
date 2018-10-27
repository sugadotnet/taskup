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
    public class JobtitleDS
    {
        private DBMAINContext db;
        public IQueryable<JobtitleVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<JobtitleVM> FIELD_INDEX { get { return this.fieldIndex(); } }


        //Constructor 1
        public JobtitleDS() { this.db = new DBMAINContext(); } //End Constructor JobtitleDS
        //Constructor 2
        public JobtitleDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<JobtitleVM> fieldAll()
        {
            IQueryable<JobtitleVM> vReturn;

            var oQRY = from tb in this.db.Jobtitle_infos
                       select new JobtitleVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           JOBTITLE_CODE = tb.JOBTITLE_CODE,
                           JOBTITLE_SHORTDESC = tb.JOBTITLE_SHORTDESC,
                           JOBTITLE_DESC = tb.JOBTITLE_DESC,
                           JOBTITLE_SEQNO = tb.JOBTITLE_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<JobtitleVM> fieldLookup()
        {
            IQueryable<JobtitleVM> vReturn;

            var oQRY = from tb in this.db.Jobtitle_infos
                       select new JobtitleVM
                       {

                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           JOBTITLE_CODE = tb.JOBTITLE_CODE,
                           JOBTITLE_SHORTDESC = tb.JOBTITLE_SHORTDESC,
                           JOBTITLE_DESC = tb.JOBTITLE_DESC,
                           JOBTITLE_SEQNO = tb.JOBTITLE_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<JobtitleVM> fieldIndex()
        {
            IQueryable<JobtitleVM> vReturn;

            var oQRY = from tb in this.db.Jobtitle_infos
                       select new JobtitleVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           JOBTITLE_CODE = tb.JOBTITLE_CODE,
                           JOBTITLE_SHORTDESC = tb.JOBTITLE_SHORTDESC,
                           JOBTITLE_DESC = tb.JOBTITLE_DESC,
                           JOBTITLE_SEQNO = tb.JOBTITLE_SEQNO
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method


        public List<JobtitleVM> getDatalist(IQueryable<JobtitleVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End Method
        public List<JobtitleVM> getDatalist_lookup(IQueryable<JobtitleVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End Method
        public JobtitleVM getData(int? id, IQueryable<JobtitleVM> poFieldsToselect = null)
        {
            IQueryable<JobtitleVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();

            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End Method
    } //End Class
} //End namespace
