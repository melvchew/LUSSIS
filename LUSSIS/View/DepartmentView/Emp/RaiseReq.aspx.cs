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
        //EF model
        LUSSdb context;
        //BLL methods
        RequisitionBLL rs = new RequisitionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Item> litems = (List<Item>)Session["AddItemlist"];
                this.BindGrid(litems);
                
            }
        }

        //Bind the data to gridview and dropdownlist
        private void BindGrid(List<Item> litems)
        {
            using (context = new LUSSdb())
            {
                gvNewReqItem.DataSource = litems;
                gvNewReqItem.DataBind();
            }
        }

        //Add items
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogue.aspx?rid=0"); //0 -- new requisition
        }

        //Submit the new requisition
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (context = new LUSSdb())
            {
                if (Session["AddItemlist"] != null) //check if choose items or not
                {
                    //flag to count the negative int
                    int flag = 0;

                    List<Item> litems = (List<Item>)Session["AddItemlist"];

                    foreach (GridViewRow row in gvNewReqItem.Rows)
                    {
                        string qtyStr = (row.FindControl("txtBoxQty") as TextBox).Text;
                        int qty = Convert.ToInt32(qtyStr);
                        if (qty <= 0)
                            flag++;
                    }

                    if(flag > 0) //Has negative quantity
                        Response.Write(" <script language=JavaScript> alert('The quantity should be positive integer.'); </script>");
                    else  
                    {
                        //No negative quantity
                        int empid = Convert.ToInt32(Session["empId"]);
                        Employee emp = context.Employees.Where(em => em.EmpId == empid).ToList().First();
                        Requisition req = rs.CreateReq(emp, txtBoxComment.Text);

                        foreach (GridViewRow row in gvNewReqItem.Rows)
                        {
                            int itemid = Convert.ToInt32(gvNewReqItem.DataKeys[row.RowIndex].Value.ToString());
                            Item i = context.Items.Where(it => it.ItemId == itemid).ToList().First();
                            string qtyStr = (row.FindControl("txtBoxQty") as TextBox).Text;
                            int qty = Convert.ToInt32(qtyStr);
                            rs.AddReqItems(req, i, qty);
                        }

                        //Melvin Added
                        //Send Email Notification
                        EmailBLL ebll = new EmailBLL();
                        RolesManagementBLL rmbll = new RolesManagementBLL();
                        Department dept = rmbll.GetDeptByUser(emp);
                        ebll.SendRequisitionNotification(emp, req, dept);
                        //Melvin Added End

                        Session["AddItemlist"] = null;
                        Response.Redirect("ReqConfirm.aspx?rid=" + req.ReqId);
                    }
                }
                else
                {
                    Response.Write(" <script language=JavaScript> alert('Need to add at least one item!!!!'); </script>");
                }
            }
        }

        //Choose/Inverse all items in gv table
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

        //Remove the items
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

                    this.BindGrid(list);

                    if (list.Count == 0)
                    {
                        Session["AddItemlist"] = null;
                    }
                    else
                    {
                        Session["AddItemlist"] = list;
                    }
                }
                else
                {
                    Response.Write(" <script language=JavaScript> alert('No Item is chosen.'); </script>");
                }
            }
        }

        //Cancel raise requisition
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["AddItemlist"] = null;
            Response.Redirect("~/View/DepartmentView/Home.aspx");
        }
    }
}