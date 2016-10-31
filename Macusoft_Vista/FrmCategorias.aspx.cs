using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class FrmCategorias : System.Web.UI.Page
{
    Logica.clsCategorias oclCategoria = new clsCategorias();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CargarCategoriasGv();

        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Logica.clsCategorias PD = new Logica.clsCategorias();
        bool respuesta = PD.Registrar_Categoria(txtNombreCategoria.Text);
        CargarCategoriasGv();
    }


    public void CargarCategoriasGv()
    {
        Logica.clsCategorias oclCategoria = new clsCategorias();
        GvCategorias.DataSource = oclCategoria.Listar_Categorias();
        GvCategorias.DataBind();


    }

    protected void BtnConsultar_Click(object sender, EventArgs e)
    {
        Response.Redirect("FmrConsultarCategoria.aspx");
    }
}