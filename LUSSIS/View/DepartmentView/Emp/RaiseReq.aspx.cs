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
    public partial class RaiseReq : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL rs = new RequisitionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Item> litems = (List<Item>)Session["AddItemlist"];
                this.BindGrid(litems);
            }

        }

        private void BindGrid(List<Item> litems)
        {

            using (context = new LUSSdb())
            {
                gvNewReqItem.DataSource = litems;
                gvNewReqItem.DataBind();
            }
        }

        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogue.aspx?rid=0");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (context = new LUSSdb())
            {
                if (Session["AddItemlist"] != null)
                {
                    int empid = 4;
                    Employee emp = context.Employees.Where(em => em.EmpId == empid).ToList().First();
                    Requisition req = rs.CreateReq(emp, txtBoxComment.Text);

                    List<Item> litems = (List<Item>)Session["AddItemlist"];

                    foreach (GridViewRow row in gvNewReqItem.Rows)
                    {
                        int itemid = Convert.ToInt32(gvNewReqItem.DataKeys[row.RowIndex].Value.ToString());
                        Item i = context.Items.Where(it => it.ItemId == itemid).ToList().First();
                        string qtyStr = (row.FindControl("txtBoxQty") as TextBox).Text;
                        int qty = Convert.ToInt32(qtyStr);
                        rs.AddReqItems(req, i, qty);
                    }

                    Response.Redirect("ReqConfirm.aspx?rid=" + req.ReqId);
                }
                else
                {
                    Response.Write(" <script language=JavaScript> alert('Need to add at least one item!!!!'); </script>");
                }
                Session["AddItemlist"] = null;
            }
        }

        protected void chkAllItem_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkall = (CheckBox)gvNewReqItem.HeaderRow.FindControl("chkAllItem");

            foreach (GridViewRow row in gvNewReqItem.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("chkNewItem");
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

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            using (context = new LUSSdb())
            {
                List<Item> litems = new List<Item>();
                foreach (GridViewRow row in gvNewReqItem.Rows)
                {
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chkNewItem");
                    if (cb != null && cb.Checked == true)
                    {
                        int itemId =
                            Convert.ToInt32(gvNewReqItem.DataKeys[row.RowIndex].Value);
                        //Labl_Test.Text = itemId.ToString();
                        litems.Add(context.Items.Where(i => i.ItemId == itemId).ToList().First());
                    }
                }

                if (litems.Count != 0)
                {
                    List<Item> list = (List<Item>)Session["AddItemlist"];
                    foreach (Item i in litems)
                    {
                        var item = list.Where(l => l.ItemId == i.ItemId).First();
                        list.Remove(item);
                    }
                    Session["AddItemlist"] = list;
                }
                else
                {
                    Response.Write(" <script language=JavaScript> alert('No Item remove!!!!'); </script>");
                }
                litems = (List<Item>)Session["AddItemlist"];
                this.BindGrid(litems);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["AddItemlist"] = null;
            Response.Redirect("~/View/DepartmentView/Home.aspx");
        }
    }
}