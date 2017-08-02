<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadExcel.aspx.cs" Inherits="LUSSIS.Store.UploadExcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Label ID="lbFileSubmit" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnTransfer" runat="server" Text="Transfer Data" OnClick="btnTransfer_Click" />
        <br />
        <br />
        <asp:Label ID="lbStatus" runat="server"></asp:Label>
        <br />

    </div>
    </form>
</body>
</html>
