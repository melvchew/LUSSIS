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

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (s.CheckSupplierID(TextBox1.Text) == false)
            {

                s.InsertNewSupplier(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text);
                HttpContext.Current.Response.Write("<script>alert('Add successfully!')</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";

            }

            else
            {
                HttpContext.Current.Response.Write("<script>alert('Supplier ID has existed')</script>");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
        }
    }
}