using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;


public partial class FrmDevoluciones_Proveedores : System.Web.UI.Page
{
    Logica.clsDevolucionesProveedores LolDevPro = new Logica.clsDevolucionesProveedores();
    Logica.clsCompras LoCom = new Logica.clsCompras();
    Logica.clsDetalles Ldet = new Logica.clsDetalles();
    Logica.clsCategorias lcat = new Logica.clsCategorias();
    Logica.clsProductos Lprod = new Logica.clsProductos();
    Logica.clsProveedores LoProv = new Logica.clsProveedores();

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            Productos();
            Cargar_Combos();
            Ldet.Elimina_Detalles();
        }
        lbtnQuitarDetalle.Visible = false;
        lbtnRegistrarDevolucion.Visible = false;
        lbtnModificarDevolucion.Visible = false;
        DlProductos.Enabled = false;
        DlNombre_Prod.Enabled = false;


    }

    protected void GVDetalles_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GVDetalles.SelectedRow;
        DlProductos.SelectedValue = row.Cells[1].Text;
        DlProductos.DataBind();
        TxtCantidad.Text = row.Cells[3].Text;
        lbtnQuitarDetalle.Enabled = true;
        DlProductos.Enabled = false;
        DlProductos.Focus();
        lbtnAgregarDetalle.Visible = false;
        lbtnModificarDevolucion.Visible = true;
        lbtnQuitarDetalle.Visible = true;


    }

    public void Productos()
    {

        DlProductos.DataSource = Lprod.dt_ListarProductos();
        DlNombre_Prod.DataSource = Lprod.dt_ListarProductos();
        DlCategorias.DataSource = lcat.Listar_Categorias();
        DlCategorias.Items.Add("Seleccione");
        DlProductos.Items.Add("Seleccione");
        DlNombre_Prod.Items.Add("Seleccione");
        DlProductos.AppendDataBoundItems = true;
        DlNombre_Prod.AppendDataBoundItems = true;
        DlCategorias.AppendDataBoundItems = true;

    }
    public void Cargar_Combos()
    {
        DlProductos.DataValueField = "Cod_Producto";
        DlNombre_Prod.DataValueField = "Cod_Producto";
        DlCategorias.DataValueField = "Id_Categoria";
        DlNombre_Prod.DataTextField = "Nombre_Producto";
        DlProductos.DataTextField = "Cod_Producto";
        DlCategorias.DataTextField = "Nombre_Categoria";
        DlProductos.DataBind();
        DlCategorias.DataBind();
        DlNombre_Prod.DataBind();
    }


    protected void DlProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlProductos.Enabled = true;
        DlNombre_Prod.Enabled = true;

        if (DlProductos.SelectedItem.Text == "Seleccione")
        {
            DlNombre_Prod.Items.Clear();
            DlProductos.Items.Clear();
            DlCategorias.Items.Clear();
            Productos();
            Cargar_Combos();

        }
        else
        {
            DlNombre_Prod.Items.Clear();
            DlCategorias.Items.Clear();
            DlCategorias.DataSource = Lprod.ProductoCod(Convert.ToString(DlProductos.SelectedItem));
            DlNombre_Prod.DataSource = Lprod.ProductoCod(Convert.ToString(DlProductos.SelectedItem));
            Cargar_Combos();
        }
    }
    protected void DlCategorias_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlProductos.Enabled = true;
        DlNombre_Prod.Enabled = true;
        DlNombre_Prod.Items.Clear();
        DlProductos.Items.Clear();
        if (DlCategorias.SelectedItem.Text == "Seleccione")
        {
            DlNombre_Prod.Items.Clear();
            DlProductos.Items.Clear();
            DlCategorias.Items.Clear();
            Productos();
            Cargar_Combos();

        }
        else
        {

            DlProductos.DataSource = lcat.Consultar_Categoria(Convert.ToInt32(DlCategorias.SelectedValue));
            DlNombre_Prod.DataSource = lcat.Consultar_Categoria(Convert.ToInt32(DlCategorias.SelectedValue));
            DlProductos.Items.Add("Seleccione");
            DlNombre_Prod.Items.Add("Seleccione");
            DlProductos.AppendDataBoundItems = true;
            DlNombre_Prod.AppendDataBoundItems = true;
            DlProductos.DataBind();
            DlNombre_Prod.DataBind();
        }
    }
    protected void DlNombre_Prod_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DlNombre_Prod.SelectedItem.Text == "Seleccione")
        {
            DlNombre_Prod.Items.Clear();
            DlProductos.Items.Clear();
            DlCategorias.Items.Clear();
            Productos();
            Cargar_Combos();

        }
    }
    protected void BtnActualizat_Click(object sender, EventArgs e)
    {
        Ldet.Eliminar_Detalles(DlProductos.SelectedItem.Text);
        Ldet.Registrar_detalles(DlProductos.SelectedItem.Text, Convert.ToInt32(TxtCantidad.Text), 0);
        GVDetalles.DataSource = Ldet.Consultar_Detalles();
        GVDetalles.DataBind();
        lbtnAgregarDetalle.Visible = true;
        TxtCantidad.Text = "";
        DlNombre_Prod.Items.Clear();
        DlProductos.Items.Clear();
        DlCategorias.Items.Clear();
        Productos();
        Cargar_Combos();
        lbtnQuitarDetalle.Enabled = false;
        DlProductos.Enabled = true;
        lbtnAgregarDetalle.Visible = true;
        lbtnRegistrarDevolucion.Visible = true;
    }

    protected void lbtnRegistrarDevolucion_Click1(object sender, EventArgs e)
    {
        bool res = false;
        bool Detalles = false;
        res = LolDevPro.Regitrar_Devoluciones(TxtNitProveedor.Text, TxtMotivo.Text, 4);
        if (res == true)
        {

            foreach (GridViewRow row in GVDetalles.Rows)
            {
                Detalles = Ldet.Agregar_Detalles(Convert.ToString(row.Cells[1].Text), Convert.ToInt32(row.Cells[3].Text), Convert.ToInt32(row.Cells[4].Text));
                if (Detalles)
                {
                    Lprod.Disminuir(Convert.ToString(row.Cells[1].Text));
                    Detalles = true;
                }
                else { Detalles = false; }
            }
            if (Detalles == true)
            {
                Respuesta2.Visible = true;
                Respuesta2.Text = "La devolucion Fue registrada correctamente";
                TxtCantidad.Text = "";
                TxtMotivo.Text = "";
                TxtNitProveedor.Text = "";
                DlNombre_Prod.ClearSelection();
                TxtNombreRazonSocial.Text = "";
                Ldet.Elimina_Detalles();
                GVDetalles.DataBind();

            }
            else Respuesta2.Text = "La devolucion no Fue registrada correctamente";
        }
        else
        {
            Respuesta.Visible = true;
            Respuesta.Text = "La devolucion no Fue registrada correctamente";
        }

    }

    protected void lbtnConsultarDevolucion_Click(object sender, EventArgs e)
    {
        Response.Redirect("Frm_Consulta_Dev_Proveedores.aspx");
    }

    protected void lbtnModificarDevolucion_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnAgregarDetalle_Click(object sender, EventArgs e)
    {
        lbtnRegistrarDevolucion.Visible = true;
        bool res = true;
        foreach (GridViewRow row in GVDetalles.Rows)
        {
            if (Convert.ToString(row.Cells[1].Text) == Convert.ToString(DlProductos.SelectedItem.Text))
            {
                Respuesta.Visible = true;
                Respuesta.Text = "No puede agregar un detalle con el mismo codigo, se recomienda modificar el existente";
                TxtCantidad.Text = "";
                DlNombre_Prod.Items.Clear();
                DlProductos.Items.Clear();
                DlCategorias.Items.Clear();
                Productos();
                Cargar_Combos();
                res = false;
            }
        }
        if (DlProductos.SelectedItem.Text == "Seleccione")
        {
            if (TxtCantidad.Text == "")
            {
                Respuesta.Visible = true;
                Respuesta.Text = "Por favor seleccione el producto, e ingrese la cantida";
                DlProductos.Focus();
                res = false;
            }
            else
            {
                Respuesta.Visible = true;
                Respuesta.Text = "Por favor seleccione el producto";
                DlProductos.Focus();
                res = false;
            }
        }
        if (DlProductos.SelectedItem.Text != "Seleccione")
        {
            if (TxtCantidad.Text == "")
            {
                Respuesta.Visible = true;
                Respuesta.Text = "Por favor ingrese cantidad";
                TxtCantidad.Focus();
                res = false;
            }
        }



        if (res)
        {
            Ldet.Eliminar_Detalles(DlProductos.SelectedItem.Text);
            Ldet.Registrar_detalles(DlProductos.SelectedItem.Text, Convert.ToInt32(TxtCantidad.Text), 0);
            GVDetalles.DataSource = Ldet.Consultar_Detalles();
            GVDetalles.DataBind();
            TxtCantidad.Text = "";
            DlNombre_Prod.Items.Clear();
            DlProductos.Items.Clear();
            DlCategorias.Items.Clear();
            Productos();
            Cargar_Combos();
            lbtnQuitarDetalle.Enabled = false;
        }
    }
    protected void lbtnQuitarDetalle_Click(object sender, EventArgs e)
    {
        Ldet.Eliminar_Detalles(DlProductos.SelectedItem.Text);
        DlProductos.ClearSelection();
        lbtnQuitarDetalle.Enabled = false;
        DlProductos.Enabled = true;
        TxtCantidad.Text = "";
        DlNombre_Prod.ClearSelection();
        GVDetalles.DataSource = Ldet.Consultar_Detalles();
        GVDetalles.DataBind();
        DlNombre_Prod.Enabled = true;
        lbtnAgregarDetalle.Visible = true;
        TxtNitProveedor.Text = "";
        TxtNombreRazonSocial.Text = "";
        TxtMotivo.Text = "";

    }
    protected void lbtnBuscarProveedor_Click(object sender, EventArgs e)
    {


        DataTable dtProveedor = LoProv.dt_ListarProveedores();
        try
        {         
            
            foreach (DataRow fila in dtProveedor.Rows)
            {
                string nombre = "" + Convert.ToString(fila[2]);
                string nitDoc = "" + Convert.ToString(fila[0]);
                if (TxtNitProveedor.Text == nitDoc)
                {
                    //Respuesta.Visible = false;
                    TxtNombreRazonSocial.Text = nombre;

                }
                
            }    
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}