using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;

namespace LUSSIS.RawCode.BLL
{
    public class HomePageBLL
    {
        LUSSdb context = new LUSSdb();

        public Employee GetDeptEmployee(int empId)
        {
            return context.Employees.FirstOrDefault(x => x.EmpId == empId);
        }

        public StoreEmployee GetStoreEmployee(int storeEmpId)
        {
            return context.StoreEmployees.FirstOrDefault(x => x.StoreEmpId == storeEmpId);
        }

        public List<Requisition> GetPendingRequitions(int empId = 0, int depId = 0)
        {
            if (empId !=0)
            {
                return context.Requisitions.Where(x => x.EmpId == empId && x.Status == ReqStatus.PENDING.ToString()).ToList();
            } else
            {
                return context.Requisitions.Where(x => x.Employee.DeptId == depId && x.Status == ReqStatus.PENDING.ToString()).ToList();
            }
            
        }

        public Department GetDepartment(int depId)
        {
            return context.Departments.FirstOrDefault(x => x.DeptId == depId);
        }

        public List<ConsolidateItem> GetRequiredConItemList(int empId)
        {
            Employee emp = context.Employees.FirstOrDefault(x => x.EmpId == empId);
            List<ConsolidateItem> conItemList = new List<ConsolidateItem>();

            List<RequisitionItem> reqItemList = GetUndeliveredRequisitionItems(empId);

            foreach (var item in reqItemList.Select(x=> x.Item).Distinct())
            {
                ConsolidateItem conItem = new ConsolidateItem();
                conItem.Item = item;
                conItem.Qty = GetActualNeededSum(item, emp);
                conItemList.Add(conItem);
            }

            return conItemList;
        }

        public int GetActualNeededSum(Item item, Employee emp)
        {
            //This method will get all the amount needed to retrieved of a particular item

            //The formula is
            //TotalRetrivedNeeded = TotalNeededAmount - AllDeliveredAmount

            //Getting sum of the amount needed for that item
            int totalNeeded = 0;
            List<RequisitionItem> requiredItemList = GetApprovedRequisitionItems(item, emp:emp);

            if (requiredItemList != null)
            {
                totalNeeded = requiredItemList.Select(x => x.Quantity).Sum();
            }

            //Getting all the delivered sum for that item
            int allDeliveredAmount = 0;
            if (requiredItemList != null)
            {
                foreach (var reqItem in requiredItemList)
                {
                    allDeliveredAmount += GetDeliveredSum(reqItem);
                }
            }

            //applying the formula
            int totalActualNeeded = totalNeeded - allDeliveredAmount;

            return totalActualNeeded;
        }

        public List<RequisitionItem> GetApprovedRequisitionItems(Item item = null, Department dep = null, Employee emp = null)
        {
            //return all the req items that are approved or partially delivered of the item and dep

            List<RequisitionItem> reqItemList;
            if (item == null && dep == null)
            {
                //return all the req items that are approved or partially delivered

                reqItemList = context.RequisitionItems.Where(x => x.Requisition.Status == ReqStatus.APPROVED.ToString()
                        || x.Requisition.Status == ReqStatus.PARTIAL.ToString()).ToList();
            }
            else if (item != null && dep == null)
            {
                //return all the req items that are approved or partially delivered of that one item

                reqItemList = context.RequisitionItems.Where(x => (x.Requisition.Status == ReqStatus.APPROVED.ToString()
                        || x.Requisition.Status == ReqStatus.PARTIAL.ToString())
                        && x.Item.ItemId == item.ItemId).ToList();
            }
            else
            {
                reqItemList = context.RequisitionItems.Where(x => (x.Requisition.Status == ReqStatus.APPROVED.ToString()
                    || x.Requisition.Status == ReqStatus.PARTIAL.ToString())
                    && x.Item.ItemId == item.ItemId && x.Requisition.Employee.DeptId == dep.DeptId).ToList();
            }

            if(emp != null)
            {
                reqItemList = reqItemList.Where(x => x.Requisition.EmpId == emp.EmpId).ToList();
            }

            return reqItemList;
        }


        public int GetDeliveredSum(RequisitionItem reqItem)
        {
            //get all the disbursement of that requisition item
            List<DisburseReqItem> disReqList = context.DisburseReqItems.Where(x => x.ReqId == reqItem.ReqId && x.ItemId == reqItem.ItemId).ToList();
            int deliveredSum = 0;
            if (disReqList != null)
            {
                deliveredSum = disReqList.Select(s => s?.DisburseQty ?? 0).Sum();
            }
            return deliveredSum;
        }

        public int GetRetrieveUndeliveredSum(RequisitionItem reqItem)
        {
            //this method will return all the retrieved item that are not delivered yet
            //the logic is to get the retrieved amount of a disbursement if the delivered quantity is null

            //get all the disbursement of that requisition item
            List<DisburseReqItem> disReqList = context.DisburseReqItems.Where(x => x.ReqId == reqItem.ReqId && x.ItemId == reqItem.ItemId).ToList();
            int retrievedSum = 0;
            if (disReqList != null)
            {
                foreach (var item in disReqList)
                {
                    if (item.DisburseQty == null)
                    {
                        retrievedSum += item.RetrieveQty;
                    }
                }
            }
            return retrievedSum;
        }

        public List<RequisitionItem> GetUndeliveredRequisitionItems(int empId)
        {
            //Get all the req items that are approved or partially delivered
            List<RequisitionItem> ReqItemList = GetApprovedRequisitionItems(emp:context.Employees.FirstOrDefault(x => x.EmpId == empId));

            List<RequisitionItem> undeliveredReqItemList = new List<RequisitionItem>();

            foreach (var reqItem in ReqItemList)
            {
                //get the sum of all the disbursement of that requisition item
                int deliveredSum = GetDeliveredSum(reqItem);

                //remove that req item if that item is fully delivered
                if (reqItem.Quantity > deliveredSum)
                {
                    undeliveredReqItemList.Add(reqItem);
                }
            }

            return undeliveredReqItemList;
        }

        public List<RequisitionItem> GetApprovedRequisitionItems()
        {
            return context.RequisitionItems.Where(x => x.Requisition.Status == ReqStatus.APPROVED.ToString() || x.Requisition.Status == ReqStatus.PARTIAL.ToString()).ToList();
        }
        //Jinshan
        public List<Item> GetLowStock()
        {
            List<Item> l2 = new List<Item>();
            List<Item> l1 = new List<Item>();
            l1 = GetAllStockStatus();
            for (int i = 0; i <= l1.Count - 1; i++)
            {
                if (l1[i].StockBalance < l1[i].ReorderLvl)
                {
                    l2.Add(l1[i]);
                }
            }
            return l2;
        }

        public List<Item> GetAllStockStatus()
        {
            List<Item> l2 = new List<Item>();
            try
            {
                context = new LUSSdb();
                l2 = context.Items.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

            return l2;
        }
    }


}