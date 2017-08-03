<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="ViewOrderDetails.aspx.cs" Inherits="LUSSIS.View.StoreView.Manager.ViewOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Purchase Order Details</h3>
            </div>
            <div class="row">
                <div class="col-md-3">
                    PO ID:
                    <asp:Label ID="lblPOId" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-3 pull-right text-right">
                    Order By:
                    <asp:Label ID="lblOrderBy" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    Supplier:
                    <asp:Label ID="lblSupplier" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-3">
                    Status:
                    <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-4 pull-right text-right">
                    Expected Delivery Date:
                    <asp:Label ID="lblExpectedDate" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvOrderDetails" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Item.Description") %>'></asp:Label>
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
                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("Item.Unit") %>'></asp:Label>
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
                <div class="col-md-4 pull-right text-right">
                    Total Amount:
                    <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    Manager Comments:<asp:TextBox CssClass="form-control" ID="txtComments" runat="server"></asp:TextBox>
                    <asp:Label ID="lblComments" runat="server"></asp:Label>
                </div>
                <div class="col-md-4 pull-right text-right">
                    <asp:Button ID="btnReject" runat="server" CssClass="btn" Text="Reject" OnClick="btnReject_Click" />
                    <asp:Button ID="btnApprove" runat="server" CssClass="btn" Text="Approve" OnClick="btnApprove_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
