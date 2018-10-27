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
using APPBASE.Svcutil;

namespace APPBASE.Models
{
    public class EmployeeCRUD
    {
        private DBMAINContext db;
        private Employee oModel;
        private HttpPostedFileBase oFileuploaded;
        private string FILE_NAME;
        private Boolean DELETE_FILE;

        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor 1
        public EmployeeCRUD() { this.db = new DBMAINContext(); } //End public EmployeeCRUD()
        //Constructor 2
        public EmployeeCRUD(DBMAINContext poDB)
        { this.db = poDB; } //End public EmployeeCRUD()

        public void Create(EmployeeVM poViewModel, HttpPostedFileBase poFileimage=null)
        {
            try
            {
                this.DELETE_FILE = false;
                this.oModel = new Employee();
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                //Set Image file name
                if (poFileimage != null)
                {
                    this.oFileuploaded = poFileimage;
                    if ((this.oModel.EMPLOYEE_IMG == null) || (this.oModel.EMPLOYEE_IMG == ""))
                    { this.oModel.EMPLOYEE_IMG = Utility_FileUploadDownload.setImage_Employee(); } //End if
                } //End if
                this.FILE_NAME = this.oModel.EMPLOYEE_IMG;

                //Process CRUD
                this.db.Employees.Add(this.oModel);
                //this.db.SaveChanges();
                //this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(EmployeeVM poViewModel, HttpPostedFileBase poFileimage = null)
        {
            try
            {
                this.DELETE_FILE = false;
                this.oModel = this.db.Employees.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE;
                //Set Image file name
                if (poFileimage != null)
                {
                    this.oFileuploaded = poFileimage;
                    if ((this.oModel.EMPLOYEE_IMG == null) || (this.oModel.EMPLOYEE_IMG == ""))
                    { this.oModel.EMPLOYEE_IMG = Utility_FileUploadDownload.setImage_Employee(); } //End if
                } //End if
                this.FILE_NAME = this.oModel.EMPLOYEE_IMG;

                //Process CRUD
                this.db.Entry(this.oModel).State = EntityState.Modified;
                //this.db.SaveChanges();
                //this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        public void Delete(int? id)
        {
            try
            {
                this.DELETE_FILE = true;
                this.oModel = this.db.Employees.Find(id);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_DELETE;
                //Set Image file name
                this.FILE_NAME = this.oModel.EMPLOYEE_IMG;
                //Process CRUD
                this.db.Entry(this.oModel).State = EntityState.Modified;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
        public void Commit()
        {
            this.db.SaveChanges();
            this.ID = this.oModel.ID;
            if (this.DELETE_FILE) this.FileDelete();
            else this.FileSave();
        } //End public void Commit()
        private void FileSave()
        {
            if ((this.oFileuploaded != null) && (this.FILE_NAME != null))
            { Utility_FileUploadDownload.saveImage_Employee(this.oFileuploaded, this.FILE_NAME); }

        } //End public void Commit()
        private void FileDelete()
        {
            //Delete Image file
            if (this.FILE_NAME != null)
            { Utility_FileUploadDownload.deleteImage_Employee(this.FILE_NAME); }
        } //End public void Commit()
    } //End public class EmployeeCRUD
} //End namespace APPBASE.Models
