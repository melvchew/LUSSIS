using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View.DepartmentView.Head
{
    public partial class DelegateRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empid = Convert.ToInt32(Session["empId"]);
                RolesManagementBLL b = new RolesManagementBLL();
                int depid = b.getDepartmentID(empid);
                List<Employee> actinghead = b.getEmployeeListByDept(depid);
                ddActingHead.DataSource = actinghead;//ID depends on login user
                ddActingHead.DataTextField = "Name";
                ddActingHead.DataValueField = "EmpId";
                ddActingHead.DataBind();
                ddActingHead.Items.Insert(0, new ListItem(String.Empty, string.Empty));
                ddActingHead.SelectedIndex = 0;

                ddDeptRepre.DataSource = actinghead;//ID depends on login user
                ddDeptRepre.DataTextField = "Name";
                ddDeptRepre.DataValueField = "EmpId";
                ddDeptRepre.DataBind();

                setName();
            }
        }

        public void setName()
        {
            int empid = Convert.ToInt32(Session["empId"]);
            RolesManagementBLL b = new RolesManagementBLL();
            int depid = b.getDepartmentID(empid);
            if (b.getCurrentActingHead(depid) != null)
            {
                Employee currentActingHead = b.getCurrentActingHead(depid);//ID depends on login user
                lblCurrentActingHead.Text = currentActingHead.Name.ToString();
                ddActingHead.SelectedValue = currentActingHead.EmpId.ToString();
            }
            else
            {
                lblCurrentActingHead.Text = "There is no Department Acting Head.";
            }
            if (b.getCurrentDeptRep(depid) != null)
            {
                Employee currentDeptRep = b.getCurrentDeptRep(depid);//ID depends on login user
                lblCurrentDeptRep.Text = currentDeptRep.Name.ToString();
                ddDeptRepre.SelectedValue = currentDeptRep.EmpId.ToString();
            }
            else
            {
                lblCurrentDeptRep.Text = "There is no Department Representative.";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddActingHead.SelectedValue == ddDeptRepre.SelectedValue)
            {
                lblerror.Text = "Acting Head and Department Representative can't be same.";
            }
            else if (ddActingHead.SelectedValue != "")
            {
                if (txtFromDate.Text == "")
                {
                    lblerror.Text = "Date need to choose.";
                }
                else if (txtToDate.Text == "")
                {
                    lblerror.Text = "Date need to choose.";
                }
                else if (DateTime.Compare(DateTime.Now, DateTime.Parse(txtFromDate.Text)) > 0)
                {
                    lblerror.Text = "From date must be later than current date";
                }
                else if (DateTime.Compare(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text)) > 0)
                {
                    lblerror.Text = "To date must be later than From date";
                }
                else
                {
                    int empid = Convert.ToInt32(Session["empId"]);
                    RolesManagementBLL b = new RolesManagementBLL();
                    int depid = b.getDepartmentID(empid);
                    
                    Department d = new Department();
                    d.DeptId = depid;// ID depends on login user
                    d.ActingHead = Convert.ToInt32(ddActingHead.SelectedValue);
                    d.DeptRep = Convert.ToInt32(ddDeptRepre.SelectedValue);
                    d.AHStartDate = DateTime.Parse(txtFromDate.Text);
                    d.AHEndDate = DateTime.Parse(txtToDate.Text);
                    bool update = b.delegateRoles(d);
                    if (update)
                    {
                        lblerror.Text = "Delegate Successful";
                        setName();
                    }
                    else
                    {
                        lblerror.Text = "Delegate Fail";
                    }
                }
            }

            else
            {
                int empid = Convert.ToInt32(Session["empId"]);
                RolesManagementBLL b = new RolesManagementBLL();
                int depid = b.getDepartmentID(empid);
                Department d = new Department();
                d.DeptId = depid;// ID depends on login user
                d.DeptRep = Convert.ToInt32(ddDeptRepre.SelectedValue);
                bool update = b.delegateRoles(d);
                if (update)
                {
                    lblerror.Text = "Delegate Successful";
                    setName();
                }
                else
                {
                    lblerror.Text = "Delegate Fail";
                }
            }
        }
    }
}