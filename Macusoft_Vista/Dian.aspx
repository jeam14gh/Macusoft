<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="Dian.aspx.cs" Inherits="Dian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-6">
                <form class="form-inline" role="form">
                    <div class="container-fluid">
                        <div class="page-header">
                            <div class="form-group">
                                <asp:Label runat="server" CssClass="sr-only" ID="lblRango_inicial">Rango Inicial: </asp:Label>
                                <asp:TextBox ID="txtRango_inicial" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" CssClass="sr-only" ID="lblRango_Final">Rango Final: </asp:Label>
                                <asp:TextBox ID="txtRango_Final" runat="server"></asp:TextBox>
                            </div>

                            <asp:Button ID="btnRegistrarConsecutivo" runat="server" Text="Registrar" CssClass="btn btn-default" OnClick="btnRegistrar_Consecutivo" />
                            <asp:Button ID="btnConsultarConsecutivo" runat="server" Text="Actualizar" CssClass="btn btn-default" OnClick="btnConsultar_Consecutivo" />

                        </div>
                        <asp:Label ID="Respuesta" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                </form>
            </div>
            <div class="col-lg-6">
                <div class="container-fluid">
                    <div class="page-header">
                        <asp:Label ID="Label1" runat="server" Text="Consecutivo"></asp:Label>
                        <asp:TextBox ID="Consecutivo" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>


        </div>
    </div>


</asp:Content>

