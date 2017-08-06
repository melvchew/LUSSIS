<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="RaiseReq.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.RaiseReq" %>

<%-- Made by Hu Xiaoxi(Team5) --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Raise New Requisition</h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvNewReqItem" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId" CssClass="table table-bordered table-striped" PageSize="8">
                        <Columns>
                            <asp:TemplateField HeaderText="Item Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit of Measurement">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBoxQty" runat="server" Text="1" TextMode="Number"
                                        onkeyup="this.value = this.value.slice(0, 6)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqfieldValidQty" runat="server"
                                        ControlToValidate="txtBoxQty" ErrorMessage="RequiredFieldValidator"
                                        ForeColor="Red">Quantity is required!</asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAllItem" runat="server" AutoPostBack="true" OnCheckedChanged="chkAllItem_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkNewItem" runat="server" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="table table-bordered table-striped"  id="t01">
                                <tr>
                                    <th>Item Description</th>
                                    <th>Quantity</th>
                                    <th>Delivered</th>
                                </tr>
                                <tr>
                                    <td>empty</td>
                                    <td>empty</td>
                                    <td>empty</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle Font-Size="Larger" Font-Underline="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnAddNewItem" runat="server" Text="Add Items" OnClick="btnAddNewItem_Click" CssClass="btn" />
                    <asp:Button ID="btnRemove" runat="server" Text="Remove Items" OnClick="btnRemove_Click" CssClass="btn" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lablComment" runat="server" Text="Comments: "></asp:Label>
                    <asp:TextBox ID="txtBoxComment" runat="server" CssClass="form-control" TextMode="multiline" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn" />
                </div>
            </div>

        </div>
        </div>
</asp:Content>
