<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ViewAllReq.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.ViewAllReq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>View Retrieval List</h3>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="input-group">
                        <span class="input-group-addon" id="basic-addon1">Department</span>
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Text="All Departments" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="Label1" runat="server" Text="Showing requisitions from: All Departments"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped"></asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnBack" runat="server" Text="Back to Home Page" OnClick="btnBack_Click" CssClass="btn" />
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
