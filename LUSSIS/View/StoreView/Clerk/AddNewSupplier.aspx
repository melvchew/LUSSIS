<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="AddNewSupplier.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.AddNewSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Add New Supplier</h3>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="row">

                        <div class="col-sm-4">
                            <label for="lblSupplierId">SupplierID</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Company Name can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*SupplierID must be captial letter" ControlToValidate="TextBox1" ValidationExpression="^[A-Z]+$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-sm-4">
                            <label for="lblCompanyName">Company Name</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*Company Name can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4">
                            <label for="lblContactPerson">Contact Person</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                        </div>
                        <div class="col-sm-4" style="margin-top: 27px;">
                            <label for="lblPhoneNo">Phone No</label>
                        </div>
                        <div class="col-sm-8" style="margin-top: 27px;">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="*Phone No can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*input number or space character" ControlToValidate="TextBox4" ValidationExpression="^[ 0-9]*$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-sm-4 ">
                            <label for="lblFaxNo">Fax No</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*input number or space character" ControlToValidate="TextBox5" ValidationExpression="^[ 0-9]*$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-sm-4">
                            <label for="lblAddress">Address</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox6" ErrorMessage="*Address can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4">
                            <label for="lblEmail">Email</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox7" runat="server" TextMode="Email" CssClass="form-control" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7" ErrorMessage="*Email can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*worng email address" ControlToValidate="TextBox7" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-sm-4">
                            <label for="lblGST No">GST No</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox8" ErrorMessage="*GSTNo can't be null" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-3">
                            <asp:Button ID="Button1" runat="server" Text="Clear All" CssClass="btn pull-right" OnClick="Button1_Click" CausesValidation="false" />
                        </div>
                        <div class="col-sm-4">
                            <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn pull-right" OnClick="Button2_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
