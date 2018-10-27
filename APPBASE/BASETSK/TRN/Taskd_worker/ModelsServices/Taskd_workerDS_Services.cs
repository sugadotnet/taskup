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

namespace APPBASE.Models
{
    public class Taskd_workerDS
    {
        //DBContext
        private DBMAINContext db;
        //DATA
        private TaskdVM oData;
        private List<TaskdVM> oData_list;
        //DS
        private TaskdDS oDS;


        //Init
        private void initConstructor(DBMAINContext poDB)
        {
            //DBContext
            this.db = poDB;
            //DS
            oDS = new TaskdDS(this.db);
        } //End initConstructor
        //Constructor 1
        public Taskd_workerDS() { this.db = new DBMAINContext(); } //End Constructor TaskdDS
        //Constructor 2
        public Taskd_workerDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
            this.initConstructor(this.db);
        } //End Constructor
        //Constructor 3
        public Taskd_workerDS(DBMAINContext poDBMAINContext, TaskdDS poDS)
        {
            this.db = poDBMAINContext;
            this.oDS = poDS;
        } //End Constructor

        public List<TaskdVM> getDatalist(int? pnTYPE, int? pnROLE_ID, int? pnRES_ID = null, int? pnASSIGNEE_ID = null) {
            List<TaskdVM> oQRY = null;

            //MASTER
            if (pnROLE_ID == valROLE.ROLEID_MASTER) oQRY = oDS.getDatalist();
            //ADMIN
            if (pnROLE_ID == valROLE.ROLEID_ADMIN) oQRY = oDS.getDatalist();
            //LEADER
            if (pnROLE_ID == valROLE.ROLEID_LEADER) {
                //oQRY = oDS.getDatalist_byRES_ID(null, pnRES_ID);
                oQRY = oDS.getDatalist_byRES_ID(pnRES_ID, pnASSIGNEE_ID);
            } //endif
            //MEMBER
            if (pnROLE_ID == valROLE.ROLEID_MEMBER) oQRY = oDS.getDatalist_byRES_ID(pnRES_ID, null);
            //OPEN
            if (pnTYPE == 1) oQRY = oQRY.Where(fld => fld.TASKD_PROGRESSPCT == null || fld.TASKD_PROGRESSPCT <= 0).ToList();
            //ONPROGRESS
            if (pnTYPE == 2) oQRY = oQRY.Where(fld => fld.TASKD_PROGRESSPCT != null && (fld.TASKD_PROGRESSPCT > 0 &&
                fld.TASKD_PROGRESSPCT < 100)).ToList();
            //FINISH
            if (pnTYPE == 3) oQRY = oQRY.Where(fld => (fld.TASKD_PROGRESSPCT != null && fld.TASKD_PROGRESSPCT == 100) &&
                (fld.TASKD_VALIDATESTS == null || fld.TASKD_VALIDATESTS == 0)).ToList();
            //VALIDATED
            if (pnTYPE == 4) oQRY = oQRY.Where(fld => (fld.TASKD_PROGRESSPCT != null && fld.TASKD_PROGRESSPCT == 100) &&
                (fld.TASKD_VALIDATESTS != null && fld.TASKD_VALIDATESTS > 0)).ToList();
            //GET ALL EXCEPET VALIDATED
            if (pnTYPE == 5) oQRY = oQRY.Where(fld => fld.TASKD_VALIDATESTS == null || fld.TASKD_VALIDATESTS == 0).ToList();


            this.oData_list = oQRY;
            return this.oData_list;
        } //End Method
    } //End Class
} //End namespace
