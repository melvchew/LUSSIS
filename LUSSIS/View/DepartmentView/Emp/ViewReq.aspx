<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ViewReq.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ViewReq" %>

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
                    <asp:GridView ID="gvDisReqItem" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                        <Columns>
                            <asp:TemplateField HeaderText="Item Discription">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Item.Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Deliveried">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="--"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table border="1" id="t01">
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
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
