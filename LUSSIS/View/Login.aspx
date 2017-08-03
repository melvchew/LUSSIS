<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LUSSIS.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" href="<%= Page.ResolveUrl("~/Content/bootstrap.min.css") %>" />
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-1.9.1.min.js") %>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/bootstrap.min.js") %>"></script>
    <link href="<%= Page.ResolveUrl("~/Style/main.css") %>" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet" type="text/css" />
    <title></title>
    <style>
        .placeholder {
            width: 25%;
            height: 50%;
            margin: 10% auto 0;
        }

        h3 {
            margin-bottom: 0;
        }

        table {
            width: 100%;
        }

        td {
            text-align: center;
            vertical-align: middle;
        }
        .btnLogin{
            width: 100%;
            margin-top: 20px;
        }
    </style>
</head>

<body style="background-color: #eee">

    <form id="form1" runat="server" class="form-horizontal">
        <div class="container-fluid">
            <div class="placeholder">
                <div class="row">
                    <h3><b>LUSSIS</b> | Log In</h3>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/View/Redirect2.aspx" OnLoggingIn="Login1_LoggingIn">
                            <InstructionTextStyle CssClass="control-label" />
                            <LayoutTemplate>
                                <div class="form-group">
                                    <asp:Label ID="UserNameLabel" runat="server" CssClass="pull-left" AssociatedControlID="UserName">Username:</asp:Label>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator Visible="false" ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Username is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="PasswordLabel" CssClass="pull-left" runat="server" AssociatedControlID="Password">Password:</asp:Label>

                                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator Visible="false" ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time" />
                                    </label>
                                </div>
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" CssClass="btn btnLogin" ValidationGroup="Login1" />
                                </div>                 
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </LayoutTemplate>
                            <LoginButtonStyle CssClass="btn" />
                            <TextBoxStyle CssClass="form-control" />
                            <TitleTextStyle CssClass="control-label" />
                        </asp:Login>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" ForeColor="Red" />
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
