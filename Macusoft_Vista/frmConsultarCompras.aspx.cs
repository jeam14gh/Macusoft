using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class frmConsultarCompras : System.Web.UI.Page
{
    Logica.clsProveedores LoProv = new Logica.clsProveedores();
    Logica.clsCompras LoCompras = new Logica.clsCompras();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlNit.DataSource = LoProv.dt_ListarProveedores();
            ListarProv();
            ConsultarCompras();

        }

        GvConsultarCompras.DataSource = LoCompras.ListarCompras();
        GvConsultarCompras.DataBind();
        lblError.Visible = false;

    }

    public void ConsultarCompras()
    {

        Logica.clsCompras loCompras = new clsCompras();
        GvConsultarCompras.DataSource = loCompras.ListarCompras();
        GvConsultarCompras.DataBind();
    }

    public void ListarProv()
    {
        ddlNit.Items.Add(new ListItem("Seleccione", "0"));
        ddlNit.AppendDataBoundItems = true;
        ddlNit.DataTextField = "Nombre_RazonSocial";
        ddlNit.DataValueField = "Documento_Nit";
        ddlNit.DataBind();
    }
    protected void lbtnConsultar_Click(object sender, EventArgs e)
    {

        if (txtProducto.Text == ""&& ddlNit.SelectedIndex==null)
        {
            lblError.Visible = true;
            lblError.Text = "Ingrese alguno de los criterios de búsqueda";
        }
        else
        {
            GvConsultarCompras.DataSource = LoCompras.ConsultarCompras(ddlNit.Text);
            GvConsultarCompras.DataBind();
        }
    }
    protected void GvConsultarCompras_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvConsultarCompras.PageIndex = e.NewPageIndex;
        GvConsultarCompras.DataSource = LoCompras.ListarCompras();
        GvConsultarCompras.DataBind();
    }
}