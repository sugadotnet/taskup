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
    public class SysinfoDS
    {
        private DBMAINContext db;
        //Constructor 1
        public SysinfoDS() { this.db = new DBMAINContext(); } //End Constructor
        //Constructor 2
        public SysinfoDS(DBMAINContext poDBMAINContext)
        {
            this.db = poDBMAINContext;
        } //End Constructor

        public SysinfodetailVM getData()
        {
            SysinfodetailVM vReturn;


            var oQRY = from tb in this.db.Sysinfo_infos
                       select new SysinfodetailVM
                       {
                           ID = tb.ID,
                           SYSDATE = tb.SYSDATE
                       };
            vReturn = oQRY.First();

            return vReturn;
        } //End public SysinfodetailVM getData(int? id = null)
        public DateTime? getSYSDATE() {
            return this.getData().SYSDATE;
        } //End public DateTime? getSYSDATE()
        public SysinfodetailVM getSYSDATEVM()
        {
            SysinfodetailVM vReturn = this.getData();

            vReturn.SYSDAY = (Byte?)vReturn.SYSDATE.Value.Day;
            vReturn.SYSMONTH = (Byte?)vReturn.SYSDATE.Value.Month;
            vReturn.SYSYEAR = (Byte?)vReturn.SYSDATE.Value.Year;

            return vReturn;
        } //End public SysinfodetailVM getSYSDATEVM()
    } //End public class SysinfoDS
} //End namespace APPBASE.Models
