using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AD.EF;

namespace AD_Web
{
    public partial class AdjustmentVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["message"] != null)
                {
                    lblAppOrRej.Text = Request.QueryString["message"];
                }
                else
                {
                    lblAppOrRej.Text = null;
                }
                BissLog b = new BissLog();
                gvVoucher.DataSource = b.getAdjVoucherListBelow250();
                gvVoucher.DataBind();
            }
        }

        protected void gvVoucher_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String id = gvVoucher.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("AdjustmentVoucherDetailBelow250.aspx?id=" + id);
        }
    }
}