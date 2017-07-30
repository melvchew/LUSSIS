using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.Phong
{
    public class RequisitionBLL
    {
        LUSSdbEntities context;
        enum ReqStatus
        {
            PENDING = 1, CANCELLED, APPROVED, REJECTED, PARTIAL, DELIVERED
        }

        public Object GetRequisitionList()
        {
            context = new LUSSdbEntities();

            //int i = (int)ReqStatus.APPROVED;
            var q2 = (from ri in context.RequisitionItems
                      where
                        ri.Requisition.Status == "APPROVED"
                      group new { ri.Item, ri } by new
                      {
                          ri.Item.Description,
                          ri.Item.BinNumber,
                          ri.Item.Category,
                          ri.Item.Unit
                      } into g
                      select new
                      {
                          g.Key.BinNumber,
                          g.Key.Category,
                          g.Key.Description,
                          Total_Requested = (int)g.Sum(p => p.ri.Quantity),
                          g.Key.Unit
                      }).ToList();

            return q2;

            //foreach (var ri in q2)
            //{
            //    Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
            //        ri.BinNumber, ri.Category, ri.Description, ri.Unit, ri.Total_Requested);

            //}

            //var q = items.GroupBy(f => f.Item.Description).Select(g => new { TotalQty = g.Sum(x => x.Quantity) }).ToList();
            //foreach (var s in q)
            //{
            //    Console.WriteLine(s.TotalQty);
            //}

            //Console.ReadLine();
        }

        public Object GetRequisitionListByDepartment(int deptID)
        {
            LUSSdbEntities context = new LUSSdbEntities();

            if (deptID == 0)
            {
                var all = (from ri in context.RequisitionItems
                           where
                             ri.Requisition.Status == "APPROVED"
                           group new { ri.Item, ri } by new
                           {
                               ri.Item.Description,
                               ri.Item.BinNumber,
                               ri.Item.Category,
                               ri.Item.Unit
                           } into g
                           select new
                           {
                               g.Key.BinNumber,
                               g.Key.Category,
                               g.Key.Description,
                               Total_Requested = (int)g.Sum(p => p.ri.Quantity),
                               g.Key.Unit
                           }).ToList();

                return all;
            }
            else
            {
                var query = (from ri in context.RequisitionItems

                             where
                               ri.Requisition.Status == "APPROVED" &&
                               ri.Requisition.Employee.Department.DeptId == deptID
                             group new { ri.Item, ri.Requisition.Employee.Department, ri } by new
                             {
                                 ri.Item.Description,
                                 ri.Item.BinNumber,
                                 ri.Item.Category,
                                 ri.Requisition.Employee.Department.DeptName,
                                 ri.Item.Unit
                             } into g
                             select new
                             {
                                 g.Key.BinNumber,
                                 g.Key.Category,
                                 Item = g.Key.Description,
                                 Total_Requested = (int)g.Sum(p => p.ri.Quantity),
                                 g.Key.Unit
                             }).ToList();

                return query;
            }

        }
    }
}