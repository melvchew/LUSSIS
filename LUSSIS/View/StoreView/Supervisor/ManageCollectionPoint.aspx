<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCollectionPoint.aspx.cs" Inherits="LUSSIS.View.StoreView.Supervisor.ManageCollectionPoint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://adminlte.io/themes/AdminLTE/bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://adminlte.io/themes/AdminLTE/dist/css/AdminLTE.min.css" />

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 292px;
        }
        .auto-style2 {
            width: 292px;
            height: 26px;
        }

        .auto-style3 {
            height: 26px;
        }

        .hei{
            height:40px;
        }

        select{
            height:31px !important;
        }

        .mhead{
            color: gray;
            border-bottom: 1px solid #3c8dbc;
        }
    </style>
</head>
<body>
    <div class="container" style="margin: 20px">
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4>Manage Store Clerk At Collection Point</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12">
                                <div class="col-md-4" style="padding-right:0px">
                                    <div class="hei mhead"><b>Collection Point</b></div><br />
                                    <div class="hei"><asp:Label ID="Label2" runat="server" Text="Stationery Store - Administration Building"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="Label1" runat="server" Text="Management School"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="Label4" runat="server" Text="Medical School"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="Label5" runat="server" Text="Engineering School"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="Label6" runat="server" Text="Science School"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="Label7" runat="server" Text="University Hospital"></asp:Label></div><br />

                                </div>
                                <div class="col-md-4"  style="padding-right:0px; padding-left:0px;">
                                    <div class="hei mhead"><b>Collection Time</b></div><br />
                                    <div class="hei"><asp:Label ID="CPT1" runat="server" Text="Label"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="CPT2" runat="server" Text="Label"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="CPT3" runat="server" Text="Label"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="CPT4" runat="server" Text="Label"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="CPT5" runat="server" Text="Label"></asp:Label></div><br />
                                    <div class="hei"><asp:Label ID="CPT6" runat="server" Text="Label"></asp:Label></div><br />
                                </div>
                                <div class="col-md-4" style="padding-left:0px;">
                                    <div class="hei mhead"><b>Store Clerk</b></div><br />
                                    <div class="hei"><asp:DropDownList ID="StationeryStoreAdministrationBuilding" runat="server" Height="16px" Width="216px" CssClass="auto-style2 admin ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="ManagementSchool" runat="server" Height="16px" Width="216px" CssClass="auto-style1 management ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="MedicalSchool" runat="server" Height="16px" Width="216px" CssClass="auto-style3 medical ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="EngineeringSchool" runat="server" Height="16px" Width="216px" CssClass="auto-style3 engineering ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="ScienceSchool" runat="server" Height="16px" Width="216px" CssClass="auto-style3 science ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="UniversityHospital" runat="server" Height="16px" Width="216px" CssClass="auto-style3 hospital ddbox form-control">
                            </asp:DropDownList></div><br />
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer" style="height:51px">
                            <asp:Button ID="Submitbtn" runat="server" Text="Save" CssClass="savebutton btn btn-primary pull-right" OnClick="Submitbtn_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>

    <script src="http://code.jquery.com/jquery-3.2.1.js" integrity="sha256-DZAnKJ/6XZ9si04Hgrsxu/8s717jcIzLy3oi35EouyE=" crossorigin="anonymous"></script>
    <script src="https://adminlte.io/themes/AdminLTE/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="https://adminlte.io/themes/AdminLTE/dist/js/adminlte.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("select").css("form-control");
            $(".savebutton").prop('disabled', true);
            checkDuplicate();
            $(".ddbox").change(function (e) {
                checkDuplicate();
            });
        });

        function checkDuplicate() {
            var admin = $(".admin").val();
            var management = $(".management").val();
            var meical = $(".medical").val();
            var engineering = $(".engineering").val();
            var science = $(".science").val();
            var hospital = $(".hospital").val();


            if (admin == meical || admin == science || meical == science) {
                alert("same user for 9.30am slot");
            } else if (management == engineering || management == hospital || management == hospital) {
                alert("same user for 11.00am slot");
            } else {
                $(".savebutton").prop('disabled', false);
            }
        }

    </script>
</body>
</html>