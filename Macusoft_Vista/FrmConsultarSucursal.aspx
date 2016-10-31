<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmConsultarSucursal.aspx.cs" Inherits="FrmConsultarSucursal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="container-fluid">
        <div class="page-header">--%>
            <div class="row">
                <div class="col-md-2">
                    <div class="row">
                        <asp:Label ID="lblIdSucursal" runat="server" Text="Id sucursal"></asp:Label>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtIdSucursal" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Label ID="lblNombreSucursal" runat="server" Text="Nombre Surcursal"></asp:Label>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtNombreSucursal" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Label ID="lblTelefonoSucursal" runat="server" Text="Telefono"></asp:Label>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtTelefonoSucursal" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Label ID="lblDireccionSucursal" runat="server" Text="Direccion"></asp:Label>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtDireccionSucursal" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-success" OnClick="btnConsultar_Click1" />
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-danger" OnClick="btnActualizar_Click1" />
                    </div>

                </div>
                <div class="col-md-6">

                    <asp:GridView ID="GvSucursal" runat="server" OnSelectedIndexChanged="GvSucursal_SelectedIndexChanged" CssClass="table table-hover table-striped" GridLines="None">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
   <%--     </div>
    </div>--%>

</asp:Content>

