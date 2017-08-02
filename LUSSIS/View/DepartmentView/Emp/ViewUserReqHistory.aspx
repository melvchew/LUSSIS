<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUserReqHistory.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ViewUserReqHistory" %>
<%-- Made by Hu Xiaoxi(Team5) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../../Content/bootstrap.min.css" rel="stylesheet" />

    <style type="text/css">
#t01 {
     font-family:"Trebuchet MS", Arial, Helvetica, sans-serif;
     width:100%;
     border-collapse:collapse;
}
#t01 td,th{
      font-size:1em;
      border:1px solid #808080;
      padding:3px 7px 2px 7px;
}
#t01 td{color:lightgray;}
</style>

</head>
<body class="container-fluid">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form id="frmViewUserReqHistory" runat="server">
                <div>
            <h1 style="text-align: center">Personal Requisition History</h1>
        <br />
                </div>
        <br /><br />

        <asp:GridView ID="gvReqHistory" runat="server" AutoGenerateColumns="False" OnRowCommand="gvReqHistory_RowCommand" 
            AllowPaging="True" OnPageIndexChanging="gvReqHistory_PageIndexChanging" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField HeaderText="Requisition ID" DataField="ReqId" />
                                      
                <asp:BoundField HeaderText="Status" DataField="Status" />
                <asp:BoundField HeaderText="Requisition Date" DataField="SubmitDate" />
                <asp:ButtonField Text="details" ButtonType="Link" CommandName="reqDetails"/>

            </Columns>
            <EmptyDataTemplate>
                <table border="1" id="t01">
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
        </asp:GridView>
    <asp:Button ID="btnBack" runat="server" Text="Back to Home Page" OnClick="btnBack_Click" CssClass="btn btn-primary pull-right"/>
    </form>
        </div>
    </div>

</body>
</html>
