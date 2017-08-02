<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="UpdateSuppliers.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.UpdateSuppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Content/bootstrap.min.css" />
    <script src="../../../Scripts/bootstrap.min.js"></script>
    <script src="../../../Scripts/jquery-1.9.1.min.js"></script>
    <link href="../../../Style/main.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 50px; margin-bottom: 20px;">
        <div class="row">
            <div class="col-lg-12" style="text-align: center">
                <h3>Add New Supplier</h3>
            </div>
            <div class="col-sm-7">
                <div class="row">

                    <div class="col-sm-4">
                        <label for="lblSupplierId">SupplierID</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Company Name can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*SupplierID must be captial letter" ControlToValidate="TextBox1" ValidationExpression="^[A-Z]+$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblCompanyName">Company Name</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*Company Name can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblContactPerson">Contact Person</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblPhoneNo">Phone No</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox4" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="*Phone No can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*phone No. must be 6-9 number" ControlToValidate="TextBox4" ValidationExpression="^\d{6,9}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblFaxNo">Fax No</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox5" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*FAX No. must be 6-9 number" ControlToValidate="TextBox5" ValidationExpression="^\d{6,9}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblAddress">Address</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox6" ErrorMessage="*Address can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblEmail">Email</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7" ErrorMessage="*Email can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*worng email address" ControlToValidate="TextBox7" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblGST No">GST No</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox8" ErrorMessage="*GSTNo can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <div class="row" style="margin-bottom: 1em">
            <div class="col-lg-6 col-lg-offset-2">
                <div class="input-group-btn">
                    <asp:Button ID="Button2" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="Button2_Click" />
                    <span class="input-group-btn">
                        <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="Button1_Click" CssClass="btn btn-danger" />
                    </span>
                </div>
            </div>
        </div>
    </asp:Content>
   
