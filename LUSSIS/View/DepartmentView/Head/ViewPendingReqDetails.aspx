<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPendingReqDetails.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Head.ViewPendingReqDetails" %>

<!DOCTYPE html>

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form2" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-2">
                    Requisition ID:
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="Label_ReqID" runat="server" Text="ID"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Requisition Date:
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="Label_ReqDate" runat="server" Text="Date"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Raised by:
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="Label_RaisedBy" runat="server" Text="Name"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView_PendingReq" runat="server" AutoGenerateColumns="False" Width="328px">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Requisitor's Comments
                </div>
                <div class="col-sm-10">
                    <asp:Label ID="Label_EmpComments" runat="server" Text="Label"></asp:Label>

                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Comments
                </div>
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBox_HeadComment" runat="server"></asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-2">
                    <asp:Button ID="Button_Approve" runat="server" Text="Approve" OnClick="Button_Approve_Click" />

                </div>
                <div class="col-lg-2">
                    <asp:Button ID="Button_Reject" runat="server" Text="Reject" OnClick="Button_Reject_Click" />

                </div>
            </div>
        </div>
    </form>




</body>
</html>

