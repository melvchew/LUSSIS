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
                    <span class="pull-right">Welcome, <b>Low Zhi Yong Peter</b>!
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
                            <p>You have a total of 30 items that are undelivered.</p>
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
                                    <a class="pull-right" href="#">View Details</a>
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
                            <p>You have a total of 2 pending requisitions.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Requisition ID</th>
                                        <th>Date</th>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>2017-08-02</td>
                                    </tr>
                                    <tr>
                                        <td>6</td>
                                        <td>2017-08-03</td>
                                    </tr>
                                </table>
                                <div>
                                    <a class="pull-right" href="#">View Details</a>
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
                            <p>You have a total of 30 items that are undelivered.</p>
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
                                    <a class="pull-right" href="#">View Details</a>
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
                            <p>You have a total of 2 pending requisitions.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Requisition ID</th>
                                        <th>Date</th>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>2017-08-02</td>
                                    </tr>
                                    <tr>
                                        <td>6</td>
                                        <td>2017-08-03</td>
                                    </tr>
                                </table>
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
                                    <a class="pull-right" href="#">View Details</a>
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
                            <p>You have a total of 2 pending requisitions that needs approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Requisition ID</th>
                                        <th>Raised By</th>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>Odelia Halm</td>
                                    </tr>
                                    <tr>
                                        <td>6</td>
                                        <td>Odelia Halm</td>
                                    </tr>
                                </table>
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
                            <h4>Roles</h4>
                            <div class="imgbox">
                                <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="body">
                            <p>Your current department repersentative: Cyndie Espinel</p>
                            <p>Your current department acting head: none.</p>
                            <div class="col-lg-12">
                                <div>
                                    <a class="pull-right" href="#">Delegate Roles</a>
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
                            <p>You have a total of 2 pending requisitions that needs approval.</p>
                            <p></p>
                            <div class="col-lg-12">
                                <table class="table table-striped table-bordered">
                                    <tr>
                                        <th>Requisition ID</th>
                                        <th>Raised By</th>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>Odelia Halm</td>
                                    </tr>
                                    <tr>
                                        <td>6</td>
                                        <td>Odelia Halm</td>
                                    </tr>
                                </table>
                                <div>
                                    <a class="pull-right" href="#">View Details</a>
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
