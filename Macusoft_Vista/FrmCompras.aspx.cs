using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using Logica;

public partial class FrmCompras : System.Web.UI.Page
{
    //llamamos la capa logica
    Logica.clsCompras loComp = new Logica.clsCompras();
    Logica.clsDetCompras LoDetComp = new Logica.clsDetCompras();
    Logica.clsCompras LoCom = new Logica.clsCompras();
    Logica.clsDetalles Lodet = new Logica.clsDetalles();
    Logica.clsProveedores LoProv = new Logica.clsProveedores();
    Logica.clsProductos LoProd = new Logica.clsProductos();
    Logica.clsCategorias LoCat = new Logica.clsCategorias();
    Logica.clsDepartamento oDep = new clsDepartamento();
    Logica.clsMunicipio oMun = new clsMunicipio();
    private DataTable Minimo;
    int StockMinimo;
    int references = 0;
    int Actuales;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Trae la fecha actual del servidor y se la asignamos al "txtFechaRegistro" del modal "Registrar cliente"
        txtFecha.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        
        if (!Page.IsPostBack)
        {
            //Ponemos los metodos que nesecitamos que se actualizen cuando se genere un evento dentro del formulario
            txtFecha.Enabled = false;
            
            
            ListarProv();
            listarProd();
            cargarCategorias();
            cargarCategoriasProveedores();
            this.cargarProductos();

            //Cargamos los municipios que estan en el Dropdownlist 
           
            
            cargarDepartamentos();
            this.cargarMunicipios();
            Lodet.Elimina_Detalles();
        }
    }
    #region Metodos del modal productos
    public void AbrirModal()
    {
        string sScriptF = "AbrirModal('#myModal');";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptAbrirModal", sScriptF, true);
    }

    public void CerrarModal()
    {
        string sScriptF = "CerrarModal('#myModal');";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptCerrarModal", sScriptF, true);
    }

    public void CerrarModalUpdatePanel()
    {
        string sScriptF = "CerrarModalUpdatePanel();";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptCerrarModalUpdatePanel", sScriptF, true);
    }
    #endregion

    #region Metodos del modal proveedores
    public void AbrirModalProveedores()
    {
        string sScriptF = "AbrirModal('#myModal2');";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptAbrirModal", sScriptF, true);
    }

    public void CerrarModalProveedores()
    {
        string sScriptF = "CerrarModal('#myModal2');";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptCerrarModal", sScriptF, true);
    }

    #endregion

    private void cargarProductos()
    {
        ddlCodigoPro.Items.Add(new ListItem("Seleccione", "0"));
        ddlCodigoPro.AppendDataBoundItems = true;
        ddlCodigoPro.DataValueField = "Cod_Producto";
        ddlCodigoPro.DataTextField = "Nombre_Producto";
        ddlCodigoPro.DataBind();
    }

    //Metodo para carga todos los municipios en un dropdownlist
    private void cargarMunicipios()
    {
        if (ddlDepartamento.SelectedItem.Text == "Seleccione")
        {
            ddlMunicipio.Items.Clear();
            ddlMunicipio.Items.Add("Seleccione");
            ddlMunicipio.AppendDataBoundItems = true;
        }
        else
        {
            ddlMunicipio.Items.Clear();
            ddlMunicipio.Items.Add("Seleccione");
            ddlMunicipio.AppendDataBoundItems = true;
            ddlMunicipio.DataSource = oMun.dtMunicipios(Convert.ToByte(ddlDepartamento.SelectedValue));
            ddlMunicipio.DataValueField = "Id_Municipio";
            ddlMunicipio.DataTextField = "Nombre_Municipio";
            ddlMunicipio.DataBind();
        }
    }

    //Metodo para carga todos los departamentos en un dropdownlist
    private void cargarDepartamentos()
    {
        ddlDepartamento.DataSource = oDep.dtDepartamentos();
        ddlDepartamento.Items.Add("Seleccione");
        ddlDepartamento.AppendDataBoundItems = true;
        ddlDepartamento.DataValueField = "Id_Departamento";
        ddlDepartamento.DataTextField = "Nombre_Departamento";
        ddlDepartamento.DataBind();
    }
    //Metodo para cargar las categorias en el modal de productos
    private void cargarCategorias()
    {
        ddlCategorias.Items.Clear();
        ddlCategorias.DataSource = LoCat.Listar_Categorias();
        ddlCategorias.Items.Add("Seleccione");
        ddlCategorias.AppendDataBoundItems = true;
        ddlCategorias.DataValueField = "Id_Categoria";
        ddlCategorias.DataTextField = "Nombre_Categoria";
        ddlCategorias.DataBind();
    }

    //Metodo para cargar las categorias en el formulario de compras
    private void cargarCategoriasProveedores()
    {
        ddlCategoriaCompra.Items.Clear();
        ddlCategoriaCompra.DataSource = LoCat.Listar_Categorias();
        ddlCategoriaCompra.Items.Add("Seleccione");
        ddlCategoriaCompra.AppendDataBoundItems = true;
        ddlCategoriaCompra.DataValueField = "Id_Categoria";
        ddlCategoriaCompra.DataTextField = "Nombre_Categoria";
        ddlCategoriaCompra.DataBind();
    }

    //Metodo para listar los proveedores en el formulario de compras
    public void ListarProv()
    {
        ddlNit.Items.Clear();
        ddlNit.DataSource = LoProv.dt_ListarProveedores();
        ddlNit.Items.Add(new ListItem("Seleccione", "0"));
        ddlNit.AppendDataBoundItems = true;
        ddlNit.DataTextField = "Nombre_RazonSocial";
        ddlNit.DataValueField = "Documento_Nit";
        ddlNit.DataBind();
    }

    //Metodo para listar los productos en el formulario de compras
    public void listarProd()
    {
        ddlCodigoPro.Items.Clear();
        ddlCodigoPro.DataSource = LoProd.dt_ListarProductos();
        ddlCodigoPro.Items.Add(new ListItem("Seleccione", "0"));
        ddlCodigoPro.AppendDataBoundItems = true;
        ddlCodigoPro.DataTextField = "Nombre_Producto";
        ddlCodigoPro.DataValueField = "Cod_Producto";
        ddlCodigoPro.DataBind();
    }

    //Metodo para llenar los campos con la informacion del gridwiev
    protected void GvCompras_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GvCompras.SelectedRow;
        ddlCodigoPro.SelectedItem.Text = row.Cells[2].Text;
        txtCantidad.Text = row.Cells[3].Text;
        txtValor.Text = row.Cells[4].Text;
        lbtnRestar.Enabled = true;
        ddlCodigoPro.Enabled = false;
        ddlCodigoPro.Focus();
        lbtnModificar.Enabled = true;
        lbtnModificar.Visible = true;

    }

    //Evento del boton para registrar una compra
    protected void lbtnRegistrar_Click(object sender, EventArgs e)
    {
        DataTable respuesta = new DataTable();
        respuesta = loComp.Registrar_Compras(ddlNit.SelectedValue.ToString(), txtFormPag.Text, 1);

        bool respuest = false;

        foreach (GridViewRow row in GvCompras.Rows)
        {

            respuest = LoDetComp.RegistrarDetallesCompra(Convert.ToString(row.Cells[1].Text), Convert.ToInt32(row.Cells[3].Text), Convert.ToInt32(row.Cells[4].Text));
            if (respuest)
            {
                LoProd.Aumentar_Existencias(Convert.ToString(row.Cells[1].Text));
            }

        }
        if (respuest == true)
        {
            lbltext.Visible = true;
            lbltext.Text = "La compra fue registrada correctamente";
            Lodet.Elimina_Detalles();
            GvCompras.DataSource = Lodet.Consultar_Detalles();
            GvCompras.DataBind();


        }
        else { lbltext.Text = "No se registro la compra"; }
        txtValor.Text = "";
        txtFormPag.Text="";
        txtCantidad.Text = "";
        ListarProv();
        listarProd();
        cargarCategoriasProveedores();

    }
    //Este boton al hacer click no redirecciona al formulario de consulta de compras 
    protected void lbtnConsultar_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmConsultarCompras.aspx");
    }

    //Este boton agrega detalles de la compra al griw
    protected void lbtnAgragar_Click(object sender, EventArgs e)
    {
        DataTable Detalles = Lodet.Consultar_Detalles();
        bool agregar = true;

        foreach (DataRow row in Detalles.Rows)
        {
            if (ddlCodigoPro.Text == row[0].ToString())
            {
                agregar = false;
            }
        }
        if (agregar)
        {
            Lodet.Registrar_detalles(ddlCodigoPro.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtValor.Text));
            Minimo = LoProd.ProductoCod(Convert.ToString(ddlCodigoPro.Text));
            Actuales = Convert.ToInt32(Minimo.Rows[0][6].ToString());
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int exitencias = Actuales + cantidad;
            if (exitencias > 50)
            {
                lbltext.Text = "No se puede agregar mas productos de la referencia '" + Convert.ToString(ddlCodigoPro.Text) + "', actualmente hay " + Actuales + " " + Convert.ToString(Minimo.Rows[0][2].ToString()) + ". Sólo puede agregar " + (Convert.ToInt32(Minimo.Rows[0][5].ToString()) - Actuales) + ", por que el stock máximo es de " + Convert.ToInt32(Minimo.Rows[0][5].ToString());
                Lodet.Eliminar_Detalles(ddlCodigoPro.Text);
            }
            else
            {
                lbltext.Text = "";
                GvCompras.DataSource = Lodet.Consultar_Detalles();
                GvCompras.DataBind();
            }
        }
        else { lbltext.Text = "No se puede agregar mas productos de la misma referencia, actualize el detalle."; }
       
    }
    //Este boton quita detalles de la compra al griw
    protected void lbtnRestar_Click(object sender, EventArgs e)
    {

        Lodet.Eliminar_Detalles(ddlCodigoPro.SelectedValue);
        ddlCodigoPro.Enabled = true;
        lbtnRestar.Enabled = false;
        ddlCodigoPro.Enabled = true;
        txtCantidad.Text = "1";
        txtValor.Text = "1";
        lbtnModificar.Visible = false;
        GvCompras.DataSource = Lodet.Consultar_Detalles();
        GvCompras.DataBind();
        lbtnRestar.Enabled = false;
    }

    //Este boton abre el modal de productos 
    protected void lbtnAddProductos_Click(object sender, EventArgs e)
    {
        AbrirModal();
    }

    //Este boton abre el modal de proveedores
    protected void lbtnAddProveedor_Click(object sender, EventArgs e)
    {
        AbrirModalProveedores();
    }

    //Evento que permite cargar los productos que estan asociados a una categoria. Por medio de un DropDownList (ddlCategoria) hacia un (ddlProductos)
    protected void ddlCategoriaCompra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCodigoPro.Items.Clear();
        ddlCodigoPro.DataSource = LoProd.dtListarProductosXCategorias(Convert.ToInt32(ddlCategoriaCompra.SelectedValue));
        this.cargarProductos();
        ddlCodigoPro.Enabled = true;
    }
    protected void lbtnRegistrarProveedor_Click(object sender, EventArgs e)
    {
        bool respuesta = LoProv.registrarProveedor(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.SelectedValue));
        if (respuesta)
        {
            lblmensage.Text = "Se registró de forma correcta el proveedor";
            CerrarModalUpdatePanel();
            AbrirModalProveedores();
            LimpiarModalProveedores();
        }
        else
        {
            lblmensage1.Text = "Error al registrar el proveedor. Intente de nuevo";
            AbrirModalProveedores();

        }
    }

    private void LimpiarModalProveedores()
    {
        txtNombre_RazonSocial.Text = "";
        txtNit_Documento.Text = "";
        ddlDepartamento.ClearSelection();
        ddlMunicipio.ClearSelection();
        txtDireccion.Text = "";
        txtTelefono.Text = "";
        txtEmail.Text = "";
    }
    protected void lbtnModificar_Click(object sender, EventArgs e)
    {
        Lodet.Eliminar_Detalles(ddlCodigoPro.Text);
        Lodet.Registrar_detalles(ddlCodigoPro.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtValor.Text));
        Minimo = LoProd.ProductoCod(Convert.ToString(ddlCodigoPro.Text));
        Actuales = Convert.ToInt32(Minimo.Rows[0][6].ToString());
        int cantidad = Convert.ToInt32(txtCantidad.Text);
        int exitencias = Actuales + cantidad;
        if (exitencias > 50)
        {
            lbltext.Text = "No se puede agregar mas productos de la referencia '" + Convert.ToString(ddlCodigoPro.Text) + "', actualmente hay " + Actuales + " " + Convert.ToString(Minimo.Rows[0][2].ToString()) + ". Sólo puede agregar " + (Convert.ToInt32(Minimo.Rows[0][5].ToString()) - Actuales) + ", por que el stock máximo es de " + Convert.ToInt32(Minimo.Rows[0][5].ToString());
            Lodet.Eliminar_Detalles(ddlCodigoPro.Text);
        }
        else
        {
            lbltext.Text = "";
            GvCompras.DataSource = Lodet.Consultar_Detalles();
            GvCompras.DataBind();
        }
        lbtnModificar.Visible=false;
       

    }
    //Este evento nos carga todos lo municipios del departamento que seleccionemos en el drowdonlist 
    protected void ddlDepartamento_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlMunicipio.DataSource = oMun.dtMunicipios(Convert.ToByte(ddlDepartamento.SelectedValue));
        this.cargarMunicipios();
        CerrarModalUpdatePanel();
        AbrirModalProveedores();
    }
    protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        CerrarModalUpdatePanel();
        AbrirModalProveedores();
    }


    protected void lbtnRegistrarProducto_Click(object sender, EventArgs e)
    {
        bool Registro = true;
        DataTable Prodcutos = LoProd.dt_ListarProductos();
        foreach (DataRow Row in Prodcutos.Rows)
        {
            if (txtCodProducto.Text == Prodcutos.Rows[0][0].ToString())
            {
                Registro = false;
                lblMensajeError.Text = "El codigo de producto ya existe en el sistema, si desea agregar mas productos de la referencia " + txtCodProducto.Text + " Por favor dirigirse al módulo de compras";
                CerrarModal();
            }
        }
        if (Convert.ToInt32(txtExistenciaActuales.Text) > 50)
        {
            Registro = false;
            lblMensajeError.Text = "Las existencias no pueden pasar el stock máximo";
            CerrarModal();
        }

        if (Registro)
        {
            LoProd.RegistrarProducto(txtCodProducto.Text, Convert.ToInt32(ddlCategorias.SelectedValue), txtNombreProd.Text, Convert.ToInt32(txtExistenciaActuales.Text), Convert.ToInt32(txtStockMinimo.Text), Convert.ToInt32(txtStockMaximo.Text), Convert.ToInt32(txtCostoCompra.Text), Convert.ToInt32(txtCostoVenta.Text), Convert.ToInt32(TxtCostoXmayor.Text));
            lblMensaje.Text = "Se registró el producto correctamente";
            txtCodProducto.Text = "";
            ddlCategorias.SelectedIndex = 0;
            txtNombreProd.Text = "";
            txtExistenciaActuales.Text = "";
            txtStockMaximo.Text = "50";
            txtStockMinimo.Text = "10";
            txtCostoCompra.Text = "";
            txtCostoVenta.Text = "";
            TxtCostoXmayor.Text = "";
            CerrarModalUpdatePanel();
            AbrirModal();
           
        }
    }
}