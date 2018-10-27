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
    public partial class RoleDS
    {
        private DBMAINContext db;

        //Constructor 1
        public RoleDS() { this.db = new DBMAINContext(); } //End Constructor
        //Constructor 2
        public RoleDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor

        public List<RolelistVM> getDatalist()
        {
            List<RolelistVM> vReturn;
            var oQRY = from tb in this.db.Roles
                       select new RolelistVM
                       {
                           ID = tb.ID,
                           ROLE_CD = tb.ROLE_CD,
                           DISPLAY_NAME = tb.DISPLAY_NAME
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<RolelistVM> getDatalist()
        public RoledetailVM getData(int? id = null)
        {
            RoledetailVM oReturn;
            var oQRY = from tb in this.db.Roles
                       where tb.ID == id
                       select new RoledetailVM
                       {
                           ID = tb.ID,
                           MDLE_ID = tb.MDLE_ID,
                           ROLE_CD = tb.ROLE_CD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           SEQNO = tb.SEQNO
                       };
            oReturn = oQRY.SingleOrDefault();
            return oReturn;
        } //End public RoledetailVM getData(int? id = null)
        public List<RoleVM> getDatalist_lookup()
        {
            List<RoleVM> vReturn;
            var oQRY = from tb in this.db.Roles
                       select new RoleVM
                       {
                           ID = tb.ID,
                           ROLE_CD = tb.ROLE_CD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           SEQNO = tb.SEQNO
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<RolelookupVM> getDatalist_lookup()
        public List<RolelookupVM> getDatalistHQ_lookup()
        {
            List<RolelookupVM> vReturn;
            var idlist = new int?[] { 1,2,3};
            var oQRY = from tb in this.db.Roles
                       select new RolelookupVM
                       {
                           ID = tb.ID,
                           ROLE_CD = tb.ROLE_CD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           SEQNO = tb.SEQNO
                       };
            vReturn = oQRY.Where(fld => idlist.Contains(fld.ID)).ToList();
            return vReturn;
        } //End public List<RolelookupVM> getDatalistHQ_lookup()
        public List<RolelookupVM> getDatalistBRANCH_lookup()
        {
            List<RolelookupVM> vReturn;
            var idlist = new int?[] { 4, 5, 6 };
            var oQRY = from tb in this.db.Roles
                       select new RolelookupVM
                       {
                           ID = tb.ID,
                           ROLE_CD = tb.ROLE_CD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           SEQNO = tb.SEQNO
                       };
            vReturn = oQRY.Where(fld => idlist.Contains(fld.ID)).ToList();
            return vReturn;
        } //End public List<RolelookupVM> getDatalistBRANCH_lookup()
    } //End public class RoleDS
} //End namespace APPBASE.Models
