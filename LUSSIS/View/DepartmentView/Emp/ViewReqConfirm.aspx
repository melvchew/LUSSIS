<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReqConfirm.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ViewReqConfirm" %>
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
            <form id="frmViewReqConfirm" runat="server">
                <div>
                    <h1 style="text-align: center">Requisition Details</h1>
        <br />
        <br />
        <asp:Literal ID="Lite_ReqStatus" runat="server"></asp:Literal>  
        <br />  
                <asp:Literal ID="Lite_ReqId" runat="server"></asp:Literal>  
        <br />  
                <asp:Literal ID="Lite_ReqDate" runat="server"></asp:Literal>  
        <br /> 
     
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
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-primary pull-right" />
    </form>
        </div>
    </div>
</body>
</html>
