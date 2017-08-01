<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDeptReqHistory.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ViewDeptReqHistory" %>
<%-- Made by Hu Xiaoxi(Team5) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
    
        <asp:Label ID="lablDeptReq" runat="server" Text="Department Requisition History"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LablEmp" runat="server" Text="Employee Name: "></asp:Label>
        <br />
        <asp:DropDownList ID="droplistEmp" runat="server" AutoPostBack="true" 
            CausesValidation="false" EnableViewState="true" 
            OnSelectedIndexChanged="droplistEmp_SelectedIndexChanged">
        </asp:DropDownList>
    
    </div>
        <asp:GridView ID="gvDeptReq" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDeptReq_RowCommand" 
            AllowPaging="true" OnPageIndexChanging="gvDeptReq_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Requisition ID" DataField="ReqId"/>
                <asp:BoundField HeaderText="Employee Name" DataField="Employee.Name"/>
                <asp:BoundField HeaderText="Status" DataField="Status" />
                <asp:BoundField HeaderText="Requisition Date" DataField="SubmitDate" />
                <asp:ButtonField Text="details" ButtonType="Link" CommandName="reqDetails"/>
            </Columns>
                        <EmptyDataTemplate>
                <table border="1" id="t01">
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
    <asp:Button ID="btnBack" runat="server" Text="Back to Home Page" OnClick="btnBack_Click" />
    </form>
</body>
</html>
