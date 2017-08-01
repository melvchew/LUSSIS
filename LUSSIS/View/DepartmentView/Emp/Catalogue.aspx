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
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form id="frmCatalogue" runat="server">
    <div>
        <h1 style="text-align: center">Item Catalogue</h1>

        <asp:TextBox ID="txtBoxSearchItem" runat="server" AutoPostBack="false"
            onfocus="if(this.value=='Please Enter the Item name') this.value=''" 
            onblur="if(this.value=='')this.value='Please Enter the Item name'" Width="336px" 
            onkeyup="this.value = this.value.slice(0, 150)" ForeColor="Gray" >Please Enter the Item name</asp:TextBox>

        <asp:Button ID="btnSearchItem" runat="server" Text="Search" OnClick="btnSearchItem_Click" CssClass="btn glyphicon-search" />

        <h4><span class="label label-primary">Item Category: </span></h4>
        <asp:DropDownList ID="droplistItemCategory" runat="server" Width="185px" 
            OnSelectedIndexChanged="droplistItemCategory_SelectedIndexChanged" 
            AutoPostBack="true" CausesValidation="false" EnableViewState="true" 
            CssClass="form-control" data-style="btn-inverse">
        </asp:DropDownList><br />

    </div>
        <asp:GridView ID="gvCatalog" runat="server" AutoGenerateColumns="False" 
            AllowPaging="true" OnPageIndexChanging="gvCatalog_PageIndexChanging" DataKeyNames="ItemId" CssClass="table table-striped">
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
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-success" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger" />
    </form>
        </div>
    </div>

</body>
</html>
