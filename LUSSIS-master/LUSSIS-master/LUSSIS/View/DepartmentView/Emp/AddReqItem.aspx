<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReqItem.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.AddReqItem" %>
<%-- Made by Hu Xiaoxi(Team5) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="frmAddReqItem" runat="server">
    <div>
    
        <asp:Label ID="lablAddReqItem" runat="server" Text="Add Requisition Items"></asp:Label>
        <br /><br />
    
    </div>
        <asp:GridView ID="gvAddReqItems" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId" >
            <Columns>
                <asp:TemplateField HeaderText="Item Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit of Measurement">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Unit") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text="1" TextMode="Number" 
                            onkeyup="this.value = this.value.slice(0, 6)" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqfieldValidQty" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator" 
                            ForeColor="Red">Quantity is required!</asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btdAddItem" runat="server" Text="Add Items" OnClick="btdAddItem_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </form>
</body>
</html>
