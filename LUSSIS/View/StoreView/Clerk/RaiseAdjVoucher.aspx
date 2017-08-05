<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="RaiseAdjVoucher.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.RaiseAdjVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <div class="row">
                    <h3><span>Raise Adjustment Voucher</span></h3>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:LinkButton CssClass="btn pull-right" ID="AddNewRowLinkBtn" runat="server" OnClick="AddNewRowLinkBtn_Click1" Font-Size="Small">Add New Row</asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">Item Name</div>
                    <div class="col-md-3">Qty Adjusted</div>
                    <div class="col-md-4">Reason</div>
                    <div class="col-md-2">Value</div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:DropDownList ID="ItemsList1" CssClass="form-control dropdown-toggle" runat="server"></asp:DropDownList><br />
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtQtyAdj1" CssClass="form-control qntyAdj" runat="server" AutoPostBack="True"></asp:TextBox><br />
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtReasons1" CssClass="form-control" runat="server"></asp:TextBox><br />
                        <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtValue1" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox><br />
                        <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
           
            <div class="row">
                <div class="col-md-9"></div>
                <div class="col-md-3">
                    <asp:Button ID="Button1" runat="server" Class="btn btn-default" Text="Calculation" OnClick="Button1_Click" />
                    <asp:Button ID="Submitbtn" runat="server" Class="btn btn-default" Text="Submit" OnClick="Submitbtn_Click" />
                </div>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </div>
           </asp:PlaceHolder>
        </div>
    </div>

</asp:Content>
