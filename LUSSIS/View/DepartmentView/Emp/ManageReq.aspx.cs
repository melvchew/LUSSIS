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
    public partial class ManageReq : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL rs = new RequisitionBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);

            using (context = new LUSSdb())
            {
                Requisition req = context.Requisitions.Where(r => r.ReqId == rid).ToList().First();

                Lite_ReqStatus.Text = "Requisition Status: " + req.Status;
                Lite_ReqId.Text = "Requisition ID: " + req.ReqId;
                Lite_ReqDate.Text = "Requisition Date: " + String.Format("{0:D}", req.SubmitDate);

                List<RequisitionItem> lreqItems = rs.GetReqItems(req);

                gvReqItem.DataSource = lreqItems;

                gvReqItem.DataBind();
            }
        }

        protected void btn_CancelReq_Click(object sender, EventArgs e)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);
            using (context = new LUSSdb())
            {
                rs.CancelReq(context.Requisitions.Where(r => r.ReqId == rid).ToList().First());
                Response.Write(" <script language=JavaScript> alert('Cancelled successfully!'); </script>");
            }
            Response.Redirect("ViewReq.aspx?rid=" + rid);
        }

        protected void btn_Remov_Click(object sender, EventArgs e)
        {
            using (context = new LUSSdb())
            {
                List<RequisitionItem> lreqItems = new List<RequisitionItem>();
                int rows = 0;
                foreach (GridViewRow row in gvReqItem.Rows)
                {
                    int rid = Int32.Parse(Request.QueryString["rid"]);
                    rows++;
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("ItemSelector");
                    if (cb != null && cb.Checked == true)
                    {
                        int itemId =
                            Convert.ToInt32(gvReqItem.DataKeys[row.RowIndex].Value);
                        lreqItems.Add(context.RequisitionItems.Where(ri => ri.ReqId == rid && ri.ItemId == itemId).ToList().First());
                    }
                }

                if (lreqItems.Count != 0 && lreqItems.Count < rows)
                {
                    rs.DeleteReqItems(lreqItems);
                }
                else if(lreqItems.Count == 0)
                {
                    Response.Write(" <script language=JavaScript> alert('No Item is removed.'); </script>");
                }
                else if(lreqItems.Count == rows)
                {
                    Response.Write(" <script language=JavaScript> alert('Can not remove all the Items.'); </script>");
                }
                this.BindGrid();
            }
        }


        protected void AllItems_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkall = (CheckBox)gvReqItem.HeaderRow.FindControl("AllItems");

            foreach (GridViewRow row in gvReqItem.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("ItemSelector");
                if (chkall.Checked)
                {
                    // Access the CheckBox
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }

        protected void gvReqItem_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvReqItem.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void gvReqItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            if ((gvReqItem.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text == "")
            {
                (gvReqItem.Rows[e.RowIndex].FindControl("lblerror") as Label).Text = "Quantity is required!";
            }
            else
            {
                int reqId = Int32.Parse(Request.QueryString["rid"]);
                int itemId = Convert.ToInt32(gvReqItem.DataKeys[e.RowIndex].Value);
                GridViewRow row = gvReqItem.Rows[e.RowIndex];
                int quantity = Convert.ToInt32((row.FindControl("TextBox2") as TextBox).Text);
                if (quantity <= 0)
                {
                    Response.Write(" <script language=JavaScript> alert('The quantity should be positive integer.'); </script>");
                }
                else
                {
                    rs.UpdateReqItems(reqId, itemId, quantity);
                    gvReqItem.EditIndex = -1;
                    this.BindGrid();
                }
            }
               
        }

        protected void gvReqItem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvReqItem.EditIndex = -1;
            this.BindGrid();
        }



        protected void btn_Add_Click(object sender, EventArgs e)
        {
            String rid = Request.QueryString["rid"];
            Response.Redirect("Catalogue.aspx?rid=" + rid);
        }

        protected void gvReqItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReqItem.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

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