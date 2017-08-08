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

                MakeLowStockChangeColor(GridView1.Rows.Count);
            }


        }
        //make low stock row change color
        protected void MakeLowStockChangeColor(int m)
        {
            for (int i = 0; i < m; i++)
            {
                string stockBalance = (GridView1.Rows[i].FindControl("lblStockBalance") as Label).Text;
                string reorderLevel = (GridView1.Rows[i].FindControl("lblReorderLvl") as Label).Text;
                if (Convert.ToInt32(stockBalance) < Convert.ToInt32(reorderLevel))
                {

                    GridView1.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                }
            }
        }
        //Page changing
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                GridView1.DataSource = report.GetAllStockStatus();
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
                MakeLowStockChangeColor(GridView1.Rows.Count);
            }
            else
            {
                List<Item> l1 = new List<Item>();
                l1 = report.SearchItemByDescription(txtSearch.Text);
                if (l1.Count != 0)
                {
                    GridView1.DataSource = l1;
                    GridView1.PageIndex = e.NewPageIndex;
                    GridView1.DataBind();
                }
                MakeLowStockChangeColor(GridView1.Rows.Count);
            }

        }

        //get low stock items
        protected void btnLowStockItems_Click(object sender, EventArgs e)
        {
            btnBack.Visible = true;
            List<Item> l1 = new List<Item>();
            l1 = report.GetLowStock();
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            GridView1.DataSource = report.GetAllStockStatus();
            GridView1.DataBind();
            MakeLowStockChangeColor(GridView1.Rows.Count);
        }
        //search item
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                Label9.Visible = false;
                GridView1.DataSource = report.FindAllItems();
                GridView1.DataBind();
                MakeLowStockChangeColor(GridView1.Rows.Count);
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
                    MakeLowStockChangeColor(GridView1.Rows.Count);
                }
                else
                {
                    GridView1.DataSource = l1;
                    GridView1.DataBind();
                    Label9.Visible = true;
                    Label9.Text = "There is no item matched";
                }
            }

        }
    }
}