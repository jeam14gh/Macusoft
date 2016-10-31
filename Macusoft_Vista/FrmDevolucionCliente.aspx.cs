using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FrmDevolucionCliente : System.Web.UI.Page
{
    Logica.clsDevolucionCliente Ldevc = new Logica.clsDevolucionCliente();
    Logica.clsDetalles Ldet = new Logica.clsDetalles();
    Logica.clsDian Ldian = new Logica.clsDian();
    Logica.clsProductos Lpro = new Logica.clsProductos();
    private DataTable Minimo;
    int StockMinimo;
    int Actuales;

    protected void Page_Load(object sender, EventArgs e)
    {
        lbtnRestar.Enabled = false;
        txtCodigoproducto.Enabled = false;
        txtNIT_Documento_Devolucion_Cliente.Enabled = false;
        txtNombre_Cliente_Devolucion.Enabled = false;
        txtNombre_Producto_Devolucion.Enabled = false;
        lbtnRegistrarDevolucion.Enabled = false;
        lbtnRestar.Visible = false;
        if (!IsPostBack)
        {
            Ldet.Elimina_Detalles();
        }
    }

    protected void lbtnBuscar_Click(object sender, EventArgs e)
    {
        GvVentas.DataSource = Ldian.Consultar_Ventas(Convert.ToInt32(txtConsecutivo_Devolucion.Text));
        GvVentas.DataBind();
        GvVentas.Focus();
        int cont = 0;
        foreach (GridViewRow row in GvVentas.Rows)
        { cont++; }
        if (cont > 0)
        {
            LblMensaje.Visible = false;
           
        }
        else 
        { 
            LblMensaje.Visible = true;
            LblMensaje.Text = "Este numero de consecutivo no se encuentra en el sistema"; 
        }
    }
    protected void lbtnAgregar_Click(object sender, EventArgs e)
    {
       
        bool res = true;
        if (txtCodigoproducto.Text == "")
        {
            LblMensaje.Visible = true;
            LblMensaje.Text = "Por favor seleccione el producto";
            res = false;
            if (txtCantidad_Producto_Devolucion.Text == "")
            {

                LblMensaje.Visible = true;
                LblMensaje.Text = "Por favor ingrese el codigo de producto,la cantidad y el consecutivo";
                res = false;
            }
            if (txtConsecutivo_Devolucion.Text == "")
            {
                LblMensaje.Visible = true;
                LblMensaje.Text = "Por favor ingrese el el consecutivo de la venta";
                res = false;
            }
            
        }
        Minimo = Lpro.ProductoCod(txtCodigoproducto.Text);
        if (res)
        {
            int cantidad = 0;
            Actuales = 0;
            bool Productos = true;
            cantidad = Convert.ToInt32(txtCantidad_Producto_Devolucion.Text);
            foreach (GridViewRow row in GvVentas.Rows)
            {
                Actuales = Convert.ToInt32(row.Cells[5].Text);
                if (row.Cells[3].Text == txtCodigoproducto.Text)
                {
                    if (Actuales < cantidad)
                    {
                        LblMensaje.Visible = true;
                        LblMensaje.Text = "No se puede devolver más de los que se compró";
                        Ldet.Eliminar_Detalles(txtCodigoproducto.Text);
                        Productos = false;
                    }
                    else
                    { 
                        Productos = true;
                        LblMensaje.Visible = false;
                    }
                }
            }

            if (Productos)
            {
                bool Funcion=true;
                foreach (GridViewRow Det in GvDetDevC.Rows)
                {
                    if (Det.Cells[1].Text == txtCodigoproducto.Text)
                    {
                        LblMensaje.Visible = true;
                        LblMensaje.Text = "No se puede agregar mas productos de la referencia ";
                        Funcion = false;
                    }
                }
                if (Funcion)
                {
                    Ldet.Registrar_detalles(txtCodigoproducto.Text, Convert.ToInt32(cantidad), 0);
                    GvDetDevC.DataSource = Ldet.Consultar_Detalles();
                    GvDetDevC.DataBind();
                    txtCodigoproducto.Text = "";
                    txtCantidad_Producto_Devolucion.Text = "";
                    txtNombre_Producto_Devolucion.Text = "";
                    txtCodigoproducto.Focus();
                    txtCodigoproducto.Enabled = true;
                    lbtnRestar.Enabled = false;
                }
            }

        }
        lbtnRegistrarDevolucion.Enabled = true;
    }

    protected void lbtnRestar_Click(object sender, EventArgs e)
    {
        Ldet.Eliminar_Detalles(txtCodigoproducto.Text);
        txtCodigoproducto.Enabled = true;
        lbtnRestar.Enabled = false;
        txtCodigoproducto.Text = "";
        txtCantidad_Producto_Devolucion.Text = "";
        txtNombre_Producto_Devolucion.Text = "";
        GvDetDevC.DataSource = Ldet.Consultar_Detalles();
        GvDetDevC.DataBind();
        LblMensaje.Text = "";
        lbtnRestar.Visible = false;
    }

    protected void lbtnRegistrarDevolucion_Click(object sender, EventArgs e)
    {
        DataTable Prodc = Lpro.dt_ListarProductos();
        int Catn = 0;
        foreach (DataRow Rest in Prodc.Rows)
        {
            if (txtCodigoproducto.Text == Prodc.Rows[0][0].ToString())
            {
                Catn = Convert.ToInt32(Prodc.Rows[0][7].ToString());
            }
        }
        bool Res = false;
        bool Detalles = false;
        Res = Ldevc.Registrar_Devolucion(this.txtNIT_Documento_Devolucion_Cliente.Text, this.txtMotivo_Devolucion.Text, Convert.ToInt32(this.txtConsecutivo_Devolucion.Text), 3);
        if (Res)
        {
            foreach (GridViewRow row in GvDetDevC.Rows)
            {
                DataTable Cods = Lpro.dtConsultarProducto(Convert.ToString(row.Cells[1].Text), "", 0);
                Detalles = Ldet.Agregar_Detalles(Convert.ToString(row.Cells[1].Text), Convert.ToInt32(row.Cells[3].Text), Convert.ToInt32(Cods.Rows[0][6].ToString()));
                if (Detalles == true)
                {
                    Lpro.Aumentar_Existencias(Convert.ToString(row.Cells[1].Text));
                    LblMensaje.Visible = true;

                    LblMensaje.ForeColor = System.Drawing.Color.Green;
                    LblMensaje.Text = "Se registró exitosamente la devolución.";
                }
            }
        }
    }

    protected void GvDetDevC_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbtnRestar.Enabled = true;
        txtCodigoproducto.Enabled = false;
        GridViewRow row = GvDetDevC.SelectedRow;
        txtCodigoproducto.Text = row.Cells[1].Text;
        txtCantidad_Producto_Devolucion.Text = row.Cells[3].Text;
        txtCodigoproducto.Focus();
        lbtnRestar.Visible = true;
    }
    protected void GvVentas_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GvVentas.SelectedRow;
        txtNIT_Documento_Devolucion_Cliente.Text = row.Cells[1].Text;
        txtCodigoproducto.Text = row.Cells[3].Text;
        txtNombre_Producto_Devolucion.Text = row.Cells[4].Text;
        txtNombre_Cliente_Devolucion.Text = row.Cells[2].Text;
    }
}