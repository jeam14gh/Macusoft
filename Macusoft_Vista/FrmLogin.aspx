<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmLogin.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="App_Themes/Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <title></title>

    <style>
        body {
            padding-top: 110px;
        }
    </style>
</head>
<body>
    <form class="form-signin" role="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UPPrincipal" runat="server">
            <ContentTemplate>
                <%-- <div class="container-fluid">--%>

                <div class="row">
                    <div class="col-lg-5">
                    </div>

                    <div class="col-lg-2">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <center><h1>Macusoft</h1></center>
                            </div>
                            <div class="panel-body">

                                <div class="form-group">
                                    <h4 class="form-signin-heading" align="center">Iniciar sesión</h4>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblNombre_Usuario" runat="server" Text="Nombre Usuario:"></asp:Label>
                                    <asp:TextBox ID="txtNombre_UsuarioSession" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
                                    <asp:TextBox ID="txtContraseniaSesion" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="btnIngresar" class="btn btn-success btn-lg btn-block" runat="server" Text="Ingresar" AutoPostBack="True" OnClick="btnIngresar_Click" />
                                </div>
                                <div class="form-group" align="center">
                                    <asp:LinkButton ID="LinkButtonRecuperarContraseña" runat="server" OnClick="LinkButtonRecuperarContraseña_Click">¿Olvido Su Contraseña?</asp:LinkButton>
                                </div>

                            </div>
                        </div>
                        <div class="form-group" align="center">
                            <asp:Label ID="lblmensaje" runat="server" Text="Label" ForeColor="red"></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-5">
                    </div>
                </div>
                <!-- Modal -->
                <div class="modal" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="myModalLabel">Recuperar contraseña</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblCorreoElectronico" runat="server" Text="Ingrese su correo"></asp:Label>
                                <asp:TextBox ID="txtCorreoElectronico" CssClass="form-control" runat="server" placeholder="Ejemplo@hotmail.com" />
                                 <asp:RequiredFieldValidator ID="rfvEmailEmp" runat="server" ErrorMessage="Ingrese un Email" ControlToValidate="txtCorreoElectronico" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmailEmp" runat="server" ErrorMessage="Correo inválido" ControlToValidate="txtCorreoElectronico" Display="Dynamic" ForeColor="Red" ValidationExpression="[a-zA-Z0-9]+[.|\-|_a-zA-Z0-9]*\@[a-zA-Z]{3,7}\.[a-zA-Z]{2,3}" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblNumeroDocumento" runat="server" Text="Ingrese su número de documento"></asp:Label>
                                <asp:TextBox ID="txtNumeroDocumento" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvDoc" runat="server" ErrorMessage="Ingrese un documento" ControlToValidate="txtNumeroDocumento" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revDoc" runat="server" ControlToValidate="txtNumeroDocumento" ErrorMessage="Ingrese sólo números" ValidationExpression="^[0-9]*" Display="Dynamic" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="modal-footer">
                                <asp:Label ID="lblError" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblBien" runat="server" Text="Label" ForeColor="Green"></asp:Label>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnEnviarSolicitud" class="btn btn-success" runat="server" Text="Enviar"  ValidationGroup="1" OnClick="btnEnviarSolicitud_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <!--Termina Modal -->
                <%--</div>--%>
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
    </form>
    <script src="App_Themes/Bootstrap/js/jquery-2.0.2.min.js"></script>
    <script src="App_Themes/Bootstrap/js/bootstrap.js"></script>
</body>
</html>
