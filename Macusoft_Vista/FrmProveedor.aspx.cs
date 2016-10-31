using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;

public partial class FrmProveedor : System.Web.UI.Page
{
    Logica.clsDepartamento oDep = new clsDepartamento();
    Logica.clsProveedores LoProv = new clsProveedores();
    Logica.clsMunicipio oMun = new clsMunicipio();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Trae la fecha actual del servidor y se la asignamos al "txtFechaRegistro" del modal "Registrar cliente"
        txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        
        if (!Page.IsPostBack)
        {
            //Cargamos los municipios que estan en el Dropdownlist 
            
            cargarDepartamentos();
            this.cargarMunicipios();
        }
        lblError.Visible = false;
        lblMensaje.Visible = false;
        cargarGridView();
        txtFechaRegistro.Enabled = false;
        GridViewListarProveedores.AutoGenerateColumns = false;
    }

    public void cargarGridView()
    {
        GridViewListarProveedores.DataSource = LoProv.dt_ListarProveedores();
        GridViewListarProveedores.DataBind();
    }

    //Metodo para carga todos los municipios en un dropdownlist
    private void cargarMunicipios()
    {
        if (ddlDepartamento.SelectedItem.Text == "Seleccione")
        {
            ddlMunicipio.Items.Clear();
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccione", "0"));
            ddlMunicipio.Enabled = false;
        }
        else
        {
            ddlMunicipio.Items.Clear();
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccione", "0"));
            ddlMunicipio.DataSource = oMun.dtMunicipios(Convert.ToByte(ddlDepartamento.SelectedValue));
            ddlMunicipio.DataValueField = "Id_Municipio";
            ddlMunicipio.DataTextField = "Nombre_Municipio";
            ddlMunicipio.DataBind();
            ddlMunicipio.Enabled = true;
        }
    }

    //Metodo para carga todos los departamentos en un dropdownlist
    private void cargarDepartamentos()
    {
        ddlDepartamento.Items.Clear();
        ddlDepartamento.DataSource = oDep.dtDepartamentos();
        ddlDepartamento.Items.Insert(0, new ListItem("Seleccione", "0"));
        ddlDepartamento.DataValueField = "Id_Departamento";
        ddlDepartamento.DataTextField = "Nombre_Departamento";
        ddlDepartamento.DataBind();
    }
    protected void lbtnRegistrarUsuario_Click(object sender, EventArgs e)
    {
        bool Registro = true;
        DataTable Proveedor = LoProv.dt_ListarProveedores();
        foreach(DataRow Row in Proveedor.Rows)
        {
            if (txtNit_Documento.Text == Convert.ToString(Row[0]))
            {
                Registro = false;
                lblError.Visible = true;
                lblMensaje.Visible = false;
                lblError.Text = "Este Proveedor ya existe en el sistema";
            }
            if (txtEmail.Text == Convert.ToString(Row[3]))
            {
                Registro = false;
                lblError.Visible = true;
                lblMensaje.Visible = false;
                lblError.Text = "Este Correo ya existe en el sistema";
            }
        }

        if (Registro)
        {
            bool respuesta = LoProv.registrarProveedor(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.SelectedValue));

            if (respuesta)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Se registró de forma correcta el proveedor";
                cargarGridView();
                lblError.Visible = false;
                limpiar();
            }
            else
            {
                lblMensaje.Visible = false;
                lblError.Visible = true;
                lblError.Text = "Error al registrar el proveedor";

            }
        }
    }

    protected void lbtnConsultar_Click(object sender, EventArgs e)
    {
        //Hace que al dar clic en el boton lo lleve hacia otro formulario
        Response.Redirect("FrmProveedores_ConAct.aspx");
    }

    protected void ddlDepartamento_SelectedIndexChanged1(object sender, EventArgs e)
    {
        this.cargarMunicipios();
    }
    protected void GridViewListarProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewListarProveedores.PageIndex = e.NewPageIndex;
        GridViewListarProveedores.DataSource = LoProv.dt_ListarProveedores();
        GridViewListarProveedores.DataBind();
    }

    private void limpiar()
    {
        txtNombre_RazonSocial.Text = "";
        txtNit_Documento.Text = "";
        ddlDepartamento.SelectedIndex = 0;
        ddlMunicipio.SelectedIndex = 0;
        ddlMunicipio.Enabled = false;
        txtDireccion.Text = "";
        txtTelefono.Text = "";
        txtEmail.Text = "";
    }
}