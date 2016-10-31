<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmDevolucionCliente.aspx.cs" Inherits="FrmDevolucionCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="well">
            <center><strong><h3>Devolución de clientes</h3></strong></center>
        </div>

        <div class="well">
            <div class="row">
                <div class="col-lg-2">
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label ID="lblConsecutivo_Devolucion" runat="server" Text="Consecutivo/Devolución:"></asp:Label>
                        <div class="input-group">
                            <asp:TextBox ID="txtConsecutivo_Devolucion" runat="server" CssClass="form-control" MaxLength="10" ValidationGroup="1"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="lbtnBuscar" runat="server" OnClick="lbtnBuscar_Click" CssClass="btn btn-info" ValidationGroup="1"><span class="glyphicon glyphicon-search"></span> Buscar</asp:LinkButton>
                            </span>
                        </div>
                        <asp:RequiredFieldValidator ID="rfvDian" runat="server" ErrorMessage="Ingrese un consecutivo." ControlToValidate="txtConsecutivo_Devolucion" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDian" runat="server" ControlToValidate="txtConsecutivo_Devolucion" ErrorMessage="Ingrese sólo números" ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>

                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblCantidad_Producto_devolucion" runat="server" Text="Cantidad/Producto:"></asp:Label>
                        <asp:TextBox ID="txtCantidad_Producto_Devolucion" runat="server" CssClass="form-control" MaxLength="2" ValidationGroup="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCantidadDevProd" runat="server" ErrorMessage="Ingrese la cantidad" ForeColor="Red" ControlToValidate="txtCantidad_Producto_Devolucion" Display="Dynamic" ValidationGroup="2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCantidadDevProd" runat="server" ErrorMessage="Ingrese sólo números" ControlToValidate="txtCantidad_Producto_Devolucion" Display="Dynamic" ValidationExpression="[0-9]+$" ForeColor="Red" ValidationGroup="2"></asp:RegularExpressionValidator>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="LblMotivo_Devolucion" runat="server" Text="Motivo devolución?"></asp:Label>
                        <asp:TextBox ID="txtMotivo_Devolucion" runat="server" CssClass="form-control" MaxLength="50" ValidationGroup="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNitDoc" runat="server" ErrorMessage="Ingrese un motivo." ControlToValidate="txtMotivo_Devolucion" Display="Dynamic" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>                                
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblNIT_Documento_Devolucion_Cliente" runat="server" Text="NIT/Documento:"></asp:Label>
                        <asp:TextBox ID="txtNIT_Documento_Devolucion_Cliente" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:LinkButton ID="lbtnRegistrarDevolucion" runat="server" OnClick="lbtnRegistrarDevolucion_Click" CssClass="btn btn-info"><span class="glyphicon glyphicon-floppy-disk"></span>  Registrar</asp:LinkButton>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LblMensaje" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label ID="lblCodigoproducto" runat="server" Text="Referencia producto"></asp:Label>
                        <asp:TextBox ID="txtCodigoproducto" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>

                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblNombre_Producto_Devolucion" runat="server" Text="Descripcion Producto:"></asp:Label>
                        <asp:TextBox ID="txtNombre_Producto_Devolucion" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblNombre_Cliente_Devolucion" runat="server" Text="Nombre/Razón social:"></asp:Label>
                        <asp:TextBox ID="txtNombre_Cliente_Devolucion" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:LinkButton ID="lbtnAgregar" runat="server" OnClick="lbtnAgregar_Click" CssClass="btn btn-info" ValidationGroup="2"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                        <asp:LinkButton ID="lbtnRestar" runat="server" OnClick="lbtnRestar_Click"  CssClass="btn btn-info"><span class="glyphicon glyphicon-minus"></span></asp:LinkButton>
                    </div>
                </div>
                <div class="col-lg-2">
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Consulta de venta</h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GvVentas" runat="server" CssClass="table table-hover table-striped table table-bordered" OnSelectedIndexChanged="GvVentas_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="Seleccione" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar" ValidationGroup="2"><span class="glyphicon glyphicon-hand-up"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Detalle de devolución</h3>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="GvDetDevC" runat="server" CssClass="table table-hover table-striped table table-bordered" OnSelectedIndexChanged="GvDetDevC_SelectedIndexChanged">
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
    </div>
</asp:Content>

