using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using APPBASE.Helpers;
using APPBASE.Filters;

namespace APPBASE
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Register global filter
            //GlobalFilters.Filters.Add(new MyActionFilterAttribute());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            ViewEngines.Engines.Add(new RDDBViewEngine());
        } //End protected void Application_Start()
        protected void Session_Start(object sender, EventArgs e)
        {
            //Set Default Session
            hlpConfig.SessionInfo.setDefSession();
        } //End protected void Session_Start(object sender, EventArgs e)
    } //End public class MvcApplication : System.Web.HttpApplication


    /*
        Note that {1} in the location format is the Controller name
     *  and {0} is the name of the view.
     *  
        Then add that view engine to the MVC ViewEngines.Engines
     * Collection in the Application_Start() method in your global.asax:
     * ViewEngines.Engines.Add(new RDDBViewEngine()); 
    */
    public class RDDBViewEngine : RazorViewEngine
    {
        private static readonly string[] NewPartialViewFormats = 
        { 
            "~/Views/{1}/Partials/{0}.cshtml"
            ,"~/Views/Shared/Layouts/{0}.cshtml"
            ,"~/Views/Shared/Buttons/{0}.cshtml"
            ,"~/Views/Shared/Lookups/{0}.cshtml"
            ,"~/Views/Shared/Others/{0}.cshtml"

            ,"~/Views/Shared/Menus/{0}.cshtml"
            ,"~/Views/Shared/Menus/Expense/{0}.cshtml"
        };

        public RDDBViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
        }
    } //End public class RDDBViewEngine : RazorViewEngine
} //End namespace APPBASE