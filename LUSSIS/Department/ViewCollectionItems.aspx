<!--
    Developed By : Kavya Elizabeth James
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCollectionItems.aspx.cs" Inherits="LUSSIS.Department.ViewCollectionItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link rel="stylesheet" href="Content/bootstrap-theme.min.css" />--%>
    <link rel="stylesheet" href="https://adminlte.io/themes/AdminLTE/bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://adminlte.io/themes/AdminLTE/dist/css/AdminLTE.min.css" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 257px;
        }
    </style>
</head>
<body class="container-fluid" style="height: 449px">
    <form id="form1" runat="server">

        <div class="container" style="margin:20px">

            <div class="panel panel-primary">

                <div class="panel-heading">
                    <h4>View Collection Items</h4>
                </div>
                <div class="panel-body">

                    <div class="col-md-12">
                        <div class="col-md-7">
                            <div class="callout callout-primary">
                                Collection Point :
                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                <br />
                                Collection Date and Time :
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                <br />
                                Store Clerk Name :
                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                <br />
                                
                                Contact No :
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                <br />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="height:10px"></div>
                    <div class="col-md-12">

                        <div class="box-body table-responsive no-padding">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table-condensed table" Width="100%">
                            </asp:GridView>
                        </div>

                    </div>
                    <div class="col-md-12" style="height:10px"></div>
                    <div class="col-md-12">
                        Total Quantity :<asp:Label ID="Label5" runat="server"></asp:Label>
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </div>

                </div>

            </div>

        </div>
    </form>
    <script src="https://adminlte.io/themes/AdminLTE/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="https://adminlte.io/themes/AdminLTE/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="https://adminlte.io/themes/AdminLTE/dist/js/adminlte.min.js"></script>

</body>
</html>
