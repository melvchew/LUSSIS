<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="TrendAnalysis.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.TrendAnalysis" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containter-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Trend Analysis Report</h3>
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Item
                </div>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlItems" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Report Period
                </div>
                <div class="col-md-5">
                    <asp:DropDownList ID="ddlFrom" CssClass="form-control" runat="server" DataTextFormatString="{0:MMM-yyyy}"></asp:DropDownList>
                </div>
                <div class="col-md-5">
                    <asp:DropDownList ID="ddlTo" CssClass="form-control" runat="server" DataTextFormatString="{0:MMM-yyyy}"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Department 1
                </div>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlDept1" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Department 2
                </div>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlDept2" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Department 3
                </div>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlDept3" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Report By
                </div>
                <div class="col-md-10">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Text="Quantity" Selected="True" Value="Quantity" />
                        <asp:ListItem Text="Cost (In SGD)" Value="Cost (In SGD)" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnReport" CssClass="btn" runat="server" Text="Generate Report" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
