﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (User.Identity.IsAuthenticated) // if the user is already logged in
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
        }
    }
}