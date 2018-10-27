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
    public class EmployeeuserCRUD
    {
        private DBMAINContext db;
        private HttpPostedFileBase oFileuploaded;
        private string FILE_NAME;
        private Boolean DELETE_FILE;

        //MODEL
        private Employeeuser_info oModel;
        //CRUD
        private EmployeeCRUD oCRUD;
        private UserCRUD oCRUD_user;
        //VM
        private EmployeeVM oVM;
        private UserdetailVM oVM_user;
        private EmployeeuserVM oViewModel;

        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor 1
        public EmployeeuserCRUD() {
            this.db = new DBMAINContext();
            this.oCRUD = new EmployeeCRUD(this.db);
            this.oCRUD_user = new UserCRUD(this.db);
        } //End public EmployeeuserCRUD()
        //Constructor 2
        public EmployeeuserCRUD(DBMAINContext poDB)
        {
            this.db = poDB;
            this.oCRUD = new EmployeeCRUD(this.db);
            this.oCRUD_user = new UserCRUD(this.db);
        } //End public EmployeeuserCRUD()
        //Constructor 3
        public EmployeeuserCRUD(DBMAINContext poDB, EmployeeCRUD poCRUD, UserCRUD poCRUD_user)
        { 
            this.db = poDB;
            this.oCRUD = poCRUD;
            this.oCRUD_user = poCRUD_user;
        } //End public EmployeeuserCRUD()
        //ACTION
        public void Create(EmployeeuserVM poViewModel, HttpPostedFileBase poFileimage=null)
        {
            try
            {
                this.oViewModel = poViewModel;
                //Employee
                this.mapEmployee();
                this.oCRUD.Create(oVM, poFileimage);
                this.oCRUD.Commit();
                this.ID = this.oCRUD.ID;
                if (!this.oCRUD.isERR) {
                    //user
                    this.mapUser();
                    this.oCRUD_user.Create(oVM_user, poFileimage);
                    this.oCRUD_user.Commit();
                } //End if
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(EmployeeuserVM poViewModel, HttpPostedFileBase poFileimage = null)
        {
            try
            {
                this.oModel = this.db.Employeeuser_infos.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                this.oVM = new EmployeeVM();
                this.oVM.InjectFrom(oModel);
                this.oVM_user = new UserdetailVM();

                this.oViewModel = poViewModel;
                this.oViewModel.EMPUSER_ID = this.oModel.EMPUSER_ID;
                //Employee
                this.mapEmployee();
                this.oCRUD.Update(oVM, poFileimage);
                this.oCRUD.Commit();
                this.ID = this.oCRUD.ID;
                if (!this.oCRUD.isERR) {
                    //User
                    this.mapUser();
                    this.oCRUD_user.Update(oVM_user, poFileimage);
                    this.oCRUD_user.Commit();
                } //End if
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        public void Delete(int? id)
        {
            try
            {
                //Employee
                this.oModel = this.db.Employeeuser_infos.Find(id);
                this.oCRUD.Delete(this.oModel.ID);
                this.oCRUD.Commit();
                if (!this.oCRUD.isERR) {
                    //User
                    this.oCRUD_user.Delete(this.oModel.EMPUSER_ID);
                    this.oCRUD_user.Commit();
                } //End if
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
        public void Commit()
        {
            //Employee
            oCRUD.Commit();
            this.ID = this.oCRUD.ID;
            //User
            oCRUD_user.Commit();
        } //End public void Commit()
        //MAPS
        private void mapUser()
        {
            if (this.oVM_user == null) this.oVM_user = new UserdetailVM();
            this.oVM_user.ID = this.oViewModel.EMPUSER_ID;
            this.oVM_user.USERNAME = this.oViewModel.EMPUSER_USERNAME;
            this.oVM_user.ROLE_ID = this.oViewModel.EMPUSER_ROLEID;

            if ((this.oViewModel.EMPUSER_PASSWORD != null) && (this.oViewModel.EMPUSER_PASSWORD != ""))
                this.oVM_user.PASSWORD = hlpObf.randomEncrypt(this.oViewModel.EMPUSER_PASSWORD);

            this.oVM_user.EMAIL = this.oViewModel.EMPUSER_EMAIL;
            this.oVM_user.USER_IMG = this.oViewModel.EMPUSER_USERIMG;
            this.oVM_user.MDLE_ID = this.oViewModel.ROLE_MDLEID;
            this.oVM_user.RES_ID = this.ID;
        } //End Method
        private void mapEmployee()
        {
            if (this.oVM == null) this.oVM = new EmployeeVM();
            this.oVM.NAME = this.oViewModel.NAME;
            this.oVM.UNIT_ID = this.oViewModel.UNIT_ID;
            this.oVM.JOBTITLE_ID = this.oViewModel.JOBTITLE_ID;
            this.oVM.SUPERIOR_ID = this.oViewModel.SUPERIOR_ID;
        } //End Method
    } //End public class EmployeeuserCRUD
} //End namespace APPBASE.Models
