<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.Chart" %>

<!DOCTYPE html>

<body>
    <form id="form1" runat="server">
        <div style="vertical-align:middle;text-align:center;">
            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:Label ID="lblNoResult" runat="server" Text="No requisition found. Please go <a href=TrendAnalysis.aspx>back</a>." Visible="False"></asp:Label>
            <br />

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
    <table>
        <tr>
            <td>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LUSSdbConnectionString %>" SelectCommand="SELECT * FROM [TransposedRequisitionReport] WHERE ([ItemId] = @ItemId)">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="1" Name="ItemId" QueryStringField="ItemID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
        </tr>
    </table>
            </div>
</form>
    </body>
    </html>