using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
using APPBASE.Svcapp;


namespace APPBASE.Controllers
{
    public partial class TaskController : Controller
    {
        public JsonResult Details_json(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            this.oData_detail = oDSDetail.getData(id);
            return Json(this.oData_detail, JsonRequestBehavior.AllowGet);
        }
    } //End Controller
} //End namespace
