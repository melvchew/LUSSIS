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
    public partial class Inventory_Status_Report : System.Web.UI.Page
    {
        ReportBLL report = new ReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    GridView1.DataSource = report.GetAllStockStatus();

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);
                }

                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    string stockBalance = (GridView1.Rows[i].FindControl("Label5") as Label).Text;
                    string reorderLevel = (GridView1.Rows[i].FindControl("Label6") as Label).Text;
                    if (Convert.ToInt32(stockBalance) < Convert.ToInt32(reorderLevel))
                    {
                        GridView1.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                    }
                }
            }


        }
        //Page changing
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.DataSource = report.GetAllStockStatus();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                string stockBalance = (GridView1.Rows[i].FindControl("Label5") as Label).Text;
                string reorderLevel = (GridView1.Rows[i].FindControl("Label6") as Label).Text;
                if (Convert.ToInt32(stockBalance) < Convert.ToInt32(reorderLevel))
                {

                    GridView1.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                }
            }
        }

        //get low stock items
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button2.Visible = true;
            List<Item> l1 = new List<Item>();
            l1= report.GetLowStock();
            if (l1.Count != 0)
            {
                GridView1.DataSource = l1;
                GridView1.DataBind();
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    GridView1.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('There is no Low Stock Item')</script>");
                
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button2.Visible =false;
            GridView1.DataSource = report.GetAllStockStatus();
            GridView1.DataBind();

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                string stockBalance = (GridView1.Rows[i].FindControl("Label5") as Label).Text;
                string reorderLevel = (GridView1.Rows[i].FindControl("Label6") as Label).Text;
                if (Convert.ToInt32(stockBalance) < Convert.ToInt32(reorderLevel))
                {

                    GridView1.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                Label9.Visible = false;
                GridView1.DataSource = report.FindAllItems();
                GridView1.DataBind();
            }
            else
            {
                Label9.Visible = false;
                List<Item> l1 = new List<Item>();
                l1 = report.SearchItemByDescription(txtSearch.Text);
                if (l1.Count != 0)
                {
                    GridView1.DataSource = l1;
                    GridView1.DataBind();
                }
                else
                {
                    Label9.Visible = true;
                    Label9.Text = "There is no item matched";
                }
            }

        }
    }
}