using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
using APPBASE.Svcapp;



namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class TaskController : Controller
    {
        //DBContext
        private DBMAINContext db = new DBMAINContext();
        //VM
        private TaskVM oVM;
        //DATA
        private TaskVM oData;
        private List<TaskVM> oData_list;
        private TaskdVM oData_detail;
        private List<TaskdVM> oDatadetail_list;
        private JsonVM oData_json;
        //DS
        private TaskDS oDS;
        private TaskdDS oDSDetail;
        private Taskd_workerDS oDSDetail_worker;
        //private DS oDSDetail;
        private EmployeeDS oDSEmployee;
        private EmployeeuserDS oDSEmployeeuser;
        private MonthDS oDSMonth;
        private YearDS oDSYear;
        private ProgressstsDS oDSProgresssts;
        private ValidatestsDS oDSValidatests;
        private ProjectDS oDSProject;
        //CRUD
        private Task_workerCRUD oCRUD;
        //VALIDATION
        private Task_Validation oVAL;
        private Taskd_Validation oVALDetail;
        //BL
        //MAP
        //JSON
        JavaScriptSerializer JsSerialize;

        //Init
        private void initConstructor(DBMAINContext poDB)
        {
            //DBContext
            this.db = poDB;
            //VM
            this.oVM = new TaskVM();
            //DS
            this.oDS = new TaskDS(this.db);
            this.oDSDetail = new TaskdDS(this.db);
            this.oDSDetail_worker = new Taskd_workerDS(this.db);
            this.oDSEmployee = new EmployeeDS(this.db);
            this.oDSEmployeeuser = new EmployeeuserDS(this.db);
            this.oDSMonth = new MonthDS(this.db);
            this.oDSYear = new YearDS(this.db);
            this.oDSProgresssts = new ProgressstsDS(this.db);
            this.oDSValidatests = new ValidatestsDS(this.db);
            this.oDSProject = new ProjectDS(this.db);
            //CRUD
            this.oCRUD = new Task_workerCRUD(this.db);

            //BL
            //MAP
            //JSON
            JsSerialize = new JavaScriptSerializer();
        } //End initConstructor
        //Constructor 1
        public TaskController()
        {
            //DBContext
            this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public TaskController(DBMAINContext poDB)
        {
            //DBContext
            this.initConstructor(poDB);
        } //End Constructor 2

        //Set Json
        private void setJson() {
            this.oData_json = new JsonVM();
            if (this.oData == null) this.oData = new TaskVM();
            this.oData_json.result = this.oData;
            if (this.oData.DETAIL == null) this.oData.DETAIL = new List<TaskdVM>();
            this.oData_json.result_detail = this.oData.DETAIL;
            this.oData_json.result_detail_template = new TaskdVM();
            ViewBag.JSON = JsSerialize.Serialize(this.oData_json);
        } //End method
        private void setJson_progresssts()
        {
            this.oData_json = new JsonVM();
            this.oData_json.result = this.oDSProgresssts.getDatalist_lookup();
            ViewBag.JSON_PROGRESSSTS = JsSerialize.Serialize(this.oData_json);
        } //End method
        //Prepare Lookup
        public void prepareLookup()
        {
            //ViewBag.SAMPLE = oDSSample.getDatalist_lookup();
            ViewBag.PROJECT = oDSProject.getDatalist();

            if ((hlpConfig.SessionInfo.getAppRoleId() == valROLE.ROLEID_MASTER) ||
                (hlpConfig.SessionInfo.getAppRoleId() == valROLE.ROLEID_ADMIN)) {
                    //MASTER/ADMIN
                    ViewBag.EMPLOYEE = oDSEmployee.getDatalist_lookup();
            } else {
                //LEADER
                ViewBag.EMPLOYEE = oDSEmployee.getDatalist_lookupBySeperiorId(hlpConfig.SessionInfo.getAppResId());
            }
            ViewBag.EMPLOYEEUSER = oDSEmployeeuser.getData(hlpConfig.SessionInfo.getAppResId());
            ViewBag.MONTH = oDSMonth.getDatalist_lookup();
            ViewBag.YEAR = oDSYear.getDatalist_lookup();
        } //End prepareLookup()
        //Prepare Lookup Filter
        public void prepareLookupFilter()
        {
            //ViewBag.SAMPLE = oDSSample.getDatalist_lookup();
        } //End prepareLookupFilter()


        public ActionResult Index()
        {
            return RedirectToAction("Index3");
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_INDEX;
            //Validate custom rules
            int? nROLE_ID = hlpConfig.SessionInfo.getAppRoleId();
            if (nROLE_ID != valROLE.ROLEID_ADMIN)
            {
                int? nRES_ID = hlpConfig.SessionInfo.getAppResId();
                this.oData_list = oDS.getDatalist_excludeRES_ID(nRES_ID);
                return View(this.oData_list);
            } //end if
            
            this.oData_list = oDS.getDatalist();
            return View(this.oData_list);
        }
        public ActionResult Index3(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_INDEX;
            int? nROLE_ID = hlpConfig.SessionInfo.getAppRoleId();
            int? nRES_ID = hlpConfig.SessionInfo.getAppResId();
            //issue#18 this.oDatadetail_list = oDSDetail_worker.getDatalist(null, nROLE_ID, null, nRES_ID);
            this.oDatadetail_list = oDSDetail_worker.getDatalist(null, nROLE_ID, nRES_ID, nRES_ID); //issue#18
            return View(this.oDatadetail_list);
        }
        public ActionResult Index2(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            int? nROLE_ID = hlpConfig.SessionInfo.getAppRoleId();
            int? nRES_ID = hlpConfig.SessionInfo.getAppResId();
            if (nROLE_ID == valROLE.ROLEID_LEADER) this.oDatadetail_list = oDSDetail_worker.getDatalist(id, nROLE_ID, nRES_ID, nRES_ID);
            else this.oDatadetail_list = oDSDetail_worker.getDatalist(id, nROLE_ID, nRES_ID);
            return View(this.oDatadetail_list);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            this.oData = oDS.getData(id);
            this.oData.DETAIL = oDSDetail.getDatalist_byForeignId(this.oData.ID);
            if (this.oData == null) { return HttpNotFound(); }
            this.prepareLookup();
            this.setJson();
            return View(this.oData);
        }
        public ActionResult Details2(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            this.oData_detail = this.oDSDetail.getData(id);
            if (this.oData_detail == null) { return HttpNotFound(); }
            return View(this.oData_detail);
        }
        public ActionResult Create()
        {
            return RedirectToAction("Create2");
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            this.prepareLookup();
            this.setJson();
            return View(new TaskVM());
        }
        public ActionResult Create2()
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            int? nROLE_ID = hlpConfig.SessionInfo.getAppRoleId();
            int? nRES_ID  = hlpConfig.SessionInfo.getAppResId();
            this.oDatadetail_list = oDSDetail_worker.getDatalist(5, nROLE_ID, null, nRES_ID);

            this.oData = new TaskVM();
            this.oData.DETAIL = oDatadetail_list;
            this.prepareLookup();
            this.setJson();
            this.oData_detail = new TaskdVM();

            this.oData_detail.RESOWNER_ID = nRES_ID;
            return View(this.oData_detail);
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;

            this.oData = oDS.getData(id);
            this.oData.DETAIL = oDSDetail.getDatalist_byForeignId(this.oData.ID);
            if (this.oData == null) { return HttpNotFound(); }
            //Validate custom rules
            int? nROLE_ID = hlpConfig.SessionInfo.getAppRoleId();
            if (nROLE_ID != valROLE.ROLEID_ADMIN)
            {
                int? nRES_ID = hlpConfig.SessionInfo.getAppResId();
                if (this.oData.RES_ID == nRES_ID) return RedirectToAction("Error403", "Error");
            } //end if
            this.prepareLookup();
            this.setJson();
            return View(this.oData);
        }
        public ActionResult Edit_planning(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            this.oData_detail = oDSDetail.getData(id);
            if (this.oData_detail == null) { return HttpNotFound(); }
            if (this.oData_detail.ASSIGNEE_ID != hlpConfig.SessionInfo.getAppResId())
            {
                return RedirectToAction("Error403", "Error");
            } //end if
            this.prepareLookup();
            this.setJson_progresssts();
            return View(oData_detail);
        }
        public ActionResult Edit_progress(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_PROGRESS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            this.oData_detail = oDSDetail.getData(id);
            if (this.oData_detail == null) { return HttpNotFound(); }
            if (this.oData_detail.RES_ID != hlpConfig.SessionInfo.getAppResId()) {
                return RedirectToAction("Error403", "Error");
            } //end if
            this.prepareLookup();
            this.setJson_progresssts();
            return View(oData_detail);
        }
        public ActionResult Edit_validate(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_VALIDATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            this.oData_detail = oDSDetail.getData(id);
            if (this.oData_detail == null) { return HttpNotFound(); }
            this.prepareLookup();
            this.setJson();
            ViewBag.VALIDATESTS = this.oDSValidatests.getDatalist_lookup();
            return View(oData_detail);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            this.oData = oDS.getData(id);
            this.oData.DETAIL = oDSDetail.getDatalist_byForeignId(this.oData.ID);
            if (this.oData == null) { return HttpNotFound(); }
            this.prepareLookup();
            this.setJson();
            return View(this.oData);
        }

        public ActionResult Index3_BACKUP(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_INDEX;
            int? nROLE_ID = hlpConfig.SessionInfo.getAppRoleId();
            int? nRES_ID = hlpConfig.SessionInfo.getAppResId();
            this.oDatadetail_list = oDSDetail_worker.getDatalist(null, nROLE_ID, null, nRES_ID);
            return View(this.oDatadetail_list);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End Controller
} //End namespace
