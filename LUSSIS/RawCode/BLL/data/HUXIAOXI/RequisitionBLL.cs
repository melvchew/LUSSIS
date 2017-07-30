using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Made by Hu Xiaoxi(Team5)
namespace LUSSIS.RawCode.BLL.data.HUXIAOXI
{
    public class RequisitionBLL
    {
        enum ReqStatus
        {
            PENDING,
            CANCELLED,
            APPROVED,
            REJECTED,
            PARTIAL,
            DELIVERED
        }

        //Get Catalog List
        public List<Item> GetCatalog()
        {
            try
            {
                LUSSdb context = new LUSSdb();
                return context.Items.ToList();
            }
            catch (Exception exp)
            {
                Console.WriteLine("GetCatalog Error: " + exp.Message);
                return new List<Item>();
            }

        }

        //Get All Item Category List
        public List<string> GetCategory()
        {
            LUSSdb context = new LUSSdb();

            List<Item> category = context.Items.GroupBy(i => i.Category).Select(i => i.FirstOrDefault()).ToList<Item>();
            List<string> ItemCategory = new List<string> { "" };
            foreach (Item i in category)
            {
                ItemCategory.Add(i.Category.ToString());
            }
            return ItemCategory;
        }

        //Get department employee name
        public List<string> GetEmpName(Department dept)
        {
            LUSSdb context = new LUSSdb();

            List<Employee> lemps = context.Employees.Where(em => em.DeptId == dept.DeptId).ToList();
            List<string> ItemCategory = new List<string> { "" };
            foreach (Employee emp in lemps)
            {
                ItemCategory.Add(emp.Name.ToString());
            }
            return ItemCategory;
        }

        //Get Department Requisition List
        public List<Requisition> GetDeptReq(Department dept)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                return context.Requisitions.Where(r => r.Employee.DeptId == dept.DeptId).ToList();
            }
            catch (Exception exp)
            {
                Console.WriteLine("GetDeptReq Error: " + exp.Message);
                return new List<Requisition>();
            }
        }

        //Get Own Requisition history List
        public List<Requisition> GetOwnReq(Employee emp)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                return context.Requisitions.Where(r => r.EmpId == emp.EmpId).ToList();
            }
            catch (Exception exp)
            {
                Console.WriteLine("GetOwnReq Error: " + exp.Message);
                return new List<Requisition>();
            }

        }

        //Get Disbursement Requisition Items
        public List<DisburseReqItem> GetDisReqItems(Requisition req)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                List<DisburseReqItem> ldisReqItems = context.DisburseReqItems.Where(ri => ri.ReqId == req.ReqId).ToList();

                return ldisReqItems;
            }
            catch (Exception exp)
            {
                Console.WriteLine("GetDisReqItems Error: " + exp.Message);
                return new List<DisburseReqItem>();
            }
        }

        //Get Requisition Items
        public List<RequisitionItem> GetReqItems(Requisition req)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                List<RequisitionItem> lreqItems = context.RequisitionItems.Where(ri => ri.ReqId == req.ReqId).ToList();

                return lreqItems;
            }
            catch (Exception exp)
            {
                Console.WriteLine("GetReqItems Error: " + exp.Message);
                return new List<RequisitionItem>();
            }
        }

        //Create new Requisition
        public Requisition CreateReq(Employee emp, String comt)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                Requisition req = new Requisition();
                req.EmpId = emp.EmpId;
                req.SubmitDate = DateTime.Now;
                req.Status = ReqStatus.PENDING.ToString();
                req.EmpComments = comt;

                context.Requisitions.Add(req);
                context.SaveChanges();
                return req;
            }
            catch (Exception exp)
            {
                Console.WriteLine("CreateReq Error: " + exp.Message);
                return new Requisition();
            }

        }

        //Add Requisition Items
        public void AddReqItems(Requisition req, Item item, int quantity)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                RequisitionItem reqItem = new RequisitionItem();
                reqItem.ReqId = req.ReqId;
                reqItem.ItemId = item.ItemId;
                reqItem.Quantity = quantity;
                //Check whether the requisition has the same ReqItem
                //if not, just add the reqitem
                if (this.CheckSameReqItem(reqItem, req))
                {
                    context.RequisitionItems.Add(reqItem);
                    context.SaveChanges();
                }
                //if has, add the qty to the original reqitem qty.
                else
                {
                    var SameReqitem = context.RequisitionItems.Find(reqItem.ReqId, reqItem.ItemId);
                    quantity += SameReqitem.Quantity;
                    this.UpdateReqItems(req.ReqId, item.ItemId, quantity);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("AddReqItems Error: " + exp.Message);
            }
        }


        //Update Requisition Item quantity
        public void UpdateReqItems(int reqId, int itemId, int quantity)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                var reqItem = context.RequisitionItems.Find(reqId, itemId);
                reqItem.Quantity = quantity;
                context.SaveChanges();
            }
            catch (Exception exp)
            {
                Console.WriteLine("UpdateReqItems Error: " + exp.Message);
            }

        }

        //Delete Requisition Item 
        public void DeleteReqItems(List<RequisitionItem> lreqitem)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                foreach (RequisitionItem i in lreqitem)
                {
                    var reqItem = context.RequisitionItems.Where(r => r.ReqId == i.ReqId && r.ItemId == i.ItemId).ToList().First();
                    context.RequisitionItems.Remove(reqItem);
                }
                context.SaveChanges();
            }
            catch (Exception exp)
            {
                Console.WriteLine("DeleteReqItems Error: " + exp.Message);
            }

        }

        //Cancel Requisition
        public bool CancelReq(Requisition req)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                if (req.Status == ReqStatus.PENDING.ToString())
                {
                    var requisition = context.Requisitions.Where(r => r.ReqId == req.ReqId).ToList().First();
                    requisition.Status = ReqStatus.CANCELLED.ToString();
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception exp)
            {
                Console.WriteLine("CancelReq Error: " + exp.Message);
                return false;
            }

        }

        //Catalog Search by Item Name(Support fuzzy query)
        public List<Item> SearchItemByName(String itemName)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                string ItemName = itemName.ToLower().Trim();
                List<Item> litem = new List<Item>();

                //"" means search all
                if (itemName == "")
                {
                    litem = this.GetCatalog();
                }
                else
                {
                    litem = context.Items.Where(i => i.Description.Trim().ToLower().Contains(itemName)).ToList();//Contains == like %value%
                }

                return litem;
            }
            catch (Exception exp)
            {
                Console.WriteLine("SearchItemByName Error: " + exp.Message);
                return new List<Item>();
            }
        }

        //Catalog Search by Category
        public List<Item> SearchItemByCategory(String category)
        {
            try
            {
                LUSSdb context = new LUSSdb();
                List<Item> litem = new List<Item>();

                //"" means search all
                if (category == "")
                {
                    litem = this.GetCatalog();
                }
                else
                {
                    litem = context.Items.Where(i => i.Category == category).ToList();
                }
                return litem;
            }
            catch (Exception exp)
            {
                Console.WriteLine("SearchItemByCategory Error: " + exp.Message);
                return new List<Item>();
            }
        }

        //Get all the disbursement item's total quantity
        public int GetDisbursedQty(int reqId, int itemId)
        {
            LUSSdb context = new LUSSdb();
            List<DisburseReqItem> ldisReqItems = context.DisburseReqItems.Where(x => x.ReqId == reqId && x.ItemId == itemId).ToList();
            int qty = 0;
            if (ldisReqItems.Count == 0)
            {
                return 0;
            }
            else
            {
                qty = ldisReqItems.Sum(x => x.DisburseQty == 0 ? 0 : (int)x.DisburseQty);
            }
            return qty;
        }


        //Check if the adding new item duplicated(for new req)
        //Not duplicated:ture, duplicated: false.
        public bool CheckSameItem(Item i, List<Item> litems)
        {
            int flag = 0;
            foreach (Item ite in litems)
            {
                if (ite.ItemId == i.ItemId)
                    flag++;
            }
            bool result = (flag == 0) ? true : false;
            return result;
        }

        //Check if the adding reqitem duplicated(for existed req)
        //Not duplicated:ture, duplicated: false.
        public bool CheckSameReqItem(RequisitionItem ri, Requisition req)
        {
            int flag = 0;
            LUSSdb context = new LUSSdb();
            List<RequisitionItem> chklist = context.RequisitionItems.Where(r => r.ReqId == req.ReqId).ToList();
            foreach (RequisitionItem r in chklist)
            {
                if (r.ItemId == ri.ItemId)
                    flag++;
            }
            bool result = (flag == 0) ? true : false; 
            return result;
        }
    }
}