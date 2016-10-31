using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmConsultarSucursal : System.Web.UI.Page
{
    Logica.clsSucursal oclSucursal = new Logica.clsSucursal();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtIdSucursal.Visible = false;
        txtDireccionSucursal.Visible = false;
        txtTelefonoSucursal.Visible = false;
        txtIdSucursal.Visible = false;
        txtDireccionSucursal.Visible = false;
        txtTelefonoSucursal.Visible = false;
    }

    protected void btnActualizar_Click1(object sender, EventArgs e)
    {
        bool respuesta = oclSucursal.Actualizar_Sucursal(Convert.ToInt32(txtIdSucursal.Text),txtNombreSucursal.Text,txtTelefonoSucursal.Text,txtDireccionSucursal.Text);
        Response.Redirect("FrmSucursal.aspx");
       
    }
    protected void btnConsultar_Click1(object sender, EventArgs e)
    {
        GvSucursal.DataSource = oclSucursal.ConsultarSucursal(txtNombreSucursal.Text);
        GvSucursal.DataBind();
    }
   
    protected void GvSucursal_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow fila = GvSucursal.SelectedRow;
        txtIdSucursal.Text = fila.Cells[1].Text;
        txtNombreSucursal.Text = fila.Cells[2].Text;
        txtTelefonoSucursal.Text = fila.Cells[3].Text;
        txtDireccionSucursal.Text = fila.Cells[4].Text;

        txtIdSucursal.Visible = true;
        txtDireccionSucursal.Visible = true;
        txtTelefonoSucursal.Visible = true;
        lblIdSucursal.Visible = true;
        lblDireccionSucursal.Visible = true;
        lblTelefonoSucursal.Visible = true;

        txtIdSucursal.Enabled = false;



    }
}