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
        private TaskVM oViewModel;
        private TaskdVM oViewModel_detail;
        private TaskDS oDS;
        private TaskdDS oDSDetail;
        public List<ValidationMSG_VM> aValidationMSG;

        //Constructor 1
        public Task_Validation(TaskVM poViewModel)
        {
            this.oViewModel = poViewModel;
            this.oDS = new TaskDS();
            aValidationMSG = new List<ValidationMSG_VM>();
        } //End Constructor 1
        //Constructor 2
        public Task_Validation(TaskVM poViewModel, TaskDS poDS)
        {
            this.oViewModel = poViewModel;
            this.oDS = poDS;
            aValidationMSG = new List<ValidationMSG_VM>();
        } //End Constructor 2
        //Constructor 3
        public Task_Validation(TaskVM poViewModel, TaskDS poDS, TaskdDS poDSDetail)
        {
            this.oViewModel = poViewModel;
            this.oViewModel.DETAIL = poViewModel.DETAIL;
            this.oDS = poDS;
            this.oDSDetail = poDSDetail;
            aValidationMSG = new List<ValidationMSG_VM>();
        } //End Constructor 2

        public void Validate_Save()
        {
            foreach (var item in this.oViewModel.DETAIL)
            {
                //Create [Do nothing]
                if (item.DETAIL_ACTION == null) { this.Validate_Create(item); } //end if
                //Create [Do nothing]
                if (item.DETAIL_ACTION == 1) { this.Validate_Create(item); } //end if
                //Update
                if (item.DETAIL_ACTION == 2) { this.Validate_Edit(item); } //end if
                //Delete
                if (item.DETAIL_ACTION == 3) { this.Validate_Delete(item); } //end if
            } //end loop
            //Validate_ID();
        } //End public void Validate_Create()
        public void Validate_Create(TaskdVM poViewModel=null)
        {
            //Validate_ID();
        } //End public void Validate_Create()
        public void Validate_Edit(TaskdVM poViewModel = null)
        {
            this.Validate_isValidated(poViewModel);
            //Validate_ID();
        } //End public void Validate_Edit()
        public void Validate_Delete(TaskdVM poViewModel = null)
        {
            this.Validate_isValidated(poViewModel);
            //Validate_ID();
        } //End public void Validate_Delete()
    } //End public partial class Task_Validation
} //End namespace APPBASE.Models
