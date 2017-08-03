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
    public partial class AddNewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StockManagementBLL b = new StockManagementBLL();
                
                ddSupplier1.DataSource = b.getSupplierList();
                ddSupplier1.DataTextField = "CompanyName";
                ddSupplier1.DataValueField = "SupplierId";
                ddSupplier1.DataBind();
                ddSupplier2.DataSource = b.getSupplierList();
                ddSupplier2.DataTextField = "CompanyName";
                ddSupplier2.DataValueField = "SupplierId";
                ddSupplier2.DataBind();
                ddSupplier3.DataSource = b.getSupplierList();
                ddSupplier3.DataTextField = "CompanyName";
                ddSupplier3.DataValueField = "SupplierId";
                ddSupplier3.DataBind();
                ddCategory.DataSource = b.getCategory();
                ddCategory.DataBind();
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(ddSupplier1.SelectedValue == ddSupplier2.SelectedValue)
            {
                lblerror.Text = "Suppler 1 and 2 must not be same.";
            }
            else if(ddSupplier1.SelectedValue == ddSupplier3.SelectedValue)
            {
                lblerror.Text = "Suppler 1 and 3 must not be same.";
            }
            else if(ddSupplier2.SelectedValue == ddSupplier3.SelectedValue)
            {
                lblerror.Text = "Suppler 2 and 3 must not be same.";
            }
            else
            {
                StockManagementBLL b = new StockManagementBLL();
                Item i = new Item();
                i.BinNumber = txtBin.Text;
                i.Category = ddCategory.Text;
                i.Description = txtDescription.Text;
                i.StockBalance = Convert.ToInt32(txtStockBalance.Text);
                i.ReorderLvl = Convert.ToInt32(txtReorderLevel.Text);
                i.ReorderQty = Convert.ToInt32(txtReorderQty.Text);
                i.Unit = ddUnitofMeasure.Text;
                i.Supplier1Id = ddSupplier1.SelectedValue;
                i.Supplier1Price = Convert.ToDecimal(txtSupplier1Price.Text);
                i.Supplier2Id = ddSupplier2.SelectedValue;
                i.Supplier2Price = Convert.ToDecimal(txtSupplier2Price.Text);
                i.Supplier3Id = ddSupplier3.SelectedValue;
                i.Supplier3Price = Convert.ToDecimal(txtSupplier3Price.Text);
                i.IsCataloged = cbIsCataloged.Checked;

                Boolean result = b.addProduct(i);
                if (result)
                {
                    Response.Redirect("ProductList.aspx");
                }
                else
                {
                    lblerror.Text = "Add New Product Faile";
                }
            }
            

        }
    }
}