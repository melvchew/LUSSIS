using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.RawCode.BLL.data.Phong
{
    public class ReportBLL
    {
        LUSSdb context;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public List<Department> getDepartmentList()
        {
            context = new LUSSdb();
            List<Department> deptList;
            deptList = context.Departments.ToList<Department>();
            return deptList;

        }
        public List<Item> getItemList()
        {
            context = new LUSSdb();
            List<Item> itemList;
            itemList = context.Items.ToList<Item>();
            return itemList;

        }

        public List<String> getSubmitMonthList()
        {
            context = new LUSSdb();
            List<String> monthList = context.TransposedRequisitionReports.Select(x => x.SubmitMonth).Distinct().ToList();
            return monthList;

        }

        public DateTime convertFromDate(string from)
        {
            DateTime fromDate;
            int year = Int32.Parse(from.Substring(3, 4));
            int month = Int32.Parse(from.Substring(0, 2));
            fromDate = new DateTime(year, month, 01);

            return fromDate;

        }

        public DateTime convertToDate(string to)
        {

            DateTime toDate;
            int year = Int32.Parse(to.Substring(3, 4));
            int month = Int32.Parse(to.Substring(0, 2));
            toDate = new DateTime(year, month, DateTime.DaysInMonth(year, month)).AddDays(1);

            return toDate;
        }

        public void CreateChartByQuantity(string itemId, string from, string to)
        {
            string query = "SELECT distinct ItemID, SubmitMonth, sum([1]) as [1], sum([2]) as [2], sum([3]) as [3]"
                    + ",  sum([4]) as [4], sum([5])as [5], sum([6]) as [6],  sum([7]) as [7], sum([8]) as [8], sum([9]) as [9], sum([10]) as [10]"
                    + " FROM TransposedRequisitionReport where ItemID=" + itemId
                   + " and SubmitDate between '" + from
                   + "' and '" + to
                   + "' group by month(SubmitDate), year(SubmitDate), ItemID, SubmitMonth";

            conn = new SqlConnection("Data Source=(local);Initial Catalog=LUSSdb;Integrated Security=True");
            cmd = new SqlCommand(query, conn);

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);


        }
    }
}