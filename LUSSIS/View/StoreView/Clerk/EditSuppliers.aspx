<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="EditSuppliers.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.EditSuppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Content/bootstrap.min.css" />
    <script src="../../../Scripts/bootstrap.min.js"></script>
    <script src="../../../Scripts/jquery-1.9.1.min.js"></script>
    <link href="../../../Style/main.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top: 50px; margin-bottom: 20px">

        <div class="row">
            <div class="col-lg-12 text-center">
                <h3>Suppliers List</h3>
                <asp:Label ID="Label9" runat="server" Visible="False" ForeColor="#FF6600"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6 col-lg-offset-6">
                <div class="input-group">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Company name"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="pull-right btn btn-default" />
                    </span>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="8"
                    OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-hover table-bordered" OnRowEditing="GridView1_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="SupplierId" HeaderText="Supplier Id" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                        <asp:BoundField DataField="ContactPerson" HeaderText="	Contact Person" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone No" />
                        <asp:BoundField DataField="Fax" HeaderText="Fax" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="GstNo" HeaderText="GstNo" />
                        <asp:CommandField ShowEditButton="true" ButtonType="Link" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
