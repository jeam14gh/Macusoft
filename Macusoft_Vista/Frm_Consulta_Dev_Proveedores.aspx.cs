using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Frm_Consulta_Dev_Proveedores : System.Web.UI.Page
{
    Logica.clsDevolucionesProveedores DvLProvedor = new Logica.clsDevolucionesProveedores();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtnConsultar_Click(object sender, EventArgs e)
    {
        if (TxtNombre_Razon_Social.Text == "" && TxtNitProveedor.Text == "")
        {
            Respuesta.Visible = true;
            Respuesta.Text = "Ingrese uno de los criterios de busquedad";

        }
        else
        {
            Respuesta.Visible = false;
            this.GridView1.DataSource = DvLProvedor.Consultar(TxtNitProveedor.Text, TxtNombre_Razon_Social.Text);
            this.GridView1.DataBind(); 
        }

               

    }
}