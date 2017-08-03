<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="OrderItems.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.OrderItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Add Items To Order List</h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvItems" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvItems_PageIndexChanging" PageSize="8">
                        <Columns>
                            <asp:TemplateField HeaderText="Category">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckbSelect" runat="server" />
                                    <asp:HiddenField ID="hfItemId" runat="server" Value='<%# Bind("ItemId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnAddToOrderList" CssClass="btn" runat="server" OnClick="btnAddToOrderList_Click" Text="Add To Order List" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
