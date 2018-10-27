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
using Omu.ValueInjecter;

namespace APPBASE.Models
{
    public partial class Task_workerCRUD
    {
        private DBMAINContext db;
        public int? ID { get; set; }
        public int? DETAIL_ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }


        //CRUD
        private TaskCRUD oCRUD;
        private TaskdCRUD oCRUD_detail;
        //DS
        private TaskdDS oDSDetail;
        private EmployeeDS oDSEmployee;
        private SysinfoDS oDSSysinfo;
        private MonthDS oDSMonth;
        private YearDS oDSYear;
        //DATA
        private TaskVM oData;
        private TaskdVM oData_detail;
        private EmployeeVM oData_employee;
        private MonthVM oData_month;
        private YearVM oData_year;
        //VM
        private TaskVM oVM;
        private TaskdVM oVM_detail;


        //Instantiate
        private void Instantiate() {
            //CRUD
            this.oCRUD = new TaskCRUD(this.db);
            this.oCRUD_detail = new TaskdCRUD(this.db);
            //DS
            this.oDSDetail = new TaskdDS(this.db);
            this.oDSSysinfo = new SysinfoDS(this.db);
            this.oDSEmployee = new EmployeeDS(this.db);
            this.oDSMonth = new MonthDS(this.db);
            this.oDSYear = new YearDS(this.db);
            //DATA
            this.oData = new TaskVM();
        } //End private void Instantiate()
        //Constructor 1
        public Task_workerCRUD() {
            this.db = new DBMAINContext();
            this.Instantiate();
        } //End public Task_workerCRUD()
        //Constructor 2
        public Task_workerCRUD(DBMAINContext poDB)
        {
            this.db = poDB;
            this.Instantiate();
        } //End public Task_workerCRUD()
        //Constructor 3
        public Task_workerCRUD(DBMAINContext poDB, TaskCRUD poCRUD, TaskdCRUD poCRUD_detail, TaskdDS poDSDetail,
            SysinfoDS poDSSysinfo, EmployeeDS poDSEmployee)
        {
            this.db = poDB;
            //CRUD
            this.oCRUD = poCRUD;
            this.oCRUD_detail = poCRUD_detail;
            //DS
            this.oDSDetail = poDSDetail;
            this.oDSEmployee = poDSEmployee;
            this.oDSSysinfo = poDSSysinfo;
        } //End public Task_workerCRUD()

        public void Create(TaskVM poViewModel)
        {
            try
            {
                //Init
                this.oVM = poViewModel;
                this.oData_employee = this.oDSEmployee.getData(this.oVM.RES_ID);
                //Date
                if (oVM.TASK_DT == null) oVM.TASK_DT = DateTime.Now.Date;
                //Month
                this.oData_month = this.oDSMonth.getData_byMonthNum(oVM.MONTH_ID);
                if (this.oData_month == null) this.oData_month = this.oDSMonth.getData_byMonthNum(oVM.TASK_DT.Value.Month);
                if (this.oData_month == null) this.oData_month = this.oDSMonth.getData_byMonthNum(DateTime.Now.Month);
                //Year
                this.oData_year = this.oDSYear.getData(this.oVM.YEAR_ID);
                if (this.oData_year == null) this.oData_year = this.oDSYear.getData_byYearNum(oVM.TASK_DT.Value.Year);
                if (this.oData_year == null) this.oData_year = this.oDSYear.getData_byYearNum(DateTime.Now.Year);

                //Header
                this.mapModel();
                this.oCRUD.Create(this.oVM);
                this.oCRUD.Commit();
                this.ID = this.oCRUD.ID;
                //Detail
                if (!this.oCRUD.isERR)
                {
                    foreach (var item in oVM.DETAIL)
                    {
                        this.oVM_detail = item;
                        this.mapModel_detail();
                        this.oCRUD_detail.Create(oVM_detail);
                    } //End foreach
                    this.oCRUD_detail.Commit();
                    this.DETAIL_ID = this.oCRUD_detail.ID;
                } //End if
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(TaskVM poViewModel)
        {
            try
            {
                //Init
                this.oVM = poViewModel;
                this.oData.DETAIL = this.oDSDetail.getDatalist_byForeignId(oVM.ID);
                this.fillModel();
                //Header
                //this.mapModel();
                this.oCRUD.Update(this.oVM);
                this.oCRUD.Commit();
                this.ID = this.oCRUD.ID;
                //Detail
                if (!this.oCRUD.isERR)
                {
                    foreach (var item in oVM.DETAIL)
                    {
                        this.oVM_detail = item;
                        this.mapModel_detail_edit();
                        if (this.oVM_detail.ID == null) this.oCRUD_detail.Create(this.oVM_detail);
                        if (this.oVM_detail.ID != null) {
                            if (this.oVM_detail.DTA_STS == null) this.oCRUD_detail.Create(this.oVM_detail);
                            if (this.oVM_detail.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE) this.oCRUD_detail.Update(this.oVM_detail);
                            if (this.oVM_detail.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE) this.oCRUD_detail.Update(this.oVM_detail);
                            if (this.oVM_detail.DTA_STS == valFLAG.FLAG_DTA_STS_DELETE) this.oCRUD_detail.Delete(this.oVM_detail.ID);
                        } //end if
                    } //End foreach
                    this.oCRUD_detail.Commit();
                } //End if
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        public void Delete(int? id)
        {
            try
            {
                //Init
                this.oData.DETAIL = this.oDSDetail.getDatalist_byForeignId(id);
                this.fillModel();
                //Header
                this.oCRUD.Delete(this.oData.ID);
                this.oCRUD.Commit();
                this.ID = this.oCRUD.ID;
                if (!this.oCRUD.isERR)
                {
                    //Detail
                    foreach (var item in this.oData.DETAIL)
                    { this.oCRUD_detail.Delete(item.ID); } //End foreach
                    this.oCRUD_detail.Commit();
                } //End if
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete

        private void mapModel() {
            //HEADER
            this.oVM.TASK_STS = 1; //OPEN
            this.oVM.TASK_DT = this.oDSSysinfo.getSYSDATE().Value.Date;
            this.oVM.BRANCH_ID = this.oData_employee.BRANCH_ID;
            this.oVM.UNIT_ID = this.oData_employee.UNIT_ID;
            this.oVM.SUBUNIT_ID = this.oData_employee.SUBUNIT_ID;
            this.oVM.RESBOS_ID = this.oData_employee.SUPERIOR_ID;

            this.oVM.YEAR_ID = this.oVM.YEAR_ID;
            if (this.oVM.TASK_YEAR == null) this.oVM.YEAR_ID = this.oData_year.ID;
            this.oVM.MONTH_ID = this.oVM.MONTH_ID;
            if (this.oVM.MONTH_ID == null) this.oVM.MONTH_ID = this.oData_month.ID;

            this.oVM.TASK_MONTH = this.oData_month.MONTH_NUM;
            this.oVM.TASK_YEAR = this.oData_year.YEAR_NUM;
            this.oVM.CACHE_YEAR_CODE = this.oData_year.YEAR_CODE;
            this.oVM.CACHE_YEAR_SHORTDESC = this.oData_year.YEAR_SHORTDESC;
            this.oVM.CACHE_YEAR_DESC = this.oData_year.YEAR_DESC;
            this.oVM.CACHE_YEAR_FROM = this.oData_year.YEAR_FROM;
            this.oVM.CACHE_YEAR_TO = this.oData_year.YEAR_TO;
            //DETAIL
            foreach (var item in this.oVM.DETAIL)
            {
                if (item.TASKD_PLANSTARTDT != null)
                    item.TASKD_PLANENDDT = item.TASKD_PLANSTARTDT.Value.AddDays(Convert.ToDouble(item.TASKD_PLANDURATION));
            } //End foreach
        } //End map
        private void fillModel()
        {
            foreach (var item in this.oData.DETAIL)
            {
                this.oData.InjectFrom(item);
                this.oData.ID = item.TASK_ID;
                break;
            } //End foreach
        } //End map
        private void mapModel_detail()
        {
            this.oVM_detail.TASK_ID = this.ID;
        } //End map
        private void mapModel_detail_edit()
        {
            //TODO: Modif "this.mapModel_detail" bagian ini untuk ambil data detail dulu jika update
            this.oData_detail = this.oVM_detail;
            this.oVM_detail = this.oData.DETAIL.Where(fld => fld.ID == this.oData_detail.ID).SingleOrDefault();
            //Replace data from user input
            this.oVM_detail.ASSIGNEE_ID = this.oData_detail.ASSIGNEE_ID;
            this.oVM_detail.RES_ID = this.oData_detail.RES_ID;
            this.oVM_detail.PROJECT_ID = this.oData_detail.PROJECT_ID;
            this.oVM_detail.TASKD_PLANDESC = this.oData_detail.TASKD_PLANDESC;
            this.oVM_detail.TASKD_PLANSTARTDT = this.oData_detail.TASKD_PLANSTARTDT;
            this.oVM_detail.TASKD_PLANDURATION = this.oData_detail.TASKD_PLANDURATION;
            this.oVM_detail.TASKD_PLANENDDT = this.oData_detail.TASKD_PLANENDDT;
        } //End map
    } //End public class Task_workerCRUD
} //End namespace APPBASE.Models
