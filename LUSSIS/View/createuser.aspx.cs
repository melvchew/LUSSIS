using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.DAL;
using System.Web.Profile;
using System.Configuration;

namespace LUSSIS.View
{
    public partial class createuser : System.Web.UI.Page
    {
        LUSSdb context;
        DropDownList k1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated) // if the user is already logged in
            {
                Response.Redirect("~/View/AccessDenied.aspx");
            }
            //context = new LUSSdbEntities();
            //List<Employee> empList = context.Employees.ToList<Employee>();

            ////List<Int32> empIdList = context.Employees.Select(x => x.EmpId).ToList<Int32>();
            //CreateUserWizardStep step1 = (CreateUserWizardStep)CreateUserWizard1.FindControl("Step1");
            //k1 = (DropDownList)step1.ContentTemplateContainer.FindControl("ddlEmpId");
            //k1.DataSource = empList;
            //k1.DataTextField = "EmpId";
            //k1.DataValueField = "EmpId";
            //k1.DataBind();
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            string username = CreateUserWizard1.UserName;
            string password = CreateUserWizard1.Password;
            dynamic profile = ProfileBase.Create(username);
            CreateUserWizardStep step1 = (CreateUserWizardStep)CreateUserWizard1.FindControl("Step1");
            TextBox k1 = (TextBox)step1.ContentTemplateContainer.FindControl("ddlEmpId");
            DropDownList k2 = (DropDownList)step1.ContentTemplateContainer.FindControl("ddlRole");
            Roles.AddUserToRole(username, k2.Text);


            //string k1selected = k1.Text;
            profile.empId = k1.Text;
            profile.role = k2.SelectedItem.ToString();
            profile.Save();


        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["empId"] = null;
            Session["storeEmpId"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}