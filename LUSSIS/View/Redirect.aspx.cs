using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View
{
    public partial class Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //IIdentity id = User.Identity;
            //dynamic profile = ProfileBase.Create(id.Name);
            //Session["EmpId"] = profile.empId;


            //Login log = (Login)Login1.FindControl("Login1");
            //TextBox txtLogin = (TextBox)log.FindControl("UserName");
            //if (txtLogin != null)
            //{
            //    MembershipUser mu = (Membership.GetUser(txtLogin.Text));
            //    if (mu.IsApproved)
            //    {
            //Session["UserID"] = mu.ProviderUserKey.ToString();
            LUSSdb context = new LUSSdb();

            //List<Department> deptList = trendAnalysisBizLogic.getDepartmentList();
            var query = context.Departments.Select(x => x.DeptRep).ToList();
            IIdentity id = User.Identity;
            dynamic profile = ProfileBase.Create(id.Name);
            List<int> deptRepList = context.Departments.Select(x => x.DeptRep).ToList<int>();
            List<Department> deptList = context.Departments.ToList<Department>();

            List<int?> queryAH = context.Departments.Select(x => x.ActingHead).ToList<int?>();
            List<String> deptActingHeadList = new List<String>();

            foreach (int? r in queryAH)
            {
                if (r.HasValue)
                {
                    string s = r.ToString();
                    if (s != null)
                        deptActingHeadList.Add(s);
                }
            }

            List<DateTime?> queryStartDate = deptList.Select(x => x.AHStartDate).ToList<DateTime?>();
            List<DateTime> ahStartDateList = new List<DateTime>();

            foreach (DateTime? d in queryStartDate)
            {
                if (d.HasValue)
                {
                    string start = d.ToString();
                    if (start != null)
                        ahStartDateList.Add(DateTime.Parse(start));
                }
            }
            List<DateTime?> queryEndDate = deptList.Select(x => x.AHEndDate).ToList<DateTime?>();
            List<DateTime> ahEndDateList = new List<DateTime>();

            foreach (DateTime? d in queryStartDate)
            {
                if (d.HasValue)
                {
                    string end = d.ToString();
                    if (end != null)
                        ahEndDateList.Add(DateTime.Parse(end));
                }
            }

            if (User.IsInRole("StoreClerk") ||
                User.IsInRole("StoreManager") ||
                User.IsInRole("StoreSupervisor"))
            {
                Session["storeEmpId"] = profile.empId;

            }

            else if (User.IsInRole("DeptEmp") ||
                User.IsInRole("DeptRep") ||
                 User.IsInRole("DeptHead") ||
                  User.IsInRole("DeptActingHead"))
            {
                Session["empId"] = profile.empId;


            }

            if (Session["empId"] == null && Session["storeEmpId"] == null)
                Response.Redirect("Login.aspx");

            else
            {

                if (User.IsInRole("StoreClerk"))
                {
                    Response.Redirect("~/Store/home.aspx");
                }
                else if (User.IsInRole("StoreManager"))
                {
                    Response.Redirect("~/Store/Manager/home.aspx");
                }
                else if (User.IsInRole("StoreSupervisor"))
                {
                    Response.Redirect("~/Store/Supervisor/home.aspx");
                }
                else if (User.IsInRole("DeptEmp"))
                {
                    //check if employee has been delegated to be rep
                    foreach (int r in deptRepList)
                    {
                        //if (r == (int)Session["empId"])
                        string s = r.ToString();
                        if (s == profile.empId)
                        {
                            Roles.AddUserToRole(id.Name, "DeptRep");
                            Roles.RemoveUserFromRole(id.Name, "DeptEmp");
                            Response.Redirect("~/Dept/Rep/home.aspx");
                            break;
                        }
                    }
                    //check if employee has been delegated to be acting head
                    foreach (string ah in deptActingHeadList)
                    {

                        string s = ah.ToString();
                        //DateTime today = DateTime.Today;
                        if (s == profile.empId)

                        {
                            foreach (DateTime sd in ahStartDateList)
                            {

                                if (DateTime.Today >= sd)
                                {
                                    Roles.AddUserToRole(id.Name, "DeptActingHead");
                                    Roles.RemoveUserFromRole(id.Name, "DeptEmp");
                                    Response.Redirect("~/Dept/ActingHead/home.aspx");
                                    break;
                                }
                            }
                        }
                    }

                    Response.Redirect("~/Dept/home.aspx");
                }
                else if (User.IsInRole("DeptActingHead"))
                {
                    foreach (string ah in deptActingHeadList)
                    {
                        string s = ah.ToString();
                        if (s == profile.empId)
                        {

                            foreach (DateTime ed in ahEndDateList)
                            {
                                //remove from role and restore Employee role if delegation has expired
                                if (DateTime.Today > ed)
                                {
                                    Roles.AddUserToRole(id.Name, "DeptEmp");
                                    Roles.RemoveUserFromRole(id.Name, "DeptActingHead");
                                    Response.Redirect("~/Dept/home.aspx");
                                    break;
                                }

                            }
                            //keep Acting Head role if today's date is before or equals to end date
                            Response.Redirect("~/Dept/ActingHead/home.aspx");
                        }
                        //if another person has been delegated as Acting Head
                        else
                            Roles.AddUserToRole(id.Name, "DeptEmp");
                        Roles.RemoveUserFromRole(id.Name, "DeptActingHead");
                        Response.Redirect("~/Dept/home.aspx");
                    }


                }
                else if (User.IsInRole("DeptRep"))
                {
                    foreach (int r in deptRepList)
                    {
                        //if (r == (int)Session["empId"])
                        string s = r.ToString();
                        if (s == profile.empId)
                        {

                            Response.Redirect("~/Dept/Rep/home.aspx");
                            break;
                        }
                    }

                    Roles.AddUserToRole(id.Name, "DeptEmp");
                    Roles.RemoveUserFromRole(id.Name, "DeptRep");
                    Response.Redirect("~/Dept/home.aspx");
                }

                else if (User.IsInRole("DeptHead"))
                {
                    Response.Redirect("~/Dept/Head/home.aspx");
                }

                else
                {
                    Response.Write("Role not assigned yet");
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}
//                else if (User.IsInRole("DeptEmp"))
//                {

//                    foreach (int r in deptRepList)
//                    {
//                        //if (r == (int)Session["empId"])
//                        string s = r.ToString();
//                        if (s == profile.empId)
//                        {
//                            Roles.AddUserToRole(id.Name, "DeptRep");
//                            Roles.RemoveUserFromRole(id.Name, "DeptEmp");
//                            Response.Redirect("~/Dept/Rep/home.aspx");
//                            break;
//                        }
//                    }
//                    foreach (string ah in deptActingHeadList)
//                    //foreach (int ah in deptActingHeadList)
//                    {
//                        string s = ah.ToString();
//                        if (s == profile.empId)
//                        //if (ah == Convert.ToInt32(profile.empId))
//                        {
//                            Roles.AddUserToRole(id.Name, "DeptActingHead");
//                            Roles.RemoveUserFromRole(id.Name, "DeptEmp");
//                            Response.Redirect("~/Dept/ActingHead/home.aspx");
//                            break;
//                        }
//                    }

//                    Response.Redirect("~/Dept/home.aspx");
//                }
//                else if (User.IsInRole("DeptActingHead"))
//                {
//                    foreach (string ah in deptActingHeadList)
//                    //foreach (int ah in deptActingHeadList)
//                    {
//                        //if (ah == (int)Session["empId"])
//                        string s = ah.ToString();
//                        if (s == profile.empId)
//                        {

//                            Response.Redirect("~/Dept/ActingHead/home.aspx");
//                            break;
//                        }
//                    }

//                    Roles.AddUserToRole(id.Name, "DeptEmp");
//                    Roles.RemoveUserFromRole(id.Name, "DeptActingHead");
//                    Response.Redirect("~/Dept/home.aspx");
//                }
//                else if (User.IsInRole("DeptRep"))
//                {
//                    foreach (int r in deptRepList)
//                    {
//                        //if (r == (int)Session["empId"])
//                        string s = r.ToString();
//                        if (s == profile.empId)
//                        {

//                            Response.Redirect("~/Dept/Rep/home.aspx");
//                            break;
//                        }
//                    }

//                    Roles.AddUserToRole(id.Name, "DeptEmp");
//                    Roles.RemoveUserFromRole(id.Name, "DeptRep");
//                    Response.Redirect("~/Dept/home.aspx");
//                }

//                else if (User.IsInRole("DeptHead"))
//                {
//                    Response.Redirect("~/Dept/Head/home.aspx");
//                }

//                else
//                {
//                    Response.Write("Role not assigned yet");
//                    Response.Redirect("Login.aspx");
//                }
//            }
//        }
//    }
//}