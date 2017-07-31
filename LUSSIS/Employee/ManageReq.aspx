<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageReq.aspx.cs" Inherits="LUSSIS.Employee.ManageReq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmManageReq" runat="server">
<div>
    
        <asp:Label ID="labl_ManageReq" runat="server" Text="Requisition Details"></asp:Label>
        <br /><br />     
        <asp:Literal ID="Lite_ReqStatus" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="Lite_ReqId" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="Lite_ReqDate" runat="server"></asp:Literal>
        <br /><br />


    </div>
        <asp:GridView ID="gvReqItem" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId" 
            OnRowEditing="gvReqItem_RowEditing" 
            OnRowCancelingEdit="gvReqItem_RowCancelingEdit" 
            OnRowUpdating="gvReqItem_RowUpdating" EnableViewState="true" 
            AllowPaging="true" OnPageIndexChanging="gvReqItem_PageIndexChanging">
            <Columns>


                <asp:TemplateField HeaderText="Item Description">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Item.Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
 
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="AllItems" runat="server" AutoPostBack="True" OnCheckedChanged="AllItems_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="ItemSelector" runat="server" AutoPostBack="True" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="True" CausesValidation="false"/>
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

        <asp:Button ID="btn_Add" runat="server" Text="Add Items" OnClick="btn_Add_Click" />

        <asp:Button ID="btn_Remov" runat="server" Text="Remove Items" 
          OnClientClick="return confirm('Are you sure to remove the requisition items?')"  
            OnClick="btn_Remov_Click" />

        <asp:Button ID="btn_CancelReq" runat="server" Text="Cancel Requisition" 
            OnClick="btn_CancelReq_Click" 
            OnClientClick="return confirm('Are you sure to cancel the requisition?')"/>
        <br /><br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </form>
</body>
</html>
