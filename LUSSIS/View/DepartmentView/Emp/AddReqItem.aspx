<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="AddReqItem.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.AddReqItem" %>

<%-- Made by Hu Xiaoxi(Team5) --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Add Requisition Items</h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvAddReqItems" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId" CssClass="table table-bordered">
                        <Columns>
                            <asp:TemplateField HeaderText="Item Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit of Measurement">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Unit") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text="1" TextMode="Number"
                                        onkeyup="this.value = this.value.slice(0, 6)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqfieldValidQty" runat="server"
                                        ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator"
                                        ForeColor="Red">Quantity is required!</asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="btdAddItem" runat="server" Text="Add Items" OnClick="btdAddItem_Click" CssClass="btn pull-right" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn pull-left" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
