using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (User.Identity.IsAuthenticated) // if the user is already logged in
            {
                Response.Redirect("~/View/AccessDenied.aspx");
            }
        }

        protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            //IIdentity id = User.Identity;
            //dynamic profile = ProfileBase.Create(id.Name);

            ////Login log = (Login)Login1.FindControl("Login1");
            ////TextBox txtLogin = (TextBox)log.FindControl("UserName");
            ////if (txtLogin != null)
            ////{
            ////    MembershipUser mu = (Membership.GetUser(txtLogin.Text));
            ////    if (mu.IsApproved)
            ////    {
            ////Session["UserID"] = mu.ProviderUserKey.ToString();

            //if (User.IsInRole("StoreClerk") ||
            //    User.IsInRole("StoreManager") ||
            //    User.IsInRole("StoreSupervisor"))
            //{
            //    Session["storeEmpId"] = profile.empId;
            //}

            //else if (User.IsInRole("DeptEmp") ||
            //    User.IsInRole("DeptRep") ||
            //     User.IsInRole("DeptHead") ||
            //      User.IsInRole("DeptActingHead"))
            //{
            //    Session["empId"] = profile.empId;
            //}
        }
    }
}