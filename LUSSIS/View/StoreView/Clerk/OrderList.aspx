<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="OrderList.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Content/themes/base/jquery-ui.min.css" />
    <script src="../../../Scripts/jquery-ui-1.12.1.min.js"></script>
    <script>
  $( function() {
      $(".datepicker").datepicker({ minDate: 0, maxDate: "+1M +10D", dateFormat: 'dd-mm-yy' });
  } );
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>OrderList</h3>
            </div>
            <div class="row">
                <div class="col-md-2 col-md-offset-7">
                    <label class="pull-right">Expected Delivery Date: </label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtExpectedDate" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtExpectedDate" ErrorMessage="Please choose expected date." ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvOrderList" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# GetItem((int)Eval("PurchaseOrderItem.ItemId")).Description %>'></asp:Label>
                                    <asp:HiddenField ID="hfItemId" runat="server" Value='<%# Bind("PurchaseOrderItem.ItemId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="1st Supplier">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbtnSupplier1" GroupName="Suppliers" runat="server" Text='<%# $"{GetSupplierName(Convert.ToInt32(Eval("PurchaseOrderItem.ItemId")), 0)} - ${GetItem((int)Eval("PurchaseOrderItem.ItemId")).Supplier1Price}" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2nd Supplier">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbtnSupplier2" GroupName="Suppliers" runat="server" Text='<%# $"{GetSupplierName(Convert.ToInt32(Eval("PurchaseOrderItem.ItemId")), 1)} - ${GetItem((int)Eval("PurchaseOrderItem.ItemId")).Supplier2Price}" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="3rd Supplier">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbtnSupplier3" GroupName="Suppliers" runat="server" Text='<%# $"{GetSupplierName(Convert.ToInt32(Eval("PurchaseOrderItem.ItemId")), 2)} - ${GetItem((int)Eval("PurchaseOrderItem.ItemId")).Supplier3Price}" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" Text='<%# Bind("PurchaseOrderItem.OrderQty") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnit" runat="server" Text='<%# GetItem((int)Eval("PurchaseOrderItem.ItemId")).Unit %>'></asp:Label>
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
                    <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnAddItem" CssClass="btn" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
                </div>
                <div class="col-md-2 pull-right">
                    <asp:Button ID="btnUpdate" CssClass="btn" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnOrder" CssClass="btn" runat="server" Text="Order" OnClick="btnOrder_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
