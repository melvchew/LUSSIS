<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalogue.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.Catalogue" %>
<%-- Made by Hu Xiaoxi(Team5) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="container-fluid">
<form id="frmCatalogue" runat="server">
    <div>
    
        <asp:Label ID="lablItemCatalog" runat="server" Text="Item Catalogue"></asp:Label>
        <br /><br />

        <asp:TextBox ID="txtBoxSearchItem" runat="server" AutoPostBack="false"
            onfocus="if(this.value=='Please Enter the Item name') this.value=''" 
            onblur="if(this.value=='')this.value='Please Enter the Item name'" Width="336px" 
            onkeyup="this.value = this.value.slice(0, 150)" ForeColor="Gray" >Please Enter the Item name</asp:TextBox>

        <asp:Button ID="btnSearchItem" runat="server" Text="Search" OnClick="btnSearchItem_Click" />

        <br /><br />
        <asp:Label ID="lablCategory" runat="server" Text="Item Category: "></asp:Label>
        <br /><br />

        <asp:DropDownList ID="droplistItemCategory" runat="server" Width="185px" 
            OnSelectedIndexChanged="droplistItemCategory_SelectedIndexChanged" 
            AutoPostBack="true" CausesValidation="false" EnableViewState="true">
        </asp:DropDownList>
        <br /><br />

    </div>
        <asp:GridView ID="gvCatalog" runat="server" AutoGenerateColumns="False" 
            AllowPaging="true" OnPageIndexChanging="gvCatalog_PageIndexChanging" DataKeyNames="ItemId">
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
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllItem" runat="server" AutoPostBack="true" OnCheckedChanged="chkAllItem_CheckedChanged"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAddItem" runat="server" AutoPostBack="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table border="1" id="t01">
                    <tr>
                        <th>Item Name</th>
                        <th>Unit of Measurement</th>
                    </tr>
                    <tr>
                        <td>No Data</td>
                        <td>No Data</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
        <br /><br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </form>
</body>
</html>
