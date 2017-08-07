using System;
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
        //EF model
        LUSSdb context;
        //BLL methods
        RequisitionBLL rs = new RequisitionBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            btn_Add.BackColor = System.Drawing.Color.FromArgb( 255, 39, 174, 96);
            btn_CancelReq.BackColor = System.Drawing.Color.FromArgb(255, 192, 57, 43);
            btn_Remov.BackColor= System.Drawing.Color.FromArgb(255, 241, 196, 15);

            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        //Bind the data to gridview and Literals
        private void BindGrid()
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);

            using (context = new LUSSdb())
            {
                Requisition req = context.Requisitions.Where(r => r.ReqId == rid).ToList().First();
                
                //Requisition details
                Lite_ReqStatus.Text = "Requisition Status: " + req.Status;
                Lite_ReqId.Text = "Requisition ID: " + req.ReqId;
                Lite_ReqDate.Text = "Requisition Date: " + String.Format("{0:D}", req.SubmitDate);

                List<RequisitionItem> lreqItems = rs.GetReqItems(req);

                gvReqItem.DataSource = lreqItems;

                gvReqItem.DataBind();
            }
        }

        //Cancel the PENDING requisition
        protected void btn_CancelReq_Click(object sender, EventArgs e)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);
            using (context = new LUSSdb())
            {
                rs.CancelReq(context.Requisitions.Where(r => r.ReqId == rid).ToList().First());
                Response.Write(" <script language=JavaScript> alert('Requisition has been cancelled.'); </script>");
            }

            //Go to View requisition page
            //can not manage the CANCELLED requisition 
            Response.Redirect("ViewReq.aspx?rid=" + rid);
        }

        //Remove reqItems from requisition
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
                //If remove items num between zero to all
                if (lreqItems.Count != 0 && lreqItems.Count < rows)
                {
                    rs.DeleteReqItems(lreqItems);
                }
                //Can not remove zero item
                else if (lreqItems.Count == 0)
                {
                    Response.Write(" <script language=JavaScript> alert('No Item is removed.'); </script>");
                }
                //Can not remove all the items
                else if(lreqItems.Count == rows)
                {
                    Response.Write(" <script language=JavaScript> alert('Can not remove all the Items.'); </script>");
                }
                this.BindGrid();
            }
        }

        //Choose/Inverse all items in gv table
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

        //Edit requisitionItem quantity
        protected void gvReqItem_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvReqItem.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        //update requisitionItem quantity
        protected void gvReqItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Qty num is null
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

                if (quantity <= 0)  //Has negative quantity
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

        //Cancel edit requisitionItem quantity
        protected void gvReqItem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvReqItem.EditIndex = -1;
            this.BindGrid();
        }

        //Add new requisition items
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            String rid = Request.QueryString["rid"];
            Response.Redirect("Catalogue.aspx?rid=" + rid);
        }

        //Change page in gridview
        protected void gvReqItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReqItem.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        //Go back to previous page
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