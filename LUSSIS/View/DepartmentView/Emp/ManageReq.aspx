<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ManageReq.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ManageReq" %>

<%-- Made by Hu Xiaoxi(Team5) --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Requisition Details</h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <p>
                        <asp:Literal ID="Lite_ReqStatus" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="Lite_ReqId" runat="server"></asp:Literal>
                    </p>
                    <p>
                        <asp:Literal ID="Lite_ReqDate" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvReqItem" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId"
                        OnRowEditing="gvReqItem_RowEditing"
                        OnRowCancelingEdit="gvReqItem_RowCancelingEdit"
                        OnRowUpdating="gvReqItem_RowUpdating" EnableViewState="true"
                        AllowPaging="true" OnPageIndexChanging="gvReqItem_PageIndexChanging" CssClass="table table-bordered">
                        <Columns>


                            <asp:TemplateField HeaderText="Item Description">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Item.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quantity">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="AllItems" runat="server" AutoPostBack="True" OnCheckedChanged="AllItems_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ItemSelector" runat="server" AutoPostBack="True" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:CommandField ShowEditButton="True" CausesValidation="false" />
                        </Columns>

                        <EmptyDataTemplate>
                            <tr>
                                <th>Item Discription</th>
                                <th>Quantity</th>
                                <th>Deliveried</th>
                            </tr>
                            <tr>
                                <td>empty</td>
                                <td>empty</td>
                                <td>empty</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btn_Add" runat="server" Text="Add Items" OnClick="btn_Add_Click" CssClass="btn" />

                    <asp:Button ID="btn_Remov" runat="server" Text="Remove Items"
                        OnClientClick="return confirm('Are you sure to remove the requisition items?')"
                        OnClick="btn_Remov_Click" CssClass="btn" />
                </div>
                <div class="col-md-8">
                    <asp:Button ID="btn_CancelReq" runat="server" Text="Cancel Requisition"
                        OnClick="btn_CancelReq_Click"
                        OnClientClick="return confirm('Are you sure to cancel the requisition?')" CssClass="btn pull-right" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
