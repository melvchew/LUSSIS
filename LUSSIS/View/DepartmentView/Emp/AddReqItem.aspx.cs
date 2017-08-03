using System;
using System.Collections;
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
    public partial class AddReqItem : System.Web.UI.Page
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
                List<Item> litems = (List<Item>)Session["AddItemlist"];

                gvAddReqItems.DataSource = litems;

                gvAddReqItems.DataBind();
            }
        }

        protected void btdAddItem_Click(object sender, EventArgs e)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);
            int flag = 0;
            using (context = new LUSSdb())
            {
                List<Item> litems = (List<Item>)Session["AddItemlist"];
                Hashtable lqty = new Hashtable();

                foreach (GridViewRow row in gvAddReqItems.Rows)
                {
                    lqty.Add(gvAddReqItems.DataKeys[row.RowIndex].Value.ToString(), (row.FindControl("TextBox3") as TextBox).Text);
                }

                foreach(String value in lqty.Values)
                {
                    int v = Int32.Parse(value);
                    if (v<=0)
                    {
                        flag++;
                    }
                }

                if (flag == 0)
                {
                    foreach (Item i in litems)
                    {
                        string itemid = i.ItemId.ToString();
                        int qty = Convert.ToInt32(lqty[itemid]);
                        Requisition req = context.Requisitions.Where(r => r.ReqId == rid).ToList().First();
                        rs.AddReqItems(req, i, qty);
                    }

                    Session["AddItemlist"] = null;
                    Response.Redirect("ManageReq.aspx?rid=" + rid);
                }
                else
                {
                    Response.Write(" <script language=JavaScript> alert('The quantity should be positive integer.'); </script>");
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);
            Session["AddItemlist"] = null;
            Response.Redirect("ManageReq.aspx?rid=" + rid);
        }
    }
}