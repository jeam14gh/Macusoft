<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FmrConsultarCategoria.aspx.cs" Inherits="FmrConsultarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <%--<div class="container-fluid">
         <div class="page-header">--%>
             <div class="row">
                 <div class="col-md-2">

                             <div class="row">
                                  <asp:Label ID="lblIdCategoria" runat="server" Text="Id " ></asp:Label>
                             </div>

                             <div class="row">
                                 <asp:TextBox ID="txtIdCategoria" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>

                                <div class="row">
                                    <asp:Label ID="lblNombreCategoria" runat="server" Text="Nombre Categoria"></asp:Label>
                                </div>
                             <div class="row">
                                 <asp:TextBox ID="txtNombreCategoria" runat="server" CssClass="form-control"></asp:TextBox>
                             </div>

                             <div class="row" >
                                
                                     <asp:Button ID="btnConsultarcatego" runat="server" Text="Consultar" CssClass="btn btn-success"   OnClick="btnConsultarcatego_Click1"  />
                                                                 
                                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-danger" OnClick="btnActualizar_Click1"  />
                                 </div>
                               
                             </div>

                 

                 <div class="col-md-6">
                         <asp:GridView ID="GvCatego" runat="server" OnSelectedIndexChanged="GvCatego_SelectedIndexChanged"  
                             CssClass="table table-hover table-striped" GridLines="None" >
                             <Columns>
                                 <asp:CommandField ShowSelectButton="True" />
                             </Columns>
                         </asp:GridView>
                     </div>
             </div>
     <%--    </div>
                     
                 
     </div>--%>


</asp:Content>

