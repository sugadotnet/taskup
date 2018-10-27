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
    public partial class JobtitleController : Controller
    {
        //DBContext
        private DBMAINContext db = new DBMAINContext();
        //VM
        private JobtitleVM oVM;
        //DATA
        private JobtitleVM oData;
        private List<JobtitleVM> oData_list;
        //DS
        private JobtitleDS oDS;
        //CRUD
        private JobtitleCRUD oCRUD;
        //VALIDATION
        private Jobtitle_Validation oVAL;
        //BL
        //MAP

        //Init
        private void initConstructor(DBMAINContext poDB)
        {
            //DBContext
            this.db = poDB;
            //VM
            this.oVM = new JobtitleVM();
            //DS
            this.oDS = new JobtitleDS(this.db);
            //CRUD
            this.oCRUD = new JobtitleCRUD(this.db);

            //BL
            //MAP
        } //End initConstructor
        //Constructor 1
        public JobtitleController()
        {
            //DBContext
            this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public JobtitleController(DBMAINContext poDB)
        {
            //DBContext
            this.initConstructor(poDB);
        } //End Constructor 2

        //Prepare Lookup
        public void prepareLookup()
        {
            //ViewBag.SAMPLE = oDSSample.getDatalist_lookup();
        } //End prepareLookup()
        //Prepare Lookup Filter
        public void prepareLookupFilter()
        {
            //ViewBag.SAMPLE = oDSSample.getDatalist_lookup();
        } //End prepareLookupFilter()


        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.MST_JOBTITLE_INDEX;
            this.oData_list = oDS.getDatalist();
            return View(this.oData_list);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.MST_JOBTITLE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            return View(this.oData);
        }
        public ActionResult Create()
        {
            //Hardcode
            return RedirectToAction("Details", new { id = 1 });
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.MST_JOBTITLE_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            return View(this.oData);
        }
        public ActionResult Delete(int? id = null)
        {
            //Hardcode
            return RedirectToAction("Details", new { id = 1 });
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            return View(this.oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End Controller
} //End namespace