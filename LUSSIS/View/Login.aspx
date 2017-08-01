<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LUSSIS.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" href="~/Content/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" />
    <title></title>
</head>

<body>

    <form id="form1" runat="server" class="form-horizontal">
        <div class="row">
            <div class="col-md-8 col-lg-offset-4">
                <h3 class="col-md-10 col-lg-offset-2">Log In</h3>
                <div class="form-group">
                    <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/View/Redirect.aspx" OnLoggingIn="Login1_LoggingIn">
                        <InstructionTextStyle CssClass="control-label" />
                        <LayoutTemplate>
                            <table class="table col-md-11 col-md-offset-1">
                                <tr>
                                    <td>
                                        <table cellpadding="0">
                                            <%--<tr>
                                                <td class="control-label"><b>Enter details to log in</b></td>
                                            </tr>--%>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" CssClass="control-label col-sm-2" AssociatedControlID="UserName">User Name:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control col-sm-10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" CssClass="control-label col-sm-2" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" CssClass="form-control col-sm-10" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" CssClass="btn btn-success" ValidationGroup="Login1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <LoginButtonStyle CssClass="btn btn-success" />
                        <TextBoxStyle CssClass="form-control" />
                        <TitleTextStyle CssClass="control-label" />
                    </asp:Login>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" ForeColor="Red" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>