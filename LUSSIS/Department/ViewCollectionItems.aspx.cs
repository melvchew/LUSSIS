/*
 * Developed By : Kavya Elizabeth James 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS.Department
{
    public partial class ViewCollectionItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service s = new Service();
            LUSS2 context = new LUSS2();
        protected void Page_Load(object sender, EventArgs e)
        {
            //// 1. Department ID 2. Disbursement ID => get in Session
            int count = 0;
            HttpContext.Current.Session["DepartmentId"] = 1; // assign value to session variable
            //Label6.Text = Session["DepartmentId"].ToString();  //get Session Variable Value
            Department dep = s.GetCurrentDeptById(Convert.ToInt32(Session["DepartmentId"]));
            Label2.Text = dep.CollectionPoint.Description;
            Disbursement d = s.GetDisbursementByID(1);
            DateTime date = (DateTime)d.DisburseDate;
            Label1.Text = date.ToString("dd/MM/yyy") + ", " + dep.CollectionPoint.CollectionTime + " AM";
            Label3.Text = dep.CollectionPoint.StoreEmployee.Name;
            Label4.Text = dep.CollectionPoint.StoreEmployee.Phone;
            int j = 0;
            DataTable dt = new DataTable();
            List<String> list = s.GetCollectionItemList(date, dep);
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("#"), new DataColumn("Item Description"), new DataColumn("Quantity"), new DataColumn("Unit") });
            for (int i = 0; i < list.Count / 3; i++)
            {
                dt.Rows.Add(i + 1, list.ElementAt(j), list.ElementAt(j + 1), list.ElementAt(j + 2));
                count = count + Convert.ToInt32(list.ElementAt(j + 1));
                j = j + 3;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label5.Text = count.ToString();
        }
    }
}

/*            Disbursement sempdet = s.GetDisbursement(date, dep);
                        Label3.Text = sempdet.StoreEmployee.Name;
                        Label4.Text = sempdet.StoreEmployee.Phone.ToString();
            
                        //GridView1.DataSource = s.GetCollectionList(date, dep);
                        //GridView1.DataBind();
                        DataTable dt = new DataTable();
                        List<String> list = s.GetCollectionList(date, dep);
                        //Label4.Text = list.ElementAt(2);
                        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Item Description"), new DataColumn("Quantity"), new DataColumn("Unit")});
                        for(int i = 0; i<list.Count/3;i++) {
                            dt.Rows.Add(list.ElementAt(i), list.ElementAt(i+1), list.ElementAt(i+2));

                        }
                        //dt.Rows.Add(list.ElementAt(0), list.ElementAt(1), list.ElementAt(2));

                        GridView1.DataSource = dt;
                        GridView1.DataBind();*/
//Employee e1 = s.GetEmployeeById(5);
//Disbursement d = s.GetDisbursementByID(1);
// List<String> list = s.GetDisbursement(date, dep);
//List<DisburseReqItem> dr = d.DisburseReqItems.ToList();
//s.GetCollectionItem(d.DisburseReqItems);
//GridView1.DataSource = d.DisburseReqItems.ToList();
//GridView1.DataSource = s.GetDisbursement(new DateTime(2017, 8, 15), empList.Department);
//GridView1.DataSource = 
//GridView1.DataBind();