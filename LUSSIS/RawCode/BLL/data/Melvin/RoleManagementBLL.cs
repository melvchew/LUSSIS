using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.Melvin
{
    public class RoleManagementBLL
    {

        //Melvin

        public Employee GetEmpByID(int id)
        {
            {
                Employee emp = ctx.Employees.Where(E => E.EmpId == id).First<Employee>();
                if (emp == null)
                {
                    //throw exception;
                }
                return emp;
            }



        }
        public Department GetDeptByID(int id)
        {
            {
                Department dept = ctx.Departments.Where(D => D.DeptId == id).First<Department>();
                if (dept == null)
                {
                    //throw Exception;
                }
                return dept;

            }
        }
        public Employee GetDeptHeadID(Department dept)
        {
            {
                Employee emp = ctx.Employees.Where(E => E.EmpId == dept.DeptHead).First<Employee>();
                if (emp == null)
                {
                    //throw exception;
                }
                return emp;

            }
        }

        public Department GetDeptByUser(Employee emp)
        {
            {
                Department dept = ctx.Departments.Where(x => x.DeptId == emp.DeptId).First<Department>();
                if (dept == null)
                {
                    //throw exeption;
                }
                return dept;
            }

        }

        public List<Employee> GetEmployees()
        {
            {
                return ctx.Employees.ToList();

            }
        }
    }
}