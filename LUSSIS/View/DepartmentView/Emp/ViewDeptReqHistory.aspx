<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDeptReqHistory.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ViewDeptReqHistory" %>
<%-- Made by Hu Xiaoxi(Team5) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="container-fluid">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form id="frmViewDeptReqHistory" runat="server">
                <div>
                    <h1 style="text-align: center">Department Requisition History</h1>
        <br />
        <h4><span class="label label-success">Employee Name: </span></h4>
        <asp:DropDownList ID="droplistEmp" runat="server" AutoPostBack="true" 
            CausesValidation="false" EnableViewState="true" 
            OnSelectedIndexChanged="droplistEmp_SelectedIndexChanged" 
            CssClass="form-control" data-style="btn-inverse" Width="400px">
        </asp:DropDownList><br />
    
    </div>
        <asp:GridView ID="gvDeptReq" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDeptReq_RowCommand" 
            AllowPaging="true" OnPageIndexChanging="gvDeptReq_PageIndexChanging" CssClass="table table-striped">
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
    <asp:Button ID="btnBack" runat="server" Text="Back to Home Page" OnClick="btnBack_Click" CssClass="btn btn-primary pull-right" />
    </form>
         </div>
    </div>
</body>
</html>
