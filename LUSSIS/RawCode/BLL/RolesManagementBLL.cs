using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;

namespace LUSSIS.RawCode.BLL
{
    public class RolesManagementBLL
    {
        LUSSdb context = new LUSSdb();

        //Created by Khin

        public int getDepartmentID(int id)
        {
            context = new LUSSdb();
            return context.Departments.Where(x => x.DeptHead == id).Select(x => x.DeptId).FirstOrDefault<int>();
        }
        public List<Employee> getEmployeeListByDept(int id)
        {
            context = new LUSSdb();
            return context.Employees.Where(x => x.DeptId == id).ToList<Employee>();
        }

        public Boolean delegateRoles(Department dept)
        {
            try
            {
                context = new LUSSdb();
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
            context = new LUSSdb();
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
            context = new LUSSdb();
            var employee = (from x in context.Employees
                            join i in context.Departments
                            on x.EmpId equals i.ActingHead
                            where i.DeptId == id
                            select x).FirstOrDefault();
            Employee e = (Employee)employee;
            return e;

        }
        public Employee getCurrentHead(int id)
        {
            context = new LUSSdb();
            var employee = (from x in context.Employees
                            join i in context.Departments
                            on x.EmpId equals i.DeptHead
                            where i.DeptId == id
                            select x).FirstOrDefault();
            Employee e = (Employee)employee;
            return e;
        }

        //--------------------------------------------------------------------------------------------------------------------

        //Melvin
        //LUSSdb ctx = new LUSSdb();
        public Employee GetEmpByID(int id)
        {
            {
                Employee emp = context.Employees.Where(E => E.EmpId == id).First<Employee>();
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
                Department dept = context.Departments.Where(D => D.DeptId == id).First<Department>();
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
                Employee emp = context.Employees.Where(E => E.EmpId == dept.DeptHead).First<Employee>();
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
                Department dept = context.Departments.Where(x => x.DeptId == emp.DeptId).First<Department>();
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
                return context.Employees.ToList();

            }
        }

        public void CheckExistingAH()
        {
            List<Department> LDept = context.Departments.ToList<Department>();
            DateTime today = DateTime.Today;
            foreach (Department dept in LDept)
            {
                
                if (dept.ActingHead != null)
                {
                    if (DateTime.Compare((DateTime)dept.AHEndDate, today) < 0)
                    {
                        dept.ActingHead = null;
                        dept.AHEndDate = null;
                        dept.AHStartDate = null;
                    }
                }


            }
            context.SaveChanges();
        }


    }
}