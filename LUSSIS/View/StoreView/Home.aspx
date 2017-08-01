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
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/StoreView/Clerk/AddNewSupplier.aspx">Add New Supplier</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/View/StoreView/Clerk/EditSuppliers.aspx">Edit Supplier</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/View/StoreView/Clerk/Inventory Status Report.aspx">Inventory Status Report</asp:HyperLink> <br />
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/View/StoreView/Clerk/RaiseAdjVoucher.aspx">Raise Adj Voucher</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/View/StoreView/Clerk/UploadExcel.aspx">Upload Excel</asp:HyperLink>    <br />
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/View/Logout.aspx">Log Out</asp:HyperLink>
    </div>
    </form>
</body>
</html>
