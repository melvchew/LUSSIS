<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ViewUserReqHistory.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ViewUserReqHistory" %>

<%-- Made by Hu Xiaoxi(Team5) --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Personal Requisition History</h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvReqHistory" runat="server" AutoGenerateColumns="False" OnRowCommand="gvReqHistory_RowCommand"
                        AllowPaging="True" OnPageIndexChanging="gvReqHistory_PageIndexChanging" CssClass="table table-bordered table-striped" PageSize="8">
                        <Columns>
                            <asp:BoundField HeaderText="Requisition ID" DataField="ReqId" />

                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# ChangeStatus((string)Eval("Status")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Requisition Date" DataField="SubmitDate" DataFormatString="{0:d}" />
                            <asp:ButtonField Text="details" ButtonType="Link" CommandName="reqDetails" />

                        </Columns>
                        <EmptyDataTemplate>
                            <table class="table table-bordered table-striped" id="t01">
                                <tr>
                                    <th>Requisition ID</th>
                                    <th>Status</th>
                                    <th>Requisition Date</th>
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
                <div class="col-md-2">
                    <asp:Button ID="btnBack" runat="server" Text="Back to Home Page" OnClick="btnBack_Click" CssClass="btn" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
