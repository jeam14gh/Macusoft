<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="Frm_Consulta_Dev_Proveedores.aspx.cs" Inherits="Frm_Consulta_Dev_Proveedores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPForm" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="well">
                    <center><h3><strong>Consultar devoluciones proveedores</strong></h3></center>
                </div>
                <div class="well">
                    <div class="row">
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="LblCedulaProveedor" runat="server" Text="Cedula/Nit:"> </asp:Label>
                                <asp:TextBox ID="TxtNitProveedor" runat="server" CssClass="form-control" placeholder="*" MaxLength="15"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="aceNitProv" runat="server" ServicePath="~/WebServiceNombreRazSoc.asmx"
                                    MinimumPrefixLength="1" ServiceMethod="GetNit_Documento " EnableCaching="true" TargetControlID="TxtNitProveedor"
                                    UseContextKey="True" CompletionSetCount="10" CompletionInterval="0">
                                </asp:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="rfvNitDocProveedor" runat="server" ErrorMessage="Ingrese un documento" ControlToValidate="TxtNitProveedor" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNitCodProveedor" runat="server" ControlToValidate="TxtNitProveedor" ErrorMessage="Ingrese sólo números" ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblNombre_Razon_Social" runat="server" Text="Nombre/Razón Social:"></asp:Label>
                                <asp:TextBox ID="TxtNombre_Razon_Social" runat="server" CssClass="form-control" placeholder="*" MaxLength="40"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="aceNomProv" runat="server" ServicePath="~/WebServiceNombreRazSoc.asmx"
                                    MinimumPrefixLength="1" ServiceMethod="GetNombre_RazonSocial " EnableCaching="true" TargetControlID="TxtNombre_Razon_Social"
                                    UseContextKey="True" CompletionSetCount="10" CompletionInterval="0">
                                </asp:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="rfvNomRazSocProv" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="TxtNombre_Razon_Social" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNomProv" runat="server" ErrorMessage="Ingrese sólo letras" ControlToValidate="TxtNombre_Razon_Social" Display="Dynamic" ValidationExpression="^[a-zñÑáéíóúÁÉÍÓÚÜüA-Z\s]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="lbtnConsultar" runat="server" OnClick="lbtnConsultar_Click" CssClass="btn btn-info" ValidationGroup="1"><span class="glyphicon glyphicon-search"></span>  Consultar</asp:LinkButton>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Respuesta" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-4">
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table table-bordered"></asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

