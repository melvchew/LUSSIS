<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Home" %>

<!DOCTYPE html>

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
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/View/Logout.aspx">Log Out</asp:HyperLink>
    </div>
    </form>
</body>
</html>
