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
                        AllowPaging="True" OnPageIndexChanging="gvReqHistory_PageIndexChanging" CssClass="table table-bordered table-striped">
                        <Columns>
                            <asp:BoundField HeaderText="Requisition ID" DataField="ReqId" />

                            <asp:BoundField HeaderText="Status" DataField="Status" />
                            <asp:BoundField HeaderText="Requisition Date" DataField="SubmitDate" />
                            <asp:ButtonField Text="details" ButtonType="Link" CommandName="reqDetails" />

                        </Columns>
                        <EmptyDataTemplate>
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
                        </EmptyDataTemplate>
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
