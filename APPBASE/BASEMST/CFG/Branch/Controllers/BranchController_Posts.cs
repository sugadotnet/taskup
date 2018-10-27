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
    public partial class BranchController : Controller
    {
        [HttpPost]
        public ActionResult Create(BranchVM poViewModel)
        {
            //Hardcode hapus feature create
            return RedirectToAction("Details", new { id = 1 });

            this.oVAL = new Branch_Validation(poViewModel, this.oDS);
            this.oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Create(poViewModel);
                this.oCRUD.Commit();
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = this.oCRUD.ID });

            } //End if (ModelState.IsValid)

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(BranchVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.MST_COMPANY_EDIT;
            this.oVAL = new Branch_Validation(poViewModel, this.oDS);
            this.oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(this.oVAL.aValidationMSG[i].VAL_ERRID, this.oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < this.oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.oCRUD.Update(poViewModel);
                this.oCRUD.Commit();
                if (this.oCRUD.isERR)
                {
                    TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!this.oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = this.oCRUD.ID });
            }
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            //Hardcode hapus feature delete
            return RedirectToAction("Details", new { id = 1 });
            this.oCRUD.Delete(id);
            this.oCRUD.Commit();
            if (this.oCRUD.isERR)
            {
                TempData["ERRMSG"] = this.oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }
    } //End Controller
} //End namespace
