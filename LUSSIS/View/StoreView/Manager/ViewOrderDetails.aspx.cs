using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;

namespace LUSSIS.View.StoreView.Manager
{
    public partial class ViewOrderDetails : System.Web.UI.Page
    {
        StockManagementBLL bll = new StockManagementBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int orderId = Convert.ToInt32(Request["orderId"]);
                BindData(orderId);
            }
        }

        private void BindData(int orderId)
        {
            PurchaseOrder po = bll.GetPurchaseOrder(orderId);
            lblPOId.Text = po.POId.ToString();
            lblSupplier.Text = po.Supplier.CompanyName;
            lblStatus.Text = po.Status;
            lblOrderBy.Text = po.OrderStoreEmployee.Name;
            lblComments.Text = po.ApproverComments;
            gvOrderDetails.DataSource = bll.GetPurchaseOrderItems(orderId);
            gvOrderDetails.DataBind();

            decimal total = 0;
            foreach (GridViewRow row in gvOrderDetails.Rows)
            {
                total += Convert.ToDecimal((row.FindControl("lblAmount") as Label).Text);
            }

            lblTotal.Text = total.ToString();

            //toggle btns based on status
            if (po.Status == PurchaseOrderStatus.PENDING.ToString())
            {
                btnApprove.Visible = true;
                btnReject.Visible = true;
                txtComments.Visible = true;
                lblComments.Visible = false;
            }
            else
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
                txtComments.Visible = false;
                lblComments.Visible = true;
            }
        }

        protected decimal GetItemPrice(int itemId, string supplierId)
        {
            Item item = bll.GetItem(itemId);
            if (item.Supplier1Id == supplierId)
            {
                return item.Supplier1Price;
            }
            else if (item.Supplier2Id == supplierId)
            {
                return item.Supplier2Price;
            }
            else if (item.Supplier3Id == supplierId)
            {
                return item.Supplier3Price;
            }
            else
            {
                return 0;
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(Request["orderId"]);
            PurchaseOrder po = bll.GetPurchaseOrder(orderId);
            po.ApproverComments = txtComments.Text;
            bll.RejectPurchaseOrder(po, bll.GetStoreEmployeeList()[2]);
            Response.Redirect("ViewOrders.aspx");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(Request["orderId"]);
            PurchaseOrder po = bll.GetPurchaseOrder(orderId);
            po.ApproverComments = txtComments.Text;
            bll.ApprovePurchaseOrder(po, bll.GetStoreEmployeeList()[2]);
            Response.Redirect("ViewOrders.aspx");
        }
    }
}