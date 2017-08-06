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
                                You have a total of items that are needed to be delivered.
                            </p>
                            <p></p>
                            <div class="col-lg-12">

                                <div>
                                    <a class="pull-right" href="#">View Details</a>
                                </div>
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
                            <p>You have a total of 8 items that are low on stock.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Description</th>
                                        <th>Quantity</th>
                                    </tr>
                                    <tr>
                                        <td>Envelope Brown (5"x7")</td>
                                        <td>12</td>
                                    </tr>
                                    <tr>
                                        <td>File-Blue Plain</td>
                                        <td>22</td>
                                    </tr>
                                    <tr>
                                        <td>Highlighter Pink</td>
                                        <td>15</td>
                                    </tr>
                                    <tr>
                                        <td>Pad Postit Memo 1"x2"</td>
                                        <td>6</td>
                                    </tr>
                                    <tr>
                                        <td>Pencil 2B with Eraser End</td>
                                        <td>11</td>
                                    </tr>
                                </table>
                                <div>
                                    <a class="pull-right" href="#">View Report</a>
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
                            <p>You have a total of 4 pending adjustment vouchers that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Raised By</th>
                                        <th>Submitted Date</th>
                                    </tr>
                                    <tr>
                                        <td>Kellia Penlington</td>
                                        <td>08/15/2017</td>
                                    </tr>
                                    <tr>
                                        <td>John Cobbing</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Cheryl Skiplorne</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Caren Guild</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                </table>
                                <div>
                                    <a class="pull-right" href="#">View Report</a>
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
                            <p>You have a total of 4 pending adjustment vouchers that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Raised By</th>
                                        <th>Submitted Date</th>
                                    </tr>
                                    <tr>
                                        <td>Kellia Penlington</td>
                                        <td>08/15/2017</td>
                                    </tr>
                                    <tr>
                                        <td>John Cobbing</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Cheryl Skiplorne</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Caren Guild</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                </table>
                                <div>
                                    <a class="pull-right" href="#">View Report</a>
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
                            <p>You have a total of 3 pending purchase orders that need approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Raised By</th>
                                        <th>Submitted Date</th>
                                    </tr>
                                    <tr>
                                        <td>Kellia Penlington</td>
                                        <td>08/15/2017</td>
                                    </tr>
                                    <tr>
                                        <td>John Cobbing</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Cheryl Skiplorne</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                    <tr>
                                        <td>Caren Guild</td>
                                        <td>08/16/2017</td>
                                    </tr>
                                </table>
                                <div>
                                    <a class="pull-right" href="#">View Report</a>
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
