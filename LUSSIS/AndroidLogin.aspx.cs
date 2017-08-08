using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Profile;

namespace LUSSIS
{
    public partial class LoginTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request["username"];
            string password = Request["password"];
            string role = Request["role"];
            string empId = "";

            bool success = Membership.ValidateUser(username, password);

            if (success)
            {
                dynamic profile = ProfileBase.Create("clerk1");
                empId = profile.empId;
            }

            string json = "{\"Success\":\""+ success + "\", \"EmpId\":\""+ empId + "\"}";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
    }
}