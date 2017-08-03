<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.Chart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>
                    <asp:Label ID="lblHeading" runat="server"></asp:Label></h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblNoResult" runat="server" Text="No requisition found. Please go <a href=TrendAnalysis.aspx>back</a>." Visible="False"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Chart ID="Chart1" runat="server">
                        <Series>
                            <asp:Series Name="Series1"></asp:Series>
                            <asp:Series Name="Series2"></asp:Series>
                            <asp:Series Name="Series3"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>

                    </asp:Chart>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LUSSdbConnectionString %>" SelectCommand="SELECT * FROM [TransposedRequisitionReport] WHERE ([ItemId] = @ItemId)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="1" Name="ItemId" QueryStringField="ItemID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
