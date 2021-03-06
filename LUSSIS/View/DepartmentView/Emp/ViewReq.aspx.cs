﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;

//Made by Hu Xiaoxi(Team5)
namespace LUSSIS.View.DepartmentView.Emp
{
    public partial class ViewReq : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL rs = new RequisitionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);

            //Bind the data to gridview and Literals
            using (context = new LUSSdb())
            {
                Requisition req = context.Requisitions.Where(r => r.ReqId == rid).ToList().First();

                Lite_ReqStatus.Text = "Requisition Status: " + req.Status;
                Lite_ReqId.Text = "Requisition ID: " + req.ReqId;
                Lite_ReqDate.Text = "Requisition Date: " + String.Format("{0:D}", req.SubmitDate);

                List<RequisitionItem> lreqItems = rs.GetReqItems(req);

                gvDisReqItem.DataSource = lreqItems;

                gvDisReqItem.DataBind();
            }
        }

        //Back to prvious page
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if ((String)Session["View"] == "dept")
            {
                Response.Redirect("ViewDeptReqHistory.aspx");
            }
            else if ((String)Session["View"] == "own")
            {
                Response.Redirect("ViewUserReqHistory.aspx");
            }
        }
    }
}