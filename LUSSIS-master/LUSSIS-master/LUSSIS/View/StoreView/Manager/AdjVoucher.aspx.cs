using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL.data.Khin;

namespace LUSSIS.View.StoreView.Manager
{
    public partial class AdjVoucher : System.Web.UI.Page
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
                VoucherManagementBLL b = new VoucherManagementBLL();
                gvVoucher.DataSource = b.getAdjVoucherList();
                gvVoucher.DataBind();

            }
        }

        protected void gvVoucher_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            String id = gvVoucher.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("AdjVoucherDetail.aspx?id=" + id);
        }
    }
}