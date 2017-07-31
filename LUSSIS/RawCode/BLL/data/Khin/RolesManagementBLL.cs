using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.RawCode.BLL.data.Khin
{
    public class RolesManagementBLL
    {
        public List<Employee> getEmployeeListByDept(int id)
        {
            LUSSdb context = new LUSSdb();
            return context.Employees.Where(x => x.DeptId == id).ToList<Employee>();
        }

        public Boolean delegateRoles(Department dept)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                Department d = context.Departments.Where(x => x.DeptId == dept.DeptId).FirstOrDefault();
                d.DeptRep = dept.DeptRep;
                d.ActingHead = dept.ActingHead;
                d.AHStartDate = dept.AHStartDate;
                d.AHEndDate = dept.AHEndDate;                
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Employee getCurrentDeptRep(int id)
        {
            LUSSdb context = new LUSSdb();
            var employee = (from x in context.Employees
                            join i in context.Departments
                            on x.EmpId equals i.DeptRep
                            where i.DeptId == id
                            select x).FirstOrDefault();
            Employee e = (Employee)employee;
            return e;
        }
        public Employee getCurrentActingHead(int id)
        {
            LUSSdb context = new LUSSdb();
            var employee = (from x in context.Employees
                            join i in context.Departments
                            on x.EmpId equals i.ActingHead
                            where i.DeptId == id
                            select x).FirstOrDefault();
            Employee e = (Employee)employee;
            return e;

        }
    }
}