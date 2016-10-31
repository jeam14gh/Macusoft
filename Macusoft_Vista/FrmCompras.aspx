<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmCompras.aspx.cs" Inherits="FrmCompras" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPForm" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="well">
                    <center><h3><strong>Compras</strong></h3></center>
                </div>
                <div class="well">
                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:"></asp:Label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlNit" runat="server" CssClass="form-control" ValidationGroup="1"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lbtnAddProveedor" runat="server" class="btn btn-default btn-md" OnClick="lbtnAddProveedor_Click" ValidationGroup="2"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Seleccione un proveedor" ControlToValidate="ddlNit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
                                <asp:DropDownList ID="ddlCategoriaCompra" runat="server" CssClass="btn-group-justified form-control" OnSelectedIndexChanged="ddlCategoriaCompra_SelectedIndexChanged" AutoPostBack="True" ValidationGroup="1"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Seleccione una categoria" ControlToValidate="ddlNit" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblCod" runat="server" Text="Nombre Producto:"></asp:Label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlCodigoPro" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lbtnAddProductos" runat="server" class="btn btn-default btn-md" OnClick="lbtnAddProductos_Click" ValidationGroup="3"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Seleccione un código" ControlToValidate="ddlNit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="lbtnRegistrar" runat="server" OnClick="lbtnRegistrar_Click" CssClass="btn btn-info" ValidationGroup="1"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                                <asp:LinkButton ID="lbtnConsultar" runat="server" OnClick="lbtnConsultar_Click" CssClass="btn btn-info"><span class="glyphicon glyphicon-search"></span>  Consultar</asp:LinkButton>
                                <asp:LinkButton ID="lbtnModificar" runat="server" OnClick="lbtnModificar_Click" CssClass="btn btn-info" Enabled="false" Visible="false"><span class="glyphicon glyphicon-refresh"></span>  Modificar</asp:LinkButton>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lbltext" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
                                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" MaxLength="2" ValidationGroup="1"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ErrorMessage="Ingrese la cantidad" ForeColor="Red" ControlToValidate="txtCantidad" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCantidad" runat="server" ErrorMessage="Ingrese sólo números.</br>" ControlToValidate="txtCantidad" Display="Dynamic" ValidationExpression="[0-9]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                                <asp:RangeValidator ID="rvCantidad" runat="server" ErrorMessage="Debe estar entre 1 a 50. " ForeColor="Red" ControlToValidate="txtCantidad" MaximumValue="50" MinimumValue="1" Display="Dynamic" ValidationGroup="1" Type="Integer"></asp:RangeValidator>

                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblValor" runat="server" Text="Valor:"></asp:Label>
                                <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" MaxLength="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvValor" runat="server" ErrorMessage="Ingrese el valor." ForeColor="Red" ControlToValidate="txtValor" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revValor" runat="server" ErrorMessage="Ingrese sólo números." ControlToValidate="txtValor" Display="Dynamic" ValidationExpression="[0-9]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblFormPag" runat="server" Text="Forma de pago:"></asp:Label>
                                <asp:TextBox ID="txtFormPag" runat="server" CssClass="form-control" MaxLength="20" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFormaPago" runat="server" ErrorMessage="Ingrese la forma de pago." ForeColor="Red" ControlToValidate="txtFormPag" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFormaPago" runat="server" ErrorMessage="Ingrese sólo letras." ControlToValidate="txtFormPag" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚüÜA-Z\s]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="lbtnAgragar" runat="server" OnClick="lbtnAgragar_Click" Text=" + " CssClass="btn btn-info" ValidationGroup="1"></asp:LinkButton>
                                <asp:LinkButton ID="lbtnRestar" runat="server" OnClick="lbtnRestar_Click" Text=" - " CssClass="btn btn-info" ValidationGroup="1"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>
                <asp:GridView ID="GvCompras" runat="server" ViewStateMode="Enabled" OnSelectedIndexChanged="GvCompras_SelectedIndexChanged"
                    CssClass="table table-hover table-striped" GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="Seleccione" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar"><span class="glyphicon glyphicon-hand-up"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <!-- Modal para agregar un nuevo producto si éste no está registrado al momento de la compra-->
            <div class="modal" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="myModalLabel">Registrar producto</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblcodProducto" runat="server" Text="Código Producto:"></asp:Label>
                                        <asp:TextBox ID="txtCodProducto" runat="server" CssClass="form-control" placeholder="*" ValidationGroup="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese un codigo o referencia" ControlToValidate="txtCodProducto" Display="Dynamic" ValidationGroup="5" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCodProducto" ErrorMessage="Ingrese solo números" ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red" ValidationGroup="5"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblCategorias" runat="server" Text="Categoria:"></asp:Label>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Seleccione una categoria" ForeColor="Red" ControlToValidate="ddlCategorias" Display="Dynamic" ValidationGroup="5"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblNombreProd" runat="server" Text="Descripcion Producto:"></asp:Label>
                                        <asp:TextBox ID="txtNombreProd" runat="server" CssClass="form-control" placeholder="*"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtNombreProd" ForeColor="Red" Display="Dynamic" ValidationGroup="5"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingrese solo letras" ControlToValidate="txtNombreProd" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[a-zA-Z\s]+$" ForeColor="Red" ValidationGroup="5"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblExistActuales" runat="server" Text="Cantidad: "></asp:Label>
                                        <asp:TextBox ID="txtExistenciaActuales" runat="server" CssClass="form-control" placeholder="*"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Ingrese la cantidad" ForeColor="Red" ControlToValidate="txtExistenciaActuales" Display="Dynamic" ValidationGroup="5"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="La cantidad es mayor al stok maximo" ForeColor="Red" ControlToValidate="txtExistenciaActuales" MaximumValue="50" MinimumValue="1" Display="Dynamic" ValidationGroup="5" Type="Integer"></asp:RangeValidator>
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
                                        <asp:TextBox ID="txtCostoCompra" runat="server" CssClass="form-control" placeholder="*" ValidationGroup="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Ingrese el costo" ForeColor="Red" ControlToValidate="txtCostoCompra" Display="Dynamic" ValidationGroup="5"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCostoCompra" ErrorMessage="Ingrese solo números" ForeColor="Red" ValidationExpression="^[0-9]*" Display="Dynamic" ValidationGroup="5"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblCostoventa" runat="server" Text="Costo Venta:"></asp:Label>
                                        <asp:TextBox ID="txtCostoVenta" runat="server" CssClass="form-control" placeholder="*"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Ingrese el valor venta" ForeColor="Red" ControlToValidate="txtCostoVenta" Display="Dynamic" ValidationGroup="5"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCostoVenta" ErrorMessage="Ingrese solo números" ForeColor="Red" ValidationExpression="^[0-9]*" Display="Dynamic" ValidationGroup="5"></asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Debe ser mayor al costo de compra" Display="Dynamic" Operator="GreaterThanEqual" ValidationGroup="5" ControlToValidate="txtCostoVenta" ControlToCompare="txtCostoCompra" ForeColor="Red" Type="Integer"></asp:CompareValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblCostoxmayor" runat="server" Text="Costo X Mayor:"></asp:Label>
                                        <asp:TextBox ID="TxtCostoXmayor" runat="server" CssClass="form-control" placeholder="*" MaxLength="7"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese el valor venta" ForeColor="Red" ControlToValidate="TxtCostoXmayor" Display="Dynamic" ValidationGroup="5"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TxtCostoXmayor" ErrorMessage="Ingrese sólo números. " ForeColor="Red" ValidationExpression="^[0-9]*" Display="Dynamic" ValidationGroup="5"></asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Debe ser mayor al costo de compra" Display="Dynamic" Operator="GreaterThanEqual" ValidationGroup="1" ControlToValidate="txtCostoVenta" ControlToCompare="txtCostoCompra" ForeColor="Red" Type="Integer"></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <asp:LinkButton ID="lbtnRegistrarProducto" runat="server" CssClass="btn btn-info" OnClick="lbtnRegistrarProducto_Click" ValidationGroup="5"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
            <!--Termina Modal -->

            <!-- Modal para agregar un nuevo proveedor si éste no está registrado al momento de la venta-->
            <div class="modal" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="H1">Registrar proveedor</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha Registro"></asp:Label>
                                        <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblNomRazSoc" runat="server" Text="Nombre / Razon Social:"></asp:Label>
                                        <asp:TextBox ID="txtNombre_RazonSocial" runat="server" CssClass="form-control" placeholder="*" ValidationGroup="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="NombrerazonSocial" runat="server" ErrorMessage="Por favor ingrese un nombre" ControlToValidate="txtNombre_RazonSocial" Display="Dynamic" ForeColor="Red" ValidationGroup="4"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Ingrese solo letras" ControlToValidate="txtNombre_RazonSocial" Display="Dynamic" ValidationExpression="^[a-zA-Z\s]+$" ForeColor="Red" ValidationGroup="4"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblNitDoc" runat="server" Text="Nit / Documento :"></asp:Label>
                                        <asp:TextBox ID="txtNit_Documento" runat="server" CssClass="form-control" placeholder="*" ValidationGroup="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="DocumentoNit" runat="server" ErrorMessage="Ingrese un número de documento" ControlToValidate="txtNit_Documento" Display="Dynamic" ForeColor="Red" ValidationGroup="4"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="Documento" runat="server" ErrorMessage="Ingrese solo números" ControlToValidate="txtNit_Documento" MaximumValue="9" MinimumValue="0" Display="Dynamic" ForeColor="Red" ValidationGroup="4"></asp:RangeValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento:"></asp:Label>
                                        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="btn-group-justified form-control" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged1" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblMunicipio" runat="server" Text="Municipio:"></asp:Label>
                                        <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="btn-group-justified form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"></asp:DropDownList>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
                                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="*" ValidationGroup="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un teléfono" ControlToValidate="txtTelefono" Display="Dynamic" ForeColor="Red" ValidationGroup="4"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Ejemplo@hotmail.com" CssClass="form-control" ValidationGroup="4"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Correo inválido" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="4"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblmensage1" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblmensage" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <asp:LinkButton ID="lbtnRegistrarProveedor" OnClick="lbtnRegistrarProveedor_Click" runat="server" CssClass="btn btn-info" ValidationGroup="4" AutoPostBack="True"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
            <!--Termina Modal -->
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

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
    </script>
</asp:Content>

