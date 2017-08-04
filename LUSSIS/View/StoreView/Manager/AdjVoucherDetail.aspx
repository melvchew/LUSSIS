<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="AdjVoucherDetail.aspx.cs" Inherits="LUSSIS.View.StoreView.Manager.AdjVoucherDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Request Details</h3>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    Request Form :
                <asp:Label ID="lblrequestID" runat="server"></asp:Label>
                </div>
                <div class="col-sm-6" style="text-align: right">
                    Request Date :
                <asp:Label ID="lbldate" runat="server"></asp:Label><br />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvItemList" CssClass="table table-bordered table-striped" GridLines="None" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Category" HeaderText="Category" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit of Measurement" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <asp:TextBox ID="txtcomment" placeholder="Comment" CssClass="form-control" runat="server" 
                        TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 250)"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-10">
                    <asp:Button ID="btnApprove" CssClass="btn" runat="server" Text="Approve" OnClick="btnApprove_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReject" CssClass="btn" runat="server" Text="Reject" OnClick="btnReject_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
