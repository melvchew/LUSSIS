using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
//using Microsoft.Office.Interop.Excel;
//using System.Runtime.InteropServices;

namespace LUSSIS.RawCode.BLL.data.Peter
{
    public class StockManagementBLL //Peter
    {
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
    }
}