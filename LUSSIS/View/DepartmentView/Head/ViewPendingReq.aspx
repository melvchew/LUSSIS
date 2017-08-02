<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="ViewPendingReq.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Head.ViewPendingReq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>
                    <asp:Label ID="Label_PageTitle" runat="server" Text="Label"></asp:Label></h3>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView CssClass="table table-bordered" ID="GridView_VPR" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <Columns>

                            <asp:BoundField DataField="ReqId" HeaderText="Requisition ID" />

                            <asp:BoundField DataField="SubmitDate" HeaderText="Date" />

                            <asp:BoundField DataField="Name" HeaderText="Employee Name" />


                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LB_ViewDetail" runat="server" CausesValidation="False" CommandName="Select" Text="View Detail"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
