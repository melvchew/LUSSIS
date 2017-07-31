<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdjVoucherBelow250Detail.aspx.cs" Inherits="LUSSIS.View.StoreView.Supervisor.AdjVoucherBelow250Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-12" style="text-align:center"><h2>Request Details</h2></div>
            <div class="col-sm-6">Request Form : <asp:Label ID="lblrequestID" runat="server"></asp:Label></div>
            <div class="col-sm-6" style="text-align:right">Request Date : <asp:Label ID="lbldate" runat="server"></asp:Label><br /><br /></div>
            <div class="col-sm-12">
                <asp:GridView ID="gvItemList" CssClass="table table-bordered" GridLines="None" runat="server" AutoGenerateColumns="false" >
                    <Columns>
                        <asp:BoundField DataField="Category" HeaderText="Category"  />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                        <asp:BoundField DataField="Unit" HeaderText="Unit of Measurement" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm-1"> </div>
            <div class="col-sm-10"> <br /><asp:TextBox ID="txtcomment" placeholder="Comment" CssClass="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox><br /></div>
            <div class="col-sm-1"> </div>
            <div class="col-sm-11" style="text-align: right">
                <asp:Button ID="btnApprove" CssClass="btn btn-success" runat="server" Text="Approve" OnClick="btnApprove_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReject" CssClass="btn btn-danger" runat="server" Text="Reject" OnClick="btnReject_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
