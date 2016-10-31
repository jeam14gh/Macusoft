<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmNavegacion.aspx.cs" Inherits="FrmNavegacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-lg-6">
        <div class="panel panel-default">
            <div class="panel-heading">Gestión de Usuarios</div>
            <div class="panel-body">
                <a href="FrmUsuario.aspx">Registrar Usuarios</a>
                <div>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Gestión de productos</h3>
            </div>
            <div class="panel-body">
                <a href="FrmProductos.aspx">Registrar Productos</a>
                <br />
                <a href="FrmProductos_ConAct.aspx">Consultar Productos</a>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Gestión de proveedores</h3>
            </div>
            <div class="panel-body">
                <a href="FrmProveedor.aspx">Registrar Proveedor</a>
                <br />
                <a href="FrmProveedores_ConAct.aspx">Consultar Proveedor</a>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Gestión de clientes</h3>
            </div>
            <div class="panel-body">
                <a href="FrmClientes.aspx">Registrar Clientes</a>
                <br />
                <a href="FrmClientesConAct.aspx">Consultar Clientes </a>
            </div>
        </div>
    </div>


    <div class="col-lg-6">
        <div class="panel panel-default">
            <div class="panel-heading">Gestión de ventas</div>
            <div class="panel-body">
                <a href="FrmVentas.aspx">Registrar Ventas</a>
                <br />

            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Devolución Clientes</h3>
            </div>
            <div class="panel-body">
                <a href="FrmDevolucionCliente.aspx">Registrar devolución  </a>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Gestión de compras</h3>
            </div>
            <div class="panel-body">
                <a href="FrmCompras.aspx">Registrar Compras</a>
                <br />
                <a href="frmConsultarCompras.aspx">Consultar Compras</a>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Devolución proveedores</h3>
            </div>
            <div class="panel-body">
                <a href="FrmDevoluciones_Proveedores.aspx">Registrar devolución</a>
            </div>
        </div>
    </div>
</asp:Content>

