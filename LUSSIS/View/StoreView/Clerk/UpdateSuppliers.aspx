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
                <h3>Update Supplier</h3>
            </div>
            <div class="col-sm-7">
                <div class="row">

                    <div class="col-sm-4">
                        <label for="lblSupplierId">SupplierID</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtSupplierId" runat="server" CssClass="form-control" ReadOnly="True" MaxLength="255"></asp:TextBox>
                    </div>
                    <div class="col-sm-4" style="margin-top: 27px;">
                        <label for="lblCompanyName">Company Name</label>
                    </div>
                    <div class="col-sm-8" style="margin-top: 27px;">
                        <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompanyName" ForeColor="Red" ErrorMessage="*Company Name can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblContactPerson">Contact Person</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                    </div>
                    <div class="col-sm-4" style="margin-top: 27px;">
                        <label for="lblPhoneNo">Phone No</label>
                    </div>
                    <div class="col-sm-8" style="margin-top: 27px;">
                        <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhoneNo" ForeColor="Red" ErrorMessage="*Phone No can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ErrorMessage="*input number or space character" ControlToValidate="txtPhoneNo" ValidationExpression="^[ 0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblFaxNo">Fax No</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtFaxNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ErrorMessage="*input number or space character" ControlToValidate="txtFaxNo" ValidationExpression="^[ 0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblAddress">Address</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="*Address can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblEmail">Email</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="*Email can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*worng email address" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm-4">
                        <label for="lblGST No">GST No</label>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtGSTNo" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtGSTNo" ForeColor="Red" ErrorMessage="*GSTNo can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="btnUpdate_Click" />
                    </div>
                    <div class="col-sm-5">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

