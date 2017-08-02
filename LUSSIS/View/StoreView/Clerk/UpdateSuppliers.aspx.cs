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
        List<Supplier> l;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Supplier sp = new Supplier();
                    sp = s.getSupplierbyID(Request.QueryString["id"].ToString());
                    TextBox1.Text = sp.SupplierId;
                    TextBox2.Text = sp.CompanyName;
                    TextBox3.Text = sp.ContactPerson;
                    TextBox4.Text = sp.Phone;
                    TextBox5.Text = sp.Fax;
                    TextBox6.Text = sp.Address;
                    TextBox7.Text = sp.Email;
                    TextBox8.Text = sp.GstNo;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Supplier sp = new Supplier();
            sp.SupplierId = TextBox1.Text;
            sp.CompanyName = TextBox2.Text;
            sp.ContactPerson = TextBox3.Text;
            sp.Phone = TextBox4.Text;
            sp.Fax = TextBox5.Text;
            sp.Address = TextBox6.Text;
            sp.Email = TextBox7.Text;
            sp.GstNo = TextBox8.Text;
            s.UpdateSupplier(sp);


        }
    }
}