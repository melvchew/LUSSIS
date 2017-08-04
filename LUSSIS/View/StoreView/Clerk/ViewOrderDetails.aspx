<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ViewOrderDetails.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.ViewOrderDetails" %>

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
                    <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
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
                <div class="col-md-3"><a href="#">Download PO Form (pdf)</a></div>
                <div class="col-md-3"><a class="btn" href="#">Send E-mail to Supplier</a></div>
                <div class="col-md-4 pull-right text-right">
                    Total Amount:
                    <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <asp:Label ID="lblComments" runat="server"></asp:Label>
                </div>
                <div class="col-md-2 pull-right text-right">
                    <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
            </div>
            <asp:Panel ID="pnlDelivery" runat="server">
                <div class="row">
                    <h3>Delivery Details</h3>
                </div>
                <div class="row">
                    <div class="col-md-5 pull-right text-right">
                        <asp:TextBox ID="txtRecievedDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox><br />
                        <asp:Label ID="lblRecievedDate" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvDeliveryDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                            <Columns>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Item.Description") %>'></asp:Label>
                                        <asp:HiddenField ID="hfItemId" runat="server" Value='<%# Eval("ItemId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expected Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpectedQty" runat="server" Text='<%# Eval("OrderQty") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recieved Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecievedQty" runat="server" Text='<%# Eval("DeliverQty") %>'></asp:Label>
                                        <asp:TextBox ID="txtRecievedQty" CssClass="form-control" runat="server" Text="0"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("Item.Unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>
                                        <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 pull-right text-right"><asp:Button ID="btnRecieve" CssClass="btn" runat="server" Text="Recieve" OnClick="btnRecieve_Click" /></div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
