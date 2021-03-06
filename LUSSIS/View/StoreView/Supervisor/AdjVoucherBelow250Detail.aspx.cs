﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.Generics;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View.StoreView.Supervisor
{
    public partial class AdjVoucherBelow250Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    VoucherManagementBLL b = new VoucherManagementBLL();
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    gvItemList.DataSource = b.getAdjustmentItemByID(id);
                    gvItemList.DataBind();
                    List<AdjustmentItem> list = b.getAdjustmentItemByID(id);
                    lblrequestID.Text = list[0].VoucherID.ToString();
                    lbldate.Text = list[0].SubmitDate.ToShortDateString();
                    lblEmpComment.Text = list[0].EmpComment.ToString();

                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            InvAdjVoucher iav = new InvAdjVoucher();
            VoucherManagementBLL b = new VoucherManagementBLL();
            iav.VoucherId = id;
            iav.ApproveBy = Convert.ToInt32(Session["storeEmpId"]); ;
            iav.ApproveDate = DateTime.Now;
            iav.ApproverComments = txtcomment.Text;
            iav.Status = "APPROVED";
            b.updateAdjVoucher(iav);
            string msg = "Request has been Approved";
            Response.Redirect("AdjVoucherBelow250.aspx?message=" + msg);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            InvAdjVoucher iav = new InvAdjVoucher();
            VoucherManagementBLL b = new VoucherManagementBLL();
            iav.VoucherId = id;
            iav.ApproveBy = Convert.ToInt32(Session["storeEmpId"]); ;
            iav.ApproveDate = DateTime.Now;
            iav.ApproverComments = txtcomment.Text;
            iav.Status = "REJECTED";
            b.updateAdjVoucher(iav);
            string msg = "Request has been Rejected";
            Response.Redirect("AdjVoucherBelow250.aspx?message=" + msg);
        }
    }
}