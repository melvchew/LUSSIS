using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;
using System.Data.SqlClient;
using System.Data.OleDb;
//using Microsoft.Office.Interop.Excel;
//using System.Runtime.InteropServices;

namespace LUSSIS.RawCode.BLL
{
    public class StockManagementBLL
    {

        LUSSdb context = new LUSSdb();
        //Created by Kavya

        public Department GetCurrentDeptById(int depId)  // Used also in ChangeCollectionPointBLL.cs
        {
            return context.Departments.Where(x => x.DeptId == depId).FirstOrDefault();
        }

        public Disbursement GetDisbursement(DateTime disDate, Department dep)
        {
            String s = disDate.ToString("dd/MM/yyyy");
            DateTime d = Convert.ToDateTime(s);
            return context.Disbursements.Where(x => x.DisburseDate == d && x.Department.DeptId == dep.DeptId).First<Disbursement>();
        }

        public List<String> GetCollectionItemList(DateTime disDate, Department dep)
        {
            List<String> list = new List<String>();
            Disbursement d = new Disbursement();
            d = context.Disbursements.FirstOrDefault(x => x.DisburseDate == disDate && x.Department.DeptId == dep.DeptId);
            foreach (var item in d.DisburseReqItems)
            {
                list.Add(item.Item.Description);
                list.Add(item.RetrieveQty.ToString());
                list.Add(item.Item.Unit);
            }
            return list;
        }

        public Disbursement GetDisbursementByID(int id)
        {
            return context.Disbursements.Where(x => x.DisbursementId == id).First<Disbursement>();
        }

        public CollectionPoint GetCollectionPointOfDepartment(Department dep)
        {
            return context.CollectionPoints.Where(x => x.CollectionPointId == dep.CollectionPointId).First<CollectionPoint>();
        }

        //-----------------------------------------------------------------------------------------------------------------

        //created by Khin

        public List<Item> getProductList()
        {
            context = new LUSSdb();
            return context.Items.ToList<Item>();
        }

        public List<Item> searchProductList(String value)
        {
            context = new LUSSdb();
            return context.Items.Where(x => x.Description.Contains(value) || x.Category.Contains(value)).ToList<Item>();
        }

       

        public List<String> getCategory()
        {
            context = new LUSSdb();
            return context.Items.Select(x => x.Category).Distinct().ToList<String>();
        }
        public List<Supplier> getSupplierList()
        {
            context = new LUSSdb();
            return context.Suppliers.ToList<Supplier>();
        }



        public Item getProductByIDs(int id)
        {
            context = new LUSSdb();
            return context.Items.Where(p => p.ItemId == id).FirstOrDefault();
        }

        public Boolean addProduct(Item item)
        {
            try
            {
                context = new LUSSdb();

                Item i = new Item();
                i.Category = item.Category;
                i.BinNumber = item.BinNumber;
                i.Description = item.Description;
                i.StockBalance = item.StockBalance;
                i.ReorderLvl = item.ReorderLvl;
                i.ReorderQty = item.ReorderQty;
                i.Unit = item.Unit;
                i.Supplier1Id = item.Supplier1Id;
                i.Supplier1Price = item.Supplier1Price;
                i.Supplier2Id = item.Supplier2Id;
                i.Supplier2Price = item.Supplier2Price;
                i.Supplier3Id = item.Supplier3Id;
                i.Supplier3Price = item.Supplier3Price;
                i.IsCataloged = item.IsCataloged;
                context.Items.Add(i);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Boolean updateProduct(Item item)
        {
            try
            {
                context = new LUSSdb();
                Item i = context.Items.Where(p => p.ItemId == item.ItemId).FirstOrDefault();
                i.Category = item.Category;
                i.BinNumber = item.BinNumber;
                i.Description = item.Description;
                i.StockBalance = item.StockBalance;
                i.ReorderLvl = item.ReorderLvl;
                i.ReorderQty = item.ReorderQty;
                i.Unit = item.Unit;
                i.Supplier1Id = item.Supplier1Id;
                i.Supplier1Price = item.Supplier1Price;
                i.Supplier2Id = item.Supplier2Id;
                i.Supplier2Price = item.Supplier2Price;
                i.Supplier3Id = item.Supplier3Id;
                i.Supplier3Price = item.Supplier3Price;
                i.IsCataloged = item.IsCataloged;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //-----------------------------------------------------------------------------------------------------------------
        //Melvin
        //LUSSdb ctx = new LUSSdb();
        public List<Item> GetItemList()
        {
            {
                return context.Items.ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------
        //Peter

        private string statusMsg = "";
        private string xlSuppTab = "[Suppliers$]";
        private string xlItemTab = "[Items$]";

        public string Status
        {
            get
            {
                return statusMsg;
            }
        }

        public void txfToDb(string sqlConnStr, string excelFilePath, string suppSqlTable, string suppSqlStagingTable, string suppSqlBackupTable, string itemSqlTable, string itemSqlStagingTable, string itemSqlBackupTable)
        {
            using (SqlConnection sqlConn = new SqlConnection(sqlConnStr))
            {
                try
                {
                    sqlConn.Open();
                    SqlTransaction sqlTxn = sqlConn.BeginTransaction();
                    SqlCommand sqlCmd = sqlConn.CreateCommand();
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.Transaction = sqlTxn;
                    string excelConnStr = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath + ";extended properties=" + "\"excel 12.0;hdr=NO;imex=1\"";
                    OleDbConnection oleDbConn = new OleDbConnection(excelConnStr);
                    string excelQuery;

                    try
                    {
                        //Delete current data from staging tables
                        sqlCmd.CommandText = "delete from " + suppSqlStagingTable;
                        sqlCmd.ExecuteNonQuery();
                        sqlCmd.CommandText = "delete from " + itemSqlStagingTable;
                        sqlCmd.ExecuteNonQuery();

                        //Drop current backup tables
                        sqlCmd.CommandText = "if object_id('dbo." + suppSqlBackupTable + "', 'U') is not null drop table " + suppSqlBackupTable;
                        sqlCmd.ExecuteNonQuery();
                        sqlCmd.CommandText = "if object_id('dbo." + itemSqlBackupTable + "', 'U') is not null drop table " + itemSqlBackupTable;
                        sqlCmd.ExecuteNonQuery();

                        //Create new backups of primary tables
                        sqlCmd.CommandText = "select * into " + suppSqlBackupTable + " from " + suppSqlTable;
                        sqlCmd.ExecuteNonQuery();
                        sqlCmd.CommandText = "select * into " + itemSqlBackupTable + " from " + itemSqlTable;
                        sqlCmd.ExecuteNonQuery();

                        //Import excel data into staging tables
                        excelQuery = "select * from " + xlSuppTab;
                        OleDbCommand oleDbCmd = new OleDbCommand(excelQuery, oleDbConn);
                        SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlConnStr);
                        oleDbConn.Open();
                        bulkcopy.DestinationTableName = suppSqlStagingTable;
                        OleDbDataReader dr = oleDbCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            bulkcopy.WriteToServer(dr);
                        }
                        dr.Close();
                        excelQuery = "select * from " + xlItemTab;
                        oleDbCmd = new OleDbCommand(excelQuery, oleDbConn);
                        bulkcopy.DestinationTableName = itemSqlStagingTable;
                        dr = oleDbCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            bulkcopy.WriteToServer(dr);
                        }
                        dr.Close();
                        oleDbConn.Close();

                        //Merge staging tables with primary tables
                        sqlCmd.CommandText = "MERGE " + suppSqlTable + @" AS target USING (select * from " + suppSqlStagingTable + @") as source
                                    ON (source.SupplierId = target.SupplierId)
                                    WHEN MATCHED THEN
                                    UPDATE SET 
                                        CompanyName = source.CompanyName,
                                        ContactPerson = source.ContactPerson,
                                        Phone = source.Phone,
                                        Fax = source.Fax,
                                        Address = source.Address,
                                        Email = source.Email,
                                        GstNo = source.GstNo
                                    WHEN NOT MATCHED THEN
                                    INSERT (SupplierId, CompanyName, ContactPerson, Phone, Fax, Address, Email, GstNo)
                                    VALUES (source.SupplierId, source.CompanyName, source.ContactPerson, source.Phone, source.Fax, source.Address, source.Email, source.GstNo);";
                        sqlCmd.ExecuteNonQuery();
                        sqlCmd.CommandText = "MERGE " + itemSqlTable + @" AS target USING (select * from " + itemSqlStagingTable + @") as source
                                    ON (source.Description = target.Description)
                                    WHEN MATCHED THEN
                                    UPDATE SET 
                                        Category = source.Category,
                                        Unit = source.Unit,
                                        Supplier1Id = source.Supplier1Id,
                                        Supplier1Price = source.Supplier1Price,
                                        Supplier2Id = source.Supplier2Id,
                                        Supplier2Price = source.Supplier2Price,
                                        Supplier3Id = source.Supplier3Id,
                                        Supplier3Price = source.Supplier3Price
                                    WHEN NOT MATCHED THEN
                                    INSERT (Category, Description, Unit, Supplier1Id, Supplier1Price, Supplier2Id, Supplier2Price, Supplier3Id, Supplier3Price)
                                    VALUES (source.Category, source.Description, source.Unit, source.Supplier1Id, source.Supplier1Price, source.Supplier2Id, source.Supplier2Price, source.Supplier3Id, source.Supplier3Price);";
                        sqlCmd.ExecuteNonQuery();

                        sqlTxn.Commit();
                        statusMsg = "Data transfer successful!";
                    }
                    catch
                    {
                        if (oleDbConn.State != System.Data.ConnectionState.Closed)
                        {
                            oleDbConn.Dispose();
                            oleDbConn = null;
                            GC.Collect();
                        }
                        sqlTxn.Rollback();
                        statusMsg = @"Transfer failed. Please make sure the file is formatted correctly and try again.<br /><br />
                        For Supplier tab:<br />
                        SupplierId must be unique and have a maximum of 4 alphanumeric digits.<br />
                        Do not edit SupplierId for existing rows.<br />
                        Required fields: SupplierId, CompanyName, Phone, Address, Email.<br /><br />
                        For Item tab:<br />
                        Values in SupplierId columns must exist in the Suppliers tab.<br />
                        Description must be unique.<br />
                        Do not edit Description for existing rows.<br />
                        Required fields: Description, Unit, Supplier1Id, Supplier1Price, Supplier2Id, Supplier2Price, Supplier3Id, Supplier3Price.";
                    }
                }
                catch
                {
                    statusMsg = "Connection error. Please contact an administrator.";
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------
        //Created by Jinshan
        //check supplierid
        public bool CheckSupplierID(string id)
        {
            bool check = false;
            IList<Supplier> l = FindAllSuppliers();
            for (int i = 0; i < l.Count; i++)
            {
                if (((Supplier)l[i]).SupplierId == id)
                {

                    check = true;
                    break;
                }

            }
            return check;
        }

        public Supplier getSupplierbyID(string id)
        {
            context = new LUSSdb();
            return context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault<Supplier>();
        }

        //insert a new supplier
        public void InsertNewSupplier(string id, string name, string contactPerson, string phoneNo, string faxNo, string address, string email, string gstNo)
        {
            Supplier supplier = new Supplier();
            supplier.SupplierId = id;
            supplier.CompanyName = name;
            supplier.ContactPerson = contactPerson;
            supplier.Phone = phoneNo;
            supplier.Fax = faxNo;
            supplier.Address = address;
            supplier.Email = email;
            supplier.GstNo = gstNo;
            try
            {
                using (context = new LUSSdb())
                {
                    context.Suppliers.Add(supplier);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        //find all suppliers
        public List<Supplier> FindAllSuppliers()
        {
            List<Supplier> v = new List<Supplier>();
            try
            {
                using (context = new LUSSdb())
                {
                    v = context.Suppliers.ToList();
                }

            }
            catch (Exception e)
            {
                throw (e);
            }
            return v;

        }

        //upsate supplier
        public void UpdateSupplier(Supplier s)
        {
            try
            {
                using (context = new LUSSdb())
                {

                    Supplier supplier = context.Suppliers.Where(x => x.SupplierId == s.SupplierId).First<Supplier>();
                    supplier.CompanyName = s.CompanyName;
                    supplier.ContactPerson = s.ContactPerson;
                    supplier.Phone = s.Phone;
                    supplier.Fax = s.Fax;
                    supplier.Address = s.Address;
                    supplier.Email = s.Email;
                    supplier.GstNo = s.GstNo;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //fuzzy query supplier by name
        public List<Supplier> SearchSupplier(string name)
        {
            List<Supplier> v = new List<Supplier>();
            if (name != null)
            {
                try
                {
                    using (context = new LUSSdb())
                    {
                        v = context.Suppliers.Where(s => s.CompanyName.Contains(name)).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return v;
        }

        // find a supplier by id
        public Supplier FindSupplierById(string id)
        {
            Supplier supplier = new Supplier();

            try
            {
                using (context = new LUSSdb())
                {
                    supplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return supplier;
        }
       
        //-----------------------------------------------------------------------------------------------------------------
        //Created by Zach
        public Item GetItem(int itemId)
        {
            return context.Items.FirstOrDefault(x => x.ItemId == itemId);
        }
        public List<Item> GetCatalogueItemList()
        {
            return context.Items.Where(x => x.IsCataloged == true).ToList();
        }

        public List<PurchaseOrder> GenerateOrderForms(List<OrderListItem> itemList, StoreEmployee emp, DateTime expectedDate)
        {
            //This method will create a list of purchase orders based on the supplier

            List<PurchaseOrder> poList = new List<PurchaseOrder>();
            //purchase order are based on supplier
            foreach (var supplier in itemList.Select(s => s.Supplier).Distinct().ToList())
            {
                PurchaseOrder po = new PurchaseOrder()
                {
                    PurchaseOrderItems = new List<PurchaseOrderItem>(),
                    SupplierId = supplier.SupplierId,
                    OrderStoreEmployee = emp,
                    OrderDate = System.DateTime.Now,
                    Status = PurchaseOrderStatus.PENDING.ToString(),
                    ExpectedDate = expectedDate
                };
                foreach (var orderItem in itemList)
                {
                    if (orderItem.Supplier == supplier)
                    {
                        PurchaseOrderItem pi = new PurchaseOrderItem
                        {
                            ItemId = orderItem.PurchaseOrderItem.ItemId,
                            OrderQty = orderItem.PurchaseOrderItem.OrderQty
                        };
                        pi.PurchaseOrder = po;
                        po.PurchaseOrderItems.Add(pi);

                    }
                }
                poList.Add(po);
            }
            return poList;
        }

        public void SavePurchaseOrder(PurchaseOrder po)
        {

            context.PurchaseOrders.Add(po);
            context.SaveChanges();
        }

        public List<PurchaseOrder> SubmitPurchaseOrders(List<PurchaseOrder> poList)
        {
            foreach (var po in poList)
            {
                context.PurchaseOrders.Add(po);
            }
            context.SaveChanges();
            return poList;
        }

        public List<PurchaseOrder> GetPurchaseOrders(bool pendingOnly)
        {
            List<PurchaseOrder> poList;
            if (pendingOnly)
            {
                poList = context.PurchaseOrders.Where(x => x.Status == PurchaseOrderStatus.PENDING.ToString()).ToList();
            }
            else
            {
                poList = context.PurchaseOrders.ToList();
            }
            return poList;
        }

        public List<Supplier> GetSupplierList()
        {

            return context.Suppliers.ToList();


        }

        public List<StoreEmployee> GetStoreEmployeeList()
        {

            return context.StoreEmployees.ToList();

        }

        public List<Department> GetDepartmentList()
        {

            return context.Departments.ToList();

        }

        public List<PurchaseOrder> GetPurchaseOrders()
        {

            return context.PurchaseOrders.ToList();

        }

        public List<PurchaseOrder> GetPurchaseOrders(DateTime startDate, DateTime endDate)
        {

            return context.PurchaseOrders.Where(x => x.OrderDate >= startDate && x.OrderDate <= endDate).ToList();

        }

        public List<PurchaseOrder> GetPendingPurchaseOrders()
        {

            return context.PurchaseOrders.Where(x => x.Status == PurchaseOrderStatus.PENDING.ToString()).ToList();

        }

        public PurchaseOrder GetPurchaseOrder(int purchaseOrderID)
        {

            return context.PurchaseOrders.FirstOrDefault(x => x.POId == purchaseOrderID);

        }

        public List<PurchaseOrderItem> GetPurchaseOrderItems(int purchaseOrderID)
        {

            return context.PurchaseOrderItems.Where(x => x.POId == purchaseOrderID).ToList();

        }

        public void ApprovePurchaseOrder(PurchaseOrder purchaseOrder, StoreEmployee emp)
        {

            PurchaseOrder po = context.PurchaseOrders.FirstOrDefault(x => x.POId == purchaseOrder.POId);
            po.Status = PurchaseOrderStatus.APPROVED.ToString();
            po.ApproveBy = emp.StoreEmpId;
            po.ApproveDate = System.DateTime.Now;
            po.ApproverComments = purchaseOrder.ApproverComments;
            context.SaveChanges();

        }

        public void RejectPurchaseOrder(PurchaseOrder purchaseOrder, StoreEmployee emp)
        {

            PurchaseOrder po = context.PurchaseOrders.FirstOrDefault(x => x.POId == purchaseOrder.POId);
            po.Status = PurchaseOrderStatus.REJECTED.ToString();
            po.ApproveBy = emp.StoreEmpId;
            purchaseOrder.ApproveDate = System.DateTime.Now;
            po.ApproverComments = purchaseOrder.ApproverComments;
            context.SaveChanges();

        }

        public void CancelPurchaseOrder(PurchaseOrder purchaseOrder)
        {

            PurchaseOrder po = context.PurchaseOrders.FirstOrDefault(x => x.POId == purchaseOrder.POId);
            po.Status = PurchaseOrderStatus.CANCELLED.ToString();
            context.SaveChanges();

        }

        public void ReceivePurchaseOrder(PurchaseOrder purchaseOrder, StoreEmployee emp)
        {

            //PurchaseOrder po = context.PurchaseOrders.FirstOrDefault(x => x.POId == purchaseOrder.POId);
            purchaseOrder.Status = PurchaseOrderStatus.RECIEVED.ToString();
            purchaseOrder.ReceiveBy = emp.StoreEmpId;
            //Add the received items to stock balance
            foreach (var item in purchaseOrder.PurchaseOrderItems)
            {
                item.Item.StockBalance += item?.DeliverQty ?? 0;
            }

            context.SaveChanges();

        }

        public List<Requisition> GetDeliveredRequsitions(Department dep = null)
        {

            List<Requisition> reqList = null;
            if (dep == null)
            {
                reqList = context.Requisitions.Where(x => x.Status == ReqStatus.APPROVED.ToString() || x.Status == ReqStatus.PARTIAL.ToString().ToString()).ToList();
            }
            else
            {
                reqList = context.Requisitions.Where(x => x.Employee.Department.DeptId == dep.DeptId
                    && (x.Status == ReqStatus.APPROVED.ToString() || x.Status == ReqStatus.PARTIAL.ToString().ToString()))
                    .ToList();
            }

            List<Requisition> deliveredReqList = new List<Requisition>();
            foreach (var req in reqList)
            {
                bool delivered = true;
                foreach (var reqItem in req.RequisitionItems)
                {
                    //get all the disbursement of that requisition item
                    int deliveredSum = GetDeliveredSum(reqItem);
                    if (reqItem.Quantity != deliveredSum)
                    {
                        delivered = false;
                        break;
                    }
                }

                if (delivered)
                {
                    deliveredReqList.Add(req);
                }
            }

            return deliveredReqList;
        }

        public List<Requisition> GetPartialRequsitions(Department dep = null)
        {

            List<Requisition> reqList = null;
            if (dep == null)
            {
                reqList = context.Requisitions.Where(x => x.Status == ReqStatus.APPROVED.ToString() || x.Status == ReqStatus.PARTIAL.ToString().ToString()).ToList();
            }
            else
            {
                reqList = context.Requisitions.Where(x => x.Employee.Department.DeptId == dep.DeptId
                    && (x.Status == ReqStatus.APPROVED.ToString() || x.Status == ReqStatus.PARTIAL.ToString().ToString()))
                    .ToList();
            }

            List<Requisition> partialReqList = new List<Requisition>();
            foreach (var req in reqList)
            {
                int totalDeliveredSum = 0;
                int totalNeededSum = 0;

                foreach (var reqItem in req.RequisitionItems)
                {
                    //get all the disbursement of that requisition item
                    totalDeliveredSum += GetDeliveredSum(reqItem);
                    totalNeededSum += reqItem.Quantity;
                }

                //if the req is not delivered but some of the items are delivered
                if ((totalNeededSum != totalDeliveredSum) && (totalDeliveredSum != 0))
                {
                    partialReqList.Add(req);
                }
            }

            return partialReqList;
        }

        public List<Requisition> DeliverRequisitions(List<Requisition> reqList)
        {
            //THIS IS JUST A TESTING METHOD.  CAN REMOVE LATER
            foreach (var item in reqList)
            {
                item.Status = ReqStatus.DELIVERED.ToString();
            }
            context.SaveChanges();
            return reqList;
        }

        public List<RequisitionItem> GetApprovedRequisitionItems(Item item = null, Department dep = null)
        {
            //return all the req items that are approved or partially delivered of the item and dep

            if (item == null && dep == null)
            {
                //return all the req items that are approved or partially delivered

                return context.RequisitionItems.Where(x => x.Requisition.Status == ReqStatus.APPROVED.ToString()
                        || x.Requisition.Status == ReqStatus.PARTIAL.ToString()).ToList();
            }
            else if (item != null && dep == null)
            {
                //return all the req items that are approved or partially delivered of that one item

                return context.RequisitionItems.Where(x => (x.Requisition.Status == ReqStatus.APPROVED.ToString()
                        || x.Requisition.Status == ReqStatus.PARTIAL.ToString())
                        && x.Item.ItemId == item.ItemId).ToList();
            }
            else
            {
                return context.RequisitionItems.Where(x => (x.Requisition.Status == ReqStatus.APPROVED.ToString()
                    || x.Requisition.Status == ReqStatus.PARTIAL.ToString())
                    && x.Item.ItemId == item.ItemId && x.Requisition.Employee.DeptId == dep.DeptId).ToList();
            }



        }

        public List<RequisitionItem> GetUndeliveredRequisitionItems()
        {
            //Get all the req items that are approved or partially delivered
            List<RequisitionItem> ReqItemList = GetApprovedRequisitionItems();

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

        public int GetRetrievedNeeded(Item item, Department dep = null, bool IOU = false)
        {
            //This method will get all the amount needed to retrieved of a particular item

            //The formula is
            //TotalRetrivedNeeded = TotalNeededAmount - AllDeliveredAmount - AllRetrievedButNotDelivered

            //Getting sum of the amount needed for that item
            int totalNeeded = 0;
            List<RequisitionItem> requiredItemList = dep == null ? GetApprovedRequisitionItems(item) : GetApprovedRequisitionItems(item, dep);

            if (IOU)
            {
                requiredItemList = requiredItemList.Where(x => x.Requisition.Status == ReqStatus.PARTIAL.ToString()).ToList();
            }

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

            //Getting all the retrieved but not delivered
            //the logic is to get the retrieved amount of a disbursement if the delivered quantity is null
            int retrieveUndeliveredAmount = 0;
            if (requiredItemList != null)
            {
                foreach (var reqItem in requiredItemList)
                {
                    retrieveUndeliveredAmount += GetRetrieveUndeliveredSum(reqItem);
                }
            }

            //applying the formula
            int totalRetrievedNeeded = totalNeeded - allDeliveredAmount - retrieveUndeliveredAmount;

            return totalRetrievedNeeded;
        }

        public Disbursement CreateDisbursement(List<ConsolidatedDisbursementItem> itemList, Department dep, StoreEmployee emp, DateTime disbursementDate)
        {
            //this method will create a disbursement based on the cosolidated items provided
            Disbursement disbursement = new Disbursement
            {
                DeptId = dep.DeptId,
                StoreEmpId = emp.StoreEmpId,
                RetrieveDate = System.DateTime.Now,
                DisburseDate = disbursementDate
            };

            foreach (var item in itemList)
            {
                //get the req for the item
                List<RequisitionItem> reqItemList = GetApprovedRequisitionItems(item.Item, dep);

                //order the list PARTIAL first then APPROVED which is desc and lowest date first which is ascending
                reqItemList = reqItemList.OrderByDescending(x => x.Requisition.Status)
                    .ThenBy(x => x.Requisition.ApproveDate)
                    .ThenBy(x => x.Requisition.SubmitDate).ToList();

                int totalRetrievedAmount = item.AmountRetrieved;
                for (int i = 0; i < reqItemList.Count; i++)
                {
                    //if the total amount is still bigger than the required amount, it will fill fully
                    //otherwise it will fill the retrieved amount
                    int retrievedAmount = totalRetrievedAmount > reqItemList[i].Quantity ? reqItemList[i].Quantity : totalRetrievedAmount;
                    DisburseReqItem disReqItem = new DisburseReqItem
                    {
                        ReqId = reqItemList[i].ReqId,
                        ItemId = reqItemList[i].ItemId,
                        RetrieveQty = retrievedAmount
                    };

                    //add that dis req to the disbursement
                    disbursement.DisburseReqItems.Add(disReqItem);
                    //minus the retrieved amount for that item from total retrieved amount
                    totalRetrievedAmount -= retrievedAmount;
                }

                if (totalRetrievedAmount > 0)
                {
                    //throw exception about retrieving more items than needed
                }
            }

            return disbursement;
        }

        public void SaveDisbursement(Disbursement disbursement)
        {
            context.Disbursements.Add(disbursement);
            context.SaveChanges();
        }

        public List<Department> GetDepartmentList(Item item)
        {
            //this method will return a list of departments that are in need of that provided item
            List<Department> depList = new List<Department>();
            foreach (var dep in context.Departments)
            {
                int neededAmount = GetRetrievedNeeded(item, dep);
                if (neededAmount != 0)
                {
                    depList.Add(dep);
                }
            }

            return depList;
        }

        public List<Item> GetItemList(Department dep)
        {
            //this method will return a list of items that are required by the provided department
            List<Item> itemList = new List<Item>();
            foreach (var item in context.Items)
            {
                int neededAmount = GetRetrievedNeeded(item, dep);
                if (neededAmount != 0)
                {
                    itemList.Add(item);
                }
            }

            return itemList;
        }

        public List<DisburseReqItem> GetDisbursementItems(DateTime disbursementDate, Department dep = null, Item item = null)
        {
            if (dep == null)
            {
                //return all the disbursement items for the provided disbursement date
                return context.DisburseReqItems.Where(x => x.Disbursement.DisburseDate == disbursementDate).ToList();
            }
            else if (dep != null && item == null)
            {
                //return all the disbursement items for the provided disbursement date and the department
                return context.DisburseReqItems.Where(x => x.Disbursement.DisburseDate == disbursementDate && x.Disbursement.DeptId == dep.DeptId).ToList();
            }
            else
            {
                //this method will return all the disbursement items for the provided disbursement date and the department and the item
                return context.DisburseReqItems.Where(x => x.Disbursement.DisburseDate == disbursementDate && x.Disbursement.DeptId == dep.DeptId && x.ItemId == item.ItemId).ToList();
            }
        }


        public List<ConsolidatedDisbursementItem> GetConsolidatedDisbursementItem(List<DisburseReqItem> disReqList)
        {
            List<ConsolidatedDisbursementItem> consolidatedList = new List<ConsolidatedDisbursementItem>();

            foreach (var disReq in disReqList)
            {
                //try to find the same item in the consolidated list
                int foundPos = -1;
                for (int i = 0; i < consolidatedList.Count; i++)
                {
                    if (consolidatedList[i].Item.ItemId == disReq.Item.ItemId)
                    {
                        foundPos = i;
                    }
                }

                //if found add the qty else add the new item to the list
                if (foundPos != -1)
                {
                    consolidatedList[foundPos].AmountRetrieved += disReq.RetrieveQty;
                }
                else
                {
                    consolidatedList.Add(new ConsolidatedDisbursementItem { Item = disReq.Item, AmountRetrieved = disReq.RetrieveQty });
                }
            }

            return consolidatedList;
        }

        public void DeliverDisbursementItems(List<ConsolidatedDisbursementItem> conDisItemList, DateTime disbursementDate, Department dep, StoreEmployee emp)
        {
            //this method will update disbursement items disbursed qty based on the cosolidated items provided

            foreach (var item in conDisItemList)
            {
                //get the req for the item
                List<DisburseReqItem> disReqItemList = GetDisbursementItems(disbursementDate, dep, item.Item);

                //order the list PARTIAL first then APPROVED which is desc and lowest date first which is ascending
                disReqItemList = disReqItemList.OrderByDescending(x => x.Requisition.Status)
                    .ThenBy(x => x.Requisition.ApproveDate)
                    .ThenBy(x => x.Requisition.SubmitDate).ToList();

                int totalDisburseAmount = item.AmountDisbursed;
                for (int i = 0; i < disReqItemList.Count; i++)
                {
                    //if the total amount is still bigger than the required amount, it will fill fully
                    //otherwise it will fill the ramining amount
                    int disbursedAmount = totalDisburseAmount > disReqItemList[i].RetrieveQty ? disReqItemList[i].RetrieveQty : totalDisburseAmount;
                    int reqId = disReqItemList[i].ReqId;
                    int itemId = disReqItemList[i].ItemId;
                    DisburseReqItem disReqItem = context.DisburseReqItems.FirstOrDefault(x => x.ReqId == reqId && x.ItemId == itemId);

                    //add the disbursed qty
                    disReqItem.DisburseQty = disbursedAmount;

                    //minus the disbursed amount for that item from total disbursed amount
                    totalDisburseAmount -= disbursedAmount;
                }

                if (totalDisburseAmount > 0)
                {
                    //throw exception about disbursing more items than needed
                }

                //auto raise adj voucher if the item disbursed is less then item retrieved
                if (item.AmountDisbursed < item.AmountRetrieved)
                {
                    //auto raise voucher
                }
            }

            //set DELIVERED or PARTIAL based on the items delivered
            List<Requisition> partialList = GetPartialRequsitions(dep);
            List<Requisition> deliveredList = GetDeliveredRequsitions(dep);

            foreach (var item in partialList)
            {
                item.Status = ReqStatus.PARTIAL.ToString();
            }
            foreach (var item in deliveredList)
            {
                item.Status = ReqStatus.DELIVERED.ToString();
            }

            context.SaveChanges();

        }

    }
}