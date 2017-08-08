<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LUSSIS.View.StoreView.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Store Home Page</h3>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-6">
                    <span class="pull-right">Welcome, <b>
                        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label></b>!
                    </span>
                </div>
            </div>
            <% if (HttpContext.Current.User.IsInRole("StoreClerk"))
                { %>
            <div class="row">
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Items Retrieval List</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-time" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of
                                <asp:Literal ID="litClerkReqItemTotal" runat="server"></asp:Literal>
                                items that are needed to be delivered.</p>
                            <p></p>
                            <div class="col-lg-12">

                                <asp:GridView ID="gvClerkReqItem" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Item.Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>

                                <asp:HyperLink ID="HyperLink2" CssClass="pull-right" NavigateUrl="~/View/StoreView/Clerk/ViewAllReq.aspx" runat="server">More</asp:HyperLink>
                                

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Low Stock Items</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>
                                You have a total of
                                <asp:Literal ID="litClerkLowStockTotal" runat="server"></asp:Literal>
                                items that are low on stock.
                            </p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvClerkLowStock" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("StockBalance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink1" CssClass="pull-right" NavigateUrl="~/View/StoreView/Clerk/Inventory Status Report.aspx" runat="server">More</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% }
                else if (HttpContext.Current.User.IsInRole("StoreSupervisor"))
                { %>
            <div class="row">
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Items Retrieval List</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-time" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>
                                You have a total of <asp:Literal ID="litSupReqItemTotal" runat="server"></asp:Literal> items that are needed to be delivered.
                            </p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvSupReqItem" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Item.Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>

                                <asp:HyperLink ID="HyperLink3" CssClass="pull-right" NavigateUrl="~/View/StoreView/Clerk/ViewAllReq.aspx" runat="server">More</asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Low Stock Items</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of <asp:Literal ID="litSupLowStockTotal" runat="server"></asp:Literal> items that are low on stock.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvSupLowStock" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("StockBalance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink4" CssClass="pull-right" NavigateUrl="~/View/StoreView/Clerk/Inventory Status Report.aspx" runat="server">More</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Pending Adjustment Vouchers</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-time" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of <asp:Literal ID="litAdjVoucherBelow250" runat="server"></asp:Literal> pending adjustment vouchers that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvAdjVoucherBelow250" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField HeaderText="Raised By" DataField="RaiseBy" />
                                        <asp:BoundField HeaderText="Submitted Date" DataField="SubmitDate" DataFormatString="{0:d}" />
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink5" CssClass="pull-right" NavigateUrl="~/View/StoreView/Supervisor/AdjVoucherBelow250.aspx" runat="server">View Report</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% }
                else if (HttpContext.Current.User.IsInRole("StoreManager"))
                { %>
            <div class="row">
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Pending Adjustment Vouchers</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-time" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of <asp:Literal ID="litAdjVoucher" runat="server"></asp:Literal> pending adjustment vouchers that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvAdjVoucher" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField HeaderText="Raised By" DataField="RaiseBy"  />
                                        <asp:BoundField HeaderText="Submitted Date" DataField="SubmitDate" DataFormatString="{0:d}" />
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink6" CssClass="pull-right" NavigateUrl="~/View/StoreView/Manager/AdjVoucher.aspx" runat="server">View Report</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Pending Purchase Orders</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-time" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of <asp:Literal ID="litViewOrder" runat="server"></asp:Literal> pending purchase orders that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvViewOrder" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField HeaderText="Raised By" DataField="Supplier.CompanyName" />
                                        <asp:BoundField HeaderText="Submitted Date" DataField="OrderDate" DataFormatString="{0:d}" />
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink7" CssClass="pull-right" NavigateUrl="~/View/StoreView/Manager/ViewOrder.aspx" runat="server">View Report</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>
