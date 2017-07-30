<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RaiseReq.aspx.cs" Inherits="LUSSIS.Employee.RaiseReq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmRaiseReq" runat="server">
<div>
    
        <asp:Label ID="labl_NewReq" runat="server" Text="Raise New Requisition"></asp:Label>
                        <br /><br />    
    </div>
        <asp:GridView ID="gvNewReqItem" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId" >
            <Columns>
                <asp:TemplateField HeaderText="Item Name">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate> 

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit of Measurement">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtBoxQty" runat="server" Text="1" TextMode="Number" 
                            onkeyup="this.value = this.value.slice(0, 6)" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqfieldValidQty" runat="server" 
                            ControlToValidate="txtBoxQty" ErrorMessage="RequiredFieldValidator" 
                            ForeColor="Red">Quantity is required!</asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllItem" runat="server" AutoPostBack="true" OnCheckedChanged="chkAllItem_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkNewItem" runat="server" AutoPostBack="true" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table border="1" id="t01">
                    <tr>
                        <th>Item Name</th>
                        <th>Unit of Measurement</th>
                        <th>Quantity</th>
                    </tr>
                    <tr>
                        <td>empty</td>
                        <td>empty</td>
                        <td>empty</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
        <br />
        <asp:Button ID="btnAddNewItem" runat="server" Text="Add Items" OnClick="btnAddNewItem_Click" />
        <asp:Button ID="btnRemove" runat="server" Text="Remove Items" OnClick="btnRemove_Click" />
        <p>
            <asp:Label ID="lablComment" runat="server" Text="Comments: "></asp:Label>
            <asp:TextBox ID="txtBoxComment" runat="server" Height="16px" Width="316px" TextMode="multiline" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
        </p>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </form>
</body>
</html>
