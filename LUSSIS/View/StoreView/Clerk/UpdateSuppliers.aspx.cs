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
    public partial class UpdateSuppliers : System.Web.UI.Page
    {
        StockManagementBLL s = new StockManagementBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Supplier sp = new Supplier();
                    sp = s.getSupplierbyID(Request.QueryString["id"].ToString());
                    txtSupplierId.Text = sp.SupplierId;
                    txtCompanyName.Text = sp.CompanyName;
                    txtContactPerson.Text = sp.ContactPerson;
                    txtPhoneNo.Text = sp.Phone;
                    txtFaxNo.Text = sp.Fax;
                    txtAddress.Text = sp.Address;
                    txtEmail.Text = sp.Email;
                    txtGSTNo.Text = sp.GstNo;
                }
            }
        }
        //update supplier
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Supplier sp = new Supplier();
            sp.SupplierId = txtSupplierId.Text;
            sp.CompanyName = txtCompanyName.Text;
            sp.ContactPerson = txtContactPerson.Text;
            sp.Phone = txtPhoneNo.Text;
            sp.Fax = txtFaxNo.Text;
            sp.Address = txtAddress.Text;
            sp.Email = txtEmail.Text;
            sp.GstNo = txtGSTNo.Text;
            s.UpdateSupplier(sp);
            Response.Redirect("EditSuppliers.aspx");
        }
        //cancel and back to EditSuppliers.aspx
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditSuppliers.aspx");
        }
    }
}