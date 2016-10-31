<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmSucursal.aspx.cs" Inherits="FrmSucursal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- <div class="container-fluid">
        <div class="page-header">--%>
    <div class="row">
        <div class="col-lg-4">
            <div class="form-group">
                <asp:Label ID="lblNombreSucursal" runat="server" Text="Nombre Sucursal"></asp:Label>
                <asp:TextBox ID="txtNombreSucursal" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTelefonoSucursal" runat="server" Text="Telefono"></asp:Label>
                <asp:TextBox ID="txtTelefonoSucursal" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDirecionSucursal" runat="server" Text="Direccion"></asp:Label>
                <asp:TextBox ID="txtDireccionSucursal" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnRegistrarSucursal" runat="server" Text="Registrar" OnClick="btnRegistrar_Sucursal" CssClass="btn btn-success" />
                <asp:Button ID="btnConsultarSucursal" runat="server" Text="Consultar" OnClick="btnConsultar_Sucursal" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GvSucursal" runat="server" CssClass="table table-hover table-striped" GridLines="None">
            </asp:GridView>
        </div>
    </div>
</asp:Content>

