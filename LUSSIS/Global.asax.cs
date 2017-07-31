using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace LUSSIS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["xlPath"] = ""; //Peter
            Session["Err"] = ""; //Peter
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError(); //Peter
            var httpException = ex.InnerException as HttpException;

            if (httpException.WebEventCode == System.Web.Management.WebEventCodes.RuntimeErrorPostTooLarge)
            {
                Response.Redirect("Default.aspx");
                Session["Err"] = "FileTooLarge";
            } //Peter
        }

        protected void Session_End(object sender, EventArgs e)
        {
            if ((string)Session["xlPath"] != "" && System.IO.File.Exists((string)Session["xlPath"])) //Peter
            {
                System.IO.File.Delete((string)Session["xlPath"]);
            } //Peter
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}