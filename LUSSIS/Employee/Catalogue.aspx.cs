using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL.data.HUXIAOXI;

//Made by Hu Xiaoxi(Team5)
namespace LUSSIS.Employee
{
    public partial class Catalogue : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL rs = new RequisitionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //String ReqId = Request.QueryString["rid"];
            //Literal1.Text="Reqsition ID: "+ReqId;
            if (!IsPostBack)
            {
                List<Item> litems = rs.GetCatalog();
                this.BindGrid(litems);
            }
        }


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

        protected void gvCatalog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCatalog.PageIndex = e.NewPageIndex;
            string category = droplistItemCategory.SelectedItem.Text;
            string itemname = txtBoxSearchItem.Text;
            List<Item> litems = new List<Item>();

            if (itemname != "" && itemname != "Please Enter the Item name")
            {
                litems = rs.SearchItemByName(itemname);
            }
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
                        int itemId =
                            Convert.ToInt32(gvCatalog.DataKeys[row.RowIndex].Value);
                        //Labl_Test.Text = itemId.ToString();
                        litems.Add(context.Items.Where(i => i.ItemId == itemId).ToList().First());
                    }
                }

                if (litems.Count != 0)
                {
                    if (rid == 0)
                    {
                        List<Item> listsession = (List<Item>)Session["AddItemlist"];
                        foreach (Item i in litems)
                        {
                            if (rs.CheckSameItem(i, listsession))
                            {
                                listsession.Add(i);
                            }
                        }
                        Session["AddItemlist"] = listsession;

                        Response.Redirect("CreateReq.aspx");
                    }
                    else
                    {
                        Session["AddItemlist"] = litems;

                        Response.Redirect("AddReqItem.aspx?rid=" + rid);
                    }
                }
                else
                {
                    Response.Write(" <script language=JavaScript> alert('No Items Added!!!!'); </script>");
                }
                List<Item> allItems = rs.GetCatalog();
                this.BindGrid(allItems);
            }
        }

        protected void droplistItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = droplistItemCategory.SelectedItem.Text;
            List<Item> litems = rs.SearchItemByCategory(category);
            this.BindGrid(litems);
            droplistItemCategory.Text = category;
            txtBoxSearchItem.Text = "";
        }

        protected void btnSearchItem_Click(object sender, EventArgs e)
        {
            string itemName = txtBoxSearchItem.Text;
            if (itemName != "Please Enter the Item name")
            {
                List<Item> litems = rs.SearchItemByName(itemName);
                this.BindGrid(litems);
            }
            else
            {
                List<Item> litems = rs.GetCatalog();
                this.BindGrid(litems);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int rid = Int32.Parse(Request.QueryString["rid"]);
            if (rid == 0)
            {
                Response.Redirect("CreateReq.aspx");
            }
            else
            {
                Response.Redirect("ManageReq.aspx?rid=" + rid);
            }

        }
    }
}