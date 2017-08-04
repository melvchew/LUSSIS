﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="Inventory Status Report.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.Inventory_Status_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Inventory Status Report</h3>
                <asp:Label ID="Label9" runat="server" Visible="False" ForeColor="#FF6600"></asp:Label>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    <asp:Button ID="Button1" runat="server" Text="Low Stock Items" OnClick="Button1_Click" CssClass="btn pull-left" Width="150px" />
                </div>
                 <div class="col-sm-4">
                    <%--<asp:Button ID="Button2" CssClass="btn pull-right" runat="server" Text="Import" />--%>
                </div>
                <div class="col-sm-6">
                    <div class="input-group">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search By Description"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnSearch" CssClass="btn pull-right" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </span>
                    </div>
                    <!-- /input-group -->
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" AllowPaging="True" CssClass="table table-striped table-bordered" PageSize="8">
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

                <div class="col-sm-4">
                    <asp:Button ID="Button2" runat="server" Text="Back" Visible="false" CssClass="btn" OnClick="Button2_Click" Width="150px" />
                </div>
            </div>
        </div>

    </div>

</asp:Content>
