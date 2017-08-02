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
    public partial class RaiseAdjVoucher : System.Web.UI.Page
    {

        VoucherManagementBLL vm = new VoucherManagementBLL();
        // get employee Id using Login Session
        int empId = 7;
        static int count = 2;
        String status = "PENDING";
        DateTime date = DateTime.Today;
        static Boolean calc = false;
        static decimal totAmt = 0;

        List<String> controlsList = new List<string>();
        int counter = 1;

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            controlsList = (List<String>)ViewState["controlsList"];

            foreach (string Id in controlsList)
            {
                counter++;
                //---DropDownListBox
                DropDownList d = new DropDownList();
                d.ID = "ItemsList" + counter;
                d.DataSource = vm.getItems();
                d.Width = 250;
                d.CssClass = "btn btn-default";
                d.DataBind();
                d.DataTextField = "Description";
                d.DataValueField = "ItemId";
                d.DataBind();
                PlaceHolder2.Controls.Add(d);
                //---TextBox Adjustement Quantity
                TextBox txtQtyAdj = new TextBox();
                txtQtyAdj.ID = "txtQtyAdj" + counter;
                //txtQtyAdj.Text = "Adj" + counter;
                txtQtyAdj.Width = 100;
                txtQtyAdj.AutoPostBack = true;
                txtQtyAdj.CssClass = "form-control qntyAdj";
                PlaceHolder3.Controls.Add(txtQtyAdj);
                //---TextBox Reason
                TextBox txtReason = new TextBox();
                txtReason.ID = "txtReason" + counter;
                //txtReason.Text = "Reason" + counter;
                txtReason.Width = 300;
                txtReason.CssClass = "form-control";
                PlaceHolder4.Controls.Add(txtReason);
                //---TextBox Value
                TextBox txtValue = new TextBox();
                txtValue.ID = "txtValue" + counter;
                //txtValue.Text = "Value" + counter;
                txtValue.Width = 100;
                txtValue.ReadOnly = true;
                txtValue.CssClass = "form-control";
                PlaceHolder5.Controls.Add(txtValue);
            }
        }

        public String calValue(int id, int dItem)
        {
            decimal avgPrice = 0;
            Decimal TotAdjValue = 0;
            Item i = vm.getItemById(id);
            avgPrice = (i.Supplier1Price + i.Supplier1Price + i.Supplier1Price) / 3;
            TotAdjValue = dItem * avgPrice;
            totAmt = TotAdjValue + totAmt;
            return TotAdjValue.ToString();
        }

        protected void AddNewRowLinkBtn_Click1(object sender, EventArgs e)
        {


            calculatebtn.Visible = true;
            Submitbtn.Visible = false;

            counter++;
            //-- DropDownList Box
            DropDownList d = new DropDownList();
            d.ID = "ItemsList" + counter;
            d.DataSource = vm.getItems();
            d.Width = 250;
            d.CssClass = "btn btn-default";
            d.DataBind();
            d.DataTextField = "Description";
            d.DataValueField = "ItemId";
            d.DataBind();
            PlaceHolder2.Controls.Add(d);
            //---TextBox Adjustment Quantity
            TextBox txtQtyAdj = new TextBox();
            txtQtyAdj.ID = "txtQtyAdj" + counter;
            //txtQtyAdj.Text = "Adj" + counter;
            txtQtyAdj.Width = 100;
            txtQtyAdj.CssClass = "form-control qntyAdj";
            PlaceHolder3.Controls.Add(txtQtyAdj);
            //---TextBox Reason
            TextBox txtReason = new TextBox();
            txtReason.ID = "txtReason" + counter;
            //txtReason.Text = "Reason" + counter;
            txtReason.Width = 300;
            txtReason.CssClass = "form-control";
            PlaceHolder4.Controls.Add(txtReason);
            //---TextBox Value
            TextBox txtValue = new TextBox();
            txtValue.ID = "txtValue" + counter;
            //txtValue.Text = "Value" + counter;
            txtValue.Width = 100;
            txtValue.ReadOnly = true;
            txtValue.CssClass = "form-control";
            PlaceHolder5.Controls.Add(txtValue);

            controlsList.Add(txtQtyAdj.ID);
            ViewState["controlsList"] = controlsList;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Submitbtn.Visible = false;
            if (!IsPostBack)
            {
                ItemsList1.DataSource = vm.getItems();
                ItemsList1.DataBind();
                ItemsList1.DataTextField = "Description";
                ItemsList1.DataValueField = "ItemId";
                ItemsList1.DataBind();
            }
        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            StoreEmployee se = vm.getStoreEmployeeById(empId);
            vm.RaiseVoucher(empId, date, status, txtReasons1.Text);
            InvAdjVoucher adj = vm.getAdjVocherIdByDate(date);
            TextBox tb = new TextBox();
            DropDownList ddl = new DropDownList();
            int itemId = 0, adjQty = 0;
            int inr = 1; String str = "";

            foreach (Control ctr in PlaceHolder1.Controls)
            {
                if (inr <= counter)
                {
                    decimal value = 0;
                    str = "txtQtyAdj" + inr;
                    tb = (TextBox)ctr.FindControl(str);
                    str = "ItemsList" + inr;
                    ddl = (DropDownList)ctr.FindControl(str);
                    itemId = Convert.ToInt32(ddl.SelectedValue);
                    adjQty = Convert.ToInt32(tb.Text);
                    str = "txtValue" + inr;
                    tb = (TextBox)ctr.FindControl(str);
                    value = Convert.ToDecimal(tb.Text);
                    vm.AddRaiseAdjItem(adj.VoucherId, itemId, adjQty);
                    if (value > 250)
                    {
                        vm.sendnotification(se, adj.VoucherId, itemId);
                    }
                }
                inr++;
            }
            Response.Write("<script>alert('Voucher ID = " + adj.VoucherId + " is raised successfully')</script>");
            Response.Redirect("~/View/StoreView/Home.aspx");
        }

        public void textbox_textchange(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(ItemsLst2.SelectedValue);
            //int dItem = Convert.ToInt32(this.QtyAdj2.Text);
            //Value1.Text = calValue(id, dItem);
            //int id = Convert.ToInt32(ItemDropDownList3.SelectedValue);
            //int dItem = Convert.ToInt32(this.QtyAdj3.Text);
            //Value3.Text = calValue(id,dItem);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            TextBox tb = new TextBox();
            DropDownList ddl = new DropDownList();
            String str = "";
            int distance;
            int adjQty = 0, itemId = 0;
            //Label2.Text = (int.TryParse(tb.Text, out distance).ToString());
            for (int i = 1; i <= counter; i++)
            {
                str = "txtQtyAdj" + i;
                tb = (TextBox)PlaceHolder1.FindControl(str);
                if (tb.Text != "" && tb.Text != null)
                {
                    if (int.TryParse(tb.Text, out distance))
                    {
                        str = "ItemsList" + i;
                        ddl = (DropDownList)PlaceHolder1.FindControl(str);
                        itemId = Convert.ToInt32(ddl.SelectedValue);
                        adjQty = Convert.ToInt32(tb.Text);
                        int id = Convert.ToInt32(ItemsList1.SelectedValue);
                        int dItem = Convert.ToInt32(this.txtQtyAdj1.Text);
                        str = "txtValue" + i;
                        tb = (TextBox)PlaceHolder1.FindControl(str);
                        tb.Text = calValue(itemId, adjQty);
                        calculatebtn.Visible = false;
                        Submitbtn.Visible = true;
                    }
                    //else
                    //{
                    //    Response.Write("<script>alert('Please Enter Numeric Data')</script>");
                    //}
                }
                //else
                //{
                //    Response.Write("<script>alert('Please Enter Valid Data')</script>");
                //}
            }
        }
    }
}
