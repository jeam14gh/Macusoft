<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmCategorias.aspx.cs" Inherits="FrmCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<div class="container-fluid">
        <div class="page-header">--%>
            <div class="row">
                <div class="col-md-3">
                    <div class="row">
                        <asp:Label ID="lblNombreCategoria" runat="server" Text="Nombre Categoria">

                        </asp:Label>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="txtNombreCategoria" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="row">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="btn btn-success" />
                        <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" OnClick="BtnConsultar_Click" CssClass="btn btn-danger" />
                    </div>

                </div>
                <div class="col-md-6">

                    <asp:GridView ID="GvCategorias" runat="server"
                        CssClass="table table-hover table-striped" GridLines="None">
                    </asp:GridView>

                </div>
            </div>
    <%--    </div>
    </div>--%>


</asp:Content>

