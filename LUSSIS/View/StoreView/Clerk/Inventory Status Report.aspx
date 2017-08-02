<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="Inventory Status Report.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.Inventory_Status_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Content/bootstrap.min.css" />
    <script src="../../../Scripts/bootstrap.min.js"></script>
    <script src="../../../Scripts/jquery-1.9.1.min.js"></script>
    <link href="../../../Style/main.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 50px; margin-bottom: 20px">
        <div class="container-fluid">
            <h3 style="text-align: center">Inventory Status Report</h3>
        </div>
        <div class="row">
            <div class="col-lg-6 col-lg-offset-1">
                <div class="input-group">
                    <asp:Button ID="Button1" runat="server" Text="Low Stock Items" OnClick="Button1_Click" CssClass="pull-right btn btn-default" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1">
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
    </div>

</asp:Content>
