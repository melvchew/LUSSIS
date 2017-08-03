<%@ Page Language="C#" MasterPageFile="~/MasterStore.Master" AutoEventWireup="true" CodeBehind="Catalogue.aspx.cs" Inherits="LUSSIS.View.DepartmentView.Emp.Catalogue" %>

<%-- Made by Hu Xiaoxi(Team5) --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">


            <div class="row">
                <h3>Item Catalogue</h3>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="input-group">
                        <span class="input-group-addon" id="basic-addon1">Category</span>
                        <asp:DropDownList ID="droplistItemCategory" runat="server"
                            OnSelectedIndexChanged="droplistItemCategory_SelectedIndexChanged"
                            AutoPostBack="true" CausesValidation="false" EnableViewState="true"
                            CssClass="form-control" data-style="btn-inverse">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <asp:TextBox ID="txtBoxSearchItem" runat="server" AutoPostBack="false"
                            onfocus="if(this.value=='Please Enter the Item name') this.value=''"
                            onblur="if(this.value=='')this.value='Please Enter the Item name'"
                            onkeyup="this.value = this.value.slice(0, 150)" CssClass="form-control">Please Enter the Item name</asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnSearchItem" runat="server" Text="Search" OnClick="btnSearchItem_Click" CssClass="btn" />
                        </span>
                    </div>
                    <!-- /input-group -->
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvCatalog" runat="server" AutoGenerateColumns="False"
                        AllowPaging="true" OnPageIndexChanging="gvCatalog_PageIndexChanging" DataKeyNames="ItemId" CssClass="table table-bordered  table-striped">
                        <Columns>
                            <asp:TemplateField HeaderText="Item Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit of Measurement">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Unit") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAllItem" runat="server" AutoPostBack="true" OnCheckedChanged="chkAllItem_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAddItem" runat="server" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="table table-bordered table-striped" id="t01">
                                <tr>
                                    <th>Item Name</th>
                                    <th>Unit of Measurement</th>
                                </tr>
                                <tr>
                                    <td>No Data</td>
                                    <td>No Data</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn" />
                </div>
            </div>

        </div>

    </div>
</asp:Content>
