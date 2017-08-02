<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ReqConfirm.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.ReqConfirm" %>

<%-- Made by Hu Xiaoxi(Team5) --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Requisition Successful</h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <p><asp:Literal ID="litaConfirm" runat="server"></asp:Literal></p>
                    <asp:Label ID="lablConfirm" runat="server" Text="Your department head will be notified via email of your requisition."></asp:Label>
                    <p></p>
                    <asp:Button ID="btnHome" runat="server" Text="Return to Home Page" OnClick="btnHome_Click" CssClass="btn btn-primary pull-left" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
