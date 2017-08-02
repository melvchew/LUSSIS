﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReqItem.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.AddReqItem" %>
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
                <form id="frmAddReqItem" runat="server">
    <div>
    

        <h1 style="text-align: center">Add Requisition Items</h1>
        <br />
    
    </div>
        <asp:GridView ID="gvAddReqItems" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId" CssClass="table table-bordered" >
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
        <asp:Button ID="btdAddItem" runat="server" Text="Add Items" OnClick="btdAddItem_Click" CssClass="btn btn-success pull-right" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger col-lg-offset-10" />
    </form>
        </div>
    </div>
</body>
</html>
