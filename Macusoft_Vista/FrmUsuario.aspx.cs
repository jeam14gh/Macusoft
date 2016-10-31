using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;

public partial class FrmUsuario : System.Web.UI.Page
{

    clsAdministrador lo_Administrador = new Logica.clsAdministrador();
    clsVendedor lo_Vendedor = new Logica.clsVendedor();
    clsCuenta lo_Cuenta = new Logica.clsCuenta();
    clsMunicipio oMun = new clsMunicipio();
    clsSucursal oSucur = new clsSucursal();
    Logica.clsSucursal oclsSucursal = new Logica.clsSucursal();
    private DataTable Dt_Ingreso;
    private DataTable Usuarios;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Trae la fecha actual del servidor y se la asignamos al "txtFechaRegistro" del modal "Registrar cliente"
        txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtFechaRegistro.Enabled = false;
        lblRegistrado.Visible = false;
        CargarSucursalesGv();
        listarEmpleados();

        //Metodo para listar los municipios 
        //Metodo para cargar los municipios en un DropDownlist

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
                DropDownListSucursal.Enabled = true;
                listarMunicipios();


                DropDownListSucursal.DataSource = oclsSucursal.ListarSucursal();
                DropDownListSucursal.Items.Add(new ListItem("Seleccione", "0"));
                DropDownListSucursal.AppendDataBoundItems = true;
                // Hace el enlace al atributo que posee el valor, es decir, el value.
                DropDownListSucursal.DataValueField = "Almacén";
                // Hace el enlace al atributo que mostrara los datos, es decir, el Text.
                DropDownListSucursal.DataTextField = "Nombre Almacen";
                // Llena el DropDownList con los datos de la fuente de datos
                DropDownListSucursal.DataBind();
                RadioButtonList1.SelectedValue = "Vendedor";
                RadioButtonList2.SelectedValue = "Habilitado";
            }
        }
    }

    #region Metodos del modal productos
    public void AbrirModal()
    {
        string sScriptF = "AbrirModal('#myModal');";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptAbrirModal", sScriptF, true);
    }

    public void CerrarModal()
    {
        string sScriptF = "CerrarModal('#myModal');";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptCerrarModal", sScriptF, true);
    }

    public void CerrarModalUpdatePanel()
    {
        string sScriptF = "CerrarModalUpdatePanel();";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptCerrarModalUpdatePanel", sScriptF, true);
    }
    #endregion

    private void ValidarConsulta()
    {
        GridViewListarUsuarios.Visible = false;
        txtDireccion_Empleado.Enabled = false;
        txtTelefono_Empleado.Enabled = false;
        txtEmail_Empleado.Enabled = false;
        DropDownListSucursal.Enabled = false;
        DropDownListMunicipio.Enabled = false;
        txtUsuario.Enabled = false;
        txtContarsenia.Enabled = false;
        txtConfirmarContraseña.Enabled = false;
        //RadioAbilitado.Enabled = false;
        //RadioInabilitado.Enabled = false;


    }
    private void limpiarFormulario()
    {
        #region validaciones de botones actualizar y limpiar
        txtfecha_Nacimiento.Text = "";
        txtNombre_Empleado.Text = "";
        txtApellido_Empleado.Text = "";
        txtNumero_Documento.Text = "";
        txtDireccion_Empleado.Text = "";
        txtTelefono_Empleado.Text = "";
        txtEmail_Empleado.Text = "";
        txtUsuario.Text = "";
        txtContarsenia.Text = "";
        txtConfirmarContraseña.Text = "";
        //RadioAbilitado.Checked = false;
        //RadioInabilitado.Checked = false;


        GridViewListarUsuarios.Visible = true;
        txtDireccion_Empleado.Enabled = true;
        txtTelefono_Empleado.Enabled = true;
        txtEmail_Empleado.Enabled = true;
        DropDownListSucursal.Enabled = true;
        DropDownListMunicipio.Enabled = true;
        txtUsuario.Enabled = true;
        txtContarsenia.Enabled = true;
        txtConfirmarContraseña.Enabled = true;
        //RadioAbilitado.Enabled = true;
        //RadioInabilitado.Enabled = true;
        //RadioAdministrador.Enabled = true;
        #endregion

    }
    private void listarEmpleados()
    {
        GridViewListarUsuarios.AutoGenerateColumns = false;
        GridViewListarUsuarios.DataSource = lo_Administrador.dt_ListarUsuarios();
        GridViewListarUsuarios.DataBind();

    }

    private void listarMunicipios()
    {
        DropDownListMunicipio.DataSource = oMun.dtMunicipios(0);
        DropDownListMunicipio.DataTextField = "Nombre_Municipio";
        DropDownListMunicipio.DataValueField = "Id_Municipio";
        DropDownListMunicipio.DataBind();

    }

    protected void GridViewListarUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblRegistradoError.Visible = false;
        GridViewRow row = GridViewListarUsuarios.SelectedRow;
        this.txtUsuario.Enabled = false;
        this.txtContarsenia.Enabled = false;
        this.txtConfirmarContraseña.Enabled = false;
        lbtnActualizar.Visible = true;
        if (row.Cells[12].Text == "")
        {
            txtNumero_Documento.Text = row.Cells[1].Text;
            txtFechaRegistro.Text = row.Cells[2].Text;
            txtNombre_Empleado.Text = row.Cells[3].Text;
            txtApellido_Empleado.Text = row.Cells[4].Text;
            txtDireccion_Empleado.Text = row.Cells[5].Text;
            txtTelefono_Empleado.Text = row.Cells[6].Text;

            txtEmail_Empleado.Text = row.Cells[7].Text;
            txtfecha_Nacimiento.Text = row.Cells[8].Text;

            //DropDownListSucursal.SelectedValue = row.Cells[13].Text;
            //DropDownListSucursal.DataTextField = row.Cells[10].Text;
            //DropDownListSucursal.DataBind();

            DropDownListMunicipio.SelectedValue = row.Cells[14].Text;
            DropDownListMunicipio.DataTextField = row.Cells[9].Text;
            DropDownListMunicipio.DataBind();

        }

        else if (row.Cells[12].Text != "")
        {
            //txtNumero_Documento.Text = row.Cells[1].Text;
            txtNumero_Documento.Text = GridViewListarUsuarios.SelectedDataKey.Value.ToString();
            txtFechaRegistro.Text = row.Cells[2].Text;
            txtNombre_Empleado.Text = row.Cells[3].Text;
            txtApellido_Empleado.Text = row.Cells[4].Text;
            txtDireccion_Empleado.Text = row.Cells[5].Text;
            txtTelefono_Empleado.Text = row.Cells[6].Text;

            txtEmail_Empleado.Text = row.Cells[7].Text;
            txtfecha_Nacimiento.Text = row.Cells[8].Text;

            //DropDownListSucursal.SelectedValue = row.Cells[13].Text;
            //DropDownListSucursal.DataTextField = row.Cells[10].Text;
            //DropDownListSucursal.DataBind();

            DropDownListMunicipio.SelectedValue = row.Cells[14].Text;
            DropDownListMunicipio.DataTextField = row.Cells[9].Text;
            DropDownListMunicipio.DataBind();
            lbtnRegistrarUsuario.Visible = false;



        }
    }

    protected void lbtnRegistrarUsuario_Click(object sender, EventArgs e)
    {
        string btEstado = "";
        bool Actualizar = true;
        if (DropDownListSucursal.SelectedItem.Text == "Seleccione" && RadioButtonList1.SelectedValue == "Vendedor")
        {
            Actualizar = false;
            lblRegistradoError.Visible = true;
            lblRegistradoError.Text = "Por favor seleccione una sucursal";
        }
        if (Actualizar)
        {
            if (RadioButtonList2.SelectedValue == "Habilitado")
            {

                btEstado = RadioButtonList2.Text;
            }
            else if (RadioButtonList2.SelectedValue == "Inhabilitado")
            {
                btEstado = RadioButtonList2.Text;
            }

            string btCargo = "";
            bool permisos = true;

            Usuarios = lo_Administrador.dt_ListarUsuarios();
            foreach (DataRow Row in Usuarios.Rows)
            {
                string documento = "";
                documento = Convert.ToString(Row[0]);
                string correo = "";
                correo = Convert.ToString(Row[6]);
                string usaurio = "";
                usaurio = Convert.ToString(Row[14]);

                if ((txtNumero_Documento.Text == documento) && (txtEmail_Empleado.Text == correo) && (txtUsuario.Text == usaurio))
                {
                    permisos = false;
                    lblRegistrado.Visible = true;
                    lblRegistradoError.Text = "El documento, el correo y el nombre de usuario ya existen";
                }
                else if ((txtNumero_Documento.Text == documento) && (txtUsuario.Text == usaurio))
                {
                    permisos = false;
                    lblRegistrado.Visible = true;
                    lblRegistradoError.Text = "El documento y el nombre de usuario ya existen";
                }
                else if ((txtEmail_Empleado.Text == correo) && (txtUsuario.Text == usaurio))
                {
                    permisos = false;
                    lblRegistrado.Visible = true;
                    lblRegistradoError.Text = "El correo y el nombre de usuario ya existen";
                }
                else if ((txtNumero_Documento.Text == documento) && (txtEmail_Empleado.Text == correo))
                {
                    permisos = false;
                    lblRegistrado.Visible = true;
                    lblRegistradoError.Text = "El documento y el correo ya existen";
                }

                else if (txtUsuario.Text == usaurio)
                {
                    permisos = false;
                    lblRegistrado.Visible = true;
                    lblRegistradoError.Text = "El usuario ya exitste ";
                }
                else if (txtNumero_Documento.Text == documento)
                {
                    permisos = false;
                    lblRegistrado.Visible = true;
                    lblRegistradoError.Text = "El documento ya existe ";
                }
                else if (txtEmail_Empleado.Text == correo)
                {
                    permisos = false;
                    lblRegistrado.Visible = true;
                    lblRegistradoError.Text = "El Correo ya existe ";
                }


            }

            if (permisos)
            {
                if (txtConfirmarContraseña.Text == txtContarsenia.Text)
                {
                    if (RadioButtonList1.SelectedValue == "Administrador")
                    {

                        DropDownListSucursal.Enabled = false;
                        btCargo = RadioButtonList1.Text;
                        bool oAdministrador = lo_Administrador.Registrar_Administrador(this.txtNombre_Empleado.Text, this.txtApellido_Empleado.Text, this.txtDireccion_Empleado.Text, this.txtTelefono_Empleado.Text, this.txtNumero_Documento.Text, Convert.ToDateTime(this.txtfecha_Nacimiento.Text), this.txtEmail_Empleado.Text, Convert.ToInt32(DropDownListMunicipio.SelectedValue));

                        if (oAdministrador)
                        {

                            string strContraEncrip = lo_Cuenta.Generar_Clave_SHA1(txtConfirmarContraseña.Text);
                            bool oCuenta = lo_Cuenta.RegistrarCuenta(btCargo, strContraEncrip, btEstado, this.txtUsuario.Text, this.txtNumero_Documento.Text, null);


                            if (oCuenta)
                            {
                                lblRegistradoError.Visible = false;
                                listarEmpleados();
                                limpiarFormulario();
                                lblRegistrado.Visible = true;
                                lblRegistrado.Text = "Se registró el administrador correctamente";

                            }
                            else
                            {
                                lblRegistradoError.Text = "Error al registrar el administrador";
                                lblRegistradoError.Visible = true;

                            }
                        }

                    }

                    if (RadioButtonList1.SelectedValue == "Vendedor")
                    {

                        btCargo = RadioButtonList1.Text;
                        bool oVendedor = lo_Vendedor.Registrar_Vendedor(this.txtNombre_Empleado.Text, this.txtApellido_Empleado.Text, this.txtDireccion_Empleado.Text, this.txtTelefono_Empleado.Text, this.txtNumero_Documento.Text, Convert.ToDateTime(this.txtfecha_Nacimiento.Text), this.txtEmail_Empleado.Text, Convert.ToInt32(DropDownListMunicipio.SelectedValue), Convert.ToInt32(DropDownListSucursal.SelectedValue));

                        if (oVendedor)
                        {

                            string strContraEncrip = lo_Cuenta.Generar_Clave_SHA1(txtConfirmarContraseña.Text);
                            bool oCuenta = lo_Cuenta.RegistrarCuenta(btCargo, strContraEncrip, btEstado, this.txtUsuario.Text, this.txtNumero_Documento.Text, null);

                            if (oCuenta)
                            {
                                lblRegistradoError.Visible = false;
                                listarEmpleados();
                                limpiarFormulario();
                                lblRegistrado.Visible = true;
                                lblRegistrado.Text = "Se registró el vendedor correctamente";
                            }

                            else
                            {
                                lblRegistradoError.Text = "Error al crear la cuenta";
                                lblRegistradoError.Visible = true;
                            }

                        }

                        else
                        {
                            lblRegistradoError.Text = "Error al registrar vendedor";

                        }

                    }
                }
                else
                {
                    lblRegistradoError.Text = "Las contraseñas no coinciden";
                }
            }
        }
    }

    protected void lbtnActualizar_Click(object sender, EventArgs e)
    {
        bool Actualizar = true;
        if (RadioButtonList2.SelectedValue == "")
        {
            Actualizar = false;
            lblRegistrado.Visible = true;
            lblRegistrado.Text = "Por favor Seleccione un estado en la cuenta";
        }
        if (RadioButtonList1.SelectedValue == "")
        {
            Actualizar = false;
            lblRegistrado.Visible = true;
            lblRegistrado.Text = "Por favor Seleccione un Perfil en la cuenta";
        }
        if (RadioButtonList1.SelectedValue == "Vendedor" && DropDownListSucursal.SelectedItem.Text == "Seleccione")
        {
            Actualizar = false;
            lblRegistradoError.Visible = true;
            lblRegistradoError.Text = "Por favor seleccione la sucursal de la cuenta";
        }
        if (Actualizar)
        {
            string btEstado = "";

            if (RadioButtonList2.SelectedValue == "Habilitado")
            {
                btEstado = RadioButtonList2.Text;
            }
            else if (RadioButtonList2.SelectedValue == "Inhabilitado")
            {
                btEstado = RadioButtonList2.Text;
            }

            string btCargo = "";

            if (txtConfirmarContraseña.Text == txtContarsenia.Text)
            {
                if (RadioButtonList1.SelectedValue == "Administrador")
                {
                    DropDownListSucursal.Enabled = false;
                    btCargo = RadioButtonList1.Text;
                    bool oAdministrador = lo_Administrador.Actualizar_Administrador(this.txtNombre_Empleado.Text, this.txtApellido_Empleado.Text, this.txtDireccion_Empleado.Text, this.txtTelefono_Empleado.Text, this.txtNumero_Documento.Text, Convert.ToDateTime(this.txtfecha_Nacimiento.Text), this.txtEmail_Empleado.Text, Convert.ToInt32(DropDownListMunicipio.SelectedValue));

                    if (oAdministrador)
                    {

                        string strContraEncrip = lo_Cuenta.Generar_Clave_SHA1(txtConfirmarContraseña.Text);
                        bool oCuenta = lo_Cuenta.Actualizar_Cuenta(btCargo, btEstado, this.txtNumero_Documento.Text, null);


                        if (oCuenta)
                        {

                            lblRegistrado.Visible = true;
                            lblRegistradoError.Visible = false;
                            lblRegistrado.Text = "Se actualizo de forma correcta el administrador";
                            lbtnRegistrarUsuario.Visible = true;
                            lbtnActualizar.Visible = false;
                            lblRegistradoError.Visible = false;
                            listarEmpleados();
                            limpiarFormulario();

                        }
                        else
                        {
                            lblRegistradoError.Text = "Error al actualizar la cuenta del administrador";
                            lblRegistradoError.Visible = true;

                        }
                    }

                }

                if (RadioButtonList1.SelectedValue == "Vendedor")
                {
                    btCargo = RadioButtonList1.Text;
                    bool oVendedor = lo_Vendedor.Actualizar_Vendedor(this.txtNombre_Empleado.Text, this.txtApellido_Empleado.Text, this.txtDireccion_Empleado.Text, this.txtTelefono_Empleado.Text, this.txtNumero_Documento.Text, Convert.ToDateTime(this.txtfecha_Nacimiento.Text), this.txtEmail_Empleado.Text, Convert.ToInt32(DropDownListMunicipio.SelectedValue), Convert.ToInt32(DropDownListSucursal.SelectedValue));

                    if (oVendedor)
                    {

                        string strContraEncrip = lo_Cuenta.Generar_Clave_SHA1(txtConfirmarContraseña.Text);
                        bool oCuenta = lo_Cuenta.Actualizar_Cuenta(btCargo, btEstado, this.txtNumero_Documento.Text, null);

                        if (oCuenta)
                        {
                            lblRegistrado.Text = "Se actualizo de forma correcta el vendedor";
                            lblRegistradoError.Visible = false;
                            lbtnRegistrarUsuario.Visible = true;
                            lbtnActualizar.Visible = false;
                            listarEmpleados();
                            limpiarFormulario();
                            lblRegistrado.Visible = true;
                        }

                        else
                        {
                            lblRegistradoError.Text = "Error al actualizar la cuenta";
                            lblRegistradoError.Visible = true;
                        }

                    }

                    else
                    {
                        lblRegistradoError.Text = "Error al actualizar el vendedor";

                    }

                }
            }
            else
            {
                lblRegistradoError.Text = "Las contraseñas no coinciden";
            }
        }
    }
    protected void lbtnNuevo_Click(object sender, EventArgs e)
    {
        limpiarFormulario();
    }
    protected void lbtnAddProveedor_Click(object sender, EventArgs e)
    {
        AbrirModal();
    }

    public void CargarSucursalesGv()
    {
        GvSucursal.DataSource = oclsSucursal.ListarSucursal();
        GvSucursal.DataBind();

    }

    protected void lbtnRegistrarSucursal_Click(object sender, EventArgs e)
    {
        bool respuesta = oclsSucursal.Registrar_Sucursal(txtNombreSucursal.Text, txtTelefonoSucursal.Text, txtDireccionSucursal.Text);
        if (respuesta)
        {
            lblmensageModal.Text = "Se registro correctamente el almacén";
            txtNombreSucursal.Text = "";
            txtTelefonoSucursal.Text = "";
            txtDireccionSucursal.Text = "";
        }
        CargarSucursalesGv();
        CerrarModalUpdatePanel();
        AbrirModal();
        DropDownListSucursal.Items.Clear();
        DropDownListSucursal.DataSource = oclsSucursal.ListarSucursal();
        DropDownListSucursal.Items.Add(new ListItem("Seleccione", "0"));
        DropDownListSucursal.AppendDataBoundItems = true;
        // Hace el enlace al atributo que posee el valor, es decir, el value.
        DropDownListSucursal.DataValueField = "Almacén";
        // Hace el enlace al atributo que mostrara los datos, es decir, el Text.
        DropDownListSucursal.DataTextField = "Nombre Almacen";
        // Llena el DropDownList con los datos de la fuente de datos
        DropDownListSucursal.DataBind();
    }
    protected void GridViewListarUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewListarUsuarios.PageIndex = e.NewPageIndex;
        GridViewListarUsuarios.DataSource = lo_Administrador.dt_ListarUsuarios();
        GridViewListarUsuarios.DataBind();
    }


    //jhon 11/07/2014
    //protected void CustomValidatorUsuario_ServerValidate(object source, ServerValidateEventArgs args)
    //{

    //    DataView dv;
    //    dv = dataSet1.Tables[0].DefaultView;

    //    string txtEmail;
    //    args.IsValid = false;    // Assume False
    //    // Loop through table and compare each record against user's entry
    //    foreach (DataRowView datarow in dv)
    //    {
    //        // Extract e-mail address from the current row
    //        txtEmail = datarow["Alias "].ToString();
    //        // Compare e-mail address against user's entry
    //        if (txtEmail == args.Value)
    //        {
    //            args.IsValid = true;
    //        }
    //    }
    //}
}