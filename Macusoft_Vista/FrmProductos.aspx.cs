using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Datos;

public partial class FrmProductos : System.Web.UI.Page
{
    Logica.clsCategorias LoCat = new Logica.clsCategorias();
    Logica.clsProductos LoPro = new Logica.clsProductos();
    private DataTable Dt_Ingreso;
    private DataTable Usuarios;
    protected void Page_Load(object sender, EventArgs e)
    {
        AbrirModal();
        CerrarModalUpdatePanel();

        if (!Page.IsPostBack)
        {
            Dt_Ingreso = (DataTable)Session["dataTable"];
            if (Dt_Ingreso == null)
            {
                Response.Redirect("FrmLogin.aspx");
            }
            else
            {
                if (Dt_Ingreso.Rows[0][3].ToString().Equals("Vendedor"))
                {
                    Response.Redirect("FrmVentas.aspx");
                }
                cargarCategorias();
                listarProductos();

            }
            lblMensajeCat.Visible = false;
            lblerrorcat.Visible = false;


        }
    }

    private void cargarCategorias()
    {
        ddlCategorias.Items.Clear();
        ddlCategorias.DataSource = LoCat.Listar_Categorias();
        ddlCategorias.Items.Insert(0, new ListItem("Seleccione","0"));
        ddlCategorias.DataValueField = "Id_Categoria";
        ddlCategorias.DataTextField = "Nombre_Categoria";
        ddlCategorias.DataBind();
    }

    protected void lbtnRegistrar_Click(object sender, EventArgs e)
    {
        bool Registro = true;
        DataTable Prodcutos = LoPro.dt_ListarProductos();
        foreach (DataRow Row in Prodcutos.Rows)
        {
            if (txtCodProducto.Text ==Convert.ToString(  Row[0]) )
            {
                Registro = false;
                lblMensaje.Text = "";
                lblMensajeError.Text = "El codigo de producto ya existe en el sistema, si desea agregar mas productos de la referencia " + txtCodProducto.Text + " Por favor dirigirse al proceso de compras";
                CerrarModal();
            }
        }

        if (Registro)
        {
            LoPro.RegistrarProducto(txtCodProducto.Text, Convert.ToInt32(ddlCategorias.SelectedValue), txtNombreProd.Text, Convert.ToInt32(txtExistenciaActuales.Text), Convert.ToInt32(txtStockMinimo.Text), Convert.ToInt32(txtStockMaximo.Text), Convert.ToInt32(txtCostoCompra.Text), Convert.ToInt32(txtCostoVenta.Text), Convert.ToInt32(TxtCostoXmayor.Text));
            lblMensajeError.Text = "";
            lblMensaje.Text = "Se registró el producto correctamente";
            listarProductos();
            limpiar();
            CerrarModal();
        }
    
      
    }

    protected void lbtnConsultar_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmProductos_ConAct.aspx");
    }

    //Metodo para limpiar todos los controles despues de registrar un producto
    private void limpiar()
    {
        txtCodProducto.Text = "";
        ddlCategorias.SelectedIndex = 0;
        txtNombreProd.Text = "";
        txtExistenciaActuales.Text = "";
        txtStockMaximo.Text = "50";
        txtStockMinimo.Text = "10";
        txtCostoCompra.Text = "";
        txtCostoVenta.Text = "";
        TxtCostoXmayor.Text = "";

    }

    //Metodo para listar todos los productos en el gridview
    private void listarProductos()
    {
        GridViewListarProductos.DataSource = LoPro.dt_ListarProductos();
        GridViewListarProductos.DataBind();
    }

    #region Modal´s
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

    //Boton "+" para abril un modal y registrar una categoria
    protected void lbtnAddCategoria_Click(object sender, EventArgs e)
    {
        AbrirModal();
    }

    protected void LbtnRegistrarCategoria_Click(object sender, EventArgs e)
    {
        Logica.clsCategorias PD = new Logica.clsCategorias();
        bool respuesta = PD.Registrar_Categoria(txtCategoria.Text);

        if (respuesta)
        {
            AbrirModal();
            txtCategoria.Text = "";
            lblerrorcat.Visible = false;
            lblMensajeCat.Visible = true;
            lblMensajeCat.Text = "Se registro correctamente la categoria";           

        }
        else
        {
            lblerrorcat.Visible = true;
            lblerrorcat.Text = "Error al registrar la categoria";

        }

        cargarCategorias();
    }
    protected void GridViewListarProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CerrarModal();
        GridViewListarProductos.PageIndex = e.NewPageIndex;
        GridViewListarProductos.DataSource = LoPro.dt_ListarProductos();
        GridViewListarProductos.DataBind();
    }
}