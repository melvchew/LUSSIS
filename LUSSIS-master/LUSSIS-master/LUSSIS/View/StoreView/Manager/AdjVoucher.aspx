<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdjVoucher.aspx.cs" Inherits="LUSSIS.View.StoreView.Manager.AdjVoucher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-12" style="text-align:center"><h2>Pending Adjustment Voucher Request</h2></div>
        </div>
        <div class="col-sm-12">
            <asp:GridView ID="gvVoucher" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" OnRowEditing="gvVoucher_RowEditing1" >
            <Columns>
                <asp:BoundField DataField="VoucherId" HeaderText="Voucher ID"  />
                <asp:BoundField DataField="SubmitDate" HeaderText="Submit Date"  DataFormatString="{0:MM/dd/yyyy}"  />
                <asp:BoundField DataField="RaiseBy" HeaderText="Raise By" />
                <asp:CommandField ShowEditButton="true" EditText="View Details" ButtonType="Link"  />
            </Columns>
            </asp:GridView>
        </div>
        <div class="col-sm-12" style="text-align:center"><br /><asp:Label ID="lblAppOrRej" runat="server" Text="Label"></asp:Label></div>
        
    </div>
    </form>
</body>
</html>
