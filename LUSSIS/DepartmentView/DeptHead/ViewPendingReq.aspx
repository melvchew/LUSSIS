<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPendingReq.aspx.cs" Inherits="LUSSIS.Employee.DeptHead.ViewPendingReq" %>

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

    <form id="form1" runat="server">
        <div class="container-fluid">
            <div>
                <div class="col-lg-12">
                    <asp:Label ID="Label_PageTitle" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-lg-12">
                    <asp:GridView ID="GridView_VPR" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <Columns>

                            <asp:BoundField DataField="ReqId" HeaderText="Requisition ID" />

                            <asp:BoundField DataField="SubmitDate" HeaderText="Date" />

                            <asp:BoundField DataField="Name" HeaderText="Employee Name" />


                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LB_ViewDetail" runat="server" CausesValidation="False" CommandName="Select" Text="View Detail"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>

                    </asp:GridView>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
