﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AD.EF;

namespace AD_Web
{
    public partial class AdjustmentVoucherDetailBelow250 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BissLog b = new BissLog();
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    gvItemList.DataSource = b.getAdjustmentItemByID(id);
                    gvItemList.DataBind();
                    List<AdjustmentItem> list = b.getAdjustmentItemByID(id);
                    lblrequestID.Text = list[0].VoucherID.ToString();
                    lbldate.Text = list[0].SubmitDate.ToShortDateString();

                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            InvAdjVoucher iav = new InvAdjVoucher();
            BissLog b = new BissLog();
            iav.VoucherId = id;
            iav.ApproveBy = 1;
            iav.ApproveDate = DateTime.Now;
            iav.ApproverComments = txtcomment.Text;
            iav.Status = "APPROVED";
            b.updateAdjVoucher(iav);
            string msg = "Request has been Approved";
            Response.Redirect("AdjustmentVoucherBelow250.aspx?message=" + msg);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            InvAdjVoucher iav = new InvAdjVoucher();
            BissLog b = new BissLog();
            iav.VoucherId = id;
            iav.ApproveBy = 1;
            iav.ApproveDate = DateTime.Now;
            iav.ApproverComments = txtcomment.Text;
            iav.Status = "REJECTED";
            b.updateAdjVoucher(iav);
            string msg = "Request has been Rejected";
            Response.Redirect("AdjustmentVoucherBelow250.aspx?message=" + msg);
        }
    }
}