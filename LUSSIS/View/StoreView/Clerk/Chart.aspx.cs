using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;

namespace LUSSIS.View.StoreView.Clerk
{
    public partial class Chart : System.Web.UI.Page
    {
        string query;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        ReportBLL chartData;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblHeading.Text = "Requisition Report for " + Request.QueryString["ItemName"]
                + " from " + Request.QueryString["From"] + " to " + Request.QueryString["To"];

            if (Request.QueryString["ReportBy"] == "Quantity")
            {

                //take data from view
                query = "SELECT distinct ItemID, SubmitMonth, sum([1]) as [1], sum([2]) as [2], sum([3]) as [3]"
                    + ",  sum([4]) as [4], sum([5])as [5], sum([6]) as [6],  sum([7]) as [7], sum([8]) as [8], sum([9]) as [9], sum([10]) as [10]"
                    + " FROM TransposedRequisitionReport where ItemID=" + Request.QueryString["ItemId"]
                   + " and SubmitDate between '" + Request.QueryString["From"]
                   + "' and '" + Request.QueryString["To"]
                   + "' group by month(SubmitDate), year(SubmitDate), ItemID, SubmitMonth";
                conn = new SqlConnection("Data Source=(local);Initial Catalog=LUSSdb;Integrated Security=True");
                cmd = new SqlCommand(query, conn);

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                //chartData.CreateChartByQuantity(Request.QueryString["ItemId"], Request.QueryString["From"], Request.QueryString["To"]);
                Chart1.DataSource = dt;
            }

            else if (Request.QueryString["ReportBy"] == "Cost (In SGD)")
            {
                query = "SELECT distinct ItemID, SubmitMonth, sum([1]) as [1], sum([2]) as [2], sum([3]) as [3]"
                    + ",  sum([4]) as [4], sum([5])as [5], sum([6]) as [6],  sum([7]) as [7], sum([8]) as [8], sum([9]) as [9], sum([10]) as [10]"
                    + " FROM TransposedRequisitionReportByCost where ItemID=" + Request.QueryString["ItemId"]
                   + " and SubmitDate between '" + Request.QueryString["From"]
                   + "' and '" + Request.QueryString["To"]
                   + "' group by month(SubmitDate), year(SubmitDate), ItemID, SubmitMonth";
                conn = new SqlConnection("Data Source=(local);Initial Catalog=LUSSdb;Integrated Security=True");
                cmd = new SqlCommand(query, conn);

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                Chart1.DataSource = dt;
            }
            else
            {
                query = null;
            }

            if (dt.Rows.Count == 0)
            {
                lblHeading.Visible = false;
                lblNoResult.Visible = true;
                Chart1.Visible = false;
            }
            else
            //Chart1.Titles.Add("NewTitle");
            //Chart1.Titles["NewTitle"].Text = "Requisition report";// for " + Request.QueryString["ItemName"]
            // + " from " + Request.QueryString["From"] + " to " + Request.QueryString["To"];
            {
                Chart1.ChartAreas[0].AxisX.Title = "Months";
                Chart1.ChartAreas[0].AxisY.Title = Request.QueryString["ReportBy"];

                Chart1.Series[0].XValueMember = dt.Columns["SubmitMonth"].ToString();
                Chart1.Series[0].YValueMembers = dt.Columns[Request.QueryString["Dept1"]].ToString();

                Chart1.Series[1].XValueMember = dt.Columns["SubmitMonth"].ToString();
                Chart1.Series[1].YValueMembers = dt.Columns[Request.QueryString["Dept2"]].ToString();

                Chart1.Series[2].XValueMember = dt.Columns["SubmitMonth"].ToString();
                Chart1.Series[2].YValueMembers = dt.Columns[Request.QueryString["Dept3"]].ToString();

                Chart1.DataBind();

                Chart1.Width = 750;
                Chart1.Legends.Add(new Legend("Legend"));
                Chart1.Series[0].Name = Request.QueryString["Dept1Name"];
                Chart1.Series[1].Name = Request.QueryString["Dept2Name"];
                Chart1.Series[2].Name = Request.QueryString["Dept3Name"];
                Chart1.Series[0].Legend = "Legend";
                Chart1.Series[0].IsVisibleInLegend = true;
            }
        }
    }
}