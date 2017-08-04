<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ViewPendingReqDetails.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Head.ViewPendingReqDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Requisition Details</h3>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Requisition ID:
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="Label_ReqID" runat="server" Text="ID"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Requisition Date:
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="Label_ReqDate" runat="server" Text="Date"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Raised by:
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="Label_RaisedBy" runat="server" Text="Name"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView_PendingReq" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Description" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Requisitor's Comments
                </div>
                <div class="col-sm-10">
                    <asp:Label ID="Label_EmpComments" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    Comments
                </div>
                <div class="col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="TextBox_HeadComment" runat="server" 
                        TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 250)"></asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="Button_Approve" CssClass="btn" runat="server" Text="Approve" OnClick="Button_Approve_Click" />

                </div>
                <div class="col-lg-2">
                    <asp:Button ID="Button_Reject" CssClass="btn" runat="server" Text="Reject" OnClick="Button_Reject_Click" />

                </div>
            </div>
        </div>

    </div>
</asp:Content>
