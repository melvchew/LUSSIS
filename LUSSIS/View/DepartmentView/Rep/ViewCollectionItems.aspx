<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ViewCollectionItems.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Rep.ViewCollectionItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Collection Items</h3>
            </div>
            <div class="row">
                <div class="col-md-3">
                    Collection Point :
                </div>
                <div class="col-md-9">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-3">
                    Collection Date and Time :
                </div>
                <div class="col-md-9">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-3">
                    Store Clerk Name :
                </div>
                <div class="col-md-9">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-3">
                    Contact No :
                </div>
                <div class="col-md-9">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table-bordered table" Width="100%">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
