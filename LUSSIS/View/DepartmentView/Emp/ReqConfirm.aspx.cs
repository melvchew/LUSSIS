﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;

//Made by Hu Xiaoxi(Team5)
namespace LUSSIS.View.DepartmentView.Emp
{
    public partial class ReqConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string rid = Request.QueryString["rid"];
            //show the requisition id and bulid successfully info
            litaConfirm.Text = "Requisition succeeded, requisition id is " + rid + ". ";
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/DepartmentView/Home.aspx");
        }
    }
}