<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmActualizarCuenta.aspx.cs" Inherits="FrmActualizarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="well">
            <center><strong><h3>Cuenta</h3></strong></center>
        </div>
        <div class="well">
            <div class="row">
                <div class="col-lg-4">
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Label ID="lblUsuario" runat="server" Text="Nombre Usuario:"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblContarseña" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox TextMode="Password" ID="txtContarsenia" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblConfirmarContraseña" runat="server" Text="Confirmar Contraseña:"></asp:Label>
                        <asp:TextBox TextMode="Password" ID="txtConfirmarContraseña" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-3">
                           <asp:LinkButton ID="lbtnActualizar" runat="server" CssClass="btn btn-info" OnClick="lbtnActualizar_Click"><span class="glyphicon glyphicon-refresh"></span>  Actualizar</asp:LinkButton>
                            <asp:Label ID="LblMensaje" runat="server" Text=""  Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

