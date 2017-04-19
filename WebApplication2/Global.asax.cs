using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MvcApplication));

            var lastError = Server.GetLastError();

            Exception exception = lastError;
            var serverError = lastError as HttpException;

            if(serverError != null && serverError.GetHttpCode() == 404)
            {
                Response.Redirect("/Home/Error404");
            }
            else if(serverError != null && serverError.GetHttpCode() == 403)
            {
                Response.Redirect("/Home/Error403");
            }
            else
            {
                logger.Error(exception.ToString());
                Server.ClearError();
                Response.Redirect("/Home/Error500");
            }


            


            /*
            if (null != serverError)
            {
                int errorCode = serverError.GetHttpCode();

                if (404 == errorCode)
                {
                    Server.ClearError();
                    Response.Redirect("/Home/Error500");
                }
                else
                {
                    logger.Error(exception.ToString());
                    Debug.WriteLine("exception.GetBaseException() :" + exception.GetBaseException());
                    Debug.WriteLine("exception.Message() :" + exception.Message);
                    Debug.WriteLine("exception.Source() :" + exception.Source);
                    Debug.WriteLine("exception.StackTrace() :" + exception.StackTrace);
                    Server.ClearError();
                    Response.Redirect("/Home/Error500");
                }
            }
            */

        }
    }
}
