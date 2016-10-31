using Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmComidas : System.Web.UI.Page
{
    Logica.clsProductos LoPro = new Logica.clsProductos();
    Comun.clsComidas coComida = null;
    private DataTable Dt_Ingreso;
    private static List<Comun.clsDetalles> listProductos =new List<clsDetalles>();
    
    private static bool estado = true;
    private static bool agregar = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            Dt_Ingreso = (DataTable)Session["dataTable"];
            if (Dt_Ingreso == null)
            {
                Response.Redirect("FrmLogin.aspx");
            }
            else
            {
                if (Dt_Ingreso.Rows[0][3].ToString().Equals("Vendedor"))
                {
                    Response.Redirect("FrmVentas.aspx");
                }
                listarProductos();

            }
        }
    }

    //Metodo para listar todos los productos en el gridview
    private void listarProductos()
    {
        gvp.DataSource = LoPro.dt_ListarProductos();
        gvp.DataBind();
    }

    protected void gvp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvp.PageIndex = e.NewPageIndex;
        gvp.DataSource = LoPro.dt_ListarProductos();
        gvp.DataBind();
    }

    protected void gvp_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvp.SelectedRow;
        var rowSelected = row.Cells[1].Text;
        var id = gvp.SelectedDataKey.Value.ToString();
        var cantidad = (DropDownList)row.FindControl("ddlCantidad");
        //Cambia el icono de la img del gridview
        LinkButton _lbtnImage = (LinkButton)row.FindControl("lbtnSeleccione");
        //lbtnImage.Text = "<span class='glyphicon glyphicon-ok'></span>";

        //Session["gvProductos"] =
        var clsdet = new clsDetalles(id, Convert.ToInt32(cantidad.SelectedValue));

        if (estado && listProductos.Count == 0)
        {
            listProductos.Add(clsdet);
            estado = false;
            changeIcon(_lbtnImage, row, 1);
            agregar = false;
        }
        else
        {
            for (int i = 0; i < listProductos.Count; i++)
            {
                if (listProductos[i].Cod_Product == clsdet.Cod_Product)
                {
                    listProductos.RemoveAt(i);
                    estado = listProductos.Count == 0 ? true : false;
                    changeIcon(_lbtnImage, row, 0);
                    agregar = false;
                    cantidad.SelectedIndex = 0;
                    break;
                }
                else
                {
                    agregar = true;
                }
            }
        }

        if (agregar)
        {
            listProductos.Add(clsdet);
            changeIcon(_lbtnImage, row, 1);
        }
    }

    private LinkButton changeIcon(LinkButton lbtnImage, GridViewRow row, int tipo)
    {
        if (tipo == 1)
        {
            lbtnImage.Text = "<span class='glyphicon glyphicon-ok'></span>";
            return lbtnImage;
        }
        else
        {
            lbtnImage.Text = "<span class='glyphicon glyphicon-hand-up'></span>";
            return lbtnImage;
        }
    }

    protected void lbtnGuardar_Click(object sender, EventArgs e)
    {
        if (listProductos.Count > 0)
        {
            coComida=new clsComidas{ 
                Comida=txtComida.Text,
                Precio=Convert.ToInt32(txtPrecio.Text),
                Productos=listProductos
            };
            new Logica.clsComidas().RegistrarComida(coComida);
            listProductos.Clear();
            Console.WriteLine("Se guardó correctamente!");
        }
        else
        {

        }
    }



}