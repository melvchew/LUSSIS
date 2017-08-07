using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;

namespace LUSSIS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        StockManagementBLL bll = new StockManagementBLL();
        public WCF_ConsolidatedRetrieveItem[] GetRetrieveItems()
        {
            List<RequisitionItem> undeliveredReqItemList = bll.GetUndeliveredRequisitionItems();
            WCF_ConsolidatedRetrieveItem[] items = new WCF_ConsolidatedRetrieveItem[undeliveredReqItemList.Select(x => x.Item).Distinct().Count()];
            int counter = 0;
            foreach (var item in undeliveredReqItemList.Select(x => x.Item).Distinct())
            {
                items[counter] = new WCF_ConsolidatedRetrieveItem(item.ItemId, item.Description, item.BinNumber, bll.GetRetrievedNeeded(item), 0);
                counter++;
            }
            return items;
        }

        public WCF_RetrieveItemByDep[] GetRetrieveItemByDep(string itemId)
        {
            Item item = bll.GetItem(Convert.ToInt32(itemId));
            //get the department that are in need of the item
            List<Department> depList = bll.GetDepartmentList(item);

            WCF_RetrieveItemByDep[] items = new WCF_RetrieveItemByDep[depList.Count];
            int counter = 0;
            foreach (var dep in depList)
            {
                items[counter] = new WCF_RetrieveItemByDep(dep.DeptId, dep.DeptName, bll.GetRetrievedNeeded(item, dep),
                    bll.GetRetrievedNeeded(item, dep, true), 0);
                counter++;
            }

            return items;
        }

        public void RetrieveItems(List<WCF_RetrievedItemData> items, string storeEmpId, string disDate)
        {
            List<int> depIdList = items.Select(x => x.DepId).Distinct().ToList();
            foreach (var depId in depIdList)
            {
                List<ConsolidatedDisbursementItem> cdiList = new List<ConsolidatedDisbursementItem>();
                foreach (var retrievedData in items.Where(x => x.DepId == depId))
                {
                    cdiList.Add(new ConsolidatedDisbursementItem
                    {
                        Item = bll.GetItem(retrievedData.ItemId),
                        AmountRetrieved = retrievedData.RetrievedQty
                    });
                }
                Department dep = bll.GetDepartmentList().FirstOrDefault(x => x.DeptId == depId);
                int empId = Convert.ToInt32(storeEmpId);
                StoreEmployee emp = bll.GetStoreEmployeeList().FirstOrDefault(x => x.StoreEmpId == empId);

                string[] dateData = disDate.Split('-');
                DateTime disbursementDate = new DateTime(Convert.ToInt32(dateData[2]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[0]));

                Disbursement dis = bll.CreateDisbursement(cdiList, dep, emp, disbursementDate);
                bll.SaveDisbursement(dis);

            }
        }

        public void DeleteDisbursementList(string disDate)
        {
            string[] dateData = disDate.Split('-');
            DateTime disbursementDate = new DateTime(Convert.ToInt32(dateData[2]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[0]));

            bll.DeleteDisbursement(disbursementDate);
        }

        public WCF_ConsolidatedRetrieveItem[] GetRetrievedItems(string disDate)
        {
            string[] dateData = disDate.Split('-');
            DateTime disbursementDate = new DateTime(Convert.ToInt32(dateData[2]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[0]));
            WCF_ConsolidatedRetrieveItem[] items;

            if (bll.IsDisbursementListExisted(disbursementDate))
            {
                List<DisburseReqItem> retrievedReqItemList = bll.GetDisbursementItems(disbursementDate);
                items = new WCF_ConsolidatedRetrieveItem[retrievedReqItemList.Select(x => x.Item).Distinct().Count()];
                int counter = 0;
                foreach (var item in retrievedReqItemList.Select(x => x.Item).Distinct())
                {
                    int retrievedQty = retrievedReqItemList.Where(x => x.ItemId == item.ItemId).Select(x => x.RetrieveQty).Sum();
                    items[counter] = new WCF_ConsolidatedRetrieveItem(item.ItemId, item.Description, item.BinNumber, retrievedQty, retrievedQty);
                    counter++;
                }
                return items;
            }
            else
            {
                List<RequisitionItem> undeliveredReqItemList = bll.GetUndeliveredRequisitionItems();
                items = new WCF_ConsolidatedRetrieveItem[undeliveredReqItemList.Select(x => x.Item).Distinct().Count()];
                int counter = 0;
                foreach (var item in undeliveredReqItemList.Select(x => x.Item).Distinct())
                {
                    items[counter] = new WCF_ConsolidatedRetrieveItem(item.ItemId, item.Description, item.BinNumber, bll.GetRetrievedNeeded(item), 0);
                    counter++;
                }
                return items;
            }
        }

        public WCF_DisbursementDate[] GetDisDates()
        {
            List<Disbursement> disList = bll.GetLatestDisbursements();
            WCF_DisbursementDate[] wcfdates = new WCF_DisbursementDate[disList.Select(x => x.DisburseDate).Distinct().Count()];
            int counter = 0;
            foreach (var d in disList.Select(x => x.DisburseDate).Distinct())
            {
                String[] dateData = d.Value.Date.ToShortDateString().Split('/');

                wcfdates[counter] = new WCF_DisbursementDate($"{dateData[1]}-{dateData[0]}-{dateData[2]}");
                counter++;
            }
            return wcfdates;
        }

        public WCF_DisbursementDepartment[] GetDisDepartments(string disDate)
        {
            string[] dateData = disDate.Split('-');
            DateTime disbursementDate = new DateTime(Convert.ToInt32(dateData[2]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[0]));

            List<Disbursement> disList = bll.GetUndeliveredDisbursements(disbursementDate);
            List<Department> depList = bll.GetDepartmentList();

            WCF_DisbursementDepartment[] wcfdeps = new WCF_DisbursementDepartment[disList.Select(x => x.Department).Distinct().Count()];
            int counter = 0;
            foreach (var dep in disList.Select(x => x.Department).Distinct())
            {
                Department d = depList.FirstOrDefault(x => x.DeptId == dep.DeptId);
                wcfdeps[counter] = new WCF_DisbursementDepartment(dep.DeptId.ToString(), d.DeptName, d.CollectionPoint.Description);
                counter++;
            }

            return wcfdeps;
        }

        public WCF_DisbursementItemData[] GetDisItems(string disDate, string depId)
        {
            string[] dateData = disDate.Split('-');
            DateTime disbursementDate = new DateTime(Convert.ToInt32(dateData[2]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[0]));
            int did = Convert.ToInt32(depId);
            Department dep = bll.GetDepartmentList().FirstOrDefault(x => x.DeptId == did);

            List<DisburseReqItem> disReqItemList = bll.GetDisbursementItems(disbursementDate, dep);
            WCF_DisbursementItemData[] wcfdisItems = new WCF_DisbursementItemData[disReqItemList.Select(x => x.Item).Distinct().Count()];
            int counter = 0;

            foreach (var item in disReqItemList.Select(x => x.Item).Distinct())
            {
                int rQty = disReqItemList.Where(x => x.ItemId == item.ItemId).Select(x => x.RetrieveQty).Sum();
                wcfdisItems[counter] = new WCF_DisbursementItemData(item.ItemId, item.Description, rQty, rQty);
                counter++;
            }

            return wcfdisItems;
        }

        public void DisburseItems(List<WCF_DisbursementItemData> items, string storeEmpId, string disDate, string deptId)
        {
            string[] dateData = disDate.Split('-');
            DateTime disbursementDate = new DateTime(Convert.ToInt32(dateData[2]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[0]));

            List<ConsolidatedDisbursementItem> conDisItemList = new List<ConsolidatedDisbursementItem>();
            foreach (var item in items)
            {
                ConsolidatedDisbursementItem cdi = new ConsolidatedDisbursementItem
                {
                    Item = bll.GetItem(item.ItemId),
                    AmountRetrieved = item.RetrievedQty,
                    AmountDisbursed = item.DeliverQty
                };
                conDisItemList.Add(cdi);
            }
            int id = Convert.ToInt32(deptId);
            Department dep = bll.GetDepartmentList().FirstOrDefault(x => x.DeptId == id);
            id = Convert.ToInt32(storeEmpId);
            StoreEmployee emp = bll.GetStoreEmployeeList().FirstOrDefault(x => x.StoreEmpId == id);
            bll.DeliverDisbursementItems(conDisItemList, disbursementDate, dep, emp);

            //Auto-raised Adj voucher
            List<ConsolidateItem> conItemList = new List<ConsolidateItem>();
            foreach (var item in items)
            {
                if (item.RetrievedQty - item.DeliverQty != 0)
                {
                    ConsolidateItem i = conItemList.FirstOrDefault(x => x.Item.ItemId == item.ItemId);
                    if (i == null)
                    {
                        i = new ConsolidateItem()
                        {
                            Item = bll.GetItem(item.ItemId),
                            Qty = item.DeliverQty - item.RetrievedQty
                        };
                        conItemList.Add(i);
                    }
                    else
                    {
                        i.Qty += item.DeliverQty - item.RetrievedQty;
                    }
                }
            }

            bll.RaiseAdjVoucher(conItemList, emp, "Found faulty during delivery");
        }

        public WCF_IsPresent IsDisbursementPresent(string disDate)
        {
            string[] dateData = disDate.Split('-');
            DateTime disbursementDate = new DateTime(Convert.ToInt32(dateData[2]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[0]));

            WCF_IsPresent isPresent = new WCF_IsPresent(bll.IsDisbursementListExisted(disbursementDate));
            return isPresent;
        }
    }
}
