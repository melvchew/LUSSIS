<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="OrderForms.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.OrderForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Purchase Order Forms</h3>
            </div>
            <div class="row">
                <div class="col-md-10">
                    <asp:Label ID="lblConfirmMsg" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnConfirm" CssClass="btn pull-right" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
                </div>
            </div>

            <asp:Repeater ID="repPurchaseOrderForm" runat="server" OnItemDataBound="repPurchaseOrderForm_ItemDataBound">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                    <div class="row" style="border-bottom: 1px #ddd solid">
                        <div class="row">
                            <div class="col-md-6">
                                <span>PO Number: <%# Eval("POId").ToString() == "0" ? "-" : Eval("POId") %></span>
                            </div>
                            <div class="col-md-6" style="text-align:right;">
                                <span>Order By: <%# Eval("OrderStoreEmployee.Name") %></span>
                            </div>
                            <div class="col-md-6">
                                <span>Supplier: <%# GetSupplier(Eval("SupplierId").ToString()).CompanyName %></span>
                            </div>
                            <div class="col-md-6" style="text-align:right;">
                                <span>Expected Delivery Date: <%# $"{Eval("ExpectedDate"):dd/MM/yyyy}" %></span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvPurchaseOrders" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataSource='<%# Eval("PurchaseOrderItems") %>'>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%# GetItem((int)Eval("ItemId")).Description %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# "$" + GetItemPrice((int)Eval("ItemId"), Eval("PurchaseOrder.SupplierId").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnit" runat="server" Text='<%# GetItem((int)Eval("ItemId")).Unit %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# GetItemPrice((int)Eval("ItemId"), Eval("PurchaseOrder.SupplierId").ToString()) * (int)Eval("OrderQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 col-md-offset-9">
                                Total Amount:
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
