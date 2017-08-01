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

        //delete items which user choose
        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Supplier> l1 = new List<Supplier>();
            Supplier s1 = new Supplier();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked == true)
                {
                    string id = (GridView1.Rows[i].FindControl("Label8") as Label).Text;
                    s1 = s.FindSupplierById(id);
                    l1.Add(s1);

                }

            }
            int items = 0;
            items = l1.Count;
            if (items== 0)
            {
                Label9.Visible = true;
                Label9.Text = "There is no item selected";

            }
            else
            {
               
                for (int i = 0; i < l1.Count; i++)
                {
                    s.DeleteSupplier(l1[i].SupplierId);
                }
                
            }
            
            GridView1.DataSource = s.FindAllSuppliers();
            GridView1.DataBind();

        }

        //Edit items which user choose
        protected void Button3_Click(object sender, EventArgs e)
        {
            List<Supplier> l = new List<Supplier>();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked == true)
                {
                    string id = (GridView1.Rows[i].FindControl("Label8") as Label).Text;
                    l.Add(s.FindSupplierById(id));

                }
            }

            if (l.Count != 0)
            {
                Label9.Visible = false;
                Session["Suppliers"] = l;
                Response.Redirect("UpdateSuppliers.aspx");
            }

            else
            {

                Label9.Visible = true;
                Label9.Text = "There is no item selected";
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Label9.Visible = false;
            TextBox1.Text = "";
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                cbox.Checked = false;
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
    }
}