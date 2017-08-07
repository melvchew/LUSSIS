using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace LUSSIS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetConNeededItems", ResponseFormat = WebMessageFormat.Json)]
        WCF_ConsolidatedRetrieveItem[] GetRetrieveItems();
        [OperationContract]
        [WebGet(UriTemplate = "/GetConNeededItems/{disDate}", ResponseFormat = WebMessageFormat.Json)]
        WCF_ConsolidatedRetrieveItem[] GetRetrievedItems(String disDate);

        [WebGet(UriTemplate = "/IsDisbursementPresent/{disDate}", ResponseFormat = WebMessageFormat.Json)]
        WCF_IsPresent IsDisbursementPresent(String disDate);

        [OperationContract]
        [WebGet(UriTemplate = "/GetNeededItem/{itemId}", ResponseFormat = WebMessageFormat.Json)]
        WCF_RetrieveItemByDep[] GetRetrieveItemByDep(string itemId);

        [OperationContract]
        [WebGet(UriTemplate = "/DeleteDisbursementList/{disDate}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteDisbursementList(string disDate);

        [OperationContract]
        [WebInvoke(UriTemplate = "/RetrieveItems/{storeEmpId}/{disDate}", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        void RetrieveItems(List<WCF_RetrievedItemData> items, string storeEmpId, string disDate);

        [OperationContract]
        [WebGet(UriTemplate = "/getDisDates", ResponseFormat = WebMessageFormat.Json)]
        WCF_DisbursementDate[] GetDisDates();

        [OperationContract]
        [WebGet(UriTemplate = "/getDisDepartments/{disDate}", ResponseFormat = WebMessageFormat.Json)]
        WCF_DisbursementDepartment[] GetDisDepartments(string disDate);

        [OperationContract]
        [WebGet(UriTemplate = "/getDisItems/{disDate}/{depId}", ResponseFormat = WebMessageFormat.Json)]
        WCF_DisbursementItemData[] GetDisItems(string disDate, string depId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/DisburseItems/{storeEmpId}/{disDate}/{deptId}", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        void DisburseItems(List<WCF_DisbursementItemData> items, string storeEmpId, string disDate, string deptId);
    }

    [DataContract]
    public class WCF_ConsolidatedRetrieveItem
    {
        [DataMember]
        public int ItemId;

        [DataMember]
        public string Description;

        [DataMember]
        public string BinNo;

        [DataMember]
        public int NeededQty;

        [DataMember]
        public int RetrievedQty;

        public WCF_ConsolidatedRetrieveItem(int itemId, string description, string binNo, int neededQty, int retrievedQty)
        {
            this.ItemId = itemId;
            this.Description = description;
            this.BinNo = binNo;
            this.NeededQty = neededQty;
            this.RetrievedQty = retrievedQty;
        }
    }
    [DataContract]
    public class WCF_RetrieveItemByDep
    {
        [DataMember]
        public int DepId;

        [DataMember]
        public string DepName;

        [DataMember]
        public int NeededQty;

        [DataMember]
        public int IOUQty;

        [DataMember]
        public int RetrievedQty;

        public WCF_RetrieveItemByDep(int depId, string depName, int neededQty, int iouQty, int retrievedQty)
        {
            this.DepId = depId;
            this.DepName = depName;
            this.IOUQty = iouQty;
            this.NeededQty = neededQty;
            this.RetrievedQty = retrievedQty;
        }
    }

    [DataContract]
    public class WCF_RetrievedItemData
    {
        [DataMember]
        public int ItemId { get; set; }
        [DataMember]
        public int DepId { get; set; }
        [DataMember]
        public int RetrievedQty { get; set; }

        public WCF_RetrievedItemData(int itemId, int depId, int retrievedQty)
        {
            this.ItemId = itemId;
            this.DepId = depId;
            this.RetrievedQty = retrievedQty;
        }
    }

    [DataContract]
    public class WCF_DisbursementDate
    {
        [DataMember]
        public string DisDate { get; set; }

        public WCF_DisbursementDate(string disDate)
        {
            this.DisDate = disDate;
        }
    }

    [DataContract]
    public class WCF_DisbursementDepartment
    {
        [DataMember]
        public string DeptId { get; set; }
        [DataMember]
        public string DeptName { get; set; }
        [DataMember]
        public string CollectionPointName { get; set; }


        public WCF_DisbursementDepartment(string deptId, string deptName, string collectionPointName)
        {
            this.DeptId = deptId;
            this.DeptName = deptName;
            this.CollectionPointName = collectionPointName;
        }
    }

    [DataContract]
    public class WCF_DisbursementItemData
    {
        [DataMember]
        public int ItemId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int RetrievedQty { get; set; }
        [DataMember]
        public int DeliverQty { get; set; }

        public WCF_DisbursementItemData(int itemId, string desc, int retrievedQty, int deliverQty)
        {
            this.ItemId = itemId;
            this.Description = desc;
            this.RetrievedQty = retrievedQty;
            this.DeliverQty = deliverQty;
        }
    }

    [DataContract]
    public class WCF_IsPresent
    {
        [DataMember]
        public bool IsPresent { get; set; }

        public WCF_IsPresent(bool isPresent)
        {
            this.IsPresent = isPresent;
        }
    }
}
