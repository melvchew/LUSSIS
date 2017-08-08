using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
namespace LUSSIS.View.StoreView.Clerk
{
    public partial class AddNewSupplier : System.Web.UI.Page
    {

        StockManagementBLL s = new StockManagementBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Add new Supplier
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (s.CheckSupplierID(txtSupplierId.Text) == false)
            {

                s.InsertNewSupplier(txtSupplierId.Text, txtCompanyName.Text, txtContactPerson.Text, txtPhoneNo.Text, txtFaxNo.Text, txtAddress.Text, txtEmail.Text, txtGSTNo.Text);
                HttpContext.Current.Response.Write("<script>alert('Add successfully!')</script>");
                clear();

            }

            else
            {
                HttpContext.Current.Response.Write("<script>alert('Supplier ID has existed')</script>");
            }

        }
        //clear content of textbox
        protected void clear()
        {
            txtSupplierId.Text = "";
            txtCompanyName.Text = "";
            txtContactPerson.Text = "";
            txtPhoneNo.Text = "";
            txtFaxNo.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtGSTNo.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}