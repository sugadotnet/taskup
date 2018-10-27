﻿using System;
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
    public partial class Taskreport_Validation
    {
        private TaskreportVM oViewModel;
        private TaskreportDS oDS;
        public List<ValidationMSG_VM> aValidationMSG;

        //Constructor 1
        public Taskreport_Validation(TaskreportVM poViewModel)
        {
            this.oViewModel = poViewModel;
            this.oDS = new TaskreportDS();
            aValidationMSG = new List<ValidationMSG_VM>();
        } //End Constructor 1
        //Constructor 2
        public Taskreport_Validation(TaskreportVM poViewModel, TaskreportDS poDS)
        {
            this.oViewModel = poViewModel;
            this.oDS = poDS;
            aValidationMSG = new List<ValidationMSG_VM>();
        } //End Constructor 2

        public void Validate_Create()
        {
            //Validate_ID();
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            //Validate_ID();
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            //Validate_ID();
        } //End public void Validate_Delete()
    } //End public partial class Taskreport_Validation
} //End namespace APPBASE.Models
