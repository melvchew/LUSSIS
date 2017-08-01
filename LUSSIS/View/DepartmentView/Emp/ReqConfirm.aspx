<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReqConfirm.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ReqConfirm" %>
<%-- Made by Hu Xiaoxi(Team5) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<form id="frmReqComfirm" runat="server">
    <div>
    
        <asp:Literal ID="litaConfirm" runat="server"></asp:Literal>
        <br />
        <br />
    
    </div>
        <asp:Label ID="lablConfirm" runat="server" Text="Your department head will be notified via email of your requisition."></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnHome" runat="server" Text="Return to Home Page" OnClick="btnHome_Click" />

    </form>
</body>
</html>
