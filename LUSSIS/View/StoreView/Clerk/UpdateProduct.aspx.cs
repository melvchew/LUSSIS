using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL.data.Khin;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View.StoreView.Clerk
{
    public partial class UpdateProduct : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    Item i = b.getProductByIDs(id);
                    txtID.Text = id.ToString();
                    txtBin.Text = i.BinNumber;
                    ddCategory.SelectedValue = i.Category;
                    txtDescription.Text = i.Description;
                    txtStockBalance.Text = i.StockBalance.ToString();
                    txtReorderLvl.Text = i.ReorderLvl.ToString();
                    txtReorderQty.Text = i.ReorderQty.ToString();
                    ddUnit.SelectedValue = i.Unit;
                    ddSupplier1.SelectedValue = i.Supplier1Id;
                    txtSupplier1Price.Text = i.Supplier1Price.ToString();
                    ddSupplier2.SelectedValue = i.Supplier2Id;
                    txtSupplier2Price.Text = i.Supplier2Price.ToString();
                    ddSupplier3.SelectedValue = i.Supplier3Id;
                    txtSupplier3Price.Text = i.Supplier3Price.ToString();
                    cbIsCataloged.Checked = i.IsCataloged;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            StockManagementBLL b = new StockManagementBLL();
            Item i = new Item();
            i.ItemId = Convert.ToInt32(txtID.Text);
            i.BinNumber = txtBin.Text;
            i.Category = ddCategory.Text;
            i.Description = txtDescription.Text;
            i.StockBalance = Convert.ToInt32(txtStockBalance.Text);
            i.ReorderLvl = Convert.ToInt32(txtReorderLvl.Text);
            i.ReorderQty = Convert.ToInt32(txtReorderQty.Text);
            i.Unit = ddUnit.Text;
            i.Supplier1Id = ddSupplier1.SelectedValue;
            i.Supplier1Price = Convert.ToDecimal(txtSupplier1Price.Text);
            i.Supplier2Id = ddSupplier2.SelectedValue;
            i.Supplier2Price = Convert.ToDecimal(txtSupplier2Price.Text);
            i.Supplier3Id = ddSupplier3.SelectedValue;
            i.Supplier3Price = Convert.ToDecimal(txtSupplier3Price.Text);
            i.IsCataloged = cbIsCataloged.Checked;

            Boolean result = b.updateProduct(i);

            if (result)
            {
                Response.Redirect("ProductList.aspx");
            }
            else
            {
                lblError.Text = "Update Failed";
            }
        }
    }
}