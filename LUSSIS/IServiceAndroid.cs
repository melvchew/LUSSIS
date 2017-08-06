using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace LUSSIS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceAndroid" in both code and config file together.
    [ServiceContract]
    public interface IServiceAndroid
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Pending/{id}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFRequisition> ListPending(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Pending/Requisition/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCFRequisition GetRequisition(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Pending/details/{id}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFRequisitionItem> GetReqItems(string id);

        //[OperationContract]
        //WCFEmployee GetEmployee(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Approve", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        void ApproveReq(WCFRequisition r);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Reject", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        void RejectReq(WCFRequisition r);

        [OperationContract]
        [WebGet(UriTemplate = "/GetCurrentDeptRepresentative/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCFEmployee getCurrentDeptRep(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetCurrentActingHead/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCFEmployee getCurrentActingHead(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Delegate/Rep", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void AppointDeptRep(WCFDepartment d);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Delegate/AH", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void AppointDeptAH(WCFDepartment d);

        [OperationContract]
        [WebGet(UriTemplate = "/Department/{id}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFEmployee> ListEmpByDept(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDepartment/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCFDepartment GetDept(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Employee/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCFEmployee GetEmpById(string id);




    }
    [DataContract]
    public class WCFRequisition
    {
        int ReqId;
        int EmpId;
        string EmpName;
        string SubmitDate;
        int? ApproveBy;
        string ApproveDate;
        string Status;
        string EmpComments;
        string ApproverComments;

        public static WCFRequisition Make(int reqid, int empid, string empname, string submitdate, int? approveby, string approvedate, string status, string empcomments, string approvercomments)
        {
            WCFRequisition r = new WCFRequisition();
            r.ReqId = reqid;
            r.EmpId = empid;
            r.EmpName = empname;
            r.SubmitDate = submitdate;
            r.ApproveBy = approveby;
            r.ApproveDate = approvedate;
            r.Status = status;
            r.EmpComments = empcomments;
            r.ApproverComments = approvercomments;
            return r;

        }
        [DataMember]
        public int reqid
        {
            get { return ReqId; }
            set { ReqId = value; }

        }
        [DataMember]
        public int empid
        {
            get { return EmpId; }
            set { EmpId = value; }

        }
        [DataMember]
        public string empname
        {
            get { return EmpName; }
            set { EmpName = value; }

        }
        [DataMember]
        public string submitdate
        {
            get { return SubmitDate; }
            set { SubmitDate = value; }
        }
        [DataMember]
        public int? approveby
        {
            get { return ApproveBy; }
            set { ApproveBy = value; }
        }

        [DataMember]
        public string approvedate
        {
            get { return ApproveDate; }
            set { ApproveDate = value; }
        }
        [DataMember]
        public string status
        {
            get { return Status; }
            set { Status = value; }
        }
        [DataMember]
        public string empcomments
        {
            get { return EmpComments; }
            set { EmpComments = value; }
        }
        [DataMember]
        public string approvercomments
        {

            get { return ApproverComments; }
            set { ApproverComments = value; }
        }
    }

    public class WCFRequisitionItem
    {
        int ReqId;
        int ItemId;
        string ItemName;
        int Quantity;

        public static WCFRequisitionItem Make(int reqid, int itemid, string itemname, int quantity)
        {
            WCFRequisitionItem item = new WCFRequisitionItem();
            item.ReqId = reqid;
            item.ItemName = itemname;
            item.ItemId = itemid;
            item.Quantity = quantity;
            return item;
        }

        [DataMember]
        public int reqid
        {
            get { return ReqId; }
            set { ReqId = value; }
        }

        [DataMember]
        public int itemid
        {
            get { return ItemId; }
            set { ItemId = value; }
        }

        [DataMember]
        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        [DataMember]
        public string itemname
        {
            get { return ItemName; }
            set { ItemName = value; }
        }
    }

    public class WCFEmployee
    {
        int EmpId;
        string Name;
        string Position;
        string Phone;
        string Email;
        int DeptId;

        public static WCFEmployee Make(int empid, string name, string position, string phone, string email, int deptid)
        {
            WCFEmployee emp = new WCFEmployee();
            emp.EmpId = empid;
            emp.Name = name;
            emp.Position = position;
            emp.Phone = phone;
            emp.Email = email;
            emp.DeptId = deptid;
            return emp;

        }

        [DataMember]
        public int empid
        {
            get { return EmpId; }
            set { EmpId = value; }
        }
        [DataMember]
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        [DataMember]
        public string position
        {
            get { return Position; }
            set { Position = value; }
        }
        [DataMember]
        public string phone
        {
            get { return Phone; }
            set { Phone = value; }
        }

        [DataMember]
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        [DataMember]
        public int deptid
        {
            get { return DeptId; }
            set { DeptId = value; }
        }
    }

    [DataContract]
    public class WCFReqData
    {
        int ReqId;
        int BossId;
        public static WCFReqData Make(int reqid, int bossid)
        {
            WCFReqData item = new WCFReqData();
            item.ReqId = reqid;
            item.BossId = bossid;
            return item;
        }
        [DataMember]
        public int reqid
        {
            get { return ReqId; }
            set { ReqId = value; }
        }
        [DataMember]
        public int bossid
        {
            get { return BossId; }
            set { BossId = value; }
        }
    }

    [DataContract]
    public class WCFDepartment
    {
        int DeptId;
        int Rep;
        int? AH;
        string AHStartDD;
        string AHStartMM;
        string AHStartYY;
        string AHEndDD;
        string AHEndMM;
        string AHEndYY;

        public static WCFDepartment Make(int deptid, int rep, int? ah, string ahstartdd, string ahstartmm, string ahstartyy, string ahenddd, string ahendmm, string ahendyy)
        {
            WCFDepartment wcfd = new WCFDepartment();
            wcfd.DeptId = deptid;
            wcfd.Rep = rep;
            wcfd.AH = ah;
            wcfd.AHStartDD = ahstartdd;
            wcfd.AHStartMM = ahstartmm;
            wcfd.AHStartYY = ahstartyy;
            wcfd.AHEndDD = ahenddd;
            wcfd.AHEndMM = ahendmm;
            wcfd.AHEndYY = ahendyy;
            return wcfd;

        }
        [DataMember]
        public int deptid
        {
            get { return DeptId; }
            set { DeptId = value; }
        }
        [DataMember]
        public int rep
        {
            get { return Rep; }
            set { Rep = value; }
        }
        [DataMember]
        public int? ah
        {
            get { return AH; }
            set { AH = value; }
        }
        [DataMember]
        public string ahstartdd
        {
            get { return AHStartDD; }
            set { AHStartDD = value; }
        }
        [DataMember]
        public string ahstartmm
        {
            get { return AHStartMM; }
            set { AHStartMM = value; }
        }
        [DataMember]
        public string ahstartyy
        {
            get { return AHStartYY; }
            set { AHStartYY = value; }
        }
        [DataMember]
        public string ahenddd
        {
            get { return AHEndDD; }
            set { AHEndDD = value; }
        }
        [DataMember]
        public string ahendmm
        {
            get { return AHEndMM; }
            set { AHEndMM = value; }
        }
        [DataMember]
        public string ahendyy
        {
            get { return AHEndYY; }
            set { AHEndYY = value; }
        }
    }
}
