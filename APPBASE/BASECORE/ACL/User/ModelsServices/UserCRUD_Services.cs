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
using APPBASE.Svcutil;
using Omu.ValueInjecter;

namespace APPBASE.Models
{
    public class UserCRUD
    {
        private DBMAINContext db;
        private User oModel;
        private HttpPostedFileBase oFileuploaded;
        private string FILE_NAME;
        private Boolean DELETE_FILE;

        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor 1
        public UserCRUD() { this.db = new DBMAINContext(); } //End public ProjectCRUD()
        //Constructor 2
        public UserCRUD(DBMAINContext poDB)
        { this.db = poDB; } //End public ProjectCRUD()


        //ALL
        public void Changepassword(UserChangepasswordVM poViewModel)
        {
            try
            {
                this.oModel = this.db.Users.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                poViewModel.PASSWORD_NEW = hlpObf.randomEncrypt(poViewModel.PASSWORD_NEW);
                this.oModel.PASSWORD = poViewModel.PASSWORD_NEW;
                //Process CRUD
                this.db.Entry(oModel).State = EntityState.Modified;
                //this.db.SaveChanges();
                //this.ID = oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update

        //HQ
        public void Create(UserdetailVM poViewModel, HttpPostedFileBase poFileimage = null)
        {
            try
            {
                this.DELETE_FILE = false;
                this.oModel = new User();
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                //DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                //USER_STS
                this.oModel.USER_STS = valFLAG.FLAG_ACTIVE_ID;
                //Set Image file name
                if (poFileimage != null)
                {
                    this.oFileuploaded = poFileimage;
                    if ((this.oModel.USER_IMG == null) || (this.oModel.USER_IMG == ""))
                    { this.oModel.USER_IMG = Utility_FileUploadDownload.setImage_User(); } //End if
                } //End if

                this.FILE_NAME = this.oModel.USER_IMG;
                //Process CRUD
                this.db.Users.Add(oModel);
                //db.SaveChanges();
                //this.ID = oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(UserdetailVM poViewModel, HttpPostedFileBase poFileimage = null)
        {
            try
            {
                this.DELETE_FILE = false;
                this.oModel = this.db.Users.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                int? nROLE_ID = oModel.ROLE_ID;
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Get existing field value
                if (nROLE_ID == 7) { this.oModel.ROLE_ID = nROLE_ID; }
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                //DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE;
                //Set Image file name
                if (poFileimage != null)
                {
                    this.oFileuploaded = poFileimage;
                    if ((this.oModel.USER_IMG == null) || (this.oModel.USER_IMG == ""))
                    { this.oModel.USER_IMG = Utility_FileUploadDownload.setImage_User(); } //End if
                } //End if

                this.FILE_NAME = this.oModel.USER_IMG;
                //Process CRUD
                this.db.Entry(oModel).State = EntityState.Modified;
                //db.SaveChanges();
                //this.ID = oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        public void Delete(int? id)
        {
            try
            {
                this.DELETE_FILE = true;
                this.oModel = this.db.Users.Find(id);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_DELETE;
                //Set Image file name
                this.FILE_NAME = this.oModel.USER_IMG;
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
            { Utility_FileUploadDownload.saveImage_User(this.oFileuploaded, this.FILE_NAME); }
        } //End public void Commit()
        private void FileDelete()
        {
            //Delete Image file
            if (this.FILE_NAME != null)
            { Utility_FileUploadDownload.deleteImage_User(this.FILE_NAME); }
        } //End public void Commit()
    } //End public class UserCRUD
} //End namespace APPBASE.Models

