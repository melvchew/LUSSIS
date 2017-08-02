<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrendAnalysis.aspx.cs" Inherits="LUSSIS.View.StoreView.Clerk.TrendAnalysis" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        table {
            margin: 0 auto;
        }
        tr{
  padding-bottom: 5em;
        }
    </style>
    <form id="form1" runat="server">
    <div style="vertical-align:middle;text-align:center;">
        <h1>Compare Item Requisitions Among Departments</h1>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <table>
            <tr><td>Item</td>
                <td><asp:DropDownList ID="ddlItems" runat="server"></asp:DropDownList></td></tr>
            <tr><td>Report Period</td><td>
                From 
                    <asp:DropDownList ID="ddlFrom" runat="server" DataTextFormatString="{0:MMM-yyyy}"></asp:DropDownList>
                To <asp:DropDownList ID="ddlTo" runat="server" DataTextFormatString="{0:MMM-yyyy}"></asp:DropDownList>
                     </td>
            </tr>
            <tr><td>Department 1 </td>
                  <td> <asp:DropDownList ID="ddlDept1" runat="server" ></asp:DropDownList></td>
       
            </tr>
             <tr><td>Department 2 </td>
                  <td>   <asp:DropDownList ID="ddlDept2" runat="server">
                      
                         </asp:DropDownList>
                      
                  </td>
       
            </tr>
             <tr><td>Department 3 </td>
                  <td> <asp:DropDownList ID="ddlDept3" runat="server" >

            

                       </asp:DropDownList></td>
       
            </tr>
            <tr><td>Report By</td>
        <td><asp:RadioButtonList ID="RadioButtonList1" align="center" runat="server">
        <asp:ListItem text="Quantity" Selected="True" Value="Quantity" />
                    <asp:ListItem text="Cost (In SGD)" Value="Cost (In SGD)" />
            </asp:RadioButtonList>
            </td>
        </tr>
            <tr><td></td>

                <td>
                    &nbsp;</td>

            </tr>
                <tr>
                    <td></td>

                    <td>
                        <asp:Button ID="btnReport" runat="server" Text="Generate Report" OnClick="Button1_Click" />

                    </td>

                </tr>
        
            </table>
    </div>
        

        
    </form>
</body>
</html>