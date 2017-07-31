using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS.View.StoreView.Clerk
{
    public partial class Inventory_Status_Report : System.Web.UI.Page
    {
        InventoryStatusReport report = new InventoryStatusReport();
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
                        GridView1.Rows[i].BackColor = System.Drawing.Color.Green;
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

                    GridView1.Rows[i].BackColor = System.Drawing.Color.Green;
                }
            }
        }

        //get low stock items
        protected void Button1_Click(object sender, EventArgs e)
        {

            GridView1.DataSource = report.GetLowStock();
            GridView1.DataBind();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.Green;
            }
        }
    }
}