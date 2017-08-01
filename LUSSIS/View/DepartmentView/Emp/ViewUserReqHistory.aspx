<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUserReqHistory.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ViewUserReqHistory" %>
<%-- Made by Hu Xiaoxi(Team5) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="frmViewUserReqHistory" runat="server">
<div>
    
        <asp:Label ID="labl_ReqHistory" runat="server" Text="Personal Requisition History"></asp:Label>
    
    </div>
        <br /><br />

        <asp:GridView ID="gvReqHistory" runat="server" AutoGenerateColumns="False" OnRowCommand="gvReqHistory_RowCommand" 
            AllowPaging="True" OnPageIndexChanging="gvReqHistory_PageIndexChanging">
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
    <asp:Button ID="btnBack" runat="server" Text="Back to Home Page" OnClick="btnBack_Click" />
    </form>
</body>
</html>
