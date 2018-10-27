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
using Omu.ValueInjecter;

namespace APPBASE.Controllers
{
    public partial class TaskController : Controller
    {
        [HttpPost]
        public ActionResult Create(TaskVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_CREATE;
            TaskVM oViewModel = poViewModel;
            oViewModel.RESOWNER_ID = hlpConfig.SessionInfo.getAppResId();
            this.oVAL = new Task_Validation(oViewModel, this.oDS);
            this.oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Create(oViewModel);
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = this.oCRUD.ID });

            } //End if (ModelState.IsValid)
            this.prepareLookup();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Create2(TaskdVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_CREATE;

            this.oData_detail = this.oDSDetail.getData(poViewModel.ID);
            if (this.oData_detail != null) {
                this.oData = this.oDS.getData(this.oData_detail.TASK_ID);
            } //end if
            if (this.oData == null) this.oData = new TaskVM();
            this.oData.DETAIL = new List<TaskdVM>();
            this.oData.DETAIL.Add(poViewModel);
            TaskVM oViewModel = new TaskVM();
            oViewModel.InjectFrom(this.oData);
            oViewModel.TASK_DESC = poViewModel.TASKD_PLANDESC;
            oViewModel.RES_ID = poViewModel.RES_ID;
            oViewModel.RESOWNER_ID = poViewModel.RESOWNER_ID;

            this.oVAL = new Task_Validation(oViewModel, this.oDS);
            this.oVAL.Validate_Save();
            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                //this.oCRUD.Create(oViewModel);

                //Create [Do nothing]
                if (poViewModel.DETAIL_ACTION == null) { this.oCRUD.Create(oViewModel); } //end if
                //Create [Do nothing]
                if (poViewModel.DETAIL_ACTION == 1) { this.oCRUD.Create(oViewModel); } //end if
                //Update
                if (poViewModel.DETAIL_ACTION == 2) { this.Edit(oViewModel); } //end if
                //Delete
                if (poViewModel.DETAIL_ACTION == 3) { this.DeleteConfirmed(oViewModel.ID); } //end if
                
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Create2");
                //return RedirectToAction("Details", new { id = this.oCRUD.ID });

            } //End if (ModelState.IsValid)
            this.prepareLookup();
            return View(poViewModel);
        }

        [HttpPost]
        public ActionResult Edit(TaskVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_EDIT;
            this.oVAL = new Task_Validation(poViewModel, this.oDS);
            this.oVAL.Validate_Save();

            //Add Error if exists
            for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Update(poViewModel);
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = this.oCRUD.ID });
            }
            this.prepareLookup();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit_progress(TaskdVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_PROGRESS;
            this.oVALDetail = new Taskd_Validation(poViewModel, this.oDSDetail);
            this.oVALDetail.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < this.oVALDetail.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVALDetail.aValidationMSG[i].VAL_ERRID, this.oVALDetail.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Update_progres(poViewModel);
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details2", new { id = this.oCRUD.DETAIL_ID });
            }
            this.prepareLookup();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit_validate(TaskdVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_VALIDATE;
            this.oVALDetail = new Taskd_Validation(poViewModel, this.oDSDetail);
            this.oVALDetail.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < this.oVALDetail.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVALDetail.aValidationMSG[i].VAL_ERRID, this.oVALDetail.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Update_validate(poViewModel);
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details2", new { id = this.oCRUD.DETAIL_ID });
            }
            this.prepareLookup();
            ViewBag.VALIDATESTS = this.oDSValidatests.getDatalist_lookup();
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_DELETE;
            this.oCRUD.Delete(id);
            if (this.oCRUD.isERR)
            {
                TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            this.prepareLookup();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Create2_backup(TaskdVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.TSK_TASK_CREATE;
            TaskVM oViewModel = new TaskVM();
            oViewModel.RES_ID = poViewModel.RES_ID;
            oViewModel.RESOWNER_ID = poViewModel.RESOWNER_ID;
            oViewModel.TASK_DESC = poViewModel.TASKD_PLANDESC;
            oViewModel.DETAIL = new List<TaskdVM>();
            oViewModel.DETAIL.Add(poViewModel);
            //oViewModel.RESOWNER_ID = hlpConfig.SessionInfo.getAppResId();

            this.oVAL = new Task_Validation(oViewModel, this.oDS);
            this.oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Create(oViewModel);
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = this.oCRUD.ID });

            } //End if (ModelState.IsValid)
            this.prepareLookup();
            return View(poViewModel);
        }
    } //End Controller
} //End namespace

