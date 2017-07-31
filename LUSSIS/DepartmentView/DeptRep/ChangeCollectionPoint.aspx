<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeCollectionPoint.aspx.cs" Inherits="LUSSIS.DepartmentView.DeptRep.ChangeCollectionPoint" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://adminlte.io/themes/AdminLTE/bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://adminlte.io/themes/AdminLTE/dist/css/AdminLTE.min.css" />

    <title></title>
    <style type="text/css">
        .colectionpt{
            height:175px;
            padding:5px;
        }
        .labl{
            padding: 5px;
        }

        .mai{
            padding: 5px;
        }

        .mbt{
            margin:5px;
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
                            <h4>Change Collection Point</h4>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <div class="labl">
                                        <asp:Label ID="Label1" runat="server" Text="Current Collection Point"></asp:Label>:
                                    </div>
                                    <div class="labl">
                                        <asp:Label ID="Label2" runat="server" Text="Current Collection Time"></asp:Label>:
                                    </div>
                                    <div class="colectionpt">
                                        <asp:Label ID="Label3" runat="server" Text="Change Collection Point"></asp:Label>:
                                    </div>
                                    <div class="labl">
                                        <asp:Label ID="Label4" runat="server" Text="Changed Collection Time"></asp:Label>:
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="mai">
                                        <asp:Label ID="CurCP" runat="server"></asp:Label>
                                    </div>
                                    <div class="mai">
                                        <asp:Label ID="CurCT" runat="server"></asp:Label>
                                    </div>
                                    <div class="colectionpt">
                                        <asp:RadioButtonList ID="CollectionPoints" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CollectionPoints_SelectedIndexChanged">
                                            <asp:ListItem Value="1">Stationery Store - Administration Building</asp:ListItem>
                                            <asp:ListItem Value="2">Management School</asp:ListItem>
                                            <asp:ListItem Value="3">Medical School</asp:ListItem>
                                            <asp:ListItem Value="4">Engineering School</asp:ListItem>
                                            <asp:ListItem Value="5">Science School</asp:ListItem>
                                            <asp:ListItem Value="6">University Hospital</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="mai">
                                        <asp:Label ID="ChangedCT" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer"  style="height:55px">
                            <asp:Button ID="Cancelbtn" runat="server" CssClass="btn btn-danger pull-right mbt" Text="Cancel" />
                            <asp:Button ID="Submitbtn" runat="server"  CssClass="btn btn-primary pull-right mbt" Text="Save" OnClick="Submitbtn_Click" />
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
    </script>


</body>
</html>