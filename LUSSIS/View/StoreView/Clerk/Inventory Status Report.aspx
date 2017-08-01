<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory Status Report.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.Inventory_Status_Report" %>

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
            <h3 style="text-align: center">Inventory Status Report</h3>
        </div>
        <div class="row" style="margin-bottom: 1em">
            <div class="col-lg-7 col-lg-offset-7">
                <div class="input-group">
                    <span >
                        <asp:Label ID="Label7" runat="server" Visible="False" Cssclass="form-control-static" ForeColor="Lime"></asp:Label>
                    </span>
                    <asp:Button ID="Button1" runat="server" Text="Low Stock Items" OnClick="Button1_Click" CssClass="pull-right btn btn-default" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" AllowPaging="True" CssClass="table table-hover table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="Description">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location">
                            <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("BinNumber") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("BinNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit">
                            <EditItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Unit") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock Balance">
                            <EditItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("StockBalance") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("StockBalance") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reorder Level">
                            <EditItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("ReorderLvl") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("ReorderLvl") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <PagerSettings Mode="NumericFirstLast" />

                    <PagerStyle Font-Size="Larger" Font-Underline="True" HorizontalAlign="Center" VerticalAlign="Middle" />

                </asp:GridView>
              
            </div>
        </div>
    </form>
</body>
</html>
