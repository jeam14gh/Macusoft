<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmAyuda.aspx.cs" Inherits="FrmAyuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel-group" id="accordion">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Gestión de usuarios
                    </a>
                </h4>
            </div>
            <div id="collapseOne" class="panel-collapse collapse">
                <div class="panel-body">
                    <h4><b>Registrar Usuarios</b>  </h4>

                    Para registrar un usuario es necesario llenar todos los campos. 

  

       

                  <h4><b>Actualizar Usuarios</b> </h4>
                    Para actualizar un usuario es necesario consultarlo primero  y seleccionarlo.<br />
                    Los espacios nombre de usuario y documento no podrán ser modificados
                    
                    
                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Gestión de productos
                    </a>
                </h4>
            </div>
            <div id="collapseTwo" class="panel-collapse collapse">
                <div class="panel-body">

                    <h4><b>Registrar Productos</b>  </h4>

                    los campos de código producto, categoría, nombre del producto y existencias actuales son obligatorios<br />

                    Las existencias actuales por defecto son 0.

                  <h4><b>Consultar Productos</b></h4>

                    Para consular un producto es necesario llenar uno de los criterios de busqueda tales como:<br />
                    Codigo de producto,categoria o nombre del producto.

                  <h4><b>Actualizar Productos</b> </h4>
                    Para actualizar un producto es necesario consultar primero el producto y seleccionarlo.<br />
                    Solo se podran modificar los siguientes campos:<br />
                    Exisencias actuales y ruta imagen.
                    
                  

                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Gestión de proveedores
                    </a>
                </h4>
            </div>
            <div id="collapseThree" class="panel-collapse collapse">
                <div class="panel-body">
                    <h4><b>Registrar Proveedores</b>  </h4>

                    Para registrar un proveedor es necesario llenar todos los campos . 

                   <h4><b>Consultar Proveedores</b></h4>

                    Para consular un proveedor es necesario llenar uno de los criterios de busqueda tales como:<br />



                    <h4><b>Actualizar Usuarios</b> </h4>
                    Para actualizar un usuario es necesario consultarlo primero  y seleccionarlo.<br />

                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour">Gestión de clientes
                    </a>
                </h4>
            </div>
            <div id="collapseFour" class="panel-collapse collapse">
                <div class="panel-body">

                    <h4><b>Registrar Clientes</b>  </h4>

                    Para registrar un cliente es necesario llenar todos los campos . 

                   <h4><b>Consultar Clientes</b></h4>

                    Para consular un cliente es necesario llenar uno de los criterios de busqueda tales como:<br />
                    Nombre/ Razón Social o  Documento/Nit.

                  <h4><b>Actualizar Clientes</b> </h4>
                    Para actualizar un cliente es necesario consultarlo primero  y seleccionarlo.<br />
                    El Documento/Nit no puede ser modificado.
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive">Gestión de ventas
                    </a>
                </h4>
            </div>
            <div id="collapseFive" class="panel-collapse collapse">
                <div class="panel-body">
                    <h4><b>Registrar Ventas</b>  </h4>

                    Para registrar una venta es necesario llenar todos los campos . 

                   <h4><b>Consultar Ventas</b></h4>

                    Para consular un cliente es necesario llenar uno de los criterios de busqueda tales como:<br />
                    Nombre/ Razón Social o  Documento/Nit.

                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">Gestión de devolucion cliente
                    </a>
                </h4>
            </div>
            <div id="collapseSix" class="panel-collapse collapse">
                <div class="panel-body">
                    <h4><b>Registrar Devolucion </b></h4>

                    Para registrar una devolicion se debe ingresar el numero de la factura, posteriormente hacer clic en el boton seleccionar y rellenar todos los campos. 

                   
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">Gestión de devolucion proveedores
                    </a>
                </h4>
            </div>
            <div id="collapseSeven" class="panel-collapse collapse">
                <div class="panel-body">
                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseEight">Gestión de compras
                    </a>
                </h4>
            </div>
            <div id="collapseEight" class="panel-collapse collapse">
                <div class="panel-body">
                    <h4><b>Registrar Compras</b>  </h4>

                    Para registrar una compra es necesario llenar todos los campos. 

                  

                  <h4><b>Consultar Compras </b></h4>

                    Para consular una compra es necesario llenar uno de los criterios de busqueda tales como:<br />
                    Fecha, proveedor o producto.

              
                    
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseNine">Gestión de reportes
                    </a>
                </h4>
            </div>
            <div id="collapseNine" class="panel-collapse collapse">
                <div class="panel-body">
                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                </div>
            </div>
        </div>
    </div>
</asp:Content>

