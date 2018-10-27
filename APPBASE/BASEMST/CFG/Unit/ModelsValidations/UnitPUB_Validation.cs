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
    public partial class Unit_Validation
    {
        private UnitVM oViewModel;
        private UnitDS oDS;
        public List<ValidationMSG_VM> aValidationMSG;

        //Constructor 1
        public Unit_Validation(UnitVM poViewModel)
        {
            this.oViewModel = poViewModel;
            this.oDS = new UnitDS();
            aValidationMSG = new List<ValidationMSG_VM>();
        } //End Constructor 1
        //Constructor 2
        public Unit_Validation(UnitVM poViewModel, UnitDS poDS)
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
    } //End public partial class Unit_Validation
} //End namespace APPBASE.Models
