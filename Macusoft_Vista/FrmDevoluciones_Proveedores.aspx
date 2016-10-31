<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmDevoluciones_Proveedores.aspx.cs" Inherits="FrmDevoluciones_Proveedores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPForm" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="well">
                    <center><strong><h3>Devolucion proveedores</h3></strong></center>
                </div>
                <div class="well">
                    <div class="row">
                        <div class="col-lg-2">
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="LblCedulaProveedor" runat="server" Text="Documento/Nit: "> </asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="TxtNitProveedor" runat="server" CssClass="form-control" placeholder="*" MaxLength="15" ValidationGroup="1"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="aceDocNitProveedor" runat="server" ServicePath="~/WebServiceNombreRazSoc.asmx"
                                        MinimumPrefixLength="1" ServiceMethod="GetNit_Documento " EnableCaching="true" TargetControlID="TxtNitProveedor"
                                        UseContextKey="True" CompletionSetCount="10" CompletionInterval="0">
                                    </asp:AutoCompleteExtender>                                    
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lbtnBuscarProveedor" runat="server" ValidationGroup="1" OnClick="lbtnBuscarProveedor_Click" class="btn btn-default btn-md"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator ID="rfvNitDocProveedor" runat="server" ErrorMessage="Ingrese un documento" ControlToValidate="TxtNitProveedor" Display="Dynamic" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNitCodProveedor" runat="server" ControlToValidate="TxtNitProveedor" ErrorMessage="Ingrese sólo números" ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="LblNombreRazonSocial" runat="server" Text="Nombre/Razon Social:"> </asp:Label>
                                <asp:TextBox ID="TxtNombreRazonSocial" runat="server" CssClass="form-control" placeholder="*" MaxLength="40" Enabled="false" > </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNomRazSocProv" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="TxtNombreRazonSocial" Display="Dynamic"  ForeColor="Red"></asp:RequiredFieldValidator>
                                
                            </div>

                            <div class="form-group">
                                <asp:Label ID="LblMotivo" runat="server" Text="Motivo Devolucion: "> </asp:Label>
                                <asp:TextBox ID="TxtMotivo" runat="server" CssClass="form-control" placeholder="*" MaxLength="45" ValidationGroup=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMotivoDev" runat="server" ErrorMessage="Ingrese un motivo" ControlToValidate="TxtMotivo" Display="Dynamic" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblCategoria" runat="server" Text="Categoria"></asp:Label>
                                <asp:DropDownList ID="DlCategorias" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DlCategorias_SelectedIndexChanged" ValidationGroup="1"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Seleccione una categoria" ControlToValidate="DlCategorias" Display="Dynamic" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="lbtnRegistrarDevolucion" runat="server" OnClick="lbtnRegistrarDevolucion_Click1" CssClass="btn btn-info" ValidationGroup=""><span class="glyphicon glyphicon-floppy-disk" ></span>  Registrar</asp:LinkButton>
                                <asp:LinkButton ID="lbtnConsultarDevolucion" runat="server" OnClick="lbtnConsultarDevolucion_Click" CssClass="btn btn-info" ValidationGroup="2"><span class="glyphicon glyphicon-search"></span>  Consultar</asp:LinkButton>
                                <asp:LinkButton ID="lbtnModificarDevolucion" runat="server" OnClick="lbtnModificarDevolucion_Click" CssClass="btn btn-info" ValidationGroup=""><span class="glyphicon glyphicon-refresh"></span>  Modificar</asp:LinkButton>
                                <asp:Label ID="Respuesta" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                                <asp:Label ID="Respuesta2" runat="server" Text="" Visible="false" ForeColor="Green"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Codigo Producto"></asp:Label>
                                <asp:DropDownList ID="DlProductos" runat="server" OnSelectedIndexChanged="DlProductos_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True" ValidationGroup="1"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Seleccione un codigo" ControlToValidate="DlProductos" Display="Dynamic" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="LblNombreProducto" runat="server" Text="Nombre Producto: "></asp:Label>
                                <asp:DropDownList ID="DlNombre_Prod" runat="server" CssClass="form-control" OnSelectedIndexChanged="DlNombre_Prod_SelectedIndexChanged" ValidationGroup="1"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Seleccione un nombre" ControlToValidate="DlNombre_Prod" Display="Dynamic" ValidationGroup="1" ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>

                            <div class="form-group">
                                <asp:Label ID="LblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                                <asp:TextBox ID="TxtCantidad" runat="server" CssClass="form-control" placeholder="*"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese una cantidad" ControlToValidate="TxtCantidad" Display="Dynamic" ValidationGroup="2" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Ingrese un número entre 1 a 50" ControlToValidate="TxtCantidad" MaximumValue="50" MinimumValue="1" Display="Dynamic" ForeColor="Red" ValidationGroup="2" Type="Integer"></asp:RangeValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblsepararbotones" runat="server" Visible="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="lbtnAgregarDetalle" runat="server" Text=" + " OnClick="lbtnAgregarDetalle_Click" CssClass="btn btn-info" ValidationGroup="2"></asp:LinkButton>
                                <asp:LinkButton ID="lbtnQuitarDetalle" runat="server" Text=" - " OnClick="lbtnQuitarDetalle_Click" CssClass="btn btn-info" ValidationGroup=""></asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-lg-2">
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <asp:GridView ID="GVDetalles" runat="server" ViewStateMode="Enabled" CssClass="table table-hover table-striped table table-bordered" OnSelectedIndexChanged="GVDetalles_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="Seleccione" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar"><span class="glyphicon glyphicon-hand-up"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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

