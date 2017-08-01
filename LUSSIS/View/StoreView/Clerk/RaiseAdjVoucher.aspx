<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RaiseAdjVoucher.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.RaiseAdjVoucher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../../content/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="../../../content/bootstrap.min.css" />
</head>

<body>
    <form id="form1" runat="server">

        <!-- <span class="label label-default">Default</span>
<span class="label label-primary">Primary</span>
<span class="label label-success">Success</span>
<span class="label label-info">Info</span>
<span class="label label-danger">Danger</span>
        -->

        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-4"></div>
                    <div class="col-md-8">
                        <h1><span class="label label-warning">Raise Item Voucher</span></h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-9"></div>
                    <div class="col-md-3">
                        <asp:LinkButton ID="AddNewRowLinkBtn" runat="server" OnClick="AddNewRowLinkBtn_Click1" Font-Size="Small">Add New Row</asp:LinkButton></div>
                </div>
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-2">Item Name</div>
                    <div class="col-md-3">Qty Adjusted</div>
                    <div class="col-md-2">Reason</div>
                    <div class="col-md-3">Value</div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ItemsList1" Width="250" CssClass="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList></div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtQtyAdj1" CssClass="form-control" runat="server" AutoPostBack="True" Width="100px"></asp:TextBox></div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtReasons1" CssClass="form-control" runat="server" Width="300px"></asp:TextBox></div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtValue1" CssClass="form-control" runat="server" Width="100px" ReadOnly="true"></asp:TextBox></div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-2">
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-3">
                        <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-3">
                        <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
                </div>
        </asp:PlaceHolder>
        <br />
        <div class="col-md-9"></div>
        <div class="col-md-3">
            <asp:Button ID="Button1" runat="server" Class="btn btn-default" OnClick="Button1_Click" Text="Calc" />
            <asp:Button ID="Submitbtn" runat="server" Class="btn btn-default" Text="Submit" OnClick="Submitbtn_Click" />
            <asp:Button ID="Cancelbtn" runat="server" Class="btn btn-default" Text="Cancel" />
        </div>
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </form>
</body>
</html>