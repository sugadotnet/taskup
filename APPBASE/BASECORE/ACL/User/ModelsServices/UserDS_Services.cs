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
    public class UserDS
    {
        private DBMAINContext db;
        public IQueryable<UserVM> FIELD_LOOKUP { get { return this.fieldLookup(); } }
        public IQueryable<UserVM> FIELD_INDEX { get { return this.fieldIndex(); } }
        
        //Constructor 1
        public UserDS() { this.db = new DBMAINContext(); } //End Constructor
        //Constructor 2
        public UserDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor
        private IQueryable<UserVM> fieldAll()
        {
            IQueryable<UserVM> vReturn;

            var oQRY = from tb in this.db.User_infos
                       select new UserVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           RES_ID = tb.RES_ID,
                           ROLE_ID = tb.ROLE_ID,
                           USERNAME = tb.USERNAME,
                           PASSWORD = tb.PASSWORD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           EMAIL = tb.EMAIL,
                           USER_STS = tb.USER_STS,
                           USER_IMG = tb.USER_IMG,
                           BRANCH_ID = tb.BRANCH_ID,
                           MDLE_ID = tb.MDLE_ID,
                           ROLE_CD = tb.ROLE_CD,
                           ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           RES_NIP = tb.RES_NIP,
                           RES_NAME = tb.RES_NAME
                       };
            vReturn = oQRY;
            return vReturn;
        } //End Method
        private IQueryable<UserVM> fieldLookup()
        {
            IQueryable<UserVM> vReturn;

            var oQRY = from tb in this.db.User_infos
                       select new UserVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           RES_ID = tb.RES_ID,
                           ROLE_ID = tb.ROLE_ID,
                           USERNAME = tb.USERNAME,
                           PASSWORD = tb.PASSWORD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           EMAIL = tb.EMAIL,
                           USER_STS = tb.USER_STS,
                           USER_IMG = tb.USER_IMG,
                           BRANCH_ID = tb.BRANCH_ID,
                           MDLE_ID = tb.MDLE_ID,
                           ROLE_CD = tb.ROLE_CD,
                           ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           RES_NIP = tb.RES_NIP,
                           RES_NAME = tb.RES_NAME
                       };
            vReturn = oQRY;
            return vReturn;
        } //End Method
        private IQueryable<UserVM> fieldIndex()
        {
            IQueryable<UserVM> vReturn;

            var oQRY = from tb in this.db.User_infos
                       select new UserVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           RES_ID = tb.RES_ID,
                           ROLE_ID = tb.ROLE_ID,
                           USERNAME = tb.USERNAME,
                           PASSWORD = tb.PASSWORD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           EMAIL = tb.EMAIL,
                           USER_STS = tb.USER_STS,
                           USER_IMG = tb.USER_IMG,
                           BRANCH_ID = tb.BRANCH_ID,
                           MDLE_ID = tb.MDLE_ID,
                           ROLE_CD = tb.ROLE_CD,
                           ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           RES_NIP = tb.RES_NIP,
                           RES_NAME = tb.RES_NAME
                       };
            vReturn = oQRY;
            return vReturn;
        } //End Method
        
        //Data List
        public List<UserdetailVM> getDatalist()
        {
            List<UserdetailVM> vReturn;
            var oQRY = from tb in this.db.User_infos
                       select new UserdetailVM
                       {
                           ID = tb.ID,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           USERNAME = tb.USERNAME,
                           USER_IMG = tb.USER_IMG,
                           ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                           USER_STS = tb.USER_STS
                       };
            vReturn = oQRY.ToList();
            return vReturn;
        } //End public List<User_ListVM> getDatalist()
        
        //Data Single
        public UserdetailVM getData(int? id = null)
        {
            UserdetailVM oReturn;
            var oQRY = from tb in this.db.User_infos
                       where tb.ID == id
                       select new UserdetailVM
                       {
                           ID = tb.ID,
                           DTA_STS = tb.DTA_STS,
                           RES_ID = tb.RES_ID,
                           ROLE_ID = tb.ROLE_ID,
                           USERNAME = tb.USERNAME,
                           PASSWORD = tb.PASSWORD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           EMAIL = tb.EMAIL,
                           USER_STS = tb.USER_STS,
                           USER_IMG = tb.USER_IMG,
                           BRANCH_ID = tb.BRANCH_ID,
                           MDLE_ID = tb.MDLE_ID,
                           ROLE_CD = tb.ROLE_CD,
                           ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                           BRANCH_TYPE = tb.BRANCH_TYPE,
                           BRANCH_DESC = tb.BRANCH_DESC,
                           RES_NIP = tb.RES_NIP,
                           RES_NAME = tb.RES_NAME
                       };
            oReturn = oQRY.SingleOrDefault();
            oReturn.PASSWORD = hlpObf.randomDecrypt(oReturn.PASSWORD);
            return oReturn;
        } //End public User_DetailVM getData(string id = null)
        public UsercredentialVM getData_Usercredential(string psUsername = null)
        {
            UsercredentialVM oReturn;
            var oQRY = from tb in this.db.Users
                       where tb.USERNAME.ToUpper() == psUsername.ToUpper()
                       select new UsercredentialVM
                       {
                           RES_ID = tb.RES_ID,
                           USERNAME = tb.USERNAME,
                           PASSWORD = tb.PASSWORD,
                           DISPLAY_NAME = tb.DISPLAY_NAME,
                           ID = tb.ID,
                           ROLE_ID = tb.ROLE_ID,
                           USER_IMG = tb.USER_IMG
                       };
            oReturn = oQRY.SingleOrDefault();
            return oReturn;
        } //End public User_DetailVM getData(string id = null)
        public UserdetailVM getData_RES_ID(int? id = null)
        {
            UserdetailVM oReturn;
            var oQRY = from tb in this.db.User_infos
                       where tb.ID == id
                       select new UserdetailVM { RES_ID = tb.RES_ID };
            oReturn = oQRY.SingleOrDefault();
            return oReturn;
        } //End public UserdetailVM getData_RES_ID(int? id = null)

        //Check Exists
        public Boolean isExists_Username(string psUsername = null)
        {
            var oQRY = (from tb in this.db.User_infos
                        where tb.USERNAME == psUsername
                        select new { USERNAME = tb.USERNAME }).ToList();

            if (oQRY.Count > 0) { return true; }
            return false;
        } //End public Boolean isExists_USR_ID(string id = null)
        public Boolean isExists_Email(string psEmail = null)
        {
            var oQRY = (from tb in this.db.User_infos
                        where tb.EMAIL == psEmail
                        select new { EMAIL = tb.EMAIL }).ToList();

            if (oQRY.Count > 0) { return true; }
            return false;
        } //End public Boolean isExists_USR_ID(string id = null)
        //Check Granted user to menu
        public Boolean isGranted_menu(int? pnRoleId = null, int? pnMenuId = null)
        {
            Boolean vReturn = false;
            //var oQRY = (from tb in this.db.Usermenus
            //            where tb.MNU_RUID == id && tb.MDLE_RUID == sMDLE_RUID && tb.USR_RUID == sUSR_RUID
            //            select new { MNU_RUID = tb.MNU_RUID }).ToList();

            //if (oQRY.Count > 0) { vReturn = true; }
            return vReturn;
        } //End public Boolean isExists_USR_ID(string id = null)
    } //End public class UserDS
} //End namespace APPBASE.Models

