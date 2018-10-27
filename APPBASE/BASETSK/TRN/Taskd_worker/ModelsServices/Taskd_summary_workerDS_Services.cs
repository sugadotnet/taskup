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
using System.Web.Script.Serialization;
using System.Web.Security;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcapp;

namespace APPBASE.Models
{
    public class Taskd_summary_workerDS
    {
        private DBMAINContext db;
        private Taskd_summaryDS oDS;
        private Taskd_summaryVM oData;
        private JavaScriptSerializer JsSerialize;

        //Init
        private void initConstructor(DBMAINContext poDB)
        {
            //DBContext
            this.db = poDB;
            //VM
            //DS
            this.oDS = new Taskd_summaryDS(this.db);
            //BL
            //MAP
        } //End initConstructor
        //Constructor 1
        public Taskd_summary_workerDS() { this.db = new DBMAINContext(); } //End Constructor Taskd_summaryDS
        //Constructor 2
        public Taskd_summary_workerDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
            this.initConstructor(this.db);
        } //End Constructor
        //Constructor 3
        public Taskd_summary_workerDS(DBMAINContext poDBMAINContext, Taskd_summaryDS poDS)
        {
            this.db = poDBMAINContext;
            this.oDS = poDS;
        } //End Constructor

        public Taskd_summaryVM getData(int? pnROLE_ID, int? pnRES_ID = null, int? pnASSIGNEE_ID = null)
        {
            List<Taskd_summaryVM> oQRY = null;

            //MASTER
            if (pnROLE_ID == valROLE.ROLEID_MASTER) oQRY = oDS.getDatalist();
            //ADMIN
            if (pnROLE_ID == valROLE.ROLEID_ADMIN) oQRY = oDS.getDatalist();
            //LEADER
            if (pnROLE_ID == valROLE.ROLEID_LEADER) oQRY = oDS.getDatalist_byRES_ID(pnRES_ID, pnASSIGNEE_ID);
            //MEMBER
            if (pnROLE_ID == valROLE.ROLEID_MEMBER) oQRY = oDS.getDatalist_byRES_ID(pnRES_ID, null);

            this.oData = new Taskd_summaryVM();
            this.oData.QTY_OPEN = 0;
            this.oData.QTY_ONPROGRESS = 0;
            this.oData.QTY_FINISH = 0;
            this.oData.QTY_VALIDATED = 0;
            foreach (var item in oQRY)
            {
                this.oData.QTY_OPEN = this.oData.QTY_OPEN + item.QTY_OPEN;
                this.oData.QTY_ONPROGRESS = this.oData.QTY_ONPROGRESS + item.QTY_ONPROGRESS;
                this.oData.QTY_FINISH = this.oData.QTY_FINISH + item.QTY_FINISH;
                this.oData.QTY_VALIDATED = this.oData.QTY_VALIDATED + item.QTY_VALIDATED;
            } //end loop

            return this.oData;
        } //End Method

    } //End Class
} //End namespace
