using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inicio : System.Web.UI.MasterPage
{
    private DataTable Dt_Ingreso;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Dt_Ingreso = (DataTable)Session["dataTable"];
            if (Dt_Ingreso == null)
            {
                Response.Redirect("FrmLogin.aspx");
            }
            else
            {
                
                lblBienvenida.Text = Convert.ToString(Dt_Ingreso.Rows[0][0]);
            }

        }
        
    }

  
}
