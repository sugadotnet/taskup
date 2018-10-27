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
    public partial class RolemenuDS
    {
        private DBMAINContext db;
        public IQueryable<RolemenuVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<RolemenuVM> FIELD_INDEX { get { return this.fieldIndex(); } }

        //Constructor 1
        public RolemenuDS() { this.db = new DBMAINContext(); } //End Constructor
        //Constructor 2
        public RolemenuDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor

        private IQueryable<RolemenuVM> fieldAll()
        {
            IQueryable<RolemenuVM> vReturn;

            var oQRY = from tb in this.db.Rolemenus
                       select new RolemenuVM
                       {
                           ID = tb.ID,
                           MDLE_ID = tb.MDLE_ID,
                           ROLE_ID = tb.ROLE_ID,
                           MNU_ID = tb.MNU_ID
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<RolemenuVM> fieldLookup()
        {
            IQueryable<RolemenuVM> vReturn;

            var oQRY = from tb in this.db.Rolemenus
                       select new RolemenuVM
                       {
                           ID = tb.ID,
                           MDLE_ID = tb.MDLE_ID,
                           ROLE_ID = tb.ROLE_ID,
                           MNU_ID = tb.MNU_ID
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method
        private IQueryable<RolemenuVM> fieldIndex()
        {
            IQueryable<RolemenuVM> vReturn;

            var oQRY = from tb in this.db.Rolemenus
                       select new RolemenuVM
                       {
                           ID = tb.ID,
                           MDLE_ID = tb.MDLE_ID,
                           ROLE_ID = tb.ROLE_ID,
                           MNU_ID = tb.MNU_ID
                       };
            vReturn = oQRY;

            return vReturn;
        } //End Method

        public List<RolemenuVM> getDatalist(IQueryable<RolemenuVM> poFieldsToselect = null)
        {
            List<RolemenuVM> vReturn;
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldAll().ToList();
        } //End public List<RolemenulistVM> getDatalist()
        public RolemenuVM getData(int? id, IQueryable<RolemenuVM> poFieldsToselect = null)
        {
            IQueryable<RolemenuVM> oQRY = null;
            if (poFieldsToselect != null) oQRY = poFieldsToselect;
            else oQRY = this.fieldAll();
            return oQRY.Where(fld => fld.ID == id).SingleOrDefault();
        } //End public RolemenudetailVM getData(int? id = null)
        public List<RolemenuVM> getDatalist_lookup(IQueryable<RolemenuVM> poFieldsToselect = null)
        {
            if (poFieldsToselect != null) return poFieldsToselect.ToList();
            return this.fieldLookup().ToList();
        } //End public List<RolemenulookupVM> getDatalist_lookup()
        //Check Granted user to menu
        public Boolean isGranted_menu(int? pnRoleId = null, int? pnMenuId = null)
        {
            Boolean vReturn = false;
            var oQRY = (from tb in this.db.Rolemenus
                        where tb.ROLE_ID == pnRoleId && tb.MNU_ID == pnMenuId
                        select new { MNU_ID = tb.MNU_ID }).ToList();

            if (oQRY.Count > 0) { vReturn = true; }
            return vReturn;
        } //End public Boolean isExists_USR_ID(string id = null)
    } //End public partial class RolemenuDS
} //End namespace APPBASE.Models
