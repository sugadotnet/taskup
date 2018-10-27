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
    public partial class EmployeeuserController : Controller
    {
        //DBContext
        private DBMAINContext db = new DBMAINContext();
        //VM
        private EmployeeuserVM oVM;
        //DATA
        private EmployeeuserVM oData;
        private List<EmployeeuserVM> oData_list;
        //DS
        private EmployeeuserDS oDS;
        private UnitDS oDSUnit;
        private JobtitleDS oDSJobtitle;
        private RoleDS oDSRole;

        //CRUD
        private EmployeeuserCRUD oCRUD;
        //VALIDATION
        private Employeeuser_Validation oVAL;
        //BL
        //MAP


        //Init
        private void initConstructor(DBMAINContext poDB)
        {
            //DBContext
            this.db = poDB;
            //VM
            this.oVM = new EmployeeuserVM();
            //DS
            this.oDS = new EmployeeuserDS(this.db);
            this.oDSUnit = new UnitDS(this.db);
            this.oDSJobtitle = new JobtitleDS(this.db);
            this.oDSRole = new RoleDS(this.db);
            //CRUD
            this.oCRUD = new EmployeeuserCRUD(this.db);

            //BL
            //MAP
        } //End initConstructor
        //Constructor 1
        public EmployeeuserController()
        {
            //DBContext
            this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public EmployeeuserController(DBMAINContext poDB)
        {
            //DBContext
            this.initConstructor(poDB);
        } //End Constructor 2

        //Prepare Lookup
        public void prepareLookup()
        {
            //ViewBag.SAMPLE = oDSSample.getDatalist_lookup();
            ViewBag.EMPLOYEE = oDS.getDatalist_lookup();
            ViewBag.UNIT = oDSUnit.getDatalist_lookup();
            ViewBag.JOBTITLE = oDSJobtitle.getDatalist_lookup();
            ViewBag.ROLE = oDSRole.getDatalist_lookup();
        } //End prepareLookup()
        //Prepare Lookup Filter
        public void prepareLookupFilter()
        {
            //ViewBag.SAMPLE = oDSSample.getDatalist_lookup();
        } //End prepareLookupFilter()


        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            this.oData_list = oDS.getDatalist();
            return View(this.oData_list);
        }
        public ActionResult Details(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(this.oData);
        }
        public ActionResult Create()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            prepareLookup();
            return View(new EmployeeuserVM());
        }
        public ActionResult Edit(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_UPDATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(this.oData);
        }
        public ActionResult Delete(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            this.oData = oDS.getData(id);
            if (this.oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(this.oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End Controller
} //End namespace.
