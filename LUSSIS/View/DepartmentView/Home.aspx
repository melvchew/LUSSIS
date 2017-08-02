<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="Home.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <link href="../Style/main.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 50px; margin-bottom: 20px">
        <span>Logged in user(Session["empId"]) =</span> <asp:Literal ID="litEmpId" runat="server"></asp:Literal>  <br />
        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/View/DepartmentView/Head/ViewPendingReq.aspx">View Pending Req</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/View/DepartmentView/Emp/RaiseReq.aspx">Raise Req</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/View/DepartmentView/Emp/ViewDeptReqHistory.aspx">View Dep Req History</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/View/DepartmentView/Emp/ViewUserReqHistory.aspx">View User Req History</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/View/DepartmentView/Rep/ViewCollectionItems.aspx">View Collection Items</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/View/DepartmentView/Rep/ChangeCollectionPoint.aspx">Change Collection Point</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/View/DepartmentView/Head/DelegateRole.aspx">Delegate Roles</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/View/Logout.aspx">Log Out</asp:HyperLink>
    </div>
</asp:Content>
