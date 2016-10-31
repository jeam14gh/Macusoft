<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmMovimientos.aspx.cs" Inherits="FrmMovimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid" id="myTab">
        <div class="page-header">
            <div class="panel-group" id="accordion">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Ventas
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse in">
                        <div class="panel-body">
                            <%--Aca es donde se diseña el formulario de ventas--%>


                            <div class="col-lg-3">
                                <%--esta es la etiqueta de apertura de la primera columna del formulario ventas--%>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblConsecutivo" runat="server" Text="Consecutivo:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtConsecutivo_venta" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblDocumento_Empleado_Venta" runat="server" Text="Doc/Empleado:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtDocumento_Empleado_Venta" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <%--Esta es la etiqueta de cierre de la primera columna--%>

                            <div class="col-lg-3">
                                <%--esta es la etiqueta de apertura de la segunda columna del formulario ventas--%>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblNombre_Razon_Venta" runat="server" Text="Nombre/Razonsocial:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNombre_Razon_Venta" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblCantidad_Producto_Venta" runat="server" Text="Cantidad:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtCantidad_Producto_Venta" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>


                            </div>
                            <%--Esta es la etiqueta de cierre de la segunda columna--%>

                            <div class="col-lg-3">
                                <%--esta es la etiqueta de apertura de la tercera columna del formulario ventas--%>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblNITDocumento_Venta" runat="server" Text="NIT/Documento:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNITDocumento_Venta" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblNombre_Producto_Venta" runat="server" Text="Nombre/Producto:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="DropDownListNombre_Producto_Venta" CssClass="form-control" runat="server"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <%--Esta es la etiqueta de cierre de la tercera columna--%>


                            <div class="col-lg-3">
                                <%--esta es la etiqueta de apertura de la cuarta columna del formulario ventas--%>


                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblAgregar_Consecutivo_Venta" runat="server" Text="Agregar/Consecutivo:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:ImageButton ID="txtAgregar_Consecutivo_Venta" runat="server" ImageUrl="~/Resources/Imagenes/iconos proyecto/AgreProduc.png"  />
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblAgregar_Producto" runat="server" Text="Agregar/Producto:"></asp:Label>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblNuevo_Producto" runat="server" Text="Nuevo/producto:"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <asp:ImageButton ID="btnAgregar_Producto_Venta" runat="server" ImageUrl="~/Resources/Imagenes/iconos proyecto/AgreProduc.png" />
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:ImageButton ID="btnNuevo_Producto_Venta" runat="server" ImageUrl="~/Resources/Imagenes/iconos proyecto/nuevoProc.png" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--Esta es la etiqueta de cierre de la cuarta columna--%>
                    </div>
                </div>

                <%--</div>--%>

                <%------------------------------------------------------------------------------------------------------------------------------------------%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Devolucion Clientes
                            </a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse">
                        <div class="panel-body">
                            <%--Aca es donde se diseña el formulario--%>

                            <div class="col-lg-4">
                                <%--esta es la etiqueta de apertura de la primera columna del formulario ventas--%>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblConsecutivo_Devolucion" runat="server" Text="Consecutivo/Devolucion:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtConsecutivo_Devolucion" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblCantidad_Producto_Devolucion" runat="server" Text="Cantidad:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtCantidad_Producto_Devolucion" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <%--Esta es la etiqueta de cierre de la primera columna--%>

                            <div class="col-lg-4">
                                <%--esta es la etiqueta de apertura de la segunda columna del formulario ventas--%>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblNIT_Documento_Devolucion_Cliente" runat="server" Text="NIT/Documento:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNIT_Documento_Devolucion_Cliente" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblNombre_Producto_Devolucion" runat="server" Text="Nombre/Producto:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="DropDownList1Nombre_Producto_Devolucion" CssClass="form-control" runat="server"></asp:DropDownList>

                                    </div>
                                </div>


                            </div>
                            <%--Esta es la etiqueta de cierre de la segunda columna--%>

                            <div class="col-lg-4">
                                <%--esta es la etiqueta de apertura de la tercera columna del formulario ventas--%>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Label ID="lblMotivo_Devolucion_Cliente" runat="server" Text="Motivo/Devolucion:"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtMotivo_Devolucion_Cliente" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="col-lg-5">
                                        <asp:Label ID="lblAgregar_Producto_Devolucion" runat="server" Text="Agregar/Producto:"></asp:Label>
                                    </div>


                                    <div class="col-lg-9">
                                        <asp:ImageButton ID="btnAgregar_Producto_Devolucion" runat="server" ImageUrl="~/Resources/Imagenes/iconos proyecto/AgreProduc.png" />
                                    </div>

                                </div>
                            </div>
                            <%--Esta es la etiqueta de cierre de la tercera columna--%>
                        </div>

                    </div>
                </div>

                <%-----------------------------------------------------------------------------------------------------------------------------%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Compras
                            </a>
                        </h4>
                    </div>
                    <div id="collapseThree" class="panel-collapse collapse">
                        <div class="panel-body">
                            <%--Aca es donde se diseña el formulario--%>
                        </div>
                    </div>
                </div>
                <%--------------------------------------------------------------------------------------------------------------------------------------%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapsefour">Devolucion Proveedores
                            </a>
                        </h4>
                    </div>
                    <div id="collapsefour" class="panel-collapse collapse">
                        <div class="panel-body">
                            <%--Aca es donde se diseña el formulario--%>
                        </div>
                    </div>
                </div>
                <%----------------------------------------------------------------------------------------------------------------------------------------------%>
            </div>
        </div>
    </div>
</asp:Content>

