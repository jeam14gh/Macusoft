using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class FrmProveedores_ConAct : System.Web.UI.Page
{
    Logica.clsProveedores LoProv = new clsProveedores();
    Logica.clsMunicipio oMun = new clsMunicipio();
    Logica.clsDepartamento oDep = new clsDepartamento();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            //Cargamos los municipios que estan en el Dropdownlist 
            ddlMunicipio.DataSource = oMun.dtMunicipios(0);
            this.cargarMunicipios();
            cargarDepartamentos();
        }
        lbtnActualizar.Visible = false;
        lbtnEliminar.Visible = false;
        GridViewProveedores.AutoGenerateColumns = false;
        EstadoControles(0);

    }

    //METODO PARA GRIDVIEW MUESTRE LA CONSULTA POR NOMBRE_RAZON SOCIAL O NIT_DOCUMENTO
    public void gv_CargarProveedor()
    {
        GridViewProveedores.DataSource = LoProv.dt_ConsulatarProveedores(txtNombre_RazonSocial.Text, txtNit_Documento.Text);
        GridViewProveedores.DataBind();
    }

    //Evento SelectedIndexChanged que indica la seleccion de una fila y que a su vez es activada por el commandfield (boton,img ó link)
    //Selecciona una fila del gridview y se la pasamos a cada control 
    protected void GridViewProveedores_SelectedIndexChanged(object sender, EventArgs e)
    {       
        GridViewRow row = GridViewProveedores.SelectedRow;

        txtFechaRegistro.Text = row.Cells[1].Text;
        txtNombre_RazonSocial.Text = row.Cells[2].Text;
        txtNit_Documento.Text = row.Cells[3].Text;

        ddlDepartamento.SelectedValue = row.Cells[9].Text;
        ddlDepartamento.DataTextField = row.Cells[4].Text;
        ddlMunicipio.DataSource = oMun.dtMunicipios(Convert.ToByte(row.Cells[9].Text));
        ddlMunicipio.SelectedValue = row.Cells[10].Text;
        ddlMunicipio.DataTextField = row.Cells[5].Text;

        txtDireccion.Text = row.Cells[6].Text;
        txtTelefono.Text = row.Cells[7].Text;
        txtEmail.Text = row.Cells[8].Text;

        //Ponemos visible ya los controles para que se puedan actualizar
        EstadoControles(1);
        lbtnEliminar.Visible = true;
        lbtnConsultar.Visible = false;
        lbtnActualizar.Visible = true;
        lblactualizar.Visible = false;
        lblError.Visible = false;
       
    }

    //Metodo para carga todos los municipios en un dropdownlist
    private void cargarMunicipios()
    {
        //ddlMunicipio.DataSource = oMun.dtMunicipios(Convert.ToByte(ddlDepartamento.SelectedValue));

        ddlMunicipio.DataValueField = "Id_Municipio";
        ddlMunicipio.DataTextField = "Nombre_Municipio";
        ddlMunicipio.DataBind();
    }

    //Metodo para carga todos los departamentos en un dropdownlist
    private void cargarDepartamentos()
    {
        ddlDepartamento.DataSource = oDep.dtDepartamentos();
        ddlDepartamento.DataValueField = "Id_Departamento";
        ddlDepartamento.DataTextField = "Nombre_Departamento";
        ddlDepartamento.DataBind();
    }

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlMunicipio.DataSource = oMun.dtMunicipios(Convert.ToByte(ddlDepartamento.SelectedValue));
        this.cargarMunicipios();
        EstadoControles(1);
        lbtnActualizar.Visible = true;
        lblactualizar.Visible = false;
    }

    //Metodo para ocultar o mostrar los controles
    private void EstadoControles(int visibilidad)
    {
        if (visibilidad == 0)
        {
            lblFechaRegistro.Visible = false;
            txtFechaRegistro.Visible = false;
            lblDireccion.Visible = false;
            txtDireccion.Visible = false;
            lblEmail.Visible = false;
            txtEmail.Visible = false;
            lblTelefono.Visible = false;
            txtTelefono.Visible = false;
            lblactualizar.Visible = false;
            lblMunicipio.Visible = false;
            ddlMunicipio.Visible = false;
            lblDepartamento.Visible = false;
            ddlDepartamento.Visible = false;
        }
        if (visibilidad == 1)
        {
            txtFechaRegistro.Enabled = false;
            lblFechaRegistro.Visible = true;
            txtFechaRegistro.Visible = true;
            lblDireccion.Visible = true;
            txtDireccion.Visible = true;
            lblEmail.Visible = true;
            txtEmail.Visible = true;
            lblTelefono.Visible = true;
            txtTelefono.Visible = true;
            lblactualizar.Visible = true;
            lblMunicipio.Visible = true;
            ddlMunicipio.Visible = true;
            lblDepartamento.Visible = true;
            ddlDepartamento.Visible = true;
        }
    }

    protected void lbtnConsultar_Click(object sender, EventArgs e)
    {
        if (txtNombre_RazonSocial.Text == "" && txtNit_Documento.Text == "")
        {
            lblError.Visible = true;
            lblError.Text = "Ingrese alguno de los criterios de búsqueda.";
        }
        else
        {
            if (txtNombre_RazonSocial.Text != String.Empty)
            {
                //Le pasamos el metodo para que cargue la consulta que se hizo y se muestre en el gridview
                txtNit_Documento.CausesValidation = false;
                lblError.Visible = false;                
                gv_CargarProveedor();
                txtNombre_RazonSocial.Text = "";
            }
            else
            {
                txtNombre_RazonSocial.CausesValidation = false;
                gv_CargarProveedor();
                txtNit_Documento.Text = "";
            }
        }
            
        
    }
    //protected void lbtnActualizar_Click(object sender, EventArgs e)
    //{

    //    bool respuesta = LoProv.actualizarProveedor(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.Text));
    //    if (respuesta)
    //    {
    //        lblactualizar.Visible = true;
    //        lblactualizar.Text = "Se actualizó correctamente el proveedor";
    //        lbtnConsultar.Visible = true;
    //        lbtnEliminar.Visible = false;
    //        txtNombre_RazonSocial.Text = "";
    //        txtNit_Documento.Text = "";
    //        gv_CargarProveedor();
    //    }
    //    else 
    //    {
    //        lblError.Visible = true;
    //        lblError.Text = "Error al actualizar al proveedor";
        
    //    }
    //}

    protected void lbtnEliminar_Click(object sender, EventArgs e)
    {
        bool respuesta = LoProv.EliminarProveedor(txtNit_Documento.Text);
        if (respuesta)
        {
            lblactualizar.Visible = true;
            lbtnConsultar.Visible = true;
            lblactualizar.Text = "Se elimino de forma correcta el proveedor";
            GridViewProveedores.DataSource = LoProv.dt_ListarProveedores();
            GridViewProveedores.DataBind();
        }
        else
        {
            lblError.Text = "No se elimino el proveedor";

        }
    }
    protected void GridViewProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewProveedores.PageIndex = e.NewPageIndex;
        GridViewProveedores.DataSource = LoProv.dt_ListarProveedores();
        GridViewProveedores.DataBind();
    }
    protected void lbtnActualizar_Click(object sender, EventArgs e)
    {
        bool respuesta = LoProv.actualizarProveedor(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.Text));
        if (respuesta)
        {
            lblactualizar.Visible = true;
            lblactualizar.Text = "Se actualizó correctamente el proveedor";
            lbtnConsultar.Visible = true;
            lbtnEliminar.Visible = false;
            txtNombre_RazonSocial.Text = "";
            txtNit_Documento.Text = "";
            gv_CargarProveedor();
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Error al actualizar al proveedor";

        }
    }
}