<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllReq.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.ViewAllReq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Content/bootstrap-theme.min.css" />
</head>
<body>
    <form id="viewRequisitions" runat="server">
        <div class="row">
            <div class="col-md-9 col-lg-offset-3">
                <h1 class="col-md-10 col-lg-offset-2">View Requisitions</h1>
                
                <asp:DropDownList ID="DropDownList1" CssClass="col-lg-offset-3" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">

                    <asp:ListItem Text="All Departments" Value="0"></asp:ListItem>

                </asp:DropDownList>
                <%--<asp:Button ID="btnFilter" CssClass="btn" runat="server" Text="Filter By Department" />--%>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Showing requisitions from: All Departments" CssClass="col-md-4 col-lg-offset-2"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red" CssClass="col-md-2 col-lg-offset-3"></asp:Label>
                <br />
            </div>
            <div class="row">
                <div class="col-lg-10 col-lg-offset-1">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover"></asp:GridView>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
    </form>
</body>
</html>
