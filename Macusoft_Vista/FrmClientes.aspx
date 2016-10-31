﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmClientes.aspx.cs" Inherits="FrmClientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPForm" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="well">
                    <center><strong><h3>Gestión de clientes</h3></strong></center>
                </div>
                <div class="well">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha Registro"></asp:Label>
                                <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblNombre_RazSoc" runat="server" Text="Nombre / Razon Social:"></asp:Label>
                                <asp:TextBox ID="txtNombre_RazonSocial" runat="server" CssClass="form-control" placeholder="*" MaxLength="40"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNomRasSoc" runat="server" ErrorMessage="Ingrese un nombre." ControlToValidate="txtNombre_RazonSocial" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNomRasSoc" runat="server" ErrorMessage="Ingrese sólo letras." ControlToValidate="txtNombre_RazonSocial" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚÜüA-Z\s]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblNitDoc" runat="server" Text="Nit / Documento :"></asp:Label>
                                <asp:TextBox ID="txtNit_Documento" runat="server" CssClass="form-control" placeholder="*" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNitDoc" runat="server" ErrorMessage="Ingrese un número de documento." ControlToValidate="txtNit_Documento" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNitDoc" runat="server" ControlToValidate="txtNit_Documento" ErrorMessage="Ingrese sólo números." ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblFechaCumple" runat="server" Text="Fecha Cumpleaños: "></asp:Label>
                                <asp:TextBox ID="txtFechaCumpleanos" runat="server" CssClass="form-control" placeholder="*" MaxLength="10"></asp:TextBox>
                                <asp:CalendarExtender ID="ceFechaCumple" Format="dd/MM/yyyy" TargetControlID="txtFechaCumpleanos" runat="server"></asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaCumple" runat="server" ErrorMessage="Ingrese una fecha.</br>" ControlToValidate="txtFechaCumpleanos" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFechaCumple" runat="server" ErrorMessage="Fecha inválida" ControlToValidate="txtFechaCumpleanos" ValidationExpression="(0[1-9]|[12][0-9]|3[01])\/([0][1-9]|[1][0-2])\/(1[9]|2[0])[0-9]{2}" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                           
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblDepartamento" runat="server" Text="Departamento:"></asp:Label>
                                <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="btn-group-justified form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:CustomValidator ID="cvDpto" runat="server" ErrorMessage="Seleccione un departamento" ForeColor="Red" ControlToValidate="ddlDepartamento" ValidateEmptyText="true" ClientValidationFunction="validaDDL" Display="Dynamic"></asp:CustomValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblMunicipio" runat="server" Text="Municipio: "></asp:Label>
                                <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="btn-group-justified form-control" AppendDataBoundItems="true" Enabled="false"></asp:DropDownList>
                                <asp:CustomValidator ID="cvMunicipio" runat="server" ErrorMessage="Seleccione un municipio" ForeColor="Red" ControlToValidate="ddlMunicipio" ValidateEmptyText="true" ClientValidationFunction="validaDDL" Display="Dynamic"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="*" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="Ingrese un teléfono" ControlToValidate="txtTelefono" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ErrorMessage="Télefono inválido." ControlToValidate="txtTelefono" Display="Dynamic" ValidationExpression="^[0-9]{6,10}((\s[a-zA-Z]{3})(\s[0-9]{2,3}))?" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Ejemplo@hotmail.com" CssClass="form-control" MaxLength="60"></asp:TextBox>
                               <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Correo inválido" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="[a-zA-Z0-9]+[.|\-|_a-zA-Z0-9]*\@[a-zA-Z]{3,7}\.[a-zA-Z]{2,3}"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:LinkButton ID="lbtnRegistrarCliente" runat="server" OnClick="lbtnRegistrarCliente_Click" CssClass="btn btn-info"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                                <asp:LinkButton ID="lbtnConsultar" runat="server" OnClick="lbtnConsultar_Click1" CssClass="btn btn-info" CausesValidation="True" ValidationGroup="2"><span class="glyphicon glyphicon-search"></span>  Consultar</asp:LinkButton>
                                <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Green"></asp:Label>
                                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="GridViewListarClientes" runat="server" ViewStateMode="Enabled" CssClass="table table-hover table-striped table table-bordered" AutoGenerateColumns="False" PageSize="5" AllowPaging="true" OnPageIndexChanging="GridViewListarClientes_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha Registro" />
                                <asp:BoundField DataField="Nombre_RazonSocial" HeaderText="Nombre / Razón Social" />
                                <asp:BoundField DataField="Documento_Nit" HeaderText="Nit / Documento" />
                                <asp:BoundField HeaderText="Fecha Cumpleaños" DataField="Fecha_Cumpleanos" />
                                <asp:BoundField DataField="Nombre_Departamento" HeaderText="Departamento" />
                                <asp:BoundField DataField="Nombre_Municipio" HeaderText="Municipio" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                            </Columns>
                            <PagerStyle CssClass="pager-custom" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--Funcion de javascript para validar la selección de un departamento y un municipio--%>
    <script type="text/javascript">
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

