using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Filters;
using APPBASE.Svcapp;

namespace APPBASE.Controllers
{
    public partial class HomeController : Controller
    {
        [MyActionFilterAttribute]
        public virtual ActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard");
            //return View();
        }
        public virtual ActionResult About()
        {
            return View();
        }
        public virtual ActionResult Contact()
        {
            return View();
        }
    } //End public class HomeController : Controller
} //End namespace APPBASE.Controllers
