<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSuppliers.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.UpdateSuppliers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Content/bootstrap-theme.min.css" />
    <title></title>
</head>
<body class="container-fluid">
    <form id="form1" runat="server">
        <div class="container-fluid">
            <h3 style="text-align: center">Edit Suppliers List</h3>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="12"
                    OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" CssClass="table table-hover table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="SupplierId">
                            <EditItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("SupplierId") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("SupplierId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="Textbox7" runat="server" Text='<%# Eval("CompanyName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact Person">
                            <EditItemTemplate>
                                <asp:TextBox ID="Textbox6" runat="server" Text='<%# Eval("ContactPerson") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("ContactPerson") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone No">
                            <EditItemTemplate>
                                <asp:TextBox ID="Textbox5" runat="server" Text='<%# Eval("Phone") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fax No">
                            <EditItemTemplate>
                                <asp:TextBox ID="Textbox4" runat="server" Text='<%# Eval("Fax") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Fax") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <EditItemTemplate>
                                <asp:TextBox ID="Textbox3" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="Textbox2" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gst No ">
                            <EditItemTemplate>
                                <asp:TextBox ID="Textbox1" runat="server" Text='<%# Eval("GstNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("GstNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
