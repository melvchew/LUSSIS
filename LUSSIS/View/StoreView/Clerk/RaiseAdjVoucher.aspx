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
                        <asp:DropDownList ID="ItemsList1" CssClass="form-control dropdown-toggle" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtQtyAdj1" CssClass="form-control qntyAdj" runat="server" AutoPostBack="True"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtReasons1" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtValue1" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-2">
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-3">
                        <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="col-md-3">
                        <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                    </div>
                </div>

            </asp:PlaceHolder>
            <br />
            <div class="col-md-9"></div>
            <div class="col-md-3">
                <asp:Button ID="Button1" runat="server" Class="btn btn-default" Style="display: none" OnClick="Button1_Click" Text="Calc" />
                <button id="calculatebtn" runat="server" class="btn btn-default">Calc</button>
                <asp:Button ID="Submitbtn" runat="server" Class="btn btn-default" Text="Submit" OnClick="Submitbtn_Click" />
            </div>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </div>
    <script src="http://code.jquery.com/jquery-3.2.1.min.js" integrity="sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        $(document).ready(function () {


            $('.qntyAdj').keydown(function (event) {
                return (((event.which > 47) && (event.which < 58)) || (event.which == 13) || (event.keyCode == 8) || (event.keyCode >= 96 && event.keyCode <= 105));
            });

            $("#calculatebtn").click(function (e) {
                var errCount = 0;
                e.preventDefault();
                $(".qntyAdj").each(function () {
                    if ($(this).val() === "" || isNaN($(this).val())) {
                        errCount = errCount + 1;
                    }
                });


                if (errCount > 0) {
                    alert("Please fill all the box");
                }
                if (errCount == 0) {
                    $("#Button1").click();
                    $("#Submitbtn").css("display", "block");
                }

            });
        });
    </script>
</asp:Content>
