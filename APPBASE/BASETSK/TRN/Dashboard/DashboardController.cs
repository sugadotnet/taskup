using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Filters;
using APPBASE.Svcapp;

namespace APPBASE.Controllers
{
    public partial class DashboardController : Controller
    {
        //DBContext
        private DBMAINContext db = new DBMAINContext();
        //VM
        private Taskd_summaryVM oVM;
        //DATA
        private Taskd_summaryVM oData;
        //DS
        private Taskd_summary_workerDS oDS;
        //CRUD
        //VALIDATION
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
            this.oVM = new Taskd_summaryVM();
            //DS
            this.oDS = new Taskd_summary_workerDS(this.db);
            //BL
            //MAP
            //JSON
            JsSerialize = new JavaScriptSerializer();
        } //End initConstructor
        //Constructor 1
        public DashboardController()
        {
            //DBContext
            this.initConstructor(new DBMAINContext());
        } //End Constructor 1
        //Constructor 2
        public DashboardController(DBMAINContext poDB)
        {
            //DBContext
            this.initConstructor(poDB);
        } //End Constructor 2

        //Set Json
        private void setJson() {
        
            //this.oData_json = new JsonVM();
            //if (this.oData == null) this.oData = new TaskVM();
            //this.oData_json.result = this.oData;
            //if (this.oData.DETAIL == null) this.oData.DETAIL = new List<TaskdVM>();
            //this.oData_json.result_detail = this.oData.DETAIL;
            //this.oData_json.result_detail_template = new TaskdVM();
            //ViewBag.JSON = JsSerialize.Serialize(this.oData_json);

        } //End method
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
            int? nRoleId = hlpConfig.SessionInfo.getAppRoleId();
            int? nResId = hlpConfig.SessionInfo.getAppResId();
            //LEADER
            if (nRoleId == valROLE.ROLEID_LEADER) this.oData = this.oDS.getData(nRoleId, nResId, nResId);
            //OTHERS
            else this.oData = this.oDS.getData(nRoleId, nResId);
            
            return View(this.oData);
        } 
    } //End public class HomeController : Controller
} //End namespace APPBASE.Controllers
