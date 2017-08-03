using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.BLL.data.ZhangJinshan;

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

            //Melvin added
            LUSSIS.RawCode.BLL.RolesManagementBLL rmBLL = new LUSSIS.RawCode.BLL.RolesManagementBLL();
            rmBLL.CheckExistingAH();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["xlPath"] = ""; //Peter
            Session["Err"] = ""; //Peter
            Session["AddItemlist"] = null; //HU XIAOXI
            Session["View"] = ""; //HU XIAOXI
            Session["empId"] = null; //Phong
            Session["storeEmpId"] = null; //Phong
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Peter
            var ex = Server.GetLastError();
            var httpException = ex.InnerException as HttpException;

            if (httpException != null)
            {
                if (httpException.WebEventCode == System.Web.Management.WebEventCodes.RuntimeErrorPostTooLarge)
                {
                    Response.Redirect("UploadExcel.aspx");
                    Session["Err"] = "FileTooLarge";
                }
            }
            //Peter
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