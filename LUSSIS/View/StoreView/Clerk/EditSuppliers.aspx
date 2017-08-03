<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="EditSuppliers.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.EditSuppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Suppliers List</h3>
                <asp:Label ID="Label9" runat="server" Visible="False" ForeColor="#FF6600"></asp:Label>
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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="6"
                    OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered" OnRowEditing="GridView1_RowEditing">
                    <Columns>
                         <asp:BoundField DataField="SupplierId" ShowHeader="false">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
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
    </div>
</asp:Content>
