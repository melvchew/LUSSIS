<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPoint.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Rep.ChangeCollectionPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Change Collection Point</h3>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="Label1" runat="server" Text="Current Collection Point"></asp:Label>:
                </div>
                <div class="col-md-9">
                    <asp:Label ID="CurCP" runat="server"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label2" runat="server" Text="Current Collection Time"></asp:Label>:
                </div>
                <div class="col-md-9">
                    <asp:Label ID="CurCT" runat="server"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label3" runat="server" Text="Change Collection Point"></asp:Label>:
                </div>
                <div class="col-md-9">
                    <asp:RadioButtonList ID="CollectionPoints" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CollectionPoints_SelectedIndexChanged">
                        <asp:ListItem Value="1">Stationery Store - Administration Building</asp:ListItem>
                        <asp:ListItem Value="2">Management School</asp:ListItem>
                        <asp:ListItem Value="3">Medical School</asp:ListItem>
                        <asp:ListItem Value="4">Engineering School</asp:ListItem>
                        <asp:ListItem Value="5">Science School</asp:ListItem>
                        <asp:ListItem Value="6">University Hospital</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label4" runat="server" Text="Changed Collection Time"></asp:Label>:
                </div>
                <div class="col-md-9">
                    <asp:Label ID="ChangedCT" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Button ID="Cancelbtn" runat="server" CssClass="btn" Text="Cancel" OnClick="Cancelbtn_Click" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="Submitbtn" runat="server" CssClass="btn" Text="Save" OnClick="Submitbtn_Click" />
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
