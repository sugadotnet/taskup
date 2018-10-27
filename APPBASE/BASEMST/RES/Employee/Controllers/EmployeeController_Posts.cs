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
    public partial class EmployeeController : Controller
    {
        [HttpPost]
        public ActionResult Create(EmployeeVM poViewModel, HttpPostedFileBase FileEMPLOYEE_IMG)
        {
            ViewBag.AC_MENU_ID = valMENU.MST_EMPLOYEE_CREATE;
            this.oVAL = new Employee_Validation(poViewModel, this.oDS);
            this.oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Create(poViewModel, FileEMPLOYEE_IMG);
                this.oCRUD.Commit();
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = this.oCRUD.ID });

            } //End if (ModelState.IsValid)

            prepareLookup();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeVM poViewModel, HttpPostedFileBase FileEMPLOYEE_IMG)
        {
            ViewBag.AC_MENU_ID = valMENU.MST_EMPLOYEE_EDIT;
            this.oVAL = new Employee_Validation(poViewModel, this.oDS);
            this.oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Update(poViewModel, FileEMPLOYEE_IMG);
                this.oCRUD.Commit();
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = this.oCRUD.ID });
            }
            prepareLookup();
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            ViewBag.AC_MENU_ID = valMENU.MST_EMPLOYEE_DELETE;
            this.oCRUD.Delete(id);
            this.oCRUD.Commit();
            if (this.oCRUD.isERR)
            {
                TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            prepareLookup();
            return RedirectToAction("Index");
        }
    } //End Controller
} //End namespace
