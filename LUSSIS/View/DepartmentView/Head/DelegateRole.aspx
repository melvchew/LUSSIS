<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DelegateRole.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Head.DelegateRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="container">
            <div class="row">
                <div class="col-sm-12" style="text-align:center"><h2>Delegate Roles</h2></div>
                <div class="col-sm-3">
                    Current Department Representative
                </div>
                <div class="col-sm-9">
                    <asp:Label ID="lblCurrentDeptRep"  runat="server" Width="300px"></asp:Label><br /><br />
                </div>
                <div class="col-sm-3">
                     Department Representative
                </div>
                <div class="col-sm-9">
                    <asp:DropDownList ID="ddDeptRepre" CssClass="form-control" runat="server" Width="300px"></asp:DropDownList><br /><br />
                </div>
                <div class="col-sm-3">
                     Current Acting Head
                </div>
                <div class="col-sm-9">
                    <asp:Label ID="lblCurrentActingHead" runat="server" Width="300px"></asp:Label><br /><br />
                </div>
                <div class="col-sm-3">
                    Acting Head
                </div>
                <div class="col-sm-9">
                     <asp:DropDownList ID="ddActingHead" CssClass="form-control" runat="server" Width="300px"></asp:DropDownList><br />
                </div>
                <div class="col-sm-3">
                     From Date
                </div>
                <div class="col-sm-9">
                     <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" TextMode="Date" Width="300px"></asp:TextBox><br />
                </div>
                <div class="col-sm-3">
                    To Date
                </div>
                <div class="col-sm-9">
                     <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server" TextMode="Date" Width="300px"></asp:TextBox><br />
                </div>
                
                <div class="col-sm-12"> <asp:Label ID="lblerror" ForeColor="Red" runat="server"></asp:Label></div><br />
                <div class="col-sm-3">

                </div>
                <div class="col-sm-9">
                    <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" Text="Delegate" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
