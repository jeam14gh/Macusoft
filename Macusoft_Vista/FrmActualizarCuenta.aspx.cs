using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FrmActualizarCuenta : System.Web.UI.Page
{
    Logica.clsCuenta LoCuen = new Logica.clsCuenta();
    private DataTable Cuenta;
    protected void Page_Load(object sender, EventArgs e)
    {
       
            Cuenta = (DataTable)Session["dataTable"];
            if (Cuenta == null)
            {
                Response.Redirect("FrmLogin.aspx");
            }
            else { this.txtUsuario.Text = "" + Convert.ToString(Cuenta.Rows[0][0]); }

        
    }
    protected void lbtnActualizar_Click(object sender, EventArgs e)
    {
        bool res = false;
        if (txtContarsenia.Text == txtConfirmarContraseña.Text)
        {
             string strContraEncrip = LoCuen.Generar_Clave_SHA1(txtContarsenia.Text);

             res = LoCuen.ActualizarContrasenia(txtUsuario.Text, strContraEncrip);
            if (res)
            {
                LblMensaje.Visible = true;
                LblMensaje.Text = "La contraseña fue cambiada";
            }
        }
    }
}