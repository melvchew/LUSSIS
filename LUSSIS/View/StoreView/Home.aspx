<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LUSSIS.View.StoreView.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span>Logged in user(Session["storeEmpId"]) = </span> <asp:Literal ID="litEmpId" runat="server"></asp:Literal>  <br />
        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/View/StoreView/Clerk/ViewAllReq.aspx">View Requisitions</asp:HyperLink>    <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/StoreView/Clerk/AddNewSupplier.aspx">Add New Supplier</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/View/StoreView/Clerk/EditSuppliers.aspx">Edit Supplier</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/View/StoreView/Clerk/Inventory Status Report.aspx">Inventory Status Report</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/View/StoreView/Clerk/RaiseAdjVoucher.aspx">Raise Adj Voucher</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/View/StoreView/Clerk/UploadExcel.aspx">Upload Excel</asp:HyperLink>    <br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/View/StoreView/Clerk/TrendAnalysis.aspx">Generate Trend Analysis</asp:HyperLink>    <br />
        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/View/StoreView/Manager/AdjVoucher.aspx">View pending adj voucher (Manager)</asp:HyperLink>    <br />
        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/View/StoreView/Supervisor/AdjVoucherBelow250.aspx">View pending adj voucher (Supervisor)</asp:HyperLink>    <br />
        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/View/StoreView/Supervisor/ManageCollectionPoint.aspx">Manage collection points</asp:HyperLink>    <br />
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/View/Logout.aspx">Log Out</asp:HyperLink>
    </div>
    </form>
</body>
</html>
