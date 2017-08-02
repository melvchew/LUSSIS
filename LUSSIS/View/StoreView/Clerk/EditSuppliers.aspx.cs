using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View.StoreView.Clerk
{
    public partial class EditSuppliers : System.Web.UI.Page
    {
        StockManagementBLL s = new StockManagementBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
           
           
            if (!IsPostBack)
            {
                GridView1.DataSource = s.FindAllSuppliers();
                GridView1.DataBind();
            }
        }

        //search item by company name
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Label9.Visible = true;
                Label9.Text = "Please input companyname!";
            }
            else
            {
                Label9.Visible = false;
                List<Supplier> l1 = new List<Supplier>();
                l1 = s.SearchSupplier(TextBox1.Text);
                if (l1.Count != 0)
                {
                    GridView1.DataSource = l1;
                    GridView1.DataBind();
                }
                else
                {
                    Label9.Visible = true;
                    Label9.Text = "There is no matching item";
                }
            }


        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LUSSdb entity = new LUSSdb();
            List<Supplier> l1 = entity.Suppliers.ToList();
            GridView1.DataSource = l1;
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String id = GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("UpdateSuppliers.aspx?id=" + id);
        }
    }
}