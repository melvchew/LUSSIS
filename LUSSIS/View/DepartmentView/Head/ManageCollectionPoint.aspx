<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCollectionPoint.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Head.ManageCollectionPoint" %>

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
                                    <div class="hei"><asp:DropDownList ID="StationeryStoreAdministrationBuilding" runat="server" data-id="9" data-val="" Height="16px" Width="216px" CssClass="auto-style2 admin ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="ManagementSchool" runat="server" Height="16px" Width="216px" data-id="11"  data-val=""  CssClass="auto-style1 management ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="MedicalSchool" runat="server" Height="16px" Width="216px" data-id="9"  data-val=""  CssClass="auto-style3 medical ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="EngineeringSchool" runat="server" Height="16px" Width="216px" data-id="11"  data-val=""  CssClass="auto-style3 engineering ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="ScienceSchool" runat="server" Height="16px" Width="216px" data-id="9"  data-val=""  CssClass="auto-style3 science ddbox form-control">
                            </asp:DropDownList></div><br />
                                    <div class="hei"><asp:DropDownList ID="UniversityHospital" runat="server" Height="16px" Width="216px" data-id="11"  data-val=""  CssClass="auto-style3 hospital ddbox form-control">
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
            var arr = setArray();
            var nine = arr[0];
            var eleven = arr[1];
            var previous = "";

            checkDuplicate();

            $(".ddbox").change(function (e) {
                var dataId = $(this).data("id");
                if (dataId == "9") {
                    var val = $(this).val();
                    var currentVal = $(this).data("val");
                    if ($.inArray(val, nine) != -1) {
                        if (currentVal != val) {
                            var erClass = $(this).attr("id") + "err";
                            $("." + erClass).remove();
                            var text = $("#" + $(this).attr("id") + " option[value='" + val + "']").text();
                            $(this).after("<p style='color:red' class=" + erClass + "><i>" + text + " already alloted for 9.30</i><p>");
                        } else {
                            var erClass = $(this).attr("id") + "err";
                            $("." + erClass).remove();
                        }
                        checkDuplicate();
                    } else {
                        if (currentVal != val) {
                            var index = $.inArray($(this).data("val"), nine);
                            nine[index] = val;
                            $(this).data("val", val);
                            var erClass = $(this).attr("id") + "err";
                            $("." + erClass).remove();
                        }
                        checkDuplicate();
                    }
                }

                if (dataId == "11") {
                    var val = $(this).val();
                    var currentVal = $(this).data("val");
                    if ($.inArray(val, eleven) != -1) {
                        if (currentVal != val) {
                            var erClass = $(this).attr("id") + "err";
                            $("." + erClass).remove();
                            var text = $("#" + $(this).attr("id") + " option[value='" + val + "']").text();
                            $(this).after("<p style='color:red' class=" + erClass + "><i>" + text + " already alloted for 11.00</i><p>")
                        } else {
                            var erClass = $(this).attr("id") + "err";
                            $("." + erClass).remove();
                        }
                        checkDuplicate();
                    } else {
                        if (currentVal != val) {
                            var index = $.inArray($(this).data("val"), eleven);
                            eleven[index] = val;
                            $(this).data("val", val);
                            var erClass = $(this).attr("id") + "err";
                            $("." + erClass).remove();
                        }
                        checkDuplicate();
                    }
                }
            });
        });


        function setArray() {
            var eleven = [];
            var nine = [];
            var arr = [];

            var manag11 = $("#ManagementSchool");
            eleven.push(manag11.val());
            manag11.data("val", manag11.val());

            var engin11 = $("#EngineeringSchool");
            eleven.push(engin11.val());
            engin11.data("val",engin11.val());

            var unihos11 = $("#UniversityHospital");
            eleven.push(unihos11.val());
            unihos11.data("val",unihos11.val());


            var admin9 = $("#StationeryStoreAdministrationBuilding");
            nine.push(admin9.val());
            admin9.data("val",admin9.val());

            var medi9 = $("#MedicalSchool");
            nine.push(medi9.val());
            medi9.data("val", medi9.val());

            var sci9 = $("#ScienceSchool");
            nine.push(sci9.val());
            sci9.data("val",sci9.val());

            arr.push(nine);
            arr.push(eleven);
            return arr;
        }

        function checkDuplicate() {
            var admin = $(".admin").val();
            var management = $(".management").val();
            var medical = $(".medical").val();
            var engineering = $(".engineering").val();
            var science = $(".science").val();
            var hospital = $(".hospital").val();


            if (admin == medical || admin == science || medical == science) {
                $(".savebutton").prop('disabled', true);
            } else if (management == engineering || management == hospital || management == hospital) {
                $(".savebutton").prop('disabled', true);
            } else {
                $(".savebutton").prop('disabled', false);
            }
        }

    </script>
</body>
</html>