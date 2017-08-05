<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStore.Master" CodeBehind="ManageCollectionPoint.aspx.cs" Inherits="LUSSIS.View.StoreView.Supervisor.ManageCollectionPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="placeholder">
            <div class="row">
                <h3>Manage Store Clerk At Collection Point</h3>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <b>Collection Point</b>
                </div>
                <div class="col-md-4">
                    <b>Collection Time</b>
                </div>
                <div class="col-md-4">
                    <b>Store Clerk</b>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="Label2" runat="server" Text="Stationery Store - Administration Building"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="CPT1" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="StationeryStoreAdministrationBuilding" runat="server" CssClass="form-control admin " AutoPostBack="false"><%-- OnSelectedIndexChanged="StationeryStoreAdministrationBuilding_SelectedIndexChanged">--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="Label1" runat="server" Text="Management School"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="CPT2" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ManagementSchool" runat="server" CssClass="form-control management" AutoPostBack="false"><%-- OnSelectedIndexChanged="ManagementSchool_SelectedIndexChanged">--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="Label4" runat="server" Text="Medical School"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="CPT3" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="MedicalSchool" runat="server" CssClass="form-control medical " AutoPostBack="false"><%-- OnSelectedIndexChanged="MedicalSchool_SelectedIndexChanged">--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="Label5" runat="server" Text="Engineering School"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="CPT4" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="EngineeringSchool" runat="server" CssClass="form-control engineering " AutoPostBack="false"><%-- OnSelectedIndexChanged="EngineeringSchool_SelectedIndexChanged">--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="Label6" runat="server" Text="Science School"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="CPT5" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ScienceSchool" runat="server" CssClass="form-control science " AutoPostBack="false"><%-- OnSelectedIndexChanged="ScienceSchool_SelectedIndexChanged">--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="Label7" runat="server" Text="University Hospital"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="CPT6" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="UniversityHospital" runat="server" CssClass="form-control hospital " AutoPostBack="false"> <%--OnSelectedIndexChanged="UniversityHospital_SelectedIndexChanged">--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="Submitbtn" runat="server" Text="Save" CssClass="savebutton btn" OnClick="Submitbtn_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
