using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using LUSSIS.RawCode.DAL;

namespace LUSSIS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //HU XIAOXI added
            System.Web.UI.ScriptManager.ScriptResourceMapping.AddDefinition
               ("jquery",
                new System.Web.UI.ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-1.12.4.min.js",
                    DebugPath = "~/scripts/jquery-1.12.4.js",
                    CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.12.4.min.js",
                    CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.12.4.js"
                }
               );
            //Zhang Jinshan Add
            System.Timers.Timer t = new System.Timers.Timer(60000);//check condition each minute
            t.Enabled = true;
            t.Elapsed += T_Elapsed;

        }
        //Zhang Jinshan Add
        public void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EmailBLL email = new EmailBLL();
            email.SendEmailsToClerk();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["xlPath"] = ""; //Peter
            Session["Err"] = ""; //Peter
            Session["Suppliers"] = new List<ADmodel.Supplier>();//Zhang Jinshan Add
            Session["AddItemlist"] = new List<Item>(); //HU XIAOXI
            Session["View"] = ""; //HU XIAOXI
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