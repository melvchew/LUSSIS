<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReqConfirm.aspx.cs" Inherits="LUSSIS.Employee.ViewReqConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmViewReqConfirm" runat="server">
<div>
    
        <asp:Label ID="labl_ViewReq" runat="server" Text="Requisition Details"></asp:Label>
        <br />
        <br />
        <asp:Literal ID="Lite_ReqStatus" runat="server"></asp:Literal>  
        <br />  
                <asp:Literal ID="Lite_ReqId" runat="server"></asp:Literal>  
        <br />  
                <asp:Literal ID="Lite_ReqDate" runat="server"></asp:Literal>  
        <br /> 
     
        <asp:GridView ID="gvDisReqItem" runat="server" Width="454px" AutoGenerateColumns="False">
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
                        <asp:Label ID="Label3" runat="server" Text='<%# GetDisbursedQty((int)Eval("ReqId"), (int)Eval("ItemId")) %>'></asp:Label>
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
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </form>
</body>
</html>
