using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Dian : System.Web.UI.Page

{
    private DataTable dtSesiion;
    Logica.clsDian dia = new Logica.clsDian();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Consecutivo.Enabled = false;
        dtSesiion = dia.Consultar_Dian();
        this.Consecutivo.Text = dtSesiion.Rows[0][0].ToString();
    }

   
    protected void btnConsultar_Consecutivo(object sender, EventArgs e)
    {
        bool res = false;
        res = dia.Actualizar_Dian();
        if (res == true)
        {
            this.Respuesta.Visible = true;
            this.Respuesta.Text = ("Se Actualizo exitosamente");
        }
        else if (res == false)
        {
            this.Respuesta.Visible = true;
            this.Respuesta.Text = ("No se Actualizo exitosamente");
        }
    }
    protected void btnRegistrar_Consecutivo(object sender, EventArgs e)
    {

        bool res = false;
        res = dia.Registrar_dian(Convert.ToInt32(this.txtRango_inicial.Text), Convert.ToInt32(this.txtRango_Final.Text));
        if (res == true)
        {
            this.Respuesta.Visible = true;
            this.Respuesta.Text = ("Se registro exitosamente");
        }
        else if (res == false)
        {
            this.Respuesta.Visible = true;
            this.Respuesta.Text = ("No se registro exitosamente");
        }
    }
}