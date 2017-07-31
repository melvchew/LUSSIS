using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.Khin
{
    public class DelegateRoleBLL
    {
        public List<Employee> getEmployeeListByDept(int id)
        {
            LUSSdbEntities context = new LUSSdbEntities();
            return context.Employees.Where(x => x.DeptId == id).ToList<Employee>();
        }

        public Boolean delegateRoles(Department dept)
        {
            try
            {
                LUSSdbEntities context = new LUSSdbEntities();
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
            LUSSdbEntities context = new LUSSdbEntities();
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
            LUSSdbEntities context = new LUSSdbEntities();
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