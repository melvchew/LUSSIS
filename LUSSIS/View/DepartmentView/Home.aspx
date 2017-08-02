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

</asp:Content>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span>Logged in user(Session["empId"]) =</span> <asp:Literal ID="litEmpId" runat="server"></asp:Literal>  <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/DepartmentView/Head/ViewPendingReq.aspx">View Pending Req</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/View/DepartmentView/Emp/RaiseReq.aspx">Raise Req</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/View/DepartmentView/Emp/ViewDeptReqHistory.aspx">View Dep Req History</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/View/DepartmentView/Emp/ViewUserReqHistory.aspx">View User Req History</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/View/DepartmentView/Rep/ViewCollectionItems.aspx">View Collection Items</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/View/DepartmentView/Rep/ChangeCollectionPoint.aspx">Change Collection Point</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/View/DepartmentView/Head/DelegateRole.aspx">Delegate Roles</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/View/Logout.aspx">Log Out</asp:HyperLink>
    </div>
    </form>
</body>
</html>
