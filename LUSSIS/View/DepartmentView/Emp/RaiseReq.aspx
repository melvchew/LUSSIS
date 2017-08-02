<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RaiseReq.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.RaiseReq" %>
<%-- Made by Hu Xiaoxi(Team5) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="container-fluid">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <form id="frmRaiseReq" runat="server">
<div>
        <h1 style="text-align: center">Raise New Requisition</h1>
                        <br /><br />    
    </div>
        <asp:GridView ID="gvNewReqItem" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemId" CssClass="table table-bordered" >
            <Columns>
                <asp:TemplateField HeaderText="Item Name">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate> 

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit of Measurement">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtBoxQty" runat="server" Text="1" TextMode="Number" 
                            onkeyup="this.value = this.value.slice(0, 6)" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqfieldValidQty" runat="server" 
                            ControlToValidate="txtBoxQty" ErrorMessage="RequiredFieldValidator" 
                            ForeColor="Red">Quantity is required!</asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllItem" runat="server" AutoPostBack="true" OnCheckedChanged="chkAllItem_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkNewItem" runat="server" AutoPostBack="true" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table border="1" id="t01">
                    <tr>
                        <th>Item Name</th>
                        <th>Unit of Measurement</th>
                        <th>Quantity</th>
                    </tr>
                    <tr>
                        <td>empty</td>
                        <td>empty</td>
                        <td>empty</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:Button ID="btnAddNewItem" runat="server" Text="Add Items" OnClick="btnAddNewItem_Click" CssClass="btn btn-success pull-left"/>
        <asp:Button ID="btnRemove" runat="server" Text="Remove Items" OnClick="btnRemove_Click" CssClass="btn btn-warning col-md-offset-1" />
        <h4><asp:Label ID="lablComment" runat="server" Text="Comments: "></asp:Label></h4>
            <asp:TextBox ID="txtBoxComment" runat="server" Height="50px" Width="400px" TextMode="multiline" onkeyup="this.value = this.value.slice(0, 200)" ></asp:TextBox>
<br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-success pull-right"/>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger col-md-offset-10" />
    </form>
        </div>
    </div>

</body>
</html>
