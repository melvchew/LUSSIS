<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="Home.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" >
        <div class="placeholder">
            <div class="row">
                <h3>Department Home Page</h3>
            </div>
            <span>Logged in user(Session["empId"]) = </span>
            <asp:Literal ID="litEmpId" runat="server"></asp:Literal>
            <br />
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/View/DepartmentView/Head/ViewPendingReq.aspx">View Pending Req</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/View/DepartmentView/Emp/RaiseReq.aspx">Raise Req</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/View/DepartmentView/Emp/ViewDeptReqHistory.aspx">View Dep Req History</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/View/DepartmentView/Emp/ViewUserReqHistory.aspx">View User Req History</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/View/DepartmentView/Rep/ViewCollectionItems.aspx">View Collection Items</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/View/DepartmentView/Rep/ChangeCollectionPoint.aspx">Change Collection Point</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/View/DepartmentView/Head/DelegateRole.aspx">Delegate Roles</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/View/Logout.aspx">Log Out</asp:HyperLink>
        </div>
    </div>
</asp:Content>
