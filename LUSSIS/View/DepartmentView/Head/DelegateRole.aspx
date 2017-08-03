<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="DelegateRole.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Head.DelegateRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtFromDate").datepicker({
                dateFormat: 'dd/mm/yy',
                onSelect: function (date) {
                    var dt1 = $('#ContentPlaceHolder1_txtFromDate').datepicker('getDate');
                    var dt2 = $('#ContentPlaceHolder1_txtToDate').datepicker('getDate');
                    if (dt1 > dt2) {
                        $('#ContentPlaceHolder1_txtToDate').datepicker('setDate', dt1);
                    }
                    $('#ContentPlaceHolder1_txtToDate').datepicker('option', 'minDate', dt1);
                }
            });

            $("#ContentPlaceHolder1_txtToDate").datepicker({
                dateFormat: "dd/mm/yy",
                minDate: $('#ContentPlaceHolder1_txtFromDate').datepicker('getDate'),
                onClose: function () {
                    var dt1 = $('#ContentPlaceHolder1_txtFromDate').datepicker('getDate');
                    var dt2 = $('#ContentPlaceHolder1_txtToDate').datepicker('getDate');
                    //check to prevent a user from entering a date below date of dt1
                    if (dt2 <= dt1) {
                        var minDate = $('#ContentPlaceHolder1_txtToDate').datepicker('option', 'minDate');
                        $('#ContentPlaceHolder1_txtToDate').datepicker('setDate', minDate);
                    }
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Delegate Roles</h3>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    Current Department Representative
                </div>
                <div class="col-sm-9">
                    <asp:Label ID="lblCurrentDeptRep" runat="server"></asp:Label><br />
                    <br />
                </div>
                <div class="col-sm-3">
                    Department Representative
                </div>
                <div class="col-sm-9">
                    <asp:DropDownList ID="ddDeptRepre" CssClass="form-control" runat="server"></asp:DropDownList><br />
                    <br />
                </div>
                <div class="col-sm-3">
                    Current Acting Head
                </div>
                <div class="col-sm-9">
                    <asp:Label ID="lblCurrentActingHead" runat="server"></asp:Label><br />
                    <br />
                </div>
                <div class="col-sm-3">
                    Acting Head
                </div>
                <div class="col-sm-9">
                    <asp:DropDownList ID="ddActingHead" CssClass="form-control" runat="server"></asp:DropDownList><br />
                </div>
                <div class="col-sm-3">
                    From Date
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox><br />
                </div>
                <div class="col-sm-3">
                    To Date
                </div>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox><br />
                </div>

                <div class="col-sm-12">
                    <asp:Label ID="lblerror" ForeColor="Red" runat="server"></asp:Label>
                </div>
                <br />
                <div class="col-sm-3">
                </div>
                <div class="col-sm-9">
                    <asp:Button ID="btnSave" CssClass="btn" runat="server" OnClick="btnSave_Click" Text="Delegate" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
