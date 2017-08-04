using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;

namespace LUSSIS.View.StoreView.Clerk
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
            lblExpectedDate.Text = po.ExpectedDate.Value.Date.ToString();
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
                btnCancel.Visible = true;
                lblComments.Visible = false;

                pnlDelivery.Visible = false;
            }
            else if (po.Status == PurchaseOrderStatus.CANCELLED.ToString())
            {
                btnCancel.Visible = false;
                lblComments.Visible = false;

                pnlDelivery.Visible = false;
            }
            else if (po.Status == PurchaseOrderStatus.REJECTED.ToString())
            {
                btnCancel.Visible = false;
                lblComments.Visible = true;
                lblComments.Text = "Manager Comments: " + po.ApproverComments;

                pnlDelivery.Visible = false;
            }
            else
            {
                btnCancel.Visible = false;
                lblComments.Visible = true;
                lblComments.Text = po.ApproverComments;

                pnlDelivery.Visible = true;

                gvDeliveryDetails.DataSource = bll.GetPurchaseOrderItems(orderId);
                gvDeliveryDetails.DataBind();


                if (po.Status == PurchaseOrderStatus.APPROVED.ToString())
                {
                    btnRecieve.Visible = true;
                    txtRecievedDate.Visible = true;
                    lblRecievedDate.Visible = false;

                    foreach (GridViewRow row in gvDeliveryDetails.Rows)
                    {
                        (row.FindControl("lblRecievedQty") as Label).Visible = false;
                        (row.FindControl("lblRemark") as Label).Visible = false;
                        (row.FindControl("txtRecievedQty") as TextBox).Visible = true;
                        (row.FindControl("txtRemark") as TextBox).Visible = true;
                    }
                }
                else
                {
                    btnRecieve.Visible = false;
                    txtRecievedDate.Visible = false;
                    lblRecievedDate.Visible = true;
                    lblRecievedDate.Text = po.ReceiveDate.Value.Date.ToString();
                    foreach (GridViewRow row in gvDeliveryDetails.Rows)
                    {
                        (row.FindControl("lblRecievedQty") as Label).Visible = true;
                        (row.FindControl("lblRemark") as Label).Visible = true;
                        (row.FindControl("txtRecievedQty") as TextBox).Visible = false;
                        (row.FindControl("txtRemark") as TextBox).Visible = false;
                    }
                }
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(Request["orderId"]);
            PurchaseOrder po = bll.GetPurchaseOrder(orderId);

            bll.CancelPurchaseOrder(po);

            BindData(orderId);
        }

        protected void btnRecieve_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(Request["orderId"]);
            PurchaseOrder po = bll.GetPurchaseOrder(orderId);
            List<PurchaseOrderItem> orderItemList = bll.GetPurchaseOrderItems(orderId);

            foreach (GridViewRow row in gvDeliveryDetails.Rows)
            {
                int itemId = Convert.ToInt32((row.FindControl("hfItemId") as HiddenField).Value);
                PurchaseOrderItem poi = orderItemList.FirstOrDefault(x => x.POId == orderId && x.ItemId == itemId);
                poi.DeliverQty = Convert.ToInt32((row.FindControl("txtRecievedQty") as TextBox).Text);
                poi.Comments = (row.FindControl("txtRemark") as TextBox).Text;
            }

            bll.ReceivePurchaseOrder(po, bll.GetStoreEmployeeList()[5]);
        }
    }
}