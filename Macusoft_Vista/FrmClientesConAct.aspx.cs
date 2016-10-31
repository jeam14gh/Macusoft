using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class FrmClientes_ConAct : System.Web.UI.Page
{

    Logica.clsMunicipio oMun = new clsMunicipio();
    Logica.clsClientes LoCli = new clsClientes();
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

        GridViewClientes.AutoGenerateColumns = false;
        EstadoControles(0);
    }

    //Metodo para carga todos los municipios en un dropdownlist
    private void cargarMunicipios()
    {

        ddlMunicipio.DataValueField = "Id_Municipio";
        ddlMunicipio.DataTextField = "Nombre_Municipio";
        ddlMunicipio.DataBind();

    }

    //Metodo para carga todos los departamentos en un dropdownlist
    private void cargarDepartamentos()
    {

        ddlDepartamento.DataSource = oDep.dtDepartamentos();
        ddlDepartamento.Items.Add("Seleccione");
        ddlDepartamento.AppendDataBoundItems = true;
        ddlDepartamento.DataValueField = "Id_Departamento";
        ddlDepartamento.DataTextField = "Nombre_Departamento";
        ddlDepartamento.DataBind();
    }

    //METODO PARA QUE EL GRIDVIEW MUESTRE LA CONSULTA POR NOMBRE_RAZON SOCIAL O NIT_DOCUMENTO
    public void gv_CargarCliente()
    {
        GridViewClientes.DataSource = LoCli.dt_ConsultarCliente(txtNombre_RazonSocial.Text, txtNit_Documento.Text);
        GridViewClientes.DataBind();
    }

    protected void GridViewClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Evento SelectedIndexChanged que indica la seleccion de una fila y que a su vez es activada por el commandfield (boton,img ó link)
        //Selecciona una fila del gridview y se la pasamos a cada control 

        GridViewRow row = GridViewClientes.SelectedRow;
        txtFechaRegistro.Text = row.Cells[1].Text;
        txtNombre_RazonSocial.Text = row.Cells[2].Text;
        txtNit_Documento.Text = row.Cells[3].Text;
        txtFechaCumpleanos.Text = row.Cells[4].Text;

        ddlDepartamento.SelectedValue = row.Cells[11].Text;
        ddlDepartamento.DataTextField = row.Cells[5].Text;
        ddlDepartamento.DataBind();

        ddlMunicipio.SelectedValue = row.Cells[10].Text;
        ddlMunicipio.DataTextField = row.Cells[6].Text;
        ddlMunicipio.DataBind();

        txtDireccion.Text = row.Cells[7].Text;
        txtTelefono.Text = row.Cells[8].Text;
        txtEmail.Text = row.Cells[9].Text;
        EstadoControles(1);
        lbtnActualizar.Visible = true;
        lbtnEliminar.Visible = true;
        lbtnConsultar.Visible = false;
        txtNit_Documento.Enabled = false;
        txtFechaRegistro.Enabled = false;
        lblError.Visible = false;
    }

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMunicipio.DataSource = oMun.dtMunicipios(Convert.ToByte(ddlDepartamento.SelectedValue));
        this.cargarMunicipios();
        EstadoControles(1);
    }

    //Metodo para ocultar varios controles mientras se hace la consulta
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
            lblActualizar.Visible = false;
            lblMunicipio.Visible = false;
            ddlMunicipio.Visible = false;
            lblDepartamento.Visible = false;
            ddlDepartamento.Visible = false;
            lblFechaCumple.Visible = false;
            txtFechaCumpleanos.Visible = false;
        }
        if (visibilidad == 1)
        {
            lblFechaRegistro.Visible = true;
            txtFechaRegistro.Visible = true;
            lblDireccion.Visible = true;
            txtDireccion.Visible = true;
            lblEmail.Visible = true;
            txtEmail.Visible = true;
            lblTelefono.Visible = true;
            txtTelefono.Visible = true;
            lblActualizar.Visible = true;
            lblMunicipio.Visible = true;
            ddlMunicipio.Visible = true;
            lblDepartamento.Visible = true;
            ddlDepartamento.Visible = true;
            lblFechaCumple.Visible = true;
            txtFechaCumpleanos.Visible = true;
        }
    }

    //Metodo para consultar
    protected void lbtnConsultar_Click(object sender, EventArgs e)
    {
        if (txtNit_Documento.Text == "" && txtNombre_RazonSocial.Text == "")
        {
            lblError.Visible = true;
            lblError.Text = "Ingrese alguno de los criterios de busquedad ";

        }
        else
        {
            lblEliminar.Visible = false;
            if (txtNombre_RazonSocial.Text != String.Empty)
            {
                //Le pasamos el metodo para que cargue la consulta que se hizo y se muestre en el gridview
                txtNit_Documento.CausesValidation = false;
                lblError.Visible = false;
                gv_CargarCliente();
                txtNombre_RazonSocial.Text = "";
            }
            else
            {
                txtNombre_RazonSocial.CausesValidation = false;
                gv_CargarCliente();
                txtNit_Documento.Text = "";
            }
        }
    }

    //Metodo para actualizar cliente
    protected void lbtnActualizar_Click(object sender, EventArgs e)
    {
        bool Res = false;
        Res = LoCli.ActualizarCliente_Logica(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.SelectedValue), Convert.ToDateTime(txtFechaCumpleanos.Text));
        lblActualizar.Visible = true;
        if (Res)
        {
            lblActualizar.Text = "Se actualizó de forma correcta el cliente";
            //GridViewClientes.DataSource = LoCli.dt_ListarCliente();
            gv_CargarCliente();
            lbtnConsultar.Visible = true;
            lbtnEliminar.Visible = false;
            lbtnActualizar.Visible = false;
            txtNit_Documento.Text = "";
            txtNombre_RazonSocial.Text = "";
            txtNit_Documento.Enabled = true;
            GridViewClientes.Visible = false;
        }

        else
        {
            lblError.Text = "No se actualizó  el cliente";
        }
    }

    //Metodo para eliminar un cliente
    protected void lbtnEliminar_Click(object sender, EventArgs e)
    {
        bool respuesta = LoCli.EliminarCliente(txtNit_Documento.Text);
        if (respuesta)
        {
            lblEliminar.Visible = true;
            lblEliminar.Text = "Se eliminó de forma correcta el cliente";
            txtNombre_RazonSocial.Text = "";
            txtNit_Documento.Enabled = true;
            txtNit_Documento.Text = "";
            lbtnActualizar.Visible = false;
            lbtnEliminar.Visible = false;
            lbtnConsultar.Visible = true;
            
        }
        else
        {
            lblError.Text = "No se eliminó el cliente.";

        }
    }

    protected void GridViewClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewClientes.PageIndex = e.NewPageIndex;
        GridViewClientes.DataSource = LoCli.dt_ListarCliente();
        GridViewClientes.DataBind();
    }
}