<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmProductos.aspx.cs" Inherits="FrmProductos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPForm" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="well">
                    <center><strong><h3>Gestión de productos</h3></strong></center>
                </div>
                <div class="well">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblcodProducto" runat="server" Text="Referencia Producto:"></asp:Label>
                                <asp:TextBox ID="txtCodProducto" runat="server" CssClass="form-control" placeholder="*" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCodProducto" runat="server" ErrorMessage="Ingrese un código" ControlToValidate="txtCodProducto" Display="Dynamic" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCodProducto" runat="server" ControlToValidate="txtCodProducto" ErrorMessage="Ingrese sólo números" ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblCategorias" runat="server" Text="Categoria:"></asp:Label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lbtnAddCategoria" runat="server" OnClick="lbtnAddCategoria_Click" class="btn btn-default btn-md"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                    </span>
                                </div>
                                <asp:CustomValidator ID="cvCategoria" runat="server" ErrorMessage="Seleccione una categoria" ForeColor="Red" ControlToValidate="ddlCategorias" ValidateEmptyText="true" ClientValidationFunction="validaDDL" Display="Dynamic" ValidationGroup="1"></asp:CustomValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblNombreProd" runat="server" Text="Descripcion Producto:"></asp:Label>
                                <asp:TextBox ID="txtNombreProd" runat="server" CssClass="form-control" placeholder="*" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNomProducto" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtNombreProd" ForeColor="Red" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNomProducto" runat="server" ErrorMessage="Ingrese sólo letras" ControlToValidate="txtNombreProd" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚüÜA-Z\s]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblExistActuales" runat="server" Text="Cantidad:"></asp:Label>
                                <asp:TextBox ID="txtExistenciaActuales" runat="server" CssClass="form-control" placeholder="*" MaxLength="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ErrorMessage="Ingrese la cantidad" ForeColor="Red" ControlToValidate="txtExistenciaActuales" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCantidad" runat="server" ErrorMessage="Ingrese sólo números.</br>" ControlToValidate="txtExistenciaActuales" Display="Dynamic" ValidationExpression="[0-9]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                                <asp:RangeValidator ID="rvCantidad" runat="server" ErrorMessage="Debe estar entre 1 a 50. " ForeColor="Red" ControlToValidate="txtExistenciaActuales" MaximumValue="50" MinimumValue="1" Display="Dynamic" ValidationGroup="1" Type="Integer"></asp:RangeValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblStockMinimo" runat="server" Text="Stock Mínimo:"></asp:Label>
                                <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control" Text="10" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblStockMaximo" runat="server" Text="Stock Máximo:"></asp:Label>
                                <asp:TextBox ID="txtStockMaximo" runat="server" CssClass="form-control" Text="50" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblCostoCompra" runat="server" Text="Costo Compra:"></asp:Label>
                                <asp:TextBox ID="txtCostoCompra" runat="server" CssClass="form-control" placeholder="*" MaxLength="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCompra" runat="server" ErrorMessage="Ingrese el costo. " ForeColor="Red" ControlToValidate="txtCostoCompra" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCompra" runat="server" ControlToValidate="txtCostoCompra" ErrorMessage="Ingrese sólo números." ForeColor="Red" ValidationExpression="^[0-9]*" Display="Dynamic" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblCostoventa" runat="server" Text="Costo Venta:"></asp:Label>
                                <asp:TextBox ID="txtCostoVenta" runat="server" CssClass="form-control" placeholder="*" MaxLength="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvVenta" runat="server" ErrorMessage="Ingrese el valor venta" ForeColor="Red" ControlToValidate="txtCostoVenta" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revVenta" runat="server" ControlToValidate="txtCostoVenta" ErrorMessage="Ingrese sólo números. " ForeColor="Red" ValidationExpression="^[0-9]*" Display="Dynamic" ValidationGroup="1"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvVenta" runat="server" ErrorMessage="Debe ser mayor al costo de compra" Display="Dynamic" Operator="GreaterThanEqual" ValidationGroup="1" ControlToValidate="txtCostoVenta" ControlToCompare="txtCostoCompra" ForeColor="Red" Type="Integer"></asp:CompareValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblCostoxmayor" runat="server" Text="Costo X Mayor:"></asp:Label>
                                <asp:TextBox ID="TxtCostoXmayor" runat="server" CssClass="form-control" placeholder="*" MaxLength="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese el valor venta" ForeColor="Red" ControlToValidate="TxtCostoXmayor" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtCostoXmayor" ErrorMessage="Ingrese sólo números. " ForeColor="Red" ValidationExpression="^[0-9]*" Display="Dynamic" ValidationGroup="1"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Debe ser mayor al costo de compra" Display="Dynamic" Operator="GreaterThanEqual" ValidationGroup="1" ControlToValidate="txtCostoVenta" ControlToCompare="txtCostoCompra" ForeColor="Red" Type="Integer"></asp:CompareValidator>
                            </div>


                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:LinkButton ID="lbtnRegistrar" runat="server" OnClick="lbtnRegistrar_Click" CssClass="btn btn-info" ValidationGroup="1"><span class="glyphicon glyphicon-floppy-disk" ></span>  Registrar</asp:LinkButton>
                            <asp:LinkButton ID="lbtnConsultar" runat="server" OnClick="lbtnConsultar_Click" CssClass="btn btn-info"><span class="glyphicon glyphicon-search"></span>  Consultar</asp:LinkButton>
                            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="co-l-md-12">
                    <div class="table-responsive">
                        <asp:GridView ID="GridViewListarProductos" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped table table-bordered" GridLines="None" PageSize="5" AllowPaging="true" OnPageIndexChanging="GridViewListarProductos_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Cod_Producto" HeaderText="Código Producto" />
                                <asp:BoundField DataField="Id_Categoria" HeaderText="Codigo categoria" />
                                <asp:BoundField DataField="Nombre_Categoria" HeaderText="Nombre Categoria" />
                                <asp:BoundField DataField="Nombre_Producto" HeaderText="Nombre Producto" />
                                <asp:BoundField DataField="Existencias_Actuales" HeaderText="Existencias Actuales" />
                                <asp:BoundField DataField="Stock_Minimo" HeaderText="Stock Mínimo" />
                                <asp:BoundField DataField="Stock_Maximo" HeaderText="Stock Máximo" />
                                <asp:BoundField DataField="Costo_Compra" HeaderText="Costo Compra" />
                                <asp:BoundField DataField="Costo_Venta" HeaderText="Costo Venta" />
                                <asp:BoundField DataField="Promedio" HeaderText="Valor promedio" />
                                <asp:BoundField DataField="CostoXMayor" HeaderText="Costo por mayor" />
                            </Columns>
                            <PagerStyle CssClass="pager-custom" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <%--<modal>--%>
            <div class="modal" id="myModal" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="myModalLabel">Registar categoría</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Nombre categoría: "></asp:Label>
                                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" placeholder="*" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNomCategoria" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtCategoria" ForeColor="Red" Display="Dynamic" ValidationGroup="2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNomCategoria" runat="server" ErrorMessage="Ingrese sólo letras" ControlToValidate="txtCategoria" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚüÜA-Z\s]+$" ForeColor="Red" ValidationGroup="2"></asp:RegularExpressionValidator>
                                <asp:Label ID="lblMensajeCat" runat="server" Text="" ForeColor="Green"></asp:Label>
                                <asp:Label ID="lblerrorcat" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="LbtnRegistrarCategoria" runat="server" OnClick="LbtnRegistrarCategoria_Click" CssClass="btn btn-info" ValidationGroup="2"><span class="glyphicon glyphicon-floppy-disk" ></span>  Registrar</asp:LinkButton>
                            <asp:LinkButton ID="lbtnCerrar" runat="server" CssClass="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancelar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <%--</modal>--%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--Funciones de javascript para el Modal de bootstrap--%>
    <script type="text/javascript">

        function AbrirModal(NombreModal) {
            $(NombreModal).modal('show');
        }

        function CerrarModal(NombreModal) {
            $(NombreModal).modal('hide');
        }

        function CerrarModalUpdatePanel() {
            $('.modal-backdrop').remove();
            $('body').removeClass('modal-open');
        }

        function validaDDL(source, arguments) {
            if (arguments.Value < 1) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }
        }
    </script>
</asp:Content>

