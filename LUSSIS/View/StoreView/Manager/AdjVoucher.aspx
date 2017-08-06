<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="AdjVoucher.aspx.cs" Inherits="LUSSIS.View.StoreView.Manager.AdjVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Pending Adjustment Voucher Request</h3>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvVoucher" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="false" OnRowEditing="gvVoucher_RowEditing1">
                        <Columns>
                            <asp:BoundField DataField="VoucherId" HeaderText="Voucher ID" />
                            <asp:BoundField DataField="SubmitDate" HeaderText="Submit Date" DataFormatString="{0:MM/dd/yyyy}" />
                            <asp:BoundField DataField="RaiseBy" HeaderText="Raised By" />
                            <asp:CommandField ShowEditButton="true" EditText="View Details" ButtonType="Link" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-sm-12">
                <asp:Label ID="lblAppOrRej" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
