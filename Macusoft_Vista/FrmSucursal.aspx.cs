using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmSucursal : System.Web.UI.Page
{
    Logica.clsSucursal oCSucursal = new Logica.clsSucursal();
    protected void Page_Load(object sender, EventArgs e)
    {
        CargarSucursalesGv();
    }
    protected void btnRegistrar_Sucursal(object sender, EventArgs e)
    {
        bool respuesta = oCSucursal.Registrar_Sucursal(txtNombreSucursal.Text, txtTelefonoSucursal.Text, txtDireccionSucursal.Text);
        CargarSucursalesGv();
    }

    public void CargarSucursalesGv()
    {
        GvSucursal.DataSource = oCSucursal.ListarSucursal();
        GvSucursal.DataBind();
    }

    protected void btnConsultar_Sucursal(object sender, EventArgs e)
    {
        Response.Redirect("FrmConsultarSucursal.aspx");
    }
}