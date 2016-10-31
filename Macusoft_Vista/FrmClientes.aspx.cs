using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;

public partial class FrmClientes : System.Web.UI.Page
{
    Logica.clsClientes LoCli = new clsClientes();
    Logica.clsMunicipio oMun = new clsMunicipio();
    Logica.clsDepartamento oDep = new clsDepartamento();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        ddlMunicipio.Enabled = false;
        if (!Page.IsPostBack)
        {
            //Trae la fecha actual del servidor y se la asignamos al "txtFechaRegistro" del modal "Registrar cliente"
            txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
       
            //Cargamos los municipios que estan en el Dropdownlist           
            
            cargarDepartamentos();
            cargarMunicipios();
           
        }

        txtFechaRegistro.Enabled = false;
        GridViewListarClientes.AutoGenerateColumns = false;
        GridViewListarClientes.DataSource = LoCli.dt_ListarCliente();
        GridViewListarClientes.DataBind();
    }

    //Boton consultar para dirigirlo a otra pagina

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

    //este metodo es para limpiar los controles despues de realizar un registro correctamente
    private void LimpiarControles() 
    {
        txtDireccion.Text = "";
        txtEmail.Text = "";
        txtFechaCumpleanos.Text = "";
        txtFechaRegistro.Text = "";
        txtNit_Documento.Text = "";
        txtNombre_RazonSocial.Text = "";
        txtTelefono.Text = "";
        ddlDepartamento.Items.Clear();
        ddlMunicipio.Items.Clear();
        cargarDepartamentos();
        cargarMunicipios();
    
    }

    //Metodo para carga todos los departamentos en un dropdownlist
    private void cargarDepartamentos()
    {
        ddlDepartamento.DataSource = oDep.dtDepartamentos();
        ddlDepartamento.Items.Insert(0,new ListItem("Seleccione","0"));
        ddlDepartamento.DataValueField = "Id_Departamento";
        ddlDepartamento.DataTextField = "Nombre_Departamento";
        ddlDepartamento.DataBind();
    }
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarMunicipios();
    }
    protected void lbtnRegistrarCliente_Click(object sender, EventArgs e)
    {
        int municipio = Convert.ToInt32(ddlMunicipio.SelectedValue);
        bool Res = true;
        bool reg = false;

        DataTable Clientes = LoCli.dt_ConsultarCliente(txtNombre_RazonSocial.Text, txtNit_Documento.Text);
        foreach (DataRow Cl in Clientes.Rows)
        {
            if ((txtNit_Documento.Text == Clientes.Rows[0][0].ToString()) && Clientes.Rows[0][3].ToString() == " ")
            {
                reg = LoCli.ActualizarCliente_Logica(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.SelectedValue), Convert.ToDateTime(txtFechaCumpleanos.Text));
                Res = false;
                if (reg == true)
                {
                   
                    lblMensaje.Text = "Se registró el cliente correctamente";
                    GridViewListarClientes.DataSource = LoCli.dt_ListarCliente();
                    GridViewListarClientes.DataBind();
                    LimpiarControles();
                    //Trae la fecha actual del servidor y se la asignamos al "txtFechaRegistro" del modal "Registrar cliente"
                    txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            else if ((txtNit_Documento.Text == Clientes.Rows[0][0].ToString()) && Clientes.Rows[0][3].ToString() != " ")
            {
                Res = false;
                lblError.Text = "El Cliente ya se encuentra en el sistema";
            }
        }
        if (Res)
        {
            reg = LoCli.Registrar_Cliente(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.SelectedValue), Convert.ToDateTime(txtFechaCumpleanos.Text));

            if (reg == true)
            {
               
                lblMensaje.Text = "Se registró el cliente correctamente";
                GridViewListarClientes.DataSource = LoCli.dt_ListarCliente();
                GridViewListarClientes.DataBind();
                LimpiarControles();
                //Trae la fecha actual del servidor y se la asignamos al "txtFechaRegistro" del modal "Registrar cliente"
                txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                lblError.Text = "no se registro";
            }
        }
       
    }

    //Boton consultar para dirigirlo a otra pagina
    protected void lbtnConsultar_Click1(object sender, EventArgs e)
    {
        Response.Redirect("FrmClientesConAct.aspx");
    }
    protected void GridViewListarClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewListarClientes.PageIndex = e.NewPageIndex;
        GridViewListarClientes.DataSource = LoCli.dt_ListarCliente();
        GridViewListarClientes.DataBind();
    }
}