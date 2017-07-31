using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL.data.Khin;

namespace LUSSIS.View.StoreView.Clerk
{
    public partial class ProductList : System.Web.UI.Page
    {
         StockManagementBLL bl= new StockManagementBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
                gvProductList.DataSource = bl.searchProductList(txtSearch.Text);
                gvProductList.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewProduct.aspx?username=");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProduct.aspx?id=");
        }

        protected void gvProductList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String id = gvProductList.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("UpdateProduct.aspx?id=" + id);

        }

        protected void gvProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}