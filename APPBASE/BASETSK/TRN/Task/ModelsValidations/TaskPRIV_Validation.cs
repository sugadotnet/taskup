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
using APPBASE;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcapp;

namespace APPBASE.Models
{
    public partial class Task_Validation
    {
        private void Validate_ID()
        {
            Boolean bIsvalid = true;
            //[ID] - Required
            if (oViewModel.ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ID1";
                oMSG.VAL_ERRMSG = "ID harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            ////[ID] - Unique
            //if (oDS.isExists_ID(oViewModel.ID))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "ID2";
            //    oMSG.VAL_ERRMSG = "ID " + oViewModel.ID + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_ID()

        private void Validate_isValidated(TaskdVM poViewModel)
        {
            Boolean bIsvalid = true;
            this.oViewModel_detail = null;
            this.oViewModel_detail = poViewModel;
            //[IS_VALIDATED] - Is Validated task
            if ((this.oViewModel_detail.TASKD_PROGRESSPCT != null &&
                this.oViewModel_detail.TASKD_PROGRESSPCT == 100) &&
                (this.oViewModel_detail.TASKD_VALIDATESTS != null &&
                this.oViewModel_detail.TASKD_VALIDATESTS > 0))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "IS_VALIDATED1";
                oMSG.VAL_ERRMSG = "Tugas "+this.oViewModel_detail.TASKD_PLANDESC+" sudah divalidasi. Tidak bisa di edit/delete.";
                aValidationMSG.Add(oMSG);
            } //End if
            ////[ID] - Unique
            //if (oDS.isExists_ID(oViewModel.ID))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "ID2";
            //    oMSG.VAL_ERRMSG = "ID " + oViewModel.ID + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "IS_VALIDATED0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_ID()
    } //End public partial class Task_Validation
} //End namespace APPBASE.Models
