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
    public class MaritalCRUD
    {
        private DBMAINContext db;
        private Marital oModel;
        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor 1
        public MaritalCRUD() { this.db = new DBMAINContext(); } //End public MaritalCRUD()
        //Constructor 2
        public MaritalCRUD(DBMAINContext poDB)
        { this.db = poDB; } //End public MaritalCRUD()

        public void Create(MaritalVM poViewModel)
        {
            try
            {
                this.oModel = new Marital();
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                //Process CRUD
                this.db.Maritals.Add(this.oModel);
                //this.db.SaveChanges();
                //this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(MaritalVM poViewModel)
        {
            try
            {
                this.oModel = this.db.Maritals.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                //Map Form Data
                this.oModel.InjectFrom(poViewModel);
                //Set Field Header
                this.oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                //Set DTA_STS
                this.oModel.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE;
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
                this.oModel = this.db.Maritals.Find(id);
                this.db.Maritals.Remove(this.oModel);
                //this.db.SaveChanges();
                //this.ID = this.oModel.ID;
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
        public void Commit()
        {
            this.db.SaveChanges();
            this.ID = this.oModel.ID;
        } //End public void Commit()
    } //End public class MaritalCRUD
} //End namespace APPBASE.Models
