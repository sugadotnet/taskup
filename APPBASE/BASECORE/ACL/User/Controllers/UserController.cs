using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
using APPBASE.Svcapp;

namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class UserController : Controller
    {
        //DBContext
        private DBMAINContext db = new DBMAINContext();
        //DS
        private UserDS oDS;
        private RoleDS oDSRole;
        //CRUD
        private UserCRUD oCRUD;
        //Validation
        private User_Validation oVAL;
        public int? ROLE_ID { get; set; }

        //Init
        private void initConstructor(DBMAINContext poDB)
        {
            //DBContext
            this.db = poDB;
            //DS
            this.oDS = new UserDS(this.db);
            this.oDSRole = new RoleDS();
            //CRUD
            this.oCRUD = new UserCRUD(this.db);
            //BL
            //MAP
        } //End initConstructor
        //Constructor 1
        public UserController()
        {
            //DBContext
            this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public UserController(DBMAINContext poDB)
        {
            //DBContext
            this.initConstructor(poDB);
        } //End Constructor 2
        //Prepare Lookup
        public void prepareLookup()
        {
            //ViewBag.SAMPLE = oDSSample.getDatalist_lookup();
            ViewBag.ROLE = oDSRole.getDatalist_lookup();
        } //End prepareLookup()
        //Prepare Lookup Filter
        public void prepareLookupFilter()
        {
            //ViewBag.SAMPLE = oDSSample.getDatalist_lookup();
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.CORE_USER_INDEX;
            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.CORE_USER_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        public ActionResult Create()
        {
            //ViewBag.AC_MENU_ID = valMENU.CORE_USER_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            prepareLookup();
            return View(new UserdetailVM());
        }
        public ActionResult Edit(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.CORE_USER_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.CORE_USER_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        public ActionResult Activate(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.CORE_USER_ENABLE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            //var oData = oDS.getDataCPAR(id);
            //if (oData == null) { return HttpNotFound(); }
            //if (oData.BP_STS == valFLAG.FLAG_ACTIVE) { oData.BP_STS_NM = lblFIELD.USR_STS_ACTIVE; }
            //else { oData.BP_STS_NM = lblFIELD.USR_STS_INACTIVE; }

            //return View(oData);
            prepareLookup();
            return View();
        }
        public ActionResult Deactivate(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.CORE_USER_DISABLE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            //var oData = oDS.getDataCPAR(id);
            //if (oData == null) { return HttpNotFound(); }
            //if (oData.BP_STS == valFLAG.FLAG_ACTIVE) { oData.BP_STS_NM = lblFIELD.USR_STS_ACTIVE; }
            //else { oData.BP_STS_NM = lblFIELD.USR_STS_INACTIVE; }

            //return View(oData);
            prepareLookup();
            return View();
        }
        public ActionResult Changepassword(int id)
        {
            if (id != hlpConfig.SessionInfo.getAppUserId())
            {
                return RedirectToAction("Error403", "Error");
            } //End if (id != hlpConfig.SessionInfo.getAppUserId())

            UserChangepasswordVM oData = new UserChangepasswordVM();
            oData.ID = id;
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class UsercparController : Controller
} //End namespace APPBASE.Controllers