using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.BLL;
using System.Globalization;

//by Phong
namespace LUSSIS.View.StoreView.Clerk
{
    public partial class TrendAnalysis : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL viewReqBizLogic;
        ReportBLL trendAnalysisBizLogic;
        List<Department> deptList;
        List<Item> itemList;
        List<String> monthList;
        DateTime fromDate;
        DateTime toDate;
        //int fromYear;
        //int fromMonth;
        //int toYear;
        //int toMonth;

        protected void Page_Load(object sender, EventArgs e)
        {
            viewReqBizLogic = new RequisitionBLL();
            trendAnalysisBizLogic = new ReportBLL();
            context = new LUSSdb();

            if (!IsPostBack)
            {
                using (context = new LUSSdb())
                {
                    //populate list of months
                    monthList = trendAnalysisBizLogic.getSubmitMonthList();
                    var sortedMonths = monthList
                                        .Select(x => new { Name = x, Sort = DateTime.ParseExact(x, "mm-yyyy", CultureInfo.InvariantCulture) })
                                        .OrderBy(x => x.Sort)
                                        .Select(x => x.Name)
                                        .ToList();
                    //ddlFrom.DataSource = monthList;
                    ddlFrom.DataSource = sortedMonths;
                    ddlFrom.DataBind();

                    //ddlTo.DataSource = monthList;
                    ddlTo.DataSource = sortedMonths;
                    ddlTo.DataBind();


                    //bind item names to dropdown list
                    itemList = trendAnalysisBizLogic.getItemList();
                    ddlItems.DataSource = itemList;
                    ddlItems.DataTextField = "Description";
                    ddlItems.DataValueField = "ItemId";
                    ddlItems.DataBind();

                    //bind department names to dropdown lists
                    deptList = trendAnalysisBizLogic.getDepartmentList();
                    ddlDept1.DataSource = deptList;
                    ddlDept1.DataTextField = "DeptName";
                    ddlDept1.DataValueField = "DeptId";
                    ddlDept1.DataBind();

                    ddlDept2.DataSource = deptList;
                    ddlDept2.DataTextField = "DeptName";
                    ddlDept2.DataValueField = "DeptId";
                    ddlDept2.DataBind();

                    ddlDept3.DataSource = deptList;
                    ddlDept3.DataTextField = "DeptName";
                    ddlDept3.DataValueField = "DeptId";
                    ddlDept3.DataBind();
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (ddlDept1.SelectedValue == ddlDept2.SelectedValue ||
                ddlDept2.SelectedValue == ddlDept3.SelectedValue ||
                ddlDept3.SelectedValue == ddlDept1.SelectedValue)
            {
                Label1.Text = "Selected departments must not be the same. Please choose 3 different departments.";
            }

            else
            {
                //construct start date from the "From" dropdown List selection
                //fromYear = Int32.Parse(ddlFrom.Text.Substring(3, 4));
                //fromMonth = Int32.Parse(ddlFrom.Text.Substring(0, 2));
                //fromDate = new DateTime(fromYear, fromMonth, 01);

                fromDate = trendAnalysisBizLogic.convertFromDate(ddlFrom.Text);

                //construct end date from the "To" dropdown List selection
                //toYear = Int32.Parse(ddlTo.Text.Substring(3, 4));
                //toMonth = Int32.Parse(ddlTo.Text.Substring(0, 2));
                //toDate = new DateTime(toYear, toMonth, DateTime.DaysInMonth(toYear, toMonth)).AddDays(1);

                toDate = trendAnalysisBizLogic.convertToDate(ddlTo.Text);
                //validate "From" field must be before "To" field
                if (fromDate < toDate)
                {
                    Label1.Text = "";
                    Response.Redirect("Chart.aspx?ItemId=" + ddlItems.SelectedValue + "&ItemName=" + ddlItems.SelectedItem
                        + "&From=" + fromDate.ToString("MM-dd-yyyy") + "&To=" + toDate.ToString("MM-dd-yyyy")
                        + "&Dept1=" + ddlDept1.SelectedValue + "&Dept1Name=" + ddlDept1.SelectedItem
                        + "&Dept2=" + ddlDept2.SelectedValue + "&Dept2Name=" + ddlDept2.SelectedItem
                        + "&Dept3=" + ddlDept3.SelectedValue + "&Dept3Name=" + ddlDept3.SelectedItem
                        + "&ReportBy=" + RadioButtonList1.SelectedItem.Text);
                }
                else
                {
                    Label1.Text = "Start month must be same with or before end month!";
                }
            }
        }


    }
}