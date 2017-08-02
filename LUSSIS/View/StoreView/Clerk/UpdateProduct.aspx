<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.UpdateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Content/bootstrap-theme.min.css" />
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script src="~/Scripts/jquery-1.9.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-12" style="text-align: center">
                    <h2>Update Product</h2>
                    <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox></div>
                <div class="col-sm-7">
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Bin#</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtBin" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBin" ErrorMessage="Bin Number is Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4">
                            <p>Category</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddCategory" CssClass="form-control" runat="server"></asp:DropDownList><br />
                        </div>
                        <div class="col-sm-4">
                            <p>Description</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description is Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4">
                            <p>Stock Balance</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtStockBalance" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtStockBalance" ErrorMessage="Stock Balance is Required"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtStockBalance" ErrorMessage="Stock Balance must be Numeric" MaximumValue="99999" MinimumValue="0"></asp:RangeValidator>
                        </div>
                        <div class="col-sm-4">
                            <p>Reorder Level</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtReorderLvl" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtReorderLvl" ErrorMessage="Reorder Level is Required"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtReorderLvl" ErrorMessage="Reorder Level must be Numeric" MaximumValue="99999" MinimumValue="0"></asp:RangeValidator>
                        </div>
                        <div class="col-sm-4">
                            <p>Reorder Quantity</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtReorderQty" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtReorderQty" ErrorMessage="Reorder Quantity is Required"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtReorderQty" ErrorMessage="Reorder Quantity must be Numeric" MaximumValue="99999" MinimumValue="0"></asp:RangeValidator>
                        </div>
                        <div class="col-sm-4">
                            <p>Unit of Measure</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddUnit" CssClass="form-control" runat="server">
                                <asp:ListItem>Each</asp:ListItem>
                                <asp:ListItem>Dozen</asp:ListItem>
                                <asp:ListItem>Set</asp:ListItem>
                                <asp:ListItem>Box</asp:ListItem>
                                <asp:ListItem>Packet</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-sm-4">
                            <p>Supplier#1</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddSupplier1" CssClass="form-control" runat="server"></asp:DropDownList><br />
                        </div>
                        <div class="col-sm-4">
                            <p>Supplier#1 Price</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSupplier1Price" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSupplier1Price" ErrorMessage="Supplier #1 Price is Required"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txtSupplier1Price" ErrorMessage="Supplier Price must be Numberic" MaximumValue="99999.99" MinimumValue="0.00"></asp:RangeValidator>
                        </div>
                        <div class="col-sm-4">
                            <p>Supplier#2</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddSupplier2" CssClass="form-control" runat="server"></asp:DropDownList><br />
                        </div>
                        <div class="col-sm-4">
                            <p>Supplier#2 Price</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSupplier2Price" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtSupplier2Price" ErrorMessage="Supplier #2 Price is Required"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator11" CssClass="form-control" runat="server" ControlToValidate="txtSupplier2Price" ErrorMessage="Supplier Price must be Numberic" MaximumValue="99999.99" MinimumValue="0.00"></asp:RangeValidator>
                        </div>
                        <div class="col-sm-4">
                            <p>Supplier#3</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddSupplier3" CssClass="form-control" runat="server"></asp:DropDownList><br />
                        </div>
                        <div class="col-sm-4">
                            <p>Supplier#3 Price</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSupplier3Price" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtSupplier3Price" ErrorMessage="Supplier #3 Price is Required"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator12" runat="server" ControlToValidate="txtSupplier3Price" ErrorMessage="Supplier Price must be Numberic" MaximumValue="99999.00" MinimumValue="0.00"></asp:RangeValidator>
                        </div>
                        <div class="col-sm-4">
                            <p>Is Cataloged</p>
                        </div>
                        <div class="col-sm-8">
                            <asp:CheckBox ID="cbIsCataloged" runat="server" />
                        </div>
                        <div class="col-sm-12">
                            <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label><br />
                        </div>
                        <div class="col-sm-12" style="text-align: right">
                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="UPDATE" OnClick="Button1_Click" /></div>
                    </div>
                </div>

                <div class="col-sm-5"></div>

            </div>
        </div>
    </form>
</body>
</html>
