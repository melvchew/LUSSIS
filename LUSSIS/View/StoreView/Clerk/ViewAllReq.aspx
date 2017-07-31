<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllReq.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.ViewAllReq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
</head>
<body>
    <form id="viewRequisitions" runat="server">
        <div class="row">
            <div class="col-md-5 col-lg-offset-7">
        <h1 class="col-md-8 col-lg-offset-4">View Requisitions</h1>
           <asp:DropDownList ID="DropDownList1" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True">

            <asp:ListItem Text = "All Deparments" Value = "0"></asp:ListItem>
              
            </asp:DropDownList><asp:Button ID="btnFilter" runat="server" Text="Filter By Department" />
         <br />
         <br />
        <asp:Label ID="Label1" runat="server" Text="Showing requisitions from: All Departments"></asp:Label>
         <br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
         <br />
        <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"></asp:GridView>
    </div>
            </div>
    </form>
</body>
</html>
