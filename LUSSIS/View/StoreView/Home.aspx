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
                            <p>You have a total of 5 pending adjustment vouchers that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Raised By</th>
                                        <th>Submitted Date</th>
                                    </tr>
                                    <tr>
                                        <td>Rajkumar Murugesan</td>
                                        <td>08/15/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Zhang Jin Shan</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Kavya Elizabeth James</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Khin Su Pyae Moe</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Hu Xiao Xi</td>
                                        <td>08/07/2017</td>
                                    </tr>
                                </table>
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
                            <p>You have a total of 7 pending adjustment vouchers that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Raised By</th>
                                        <th>Submitted Date</th>
                                    </tr>
                                    <tr>
                                        <td>Rajkumar Murugesan</td>
                                        <td>08/15/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Zhang Jin Shan</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Kavya Elizabeth James</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Hu Xiao Xi</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Khin Su Pyae Moe</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                </table>
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
                            <p>You have a total of 2 pending purchase orders that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Raised By</th>
                                        <th>Submitted Date</th>
                                    </tr>
                                    <tr>
                                        <td>ALPHA Office Supplies</td>
                                        <td>8/1/2017</td>
                                    </tr>
                                    <tr>
                                        <td>BANES Shop</td>
                                        <td>8/7/2017</td>
                                    </tr>
                                </table>
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
