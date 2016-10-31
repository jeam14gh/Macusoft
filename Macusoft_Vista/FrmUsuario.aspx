<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmUsuario.aspx.cs" Inherits="FrmUsuario" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPForm" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="well">
                    <center><strong><h3>Gestión de usuarios</h3></strong></center>
                </div>
                <div class="well">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha Registro:"></asp:Label>
                                <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                                <asp:TextBox ID="txtfecha_Nacimiento" runat="server" CssClass="form-control" placeholder="*" MaxLength="10" ValidationGroup="1"></asp:TextBox>
                                <asp:CalendarExtender ID="ceFechaNac" TargetControlID="txtfecha_Nacimiento" runat="server" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ErrorMessage="Ingrese una fecha" ControlToValidate="txtfecha_Nacimiento" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFechaNac" runat="server" ErrorMessage="Fecha inválida" ControlToValidate="txtfecha_Nacimiento" ValidationExpression="(0[1-9]|[12][0-9]|3[01])\/([0][1-9]|[1][0-2])\/(1[9]|2[0])[0-9]{2}" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                           
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblNombre_Empleado" runat="server" Text="Nombre Empleado:"></asp:Label>
                                <asp:TextBox ID="txtNombre_Empleado" runat="server" CssClass="form-control" placeholder="*" MaxLength="20" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNomEmpleado" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtNombre_Empleado" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNomEmpleado" runat="server" ErrorMessage="Ingrese sólo letras" ControlToValidate="txtNombre_Empleado" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚÜüA-Z\s]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblApellido_Empleado" runat="server" Text="Apellido Empleado:"></asp:Label>
                                <asp:TextBox ID="txtApellido_Empleado" runat="server" CssClass="form-control" placeholder="*" MaxLength="20" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvApellidoEmp" runat="server" ErrorMessage="Ingrese un apellido" ControlToValidate="txtApellido_Empleado" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revApellidoEmp" runat="server" ErrorMessage="Ingrese sólo letras" ControlToValidate="txtApellido_Empleado" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚÜüA-Z\s]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblNDocumento" runat="server" Text="No Documento:"></asp:Label>
                                <asp:TextBox ID="txtNumero_Documento" runat="server" CssClass="form-control" placeholder="*" MaxLength="15" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDoc" runat="server" ErrorMessage="Ingrese un documento" ControlToValidate="txtNumero_Documento" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revDoc" runat="server" ControlToValidate="txtNumero_Documento" ErrorMessage="Ingrese sólo números" ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:LinkButton ID="lbtnRegistrarUsuario" runat="server" OnClick="lbtnRegistrarUsuario_Click" CssClass="btn btn-info" ValidationGroup="1"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                                <asp:LinkButton ID="lbtnActualizar" runat="server" OnClick="lbtnActualizar_Click" CssClass="btn btn-info" ValidationGroup="8" Visible="false"> <span class="glyphicon glyphicon-refresh"></span>  Actualizar</asp:LinkButton>
                                <asp:LinkButton ID="lbtnNuevo" runat="server" OnClick="lbtnNuevo_Click" CssClass="btn btn-info"><span class="glyphicon glyphicon-share"></span>  Nuevo</asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lblMunicipio" runat="server" Text="Municipio:"></asp:Label>
                                <asp:DropDownList ID="DropDownListMunicipio" runat="server" CssClass="form-control" placeholder="*" ValidationGroup="1"></asp:DropDownList>


                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblDireccion_Empleado" runat="server" Text="Dirección:"></asp:Label>
                                <asp:TextBox ID="txtDireccion_Empleado" runat="server" CssClass="form-control" placeholder="*" MaxLength="40" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDireccionEmp" runat="server" ErrorMessage="Ingrese una dirección" ControlToValidate="txtDireccion_Empleado" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblTelefono_Empleado" runat="server" Text="Teléfono:"></asp:Label>
                                <asp:TextBox ID="txtTelefono_Empleado" runat="server" CssClass="form-control" placeholder="*" MaxLength="15" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTelefonoEmp" runat="server" ErrorMessage="Ingrese un teléfono" ControlToValidate="txtTelefono_Empleado" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revTelefonoEmp" runat="server" ErrorMessage="Télefono inválido." ControlToValidate="txtTelefono_Empleado" Display="Dynamic" ValidationExpression="^[0-9]{6,10}((\s[a-zA-Z]{3})(\s[0-9]{2,3}))?" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblEmail_Empleado" runat="server" Text="Email:"></asp:Label>
                                <asp:TextBox ID="txtEmail_Empleado" runat="server" CssClass="form-control" placeholder="* Ejemplo@hotmail.com" MaxLength="50" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmailEmp" runat="server" ErrorMessage="Ingrese un Email" ControlToValidate="txtEmail_Empleado" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmailEmp" runat="server" ErrorMessage="Correo inválido" ControlToValidate="txtEmail_Empleado" Display="Dynamic" ForeColor="Red" ValidationExpression="[a-zA-Z0-9]+[.|\-|_a-zA-Z0-9]*\@[a-zA-Z]{3,7}\.[a-zA-Z]{2,3}" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblRegistrado" runat="server" Text="" ForeColor="Green"></asp:Label>
                                <asp:Label ID="lblRegistradoError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lblSucursal" runat="server" Text="Sucursal:"></asp:Label>
                                <div class="input-group">
                                    <asp:DropDownList ID="DropDownListSucursal" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lbtnAddProveedor" runat="server" class="btn btn-default btn-md" OnClick="lbtnAddProveedor_Click" ValidationGroup="2"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese una sucursal" ControlToValidate="DropDownListSucursal" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblUsuario" runat="server" Text="Nombre Usuario:"></asp:Label>
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="*" MaxLength="20" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNomUsuario" runat="server" ErrorMessage="Ingrese un nombre de usuario" ControlToValidate="txtUsuario" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNomUsuario" runat="server" ErrorMessage="Ingrese sólo letras y números" ControlToValidate="txtUsuario" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblContarseña" runat="server" Text="Contraseña:"></asp:Label>
                                <asp:TextBox TextMode="Password" ID="txtContarsenia" runat="server" CssClass="form-control" placeholder="*" MaxLength="15" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvContrasena1" runat="server" ErrorMessage="Ingrese una contraseña. " ControlToValidate="txtContarsenia" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revContrasena1" runat="server" ErrorMessage="Ingrese sólo letras y números. " ControlToValidate="txtContarsenia" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblConfirmarContraseña" runat="server" Text="Confirmar Contraseña:"></asp:Label>
                                <asp:TextBox TextMode="Password" ID="txtConfirmarContraseña" runat="server" CssClass="form-control" placeholder="*" MaxLength="15" ValidationGroup="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvContrasena2" runat="server" ErrorMessage="Confirmar contraseña. " ControlToValidate="txtConfirmarContraseña" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revContrasena2" runat="server" ErrorMessage="Ingrese sólo letras y números." ControlToValidate="txtConfirmarContraseña" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]+$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvContrasena" runat="server" ErrorMessage="Contraseña diferente" ControlToValidate="txtConfirmarContraseña" ControlToCompare="txtContarsenia" ForeColor="Red" Type="String" ValidationGroup="1"></asp:CompareValidator>

                                <div class="row">
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblCargo" runat="server" Text="Cargo:"></asp:Label>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                            <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
                                            <asp:ListItem Value="Vendedor">Vendedor</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                                            <asp:ListItem Value="Habilitado">Habilitado</asp:ListItem>
                                            <asp:ListItem Value="Inhabilitado">Inhabilitado</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="table-responsive">
                            <asp:GridView ID="GridViewListarUsuarios" DataKeyNames="Documento_Empleado" runat="server" CssClass="table table-hover table-striped table table-bordered" PageSize="5" AllowPaging="true" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewListarUsuarios_SelectedIndexChanged" OnPageIndexChanging="GridViewListarUsuarios_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Seleccione" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnSeleccione" runat="server" CausesValidation="False" Text="Seleccionar" CommandName="Select"><span class="glyphicon glyphicon-hand-up"></span></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Documento_Empleado" HeaderText="Documento" Visible="false"/>
                                    <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha Registro" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                                    <asp:BoundField DataField="Email" HeaderText="Correo Electrónico" />
                                    <asp:BoundField DataField="Fecha_Nacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}"/>
                                    <asp:BoundField DataField="Nombre_Municipio" HeaderText="Municipio" />
                                    <asp:BoundField DataField="Nombre_Surculsal" HeaderText="Almacén" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Perfil" HeaderText="Perfil" />
                                    <asp:BoundField DataField="Id_Surculsal" HeaderText="Surcursal" />
                                    <asp:BoundField DataField="Id_Municipio" HeaderText="Municipio" />
                                </Columns>
                                <PagerStyle CssClass="pager-custom" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <%--Empiesa el modal--%>
            <div class="modal" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="H1">Registrar sucursal</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblNombreSucursal" runat="server" Text="Nombre Sucursal:"></asp:Label>
                                        <asp:TextBox ID="txtNombreSucursal" runat="server" CssClass="form-control" placeholder="*" MaxLength="30" ValidationGroup="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSucursal" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="txtNombreSucursal" Display="Dynamic" ForeColor="Red" ValidationGroup="3"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revSucursal" runat="server" ErrorMessage="Ingrese sólo letras" ControlToValidate="txtNombreSucursal" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚÜüA-Z\s]+$" ForeColor="Red" ValidationGroup="3"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblTelefonoSucursal" runat="server" Text="Telefono:"></asp:Label>
                                        <asp:TextBox ID="txtTelefonoSucursal" runat="server" CssClass="form-control" placeholder="*" MaxLength="15" ValidationGroup="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvTelSucursal" runat="server" ErrorMessage="Ingrese un teléfono" ControlToValidate="txtTelefonoSucursal" Display="Dynamic" ForeColor="Red" ValidationGroup="3"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revTelSucursal" runat="server" ErrorMessage="Télefono inválido." ControlToValidate="txtTelefonoSucursal" Display="Dynamic" ValidationExpression="^[0-9]{6,10}((\s[a-zA-Z]{3})(\s[0-9]{2,3}))?" ForeColor="Red" ValidationGroup="3"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblDirecionSucursal" runat="server" Text="Direccion:"></asp:Label>
                                        <asp:TextBox ID="txtDireccionSucursal" runat="server" CssClass="form-control" placeholder="*" MaxLength="30" ValidationGroup="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Ingrese una dirección" ControlToValidate="txtDireccionSucursal" Display="Dynamic" ForeColor="Red" ValidationGroup="3"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="GvSucursal" runat="server" CssClass="table table-hover table-striped" GridLines="None">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblmensageModal" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <asp:LinkButton ID="lbtnRegistrarSucursal" runat="server" OnClick="lbtnRegistrarSucursal_Click" CssClass="btn btn-info" ValidationGroup="3"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
            <%--Termina el modal--%>
            </span>
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
