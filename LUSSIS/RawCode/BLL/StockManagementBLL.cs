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

        //delete supplier
        public void DeleteSupplier(string id)
        {
            try
            {
                using (context = new LUSSdb())
                {
                    Supplier supplier = context.Suppliers.Where(s => s.SupplierId == id).First<Supplier>();
                    context.Suppliers.Remove(supplier);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
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

    }
}