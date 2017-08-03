<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ViewDeptReqHistory.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ViewDeptReqHistory" %>

<%-- Made by Hu Xiaoxi(Team5) --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Department Requisition History</h3>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="input-group">
                        <span class="input-group-addon" id="basic-addon1">Employee Name</span>
                        <asp:DropDownList ID="droplistEmp" runat="server" AutoPostBack="true"
                            CausesValidation="false" EnableViewState="true"
                            OnSelectedIndexChanged="droplistEmp_SelectedIndexChanged"
                            CssClass="form-control" data-style="btn-inverse">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvDeptReq" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDeptReq_RowCommand"
                        AllowPaging="true" OnPageIndexChanging="gvDeptReq_PageIndexChanging" CssClass="table table-bordered table-striped">
                        <Columns>
                            <asp:BoundField HeaderText="Requisition ID" DataField="ReqId" />
                            <asp:BoundField HeaderText="Employee Name" DataField="Employee.Name" />
                            <asp:BoundField HeaderText="Status" DataField="Status" />
                            <asp:BoundField HeaderText="Requisition Date" DataField="SubmitDate" DataFormatString="{0:d}"/>
                            <asp:ButtonField Text="details" ButtonType="Link" CommandName="reqDetails" />
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="table table-bordered table-striped" id="t01">
                                <tr>
                                    <th>Requisition ID</th>
                                    <th>Employee Name</th>
                                    <th>Status</th>
                                    <th>Requisition Date</th>
                                </tr>
                                <tr>
                                    <td>No data</td>
                                    <td>No data</td>
                                    <td>No data</td>
                                    <td>No data</td>
                                </tr>
                                </table>
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

