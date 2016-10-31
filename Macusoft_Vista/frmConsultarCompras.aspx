<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="frmConsultarCompras.aspx.cs" Inherits="frmConsultarCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="well">
            <center><strong><h3>Consultar compras</h3></strong></center>
        </div>
        <div class="well">
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:"></asp:Label>
                        <asp:DropDownList ID="ddlNit" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
                        <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:LinkButton ID="lbtnConsultar" runat="server" OnClick="lbtnConsultar_Click" CssClass="btn btn-info"><span class="glyphicon glyphicon-search"></span>  Consultar</asp:LinkButton>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="table-responsive">
                <asp:GridView ID="GvConsultarCompras" runat="server" ViewStateMode="Enabled" CssClass="table table-hover table-striped table table-bordered" GridLines="None" PageSize="5" AllowPaging="true"
                    OnPageIndexChanging="GvConsultarCompras_PageIndexChanging">
                    <PagerStyle CssClass="pager-custom" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>


