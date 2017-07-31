using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL.data.ZhangJinshan;
using LUSSIS.RawCode.DAL;
namespace LUSSIS.View.StoreView.Clerk
{
    public partial class UpdateSuppliers : System.Web.UI.Page
    {
        StockManagementBLL s = new StockManagementBLL();
        List<Supplier> l;
        protected void Page_Load(object sender, EventArgs e)
        {
            l = (List<Supplier>)Session["Suppliers"];
            if (!IsPostBack)
            {
                GridView1.DataSource = l;
                GridView1.DataBind();
            }

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.LightYellow;
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = l;
            GridView1.DataBind();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.LightYellow;
            }
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string id = (row.FindControl("Label8") as Label).Text;
            string name = (row.FindControl("TextBox7") as TextBox).Text;
            string contactPerson = (row.FindControl("TextBox6") as TextBox).Text;
            string phoneNo = (row.FindControl("TextBox5") as TextBox).Text;
            string faxNo = (row.FindControl("TextBox4") as TextBox).Text;
            string address = (row.FindControl("TextBox3") as TextBox).Text;
            string email = (row.FindControl("TextBox2") as TextBox).Text;
            string gstNo = (row.FindControl("TextBox1") as TextBox).Text;
            s.UpdateSupplier(id, name, contactPerson, phoneNo, faxNo, address, email, gstNo);
            List<Supplier> l = new List<Supplier>();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {

                string supplierid = (GridView1.Rows[i].FindControl("Label8") as Label).Text;
                l.Add(s.FindSupplierById(supplierid));


            }
            GridView1.EditIndex = -1;
            Session["Suppliers"] = l;
            GridView1.DataSource = l;
            GridView1.DataBind();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.LightYellow;
            }
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = l;
            GridView1.DataBind();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].BackColor = System.Drawing.Color.LightYellow;
            }
        }
    }
}