using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting;


public partial class FrmReporte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.ReportViewerVentas.Visible = false;   
        
    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        //ReportViewerVentas.Visible = true;
        //ReportViewerVentas.LocalReport.Refresh();                
    }



    protected void btnFactura_Click(object sender, EventArgs e)
    {
        rvFacturaVenta.LocalReport.Refresh();
    }
}