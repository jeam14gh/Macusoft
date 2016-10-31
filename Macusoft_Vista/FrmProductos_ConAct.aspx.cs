using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class FrmProductos_ConAct : System.Web.UI.Page
{

    Logica.clsCategorias LoCat = new Logica.clsCategorias();
    Logica.clsProductos LoPro = new Logica.clsProductos();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCategorias();
        }
        EstadoControles(0);
        lbtnActualizar.Visible = false;
    }

    private void cargarCategorias()
    {
        ddlCategorias.DataSource = LoCat.dtListarCategorias();
        ddlCategorias.Items.Insert(0, new ListItem("Seleccione", "0"));
        ddlCategorias.DataValueField = "Id_Categoria";
        ddlCategorias.DataTextField = "Nombre_Categoria";
        ddlCategorias.DataBind();
    }

    protected void GridViewProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        GridViewRow row = GridViewProductos.SelectedRow;
        txtCodProducto.Text = row.Cells[1].Text;

        ddlCategorias.SelectedValue = row.Cells[9].Text;
        ddlCategorias.DataTextField = row.Cells[2].Text;
        ddlCategorias.DataBind();

        txtNombreProd.Text = row.Cells[3].Text;
        txtExistenciaActuales.Text = row.Cells[4].Text;
        txtStockMinimo.Text = row.Cells[5].Text;
        txtStockMaximo.Text = row.Cells[6].Text;
        txtCostoCompra.Text = row.Cells[7].Text;
        txtCostoVenta.Text = row.Cells[8].Text;

        EstadoControles(1);
        lbtnActualizar.Visible = true;
        lbtnConsultar.Visible = false;
        lblerror.Visible = false;

    }

    protected void lbtnConsultar_Click(object sender, EventArgs e)
    {
        if (txtCodProducto.Text == "" && txtNombreProd.Text == "" && ddlCategorias.SelectedItem.Text == "Seleccione")
        {
            GridViewProductos.DataSource = null;
            GridViewProductos.DataBind();
            lblerror.Visible = true;
            lblerror.Text = "Ingrese alguno de los criterios de busqueda";

        }
        else
        {
            GridViewProductos.DataSource = LoPro.dtConsultarProducto(txtCodProducto.Text, txtNombreProd.Text, Convert.ToInt32(ddlCategorias.SelectedValue));
            GridViewProductos.DataBind();
            ddlCategorias.ClearSelection();
            lblerror.Visible = false;
        }
    }

    protected void lbtnActualizar_Click(object sender, EventArgs e)
    {
        bool respuesta = LoPro.ActualizarProducto(txtCodProducto.Text, Convert.ToInt32(ddlCategorias.SelectedValue), txtNombreProd.Text, Convert.ToInt32(txtExistenciaActuales.Text), Convert.ToInt32(txtStockMinimo.Text), Convert.ToInt32(txtStockMaximo.Text), Convert.ToInt32(txtCostoCompra.Text), Convert.ToInt32(txtCostoVenta.Text), Convert.ToInt32(TxtCostoXmayor.Text));

        if (respuesta)
        {

            lblMensaje.Text = "Se actualizó de forma correcta el producto";
            limpiar();
            lbtnConsultar.Visible = true;
            GridViewProductos.DataSource = LoPro.dt_ListarProductos();
            GridViewProductos.DataBind();
  
        }
        else 
        {
            lblerror.Visible = true;
            lblerror.Text = "Error al actualizar el producto";
        
        }
    }

    private void EstadoControles(int visibilidad)
    {
        if (visibilidad == 0)
        {
            lblExistActuales.Visible = false;
            txtExistenciaActuales.Visible = false;
            lblStockMinimo.Visible = false;
            txtStockMinimo.Visible = false;
            lblStockMaximo.Visible = false;
            txtStockMaximo.Visible = false;
            lblCostoventa.Visible = false;
            txtCostoVenta.Visible = false;
            lblCostoCompra.Visible = false;
            txtCostoCompra.Visible = false;
            lblCostoxmayor.Visible = false;
            TxtCostoXmayor.Visible = false;
           
        }
        if (visibilidad == 1)
        {
            lblExistActuales.Visible = true;
            txtExistenciaActuales.Visible = true;
            lblStockMinimo.Visible = true;
            txtStockMinimo.Visible = true;
            lblStockMaximo.Visible = true;
            txtStockMaximo.Visible = true;
            lblCostoventa.Visible = true;
            txtCostoVenta.Visible = true;
            lblCostoCompra.Visible = true;
            txtCostoCompra.Visible = true;
            lblCostoxmayor.Visible = true;
            TxtCostoXmayor.Visible = true;
        }
    }

    private void limpiar()
    {
        txtCodProducto.Text = "";
        txtNombreProd.Text = "";
        ddlCategorias.ClearSelection();
        txtExistenciaActuales.Text = "";
        txtStockMinimo.Text = "";
        txtStockMaximo.Text = "";
        txtCostoVenta.Text = "";
        txtCostoCompra.Text = "";
        TxtCostoXmayor.Text = "";

    }
    protected void GridViewProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewProductos.PageIndex = e.NewPageIndex;
        GridViewProductos.DataSource = LoPro.dt_ListarProductos();
        GridViewProductos.DataBind();
    }
}