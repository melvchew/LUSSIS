<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewSupplier.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.AddNewSupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
    <title></title>
</head>
<body class="container-fluid">
    <form id="form1" runat="server">
        <div class="row" style="margin-bottom: 10px">
            <div class="col-lg-6 col-lg-offset-4">
                <h3>Add New Supplier</h3>
            </div>
          
            <div class="col-lg-8 col-lg-offset-1">
                <div class="form-group">
                    <label for="lblSupplierId">SupplierID</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Company Name can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*SupplierID must be captial letter" ControlToValidate="TextBox1" ValidationExpression="[A-Z]"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="lblCompanyName">Company Name</label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*Company Name can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="lblContactPerson">Contact Person</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <label for="lblPhoneNo">Phone No</label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="*Phone No can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="lblFaxNo">Fax No</label>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <label for="lblAddress">Address</label>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox6" ErrorMessage="*Address can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="lblEmail">Email</label>
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7" ErrorMessage="*Email can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="lblGST No">GST No</label>
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1 col-lg-offset-1">
                <asp:Button ID="Button1" runat="server" Text="Clear All" CssClass="btn btn-danger col-lg-12" OnClick="Button1_Click" />
            </div>
            <div class="col-lg-1">
                <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn btn-warning col-lg-12" OnClick="Button2_Click" />
            </div>
        </div>

    </form>
</body>
</html>
