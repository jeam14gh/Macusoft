<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmVentas.aspx.cs" Inherits="FrmVentas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPForm" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="well">
                    <center><h3><strong>VENTAS</strong></h3></center>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblConsecutivo" runat="server" Text="Consecutivo:"></asp:Label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtConsecutivo" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbtnAddConsecutivo" runat="server" OnClick="lbtnAddConsecutivo_Click" CausesValidation="false" class="btn btn-default btn-md"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                        </span>
                                    </div>
                                    <asp:Label ID="Restantes" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblDocNit" runat="server" Text="Documento / NIT:"></asp:Label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtDocNit" runat="server" CssClass="form-control" MaxLength="15" ValidationGroup="1"></asp:TextBox>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServicePath="~/WebServiceNombreRazSoc.asmx"
                                            MinimumPrefixLength="1" ServiceMethod="GetDocNit " EnableCaching="true" TargetControlID="txtDocNit"
                                            UseContextKey="True" CompletionSetCount="10" CompletionInterval="0">
                                        </asp:AutoCompleteExtender>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbtnBuscar" runat="server" CausesValidation="false" OnClick="lbtnBuscar_Click" class="btn btn-default btn-md"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvNitDoc" runat="server" ErrorMessage="Ingrese un número de documento" ControlToValidate="txtDocNit" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revNitDoc" runat="server" ControlToValidate="txtDocNit" ErrorMessage="Ingrese sólo números" ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblNombreRazSoc" runat="server" Text="Nombre / Razón Social:"></asp:Label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtNomRazSoc" runat="server" CssClass="form-control" MaxLength="40" ValidationGroup="1"></asp:TextBox>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServicePath="~/WebServiceNombreRazSoc.asmx"
                                            MinimumPrefixLength="1" ServiceMethod="GetNombreRazSoc " EnableCaching="true" TargetControlID="txtNomRazSoc"
                                            UseContextKey="True" CompletionSetCount="10" CompletionInterval="0">
                                        </asp:AutoCompleteExtender>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbtnAddCliente" runat="server" CausesValidation="false" OnClick="lbtnAddCliente_Click" class="btn btn-default btn-md"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtNomRazSoc" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Ingrese solo letras" ControlToValidate="txtNomRazSoc" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[a-zA-Z\s]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="lblDocEmpleado" runat="server" Text="Documento Empleado:"></asp:Label>
                                    <asp:TextBox ID="txtDocEmpleado" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--Panel de detalle--%>
                        <div class="row" style="padding: 10px 10px">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <center><h3 class="panel-title"><strong>Detalle de Venta</strong></h3></center>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
                                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn-group-justified form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" ValidationGroup="detalle"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Seleccione una categoria" ControlToValidate="ddlCategoria" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <asp:Label ID="lblProducto" runat="server" Text="Descripcion Producto:"></asp:Label>
                                                <asp:DropDownList ID="ddlProductos" runat="server" CssClass="btn-group-justified form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Seleccione un producto" ControlToValidate="ddlProductos" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Label ID="lblCargo" runat="server" Text="Tipo Venta:"></asp:Label>
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                <asp:ListItem Value="Publico">Publico</asp:ListItem>
                                                <asp:ListItem Value="Pormayor">Por mayor</asp:ListItem>                  
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-md-1">
                                            <div class="form-group">
                                                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
                                                <asp:TextBox ID="txtCAntidad" runat="server" CssClass="form-control" ValidationGroup="1" AutoPostBack="True" OnTextChanged="txtCAntidad_TextChanged" placeholder="0" MaxLength="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese una cantidad" ControlToValidate="txtCAntidad" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ingrese solo números" ControlToValidate="txtCAntidad" MaximumValue="9" MinimumValue="1" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RangeValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Label ID="lblPrecioVenta" runat="server" Text="Precio:"></asp:Label>
                                                <asp:TextBox ID="txtPrecioVenta" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <asp:Button ID="btnAgregarDetalle" runat="server" Text="Agregar detalle" OnClick="btnAgregarDetalle_Click" CssClass="btn btn-primary btn-xs btn-block" ValidationGroup="1" />
                                                <asp:Button ID="btnModificarDetalle" runat="server" Text="Modificar" Visible="false" CssClass="btn btn-primary btn-xs btn-block" OnClick="btnModificarDetalle_Click" />
                                                <asp:Button ID="btnQuitarDetalle" runat="server" Text="Quitar detalle" OnClick="btnQuitarDetalle_Click" CssClass="btn btn-primary btn-xs btn-block" Visible="false" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="table-responsive">
                                <asp:GridView ID="GridViewDetalleVenta" runat="server" CssClass="table" GridLines="None" OnSelectedIndexChanged="GridViewDetalleVenta_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                        <%--Termina panel de detalle--%>

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Descuento:"></asp:Label>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlDescuento" CssClass="form-control" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbtnDescuento" runat="server" OnClick="lbtnDescuento_Click" CausesValidation="False" class="btn btn-default btn-md"><span class="glyphicon glyphicon-usd"></span>  Aplicar</asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Total a Pagar:"></asp:Label>
                                    <asp:TextBox ID="txtTotalPagar" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:LinkButton ID="lbtnRegistrar" runat="server" CssClass="btn btn-info" OnClick="lbtnRegistrar_Click" ValidationGroup="1"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <center>
                    <div class="row">
                        <div class="col-md-12">
                          <asp:Label ID="lblmsj" runat="server" Text="" ForeColor="red"></asp:Label>
                          <asp:Label ID="lblmsj2" runat="server" Text="" ForeColor="Green" Visible="false"></asp:Label>                            
                        </div>
                    </div>
                  </center>
                </div>
            </div>
            <!-- Modal para agregar un nuevo cliente si éste no está registrado al momento de la venta-->
            <div class="modal" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="myModalLabel">Registrar Cliente</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha Registro"></asp:Label>
                                        <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblNombre_RazSoc" runat="server" Text="Nombre / Razon Social:"></asp:Label>
                                        <asp:TextBox ID="txtNombre_RazonSocial" runat="server" CssClass="form-control" placeholder="*" MaxLength="40" ValidationGroup="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNomRasSoc" runat="server" ErrorMessage="Ingrese un nombre." ControlToValidate="txtNombre_RazonSocial" Display="Dynamic" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revNomRasSoc" runat="server" ErrorMessage="Ingrese sólo letras." ControlToValidate="txtNombre_RazonSocial" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚÜüA-Z\s]+$" ForeColor="Red" ValidationGroup="2"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblNitDoc" runat="server" Text="Nit / Documento :"></asp:Label>
                                        <asp:TextBox ID="txtNit_Documento" runat="server" CssClass="form-control" placeholder="*" MaxLength="15" ValidationGroup="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDocNit" runat="server" ErrorMessage="Ingrese un número de documento." ControlToValidate="txtNit_Documento" Display="Dynamic" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revDocNit" runat="server" ControlToValidate="txtNit_Documento" ErrorMessage="Ingrese sólo números." ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red" ValidationGroup="2"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblFechaCumple" runat="server" Text="Fecha Cumpleaños: "></asp:Label>
                                        <asp:TextBox ID="txtFechaCumpleanos" runat="server" CssClass="form-control" placeholder="*" MaxLength="20" ValidationGroup="2"></asp:TextBox>
                                        <asp:CalendarExtender ID="ceFechaCumple" Format="dd/MM/yyyy" TargetControlID="txtFechaCumpleanos" runat="server"></asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="rfvFechaCumple" runat="server" ErrorMessage="Ingrese una fecha" ControlToValidate="txtFechaCumpleanos" Display="Dynamic" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revFechaCumple" runat="server" ErrorMessage="Fecha inválida" ControlToValidate="txtFechaCumpleanos" ValidationExpression="(0[1-9]|[12][0-9]|3[01])\/([0][1-9]|[1][0-2])\/(1[9]|2[0])[0-9]{2}" Display="Dynamic" ForeColor="Red" ValidationGroup="2"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento:"></asp:Label>
                                        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="btn-group-justified form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AppendDataBoundItems="true" ValidationGroup="2"></asp:DropDownList>
                                        <asp:CustomValidator ID="cvDpto" runat="server" ErrorMessage="Seleccione un departamento" ForeColor="Red" ControlToValidate="ddlDepartamento" ValidateEmptyText="true" ClientValidationFunction="validaDDL" Display="Dynamic" ValidationGroup="2"></asp:CustomValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblMunicipio" runat="server" Text="Municipio: "></asp:Label>
                                        <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="btn-group-justified form-control" AppendDataBoundItems="true" Enabled="false" ValidationGroup="2"></asp:DropDownList>
                                        <asp:CustomValidator ID="cvMunicipio" runat="server" ErrorMessage="Seleccione un municipio" ForeColor="Red" ControlToValidate="ddlMunicipio" ValidateEmptyText="true" ClientValidationFunction="validaDDL" Display="Dynamic" ValidationGroup="2"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
                                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="*" MaxLength="15" ValidationGroup="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="Ingrese un teléfono" ControlToValidate="txtTelefono" Display="Dynamic" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ErrorMessage="Télefono inválido." ControlToValidate="txtTelefono" Display="Dynamic" ValidationExpression="^[0-9]{6,10}((\s[a-zA-Z]{3})(\s[0-9]{2,3}))?" ForeColor="Red" ValidationGroup="2"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Ejemplo@hotmail.com" CssClass="form-control" MaxLength="60" ValidationGroup="2"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Correo inválido" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="[a-zA-Z0-9]+[.|\-|_a-zA-Z0-9]*\@[a-zA-Z]{3,7}\.[a-zA-Z]{2,3}"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <asp:LinkButton ID="lbtnRegistrarCliente" runat="server" OnClick="lbtnRegistrarCliente_Click" CssClass="btn btn-info" ValidationGroup="2"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                            <asp:LinkButton ID="lbtnCerrarModal" runat="server" CssClass="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span> Cancelar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <!--Termina Modal -->

            <%--Modal de registro del cosecutivo de la dian--%>
            <div class="modal" id="Mymodal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="H1">Registrar consecutivo</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblRango_inicial">Rango Inicial: </asp:Label>
                                        <asp:TextBox ID="txtRango_inicial" runat="server" CssClass="form-control" MaxLength="10" ValidationGroup="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRangoInicial" runat="server" ErrorMessage="Ingrese un rango inicial. " ForeColor="Red" ControlToValidate="txtRango_inicial" Display="Dynamic" ValidationGroup="3"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revRangoInicial" runat="server" ControlToValidate="txtRango_inicial" ErrorMessage="Ingrese sólo números." ForeColor="Red" ValidationExpression="^[0-9]*" Display="Dynamic" ValidationGroup="3"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblRango_Final">Rango Final: </asp:Label>
                                        <asp:TextBox ID="txtRango_Final" runat="server" CssClass="form-control" MaxLength="10" ValidationGroup="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRangoFinal" runat="server" ErrorMessage="Ingrese un rango final. " ForeColor="Red" ControlToValidate="txtRango_Final" Display="Dynamic" ValidationGroup="3"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revRangoFinal" runat="server" ControlToValidate="txtRango_Final" ErrorMessage="Ingrese sólo números.</br>" ForeColor="Red" ValidationExpression="^[0-9]*" Display="Dynamic" ValidationGroup="3"></asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="cvRiYRf" runat="server" ErrorMessage="Debe ser mayor al rango inicial" Display="Dynamic" Operator="GreaterThan" ValidationGroup="3" ControlToValidate="txtRango_Final" ControlToCompare="txtRango_inicial" ForeColor="Red" Type="Integer"></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblmensageModal" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <asp:LinkButton ID="lbtnRegistrarConsecutivo" runat="server" OnClick="lbtnRegistrarConsecutivo_Click" CssClass="btn btn-info" ValidationGroup="3"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                            <asp:LinkButton ID="lbtnCancelarDian" runat="server" CssClass="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span> Cancelar</asp:LinkButton>

                        </div>
                    </div>
                </div>
            </div>
            <%--Termina el modal--%>
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

        //$('#btnAgregarDetalle').tooltip(options)

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

