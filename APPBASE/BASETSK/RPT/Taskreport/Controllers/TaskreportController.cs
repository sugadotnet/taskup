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
    public partial class TaskreportController : Controller
    {
        //DBContext
        private DBMAINContext db = new DBMAINContext();
        //VM
        private TaskreportVM oVM;
        //DATA
        private TaskVM oData;
        private List<TaskVM> oData_list;
        //DS
        private TaskreportDS oDS;
        private EmployeeDS oDSEmployee;
        //CRUD
        //private TaskreportCRUD oCRUD;
        //VALIDATION
        private Taskreport_Validation oVAL;
        //BL
        //MAP


        //Init
        private void initConstructor(DBMAINContext poDB)
        {
            //DBContext
            this.db = poDB;
            //VM
            this.oVM = new TaskreportVM();
            //DS
            this.oDS = new TaskreportDS(this.db);
            this.oDSEmployee = new EmployeeDS(this.db);
            //CRUD
            //this.oCRUD = new TaskreportCRUD(this.db);

            //BL
            //MAP
        } //End initConstructor
        //Constructor 1
        public TaskreportController()
        {
            //DBContext
            this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public TaskreportController(DBMAINContext poDB)
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
            ViewBag.EMPLOYEE = oDSEmployee.getDatalist_lookup();
        } //End prepareLookupFilter()


        public ActionResult Index()
        {
            if (hlpConfig.SessionInfo.getAppRoleId() == valROLE.ROLEID_MASTER) return RedirectToAction("Filter_admin");
            if (hlpConfig.SessionInfo.getAppRoleId() == valROLE.ROLEID_ADMIN) return RedirectToAction("Filter_admin");
            if (hlpConfig.SessionInfo.getAppRoleId() == valROLE.ROLEID_LEADER) return RedirectToAction("Filter_admin");
            if (hlpConfig.SessionInfo.getAppRoleId() == valROLE.ROLEID_MEMBER) {
                int? nRES_ID = hlpConfig.SessionInfo.getAppResId();
                return RedirectToAction("Taskprint", new { id = nRES_ID });
            } //end if
            return View(new BaseVM());
        }
        public ActionResult Filter_admin()
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_REPORT_ADMIN;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.DataNotFound = TempData["DataNotFound"];
            TempData["RidirectTo"] = "Filter_admin";
            prepareLookupFilter();
            return View(new TaskVM());
        }
        public ActionResult Filter_member()
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_REPORT_MEMBER;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.DataNotFound = TempData["DataNotFound"];
            TempData["RidirectTo"] = "Filter_member";

            return View(new BaseVM());
        }
        public ActionResult Taskprint(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_REPORT_MEMBER;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;

            this.oData = oDS.getData(id);
            if (this.oData == null) {
                TempData["DataNotFound"] = valFLAG.FLAG_TRUE;
                return RedirectToAction(TempData["RidirectTo"].ToString());
            }
            return View(this.oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End Controller
} //End namespace
