<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmComidas.aspx.cs" Inherits="FrmComidas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPForm" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="well">
                    <center><strong><h3>Gestión de Comidas</h3></strong></center>
                </div>
                <div class="well">
                    <div class="container-fluid">

                        <div class="row">
                            <div class="col-lg-3">

                                <div class="form-group">
                                    <label>Comida: </label>
                                    <asp:TextBox ID="txtComida" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Precio: </label>
                                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <div class="form-horizontal">
                                        <asp:LinkButton ID="lbtnGuardar" runat="server" OnClick="lbtnGuardar_Click" CssClass="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span>  Guardar</asp:LinkButton>
                                        <button id="lbtnConsultar" class="btn btn-success" data-toggle="modal" data-target="#modalProductos"><span class="glyphicon glyphicon-search"></span>Consultar</button>
                                        <%-- Modal productos --%>
                                        <div class="modal" id="modalProductos" tabindex="-1" role="dialog" aria-labelledby="...">
                                            <div class="modal-dialog modal-lg" role="document">
                                                <div class="modal-content">
                                                    ...
                                                </div>
                                            </div>
                                        </div>
                                        <%-- Fin Modal --%>
                                    </div>
                                </div>

                            </div>


                            <div class="col-lg-9">
                                <div class="table-responsive">
                                    <asp:GridView ID="gvp" runat="server" DataKeyNames="Cod_Producto" AutoGenerateColumns="false" OnSelectedIndexChanged="gvp_SelectedIndexChanged" OnPageIndexChanging="gvp_PageIndexChanging" CssClass="table table-hover table-striped table table-bordered" PageSize="10" AllowPaging="true">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnSeleccione" runat="server" Text="Seleccionar" CommandName="Select"><span class="glyphicon glyphicon-hand-up"></span></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Cod_Producto" HeaderText="Código Producto" Visible="false" />
                                            <asp:BoundField DataField="Nombre_Producto" HeaderText="Producto" ItemStyle-Width="92%" />
                                            <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlCantidad" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="1" Value="1" />
                                                        <asp:ListItem Text="2" Value="2" />
                                                        <asp:ListItem Text="3" Value="3" />
                                                        <asp:ListItem Text="4" Value="4" />
                                                        <asp:ListItem Text="5" Value="5" />
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pager-custom" />
                                    </asp:GridView>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

