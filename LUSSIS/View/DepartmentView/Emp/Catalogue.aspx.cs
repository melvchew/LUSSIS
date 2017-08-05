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
    public partial class Catalogue : System.Web.UI.Page
    {
        //EF model
        LUSSdb context;
        //BLL methods
        RequisitionBLL rs = new RequisitionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Item> litems = rs.GetCatalog();
                this.BindGrid(litems);
            }
        }

        //Bind the data to gridview and dropdownlist
        private void BindGrid(List<Item> litems)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);
                using (context = new LUSSdb())
                {

                    gvCatalog.DataSource = litems;

                    gvCatalog.DataBind();

                    droplistItemCategory.DataSource = rs.GetCategory();

                    droplistItemCategory.DataBind();
                }
        }

        //Change page in gridview
        protected void gvCatalog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCatalog.PageIndex = e.NewPageIndex;
            string category = droplistItemCategory.SelectedItem.Text;
            string itemname = txtBoxSearchItem.Text;
            List<Item> litems = new List<Item>();

            //Change DataSource after searching by Item name 
            if (itemname != "" && itemname != "Please Enter the Item name")
            {
                litems = rs.SearchItemByName(itemname);
            }
            //Change DataSource after searching by Item category
            else if (category != "")
            {
                litems = rs.SearchItemByCategory(category);
            }
            else
            {
                litems = rs.GetCatalog();
            }
            this.BindGrid(litems);
            droplistItemCategory.Text = category;
        }

        //Choose/Inverse all items in gv table
        protected void chkAllItem_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkall = (CheckBox)gvCatalog.HeaderRow.FindControl("chkAllItem");

            foreach (GridViewRow row in gvCatalog.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("chkAddItem");
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

        //Add the chosen Items to requisition
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);
            using (context = new LUSSdb())
            {
                List<Item> litems = new List<Item>();
                foreach (GridViewRow row in gvCatalog.Rows)
                {
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chkAddItem");
                    if (cb != null && cb.Checked == true)
                    {
                        int itemId = Convert.ToInt32(gvCatalog.DataKeys[row.RowIndex].Value);
                        litems.Add(context.Items.Where(i => i.ItemId == itemId).ToList().First());
                    }
                }

                if (litems.Count != 0) //check if choose items or not
                {
                    if (rid == 0)  //0 -- new requisition
                    {
                        List<Item> listsession = new List<Item>();
                        if (Session["AddItemlist"] != null)   //Not the first time to add items
                        {
                            listsession = (List<Item>)Session["AddItemlist"];
                        foreach (Item i in litems)
                            {
                                if (rs.CheckSameItem(i, listsession))   //check duplicated items
                                {
                                    listsession.Add(i);   //add different items
                                }
                            }
                        }
                        else
                        {
                            foreach (Item i in litems)
                                listsession.Add(i);   //The first time to add items
                        }

                        Session["AddItemlist"] = listsession;

                        Response.Redirect("RaiseReq.aspx");
                    }
                    else  //Add items to PENDING requisition
                    {
                        Session["AddItemlist"] = litems;

                        Response.Redirect("AddReqItem.aspx?rid=" + rid);
                    }
                }
                else   //Do not choose any items
                {
                    Response.Write(" <script language=JavaScript> alert('No Items Added!!!!'); </script>");
                }

                //Re-bind data to gridview
                List<Item> allItems = rs.GetCatalog();
                this.BindGrid(allItems);
            }
        }

        //Change the searching item category
        protected void droplistItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = droplistItemCategory.SelectedItem.Text;
            List<Item> litems = rs.SearchItemByCategory(category);
            this.BindGrid(litems);
            droplistItemCategory.Text = category;
            txtBoxSearchItem.Text = "";
        }

        //Seach the item(By name)
        protected void btnSearchItem_Click(object sender, EventArgs e)
        {
            string itemName = txtBoxSearchItem.Text;
            if (itemName != "Please Enter the Item name") //Item name exist
            {
                List<Item> litems = rs.SearchItemByName(itemName);
                this.BindGrid(litems);
            }
            else //default search
            {
                List<Item> litems = rs.GetCatalog();
                this.BindGrid(litems);
            }
        }

        //cancel adding Items
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);
            if (rid == 0)  //0 -- new requisition
            {
                Response.Redirect("RaiseReq.aspx");
            }
            else   //go back to Manage Requisition page with the req id
            {
                Response.Redirect("ManageReq.aspx?rid=" + rid);
            }

        }
    }
}