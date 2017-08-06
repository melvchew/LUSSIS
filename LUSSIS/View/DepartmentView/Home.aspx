<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="Home.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Department Home Page</h3>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-6">
                    <span class="pull-right">Welcome, <b>
                        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label></b>!
                    </span>
                </div>
            </div>
            <% if (HttpContext.Current.User.IsInRole("DeptEmp"))
                { %>
            <div class="row">
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Items Requested</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of <asp:Literal ID="litDeptEmpUndelTotal" runat="server"></asp:Literal> items that are undelivered.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvDeptEmpUndelItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeptEmpItemDes" runat="server" Text='<%# Eval("Item.Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeptEmpItemQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        You don&#39;t have any undelivered items.
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink1" CssClass="pull-right" NavigateUrl="~/View/DepartmentView/Emp/ViewUserReqHistory.aspx" runat="server">More</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Pending Requisitions</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-file" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of <asp:Literal ID="litDeptEmpPendingToal" runat="server"></asp:Literal> pending requisitions.</p>
                            <p></p>
                            <asp:GridView ID="gvDeptEmpPendingTotal" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Requisition ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptEmpPendingReqId" runat="server" Text='<%# Eval("ReqId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Submit Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptEmpPendingReqDate" runat="server" Text='<%# Convert.ToDateTime(Eval("SubmitDate")).ToShortDateString() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="col-lg-12">
                                <div>
                                    <asp:HyperLink ID="HyperLink2" CssClass="pull-right" NavigateUrl="~/View/DepartmentView/Emp/ViewUserReqHistory.aspx" runat="server">More</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% }
                else if (HttpContext.Current.User.IsInRole("DeptRep"))
                { %>
            <div class="row">
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Items Requested</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                            </div>
                        </div>
                         <div class="body">
                            <p>You have a total of <asp:Literal ID="litDeptRepUndelTotal" runat="server"></asp:Literal> items that are undelivered.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvDeptRepUndelItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeptEmpItemDes" runat="server" Text='<%# Eval("Item.Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeptEmpItemQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        You don&#39;t have any undelivered items.
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink3" CssClass="pull-right" NavigateUrl="~/View/DepartmentView/Home.aspx" runat="server">More</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Pending Requisitions</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-file" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of <asp:Literal ID="litDeptRepPendingToal" runat="server"></asp:Literal> pending requisitions.</p>
                            <p></p>
                            <asp:GridView ID="gvDeptRepPendingTotal" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Requisition ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptEmpPendingReqId" runat="server" Text='<%# Eval("ReqId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Submit Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptEmpPendingReqDate" runat="server" Text='<%# Convert.ToDateTime(Eval("SubmitDate")).ToShortDateString() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="col-lg-12">
                                <div>
                                    <asp:HyperLink ID="HyperLink4" CssClass="pull-right" NavigateUrl="~/View/DepartmentView/Emp/ViewUserReqHistory.aspx" runat="server">More</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Collection Point</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-map-marker" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>Your current collection point is Management School.  The collection time is 09:30 am.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Description</th>
                                        <th>Quantity</th>
                                    </tr>
                                    <tr>
                                        <td>Clips Double 1"</td>
                                        <td>2</td>
                                    </tr>
                                    <tr>
                                        <td>Envelope Brown (3"x6")</td>
                                        <td>5</td>
                                    </tr>
                                    <tr>
                                        <td>Envelope White (3"x6") w/ Window</td>
                                        <td>5</td>
                                    </tr>
                                    <tr>
                                        <td>Exercise Book (100 pg)</td>
                                        <td>5</td>
                                    </tr>
                                    <tr>
                                        <td>File Separator</td>
                                        <td>8</td>
                                    </tr>
                                </table>
                                <div>
                                    <a class="pull-right" href="#">More</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% }
                else if (HttpContext.Current.User.IsInRole("DeptHead"))
                { %>
            <div class="row">
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Pending Requisitions</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-file" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>You have a total of <asp:Literal ID="litDeptHeadPendingReqTotal" runat="server"></asp:Literal> pending requisitions that needs approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvDeptHeadPendingReq" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Requisition ID">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ReqId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Raised By">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Employee.Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink5" CssClass="pull-right" NavigateUrl="~/View/DepartmentView/Head/ViewPendingReq.aspx" runat="server">More</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Roles</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>Your current department repersentative: <asp:Literal ID="litDeptHeadCurrentRep" runat="server"></asp:Literal>.</p>
                            <p>Your current department acting head: <asp:Literal ID="litDeptHeadCurrentAH" runat="server"></asp:Literal>.</p>
                            <div class="col-lg-12">
                                <div>
                                    <asp:HyperLink ID="HyperLink6" CssClass="pull-right" NavigateUrl="~/View/DepartmentView/Head/DelegateRole.aspx" runat="server">Delegate Roles</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% }
                else if (HttpContext.Current.User.IsInRole("DeptActingHead"))
                { %>
            <div class="row">
                <div class="col-md-6">
                    <div class="infocard">
                        <div class="title">
                            <h4>Pending Requisitions</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-file" aria-hidden="true"></span>
                            </div>
                        </div>
                         <div class="body">
                            <p>You have a total of <asp:Literal ID="litDeptAHPendingReqTotal" runat="server"></asp:Literal> pending requisitions that needs approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <asp:GridView ID="gvDeptAHPendingReq" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Requisition ID">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ReqId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Raised By">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Employee.Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div>
                                    <asp:HyperLink ID="HyperLink7" CssClass="pull-right" NavigateUrl="~/View/DepartmentView/Head/ViewPendingReq.aspx" runat="server">More</asp:HyperLink>
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
