using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FmrConsultarCategoria : System.Web.UI.Page
{
    Logica.clsCategorias olsCategoria = new Logica.clsCategorias();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtIdCategoria.Visible = false;
    }
    protected void btnConsultarcatego_Click1(object sender, EventArgs e)
    {
        GvCatego.DataSource = olsCategoria.Consultar_Categorias(txtNombreCategoria.Text);
        GvCatego.DataBind();
    }

    protected void GvCatego_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow fila = GvCatego.SelectedRow;
        txtIdCategoria.Text = fila.Cells[1].Text;
        txtNombreCategoria.Text = fila.Cells[2].Text;

        txtIdCategoria.Visible = true;
        txtNombreCategoria.Enabled = false;

    }

    protected void btnActualizar_Click1(object sender, EventArgs e)
    {
        bool respuesta = olsCategoria.ActualizarCategorias(Convert.ToInt32(txtIdCategoria.Text),txtNombreCategoria.Text);
        Response.Redirect("FrmCategorias.aspx");
    }
}