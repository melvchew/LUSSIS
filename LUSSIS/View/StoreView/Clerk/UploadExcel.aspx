<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="UploadExcel.aspx.cs" Inherits="LUSSIS.Store.UploadExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Upload Product From Excel</h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="col-md-12">
                    <asp:Label ID="lbFileSubmit" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="btnUpload" CssClass="btn" runat="server" Text="Upload File" OnClick="btnUpload_Click" />
                    <asp:Button ID="btnTransfer" CssClass="btn" runat="server" Text="Transfer Data" OnClick="btnTransfer_Click" />
                </div>
                <div class="col-md-12">
                    <asp:Label ID="lbStatus" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
