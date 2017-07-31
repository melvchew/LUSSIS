using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS.Store.Clerk
{
    public partial class RaiseAdjVoucher : System.Web.UI.Page
    {
        Class1 c = new Class1();
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
                d.DataSource = c.getItems();
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
                txtQtyAdj.CssClass = "btn btn-default";
                PlaceHolder3.Controls.Add(txtQtyAdj);
                //---TextBox Reason
                TextBox txtReason = new TextBox();
                txtReason.ID = "txtReason" + counter;
                //txtReason.Text = "Reason" + counter;
                txtReason.Width = 300;
                txtReason.CssClass = "btn btn-default";
                PlaceHolder4.Controls.Add(txtReason);
                //---TextBox Value
                TextBox txtValue = new TextBox();
                txtValue.ID = "txtValue" + counter;
                //txtValue.Text = "Value" + counter;
                txtValue.Width = 100;
                txtValue.ReadOnly = true;
                txtValue.CssClass = "btn btn-default";
                PlaceHolder5.Controls.Add(txtValue);

                Literal lt = new Literal();
                lt.Text = "<br/>";
                PlaceHolder5.Controls.Add(lt);
            }
        }

        //private void TxtQtyAdj_TextChanged(object sender, EventArgs e)
        //{
        //    //int value = Convert.ToInt32(((TextBox)sender).Text);
        //    //Label2.Text = "AAAA";
        //}

        //protected void QtyAdj1_TextChanged(object sender, EventArgs e)
        //{
        //    //Response.Write("Hello");
        //    //Label2.Text = ((TextBox)sender).Text;
        //    int id = Convert.ToInt32(ItemsList1.SelectedValue);
        //    int dItem = Convert.ToInt32(this.txtQtyAdj1.Text);
        //    txtValue1.Text = calValue(id, dItem);
        //}

        public String calValue(int id, int dItem)
        {
            decimal avgPrice = 0;
            Decimal TotAdjValue = 0;
            Item i = c.getItemById(id);
            avgPrice = (i.Supplier1Price + i.Supplier1Price + i.Supplier1Price) / 3;
            TotAdjValue = dItem * avgPrice;
            totAmt = TotAdjValue + totAmt;
            return TotAdjValue.ToString();
        }

        protected void AddTextBox(object sender, EventArgs e)
        { }
        protected void AddNewRowLinkBtn_Click1(object sender, EventArgs e)
        {
            Button1.Visible = true;
            counter++;
            //-- DropDownList Box
            DropDownList d = new DropDownList();
            d.ID = "ItemsList" + counter;
            d.DataSource = c.getItems();
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
            txtQtyAdj.CssClass = "btn btn-default";
            PlaceHolder3.Controls.Add(txtQtyAdj);
            //---TextBox Reason
            TextBox txtReason = new TextBox();
            txtReason.ID = "txtReason" + counter;
            //txtReason.Text = "Reason" + counter;
            txtReason.Width = 300;
            txtReason.CssClass = "btn btn-default";
            PlaceHolder4.Controls.Add(txtReason);
            //---TextBox Value
            TextBox txtValue = new TextBox();
            txtValue.ID = "txtValue" + counter;
            //txtValue.Text = "Value" + counter;
            txtValue.Width = 100;
            txtValue.ReadOnly = true;
            txtValue.CssClass = "btn btn-default";
            PlaceHolder5.Controls.Add(txtValue);

            Literal lt = new Literal();
            lt.Text = "<br/>";
            PlaceHolder5.Controls.Add(lt);

            controlsList.Add(txtQtyAdj.ID);
            //controlsList.Add(d.ID);
            //controlsList.Add(txtReason.ID);
            //controlsList.Add(txtValue.ID);

            ViewState["controlsList"] = controlsList;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Submitbtn.Visible = false;
            Button1.Visible = true;
            if (!IsPostBack)
            {
                ItemsList1.DataSource = c.getItems();
                ItemsList1.DataBind();
                ItemsList1.DataTextField = "Description";
                ItemsList1.DataValueField = "ItemId";
                ItemsList1.DataBind();
            }
        }

        protected void AddNewRowLinkBtn_Click(object sender, EventArgs e)
        {

        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            StoreEmployee se = c.getStoreEmployeeById(empId);
            c.RaiseVoucher(empId, date, status, txtReasons1.Text);
            InvAdjVoucher adj = c.getAdjVocherIdByDate(date);
            TextBox tb = new TextBox();
            DropDownList ddl = new DropDownList();
            int itemId = 0, adjQty = 0;
            int inr = 1; String str = "";

            foreach (Control ctr in PlaceHolder1.Controls)
            {
                if (inr <= counter)
                {
                    str = "txtQtyAdj" + inr;
                    tb = (TextBox)ctr.FindControl(str);
                    str = "ItemsList" + inr;
                    ddl = (DropDownList)ctr.FindControl(str);
                    itemId = Convert.ToInt32(ddl.SelectedValue);
                    adjQty = Convert.ToInt32(tb.Text);
                    c.AddRaiseAdjItem(adj.VoucherId, itemId, adjQty);
                }
                inr++;
            }
            Response.Write("<script>alert('Voucher ID = " + adj.VoucherId + " is raised successfully')</script>");
            if (totAmt > 250)
            {
                c.sendnotification(se, adj.VoucherId);
            }
            //Label2.Text = adj.VoucherId.ToString();
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

        public void createControls(int Count)
        {
            DropDownList d = new DropDownList();
            d.ID = "ItemsLst" + count;
            d.DataSource = c.getItems();
            d.DataBind();
            d.DataTextField = "Description";
            d.DataValueField = "ItemId";
            d.DataBind();
            form1.Controls.Add(d);

            TextBox AdjQ = new TextBox();
            AdjQ.ID = "QtyAdj" + count;
            AdjQ.TextChanged += new EventHandler(textbox_textchange);
            form1.Controls.Add(AdjQ);

            TextBox r = new TextBox();
            r.ID = "Reasons" + count;
            form1.Controls.Add(r);

            TextBox v = new TextBox();
            v.ID = "Value" + count;
            form1.Controls.Add(v);

            form1.Controls.Add(new LiteralControl("<br />"));
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
                        Button1.Visible = false;
                        Submitbtn.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Please Enter Numeric Data')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Valid Data')</script>");
                }
            }
        }
    }
}