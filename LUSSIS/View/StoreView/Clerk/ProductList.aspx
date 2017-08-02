<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <div class="col-sm-12">
                    <h3>Product List</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    <asp:Button ID="Button1" CssClass="btn pull-left" runat="server" Text="Add New Product" OnClick="Button1_Click" />
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="Button2" CssClass="btn pull-right" runat="server" Text="Import" />
                </div>
                <div class="col-sm-6">
                    <div class="input-group">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search By Name or Category"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnSearch" CssClass="btn pull-right" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </span>
                    </div>
                    <!-- /input-group -->
                </div>
            </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="gvProductList" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowEditing="gvProductList_RowEditing" AllowPaging="True" OnPageIndexChanging="gvProductList_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="ItemId" ShowHeader="false">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Category" HeaderText="Category" />
                        <asp:BoundField DataField="BinNumber" HeaderText="Bin Number" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="ReorderLvl" HeaderText="Reorder Level" />
                        <asp:BoundField DataField="ReorderQty" HeaderText="Reorder Qty" />
                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                        <asp:TemplateField HeaderText="Is Cataloged">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" Checked='<%# Eval("IsCataloged") %>' Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="true" ButtonType="Link" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        </div>
    </div>
    <!-- Containter End -->
</asp:Content>


