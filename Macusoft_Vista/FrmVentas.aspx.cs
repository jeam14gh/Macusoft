using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;
using System.Data.SqlClient;

public partial class FrmVentas : System.Web.UI.Page
{
    //Instancias de las clases de la capa de lógica
    Logica.clsCategorias LoCat = new Logica.clsCategorias();
    Logica.clsProductos LoPro = new Logica.clsProductos();
    Logica.clsVentas LoVen = new Logica.clsVentas();
    Logica.clsMunicipio LoMun = new clsMunicipio();
    Logica.clsDepartamento oDep = new clsDepartamento();
    Logica.clsClientes LoCli = new clsClientes();
    Logica.clsVentasDetalle LoVenDet = new clsVentasDetalle();
    Logica.clsDetalles LoDet = new clsDetalles();
    Logica.clsDian LoDia = new clsDian();
    int precio = 0;
    int tot = 0;
    //private DataTable dtDetalle;
    public string idProducto;
    //Varaiable que almacena el valor total de la venta
    private int totalPagar = 0;
    private decimal descuento = 0;
    private DataTable dtSesiion;
    private DataTable CostoVenta;
    private DataTable Documento;
    private DataTable dt = new DataTable();
    private DataTable dtDetalle = new DataTable("Detalles");
    int exitencias = 0;
    private DataTable Minimo;
    private DataTable Producto;
    int StockMinimo;
    int Actuales;
    Logica.clsDian dia = new Logica.clsDian();
   

    string cod = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Trae la fecha actual del servidor y se la asignamos al "txtFechaRegistro" del modal "Registrar cliente"
        txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        ddlDescuento.AppendDataBoundItems = true;
        ddlProductos.Enabled = false;
        DataTable Dian = LoDia.Consultar_Dian();
        int Inicio = Convert.ToInt32(Dian.Rows[0][0].ToString());
        int Final = Convert.ToInt32(Dian.Rows[0][1].ToString());
        Restantes.Text = "Consecutivos Restantes " + (Final - Inicio);
        ddlMunicipio.Enabled = false;
        
       


        if (Final < Inicio)
        {
            Restantes.Text = "Por Favor Ingrese los nuevos Rangos";
            txtDocNit.Enabled = false;
            txtCAntidad.Enabled = false;
            txtTotalPagar.Enabled = false;
            txtNomRazSoc.Enabled = false;
            txtPrecioVenta.Enabled = false;
            lbtnDescuento.Enabled = false;
            lbtnRegistrar.Enabled = false;
            btnAgregarDetalle.Enabled = false;

        }
        if (Final >= Inicio)
        {
            txtDocNit.Enabled = true;
            txtCAntidad.Enabled = true;
            txtTotalPagar.Enabled = true;
            txtNomRazSoc.Enabled = true;
            txtPrecioVenta.Enabled = true;
            lbtnDescuento.Enabled = true;
            lbtnRegistrar.Enabled = true;
            btnAgregarDetalle.Enabled = true;
        }
        if (txtTotalPagar.Text != "" || tot > 0)
        {
            lbtnDescuento.Enabled = true;
        }
        if (tot == 0)
        {
            lbtnRegistrar.Visible = false;
        }
        txtCAntidad.Enabled = false;
        btnAgregarDetalle.Enabled = false;
        txtPrecioVenta.Enabled = false;
        lbtnDescuento.Enabled = false;
        lbtnRegistrar.Visible = false;
        if (!Page.IsPostBack)
        {
            //Esta es la varible de sesion donde le mostramos los formularios al rol del usuario


            Documento = (DataTable)Session["dataTable"];
            if (Documento == null)
            {
                Response.Redirect("FrmLogin.aspx");
            }
            else
            {
                this.txtDocEmpleado.Text = "" + Convert.ToString(Documento.Rows[0][4]);

                txtDocEmpleado.Enabled = false;
                ddlProductos.DataSource = LoPro.dtListarProductosXCategorias(0);
                this.cargarProductos();
                cargarCategorias();
                txtPrecioVenta.Enabled = false;

                this.cargarDepartamentos();
                cargarMunicipios();//Prueba jhon

                this.txtConsecutivo.Enabled = false;
                dtSesiion = dia.Consultar_Dian();
                this.txtConsecutivo.Text = dtSesiion.Rows[0][0].ToString();
                LoDet.Elimina_Detalles();
                lblmsj.Text = "";
                lblMensaje.Text = "";
                lblmensageModal.Text = "";
            }
        }

    }

    //Metodo para cargar las categorias en un DropDownList
    private void cargarCategorias()
    {
        ddlCategoria.DataSource = LoCat.dtListarCategorias();
        ddlCategoria.Items.Add(new ListItem("Seleccione", "0"));
        ddlCategoria.AppendDataBoundItems = true;
        ddlCategoria.DataValueField = "Id_Categoria";
        ddlCategoria.DataTextField = "Nombre_Categoria";
        ddlCategoria.DataBind();
    }

    //Metodo para cargar los productos en un DropDownList
    private void cargarProductos()
    {
        ddlProductos.Items.Add(new ListItem("Seleccione", "0"));
        ddlProductos.AppendDataBoundItems = true;
        ddlProductos.DataValueField = "Cod_Producto";
        ddlProductos.DataTextField = "Nombre_Producto";
        ddlProductos.DataBind();
    }

    //Metodo para carga todos los municipios en un dropdownlist
    private void cargarMunicipios()
    {
        if (ddlDepartamento.SelectedItem.Text == "Seleccione")
        {
            ddlMunicipio.Items.Clear();
            //ddlMunicipio.Items.Add("Seleccione");
            //ddlMunicipio.AppendDataBoundItems = true;
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        else
        {
            ddlMunicipio.Items.Clear();
            //ddlMunicipio.Items.Add("Seleccione");
            //ddlMunicipio.AppendDataBoundItems = true;
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccione", "0"));
            ddlMunicipio.DataSource = LoMun.dtMunicipios(Convert.ToByte(ddlDepartamento.SelectedValue));
            ddlMunicipio.DataValueField = "Id_Municipio";
            ddlMunicipio.DataTextField = "Nombre_Municipio";
            ddlMunicipio.DataBind();
        }

    }

    //Metodo para carga todos los departamentos en un dropdownlist
    private void cargarDepartamentos()
    {
        ddlDepartamento.DataSource = oDep.dtDepartamentos();
        //ddlDepartamento.Items.Add("Seleccione");
        ddlDepartamento.Items.Insert(0, new ListItem("Seleccione", "0"));
        //ddlDepartamento.AppendDataBoundItems = true;
        ddlDepartamento.DataValueField = "Id_Departamento";
        ddlDepartamento.DataTextField = "Nombre_Departamento";
        ddlDepartamento.DataBind();
    }

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlMunicipio.DataSource = LoMun.dtMunicipios(Convert.ToByte(ddlDepartamento.SelectedValue));
        this.cargarMunicipios();
        CerrarModalUpdatePanel();
        AbrirModal();
        ddlMunicipio.Enabled = true;
    }

    //Evento que permite cargar los productos que estan asociados a una categoria. Por medio de un DropDownList (ddlCategoria) hacia un (ddlProductos)
    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProductos.Items.Clear();
        ddlProductos.DataSource = LoPro.dtListarProductosXCategorias(Convert.ToInt32(ddlCategoria.SelectedValue));
        this.cargarProductos();
        ddlProductos.Enabled = true;
    }

    //Evento del boton "+" para llevarlo al formulario "registrar cliente", si este no está registrado al momento de la venta
    protected void lbtnAddCliente_Click(object sender, EventArgs e)
    {
        AbrirModal();
    }

    #region Metodos del modal
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

    #region Metodos del modal del consecutivo
    public void AbrirModal2()
    {
        string sScriptF = "AbrirModal('#Mymodal2');";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptAbrirModal", sScriptF, true);
    }

    public void CerrarModal2()
    {
        string sScriptF = "CerrarModal('#Mymodal2');";
        ScriptManager.RegisterClientScriptBlock(this.UPForm, UPForm.GetType(), "ScriptCerrarModal", sScriptF, true);
    }
    #endregion


    protected void btnRegistrar_Click(object sender, EventArgs e)   //Boton registrar nuevo cliente del modal
    {
        string Esta = "";
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
                    txtNombre_RazonSocial.Text = txtNomRazSoc.Text;
                    lblMensaje.Text = "Se registró el cliente correctamente";
                }
            }
            else if ((txtNit_Documento.Text == Clientes.Rows[0][0].ToString()) && Clientes.Rows[0][3].ToString() != " ")
            {
                Res = false;
                lblMensaje.Text = "El Cliente ya se encuentra en el sistema";
            }
        }
        if (Res)
        {
            reg = LoCli.Registrar_Cliente(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.SelectedValue), Convert.ToDateTime(txtFechaCumpleanos.Text));

            if (reg == true)
            {
                txtNombre_RazonSocial.Text = txtNomRazSoc.Text;
                lblMensaje.Text = "Se registró el cliente correctamente";
            }
            else
            {
                lblMensaje.Text = "no se registro";
            }
        }
    }

    protected void btnAgregarDetalle_Click(object sender, EventArgs e)
    {
        bool Res = true;
        if (Convert.ToInt32(txtCAntidad.Text) == 0)
        {
            lblmsj.Text = "la Catindad tiene que ser mayor a 0";
        }
        else
        {
            foreach (GridViewRow Rows in GridViewDetalleVenta.Rows)
            {
                if (Rows.Cells[1].Text == Convert.ToString(ddlProductos.SelectedValue))
                {
                    Res = false;
                }
            }
            if (Res)
            {
                LoDet.Registrar_detalles(Convert.ToString(ddlProductos.SelectedValue), Convert.ToInt32(txtCAntidad.Text), Convert.ToInt32(txtPrecioVenta.Text));
                Minimo = LoPro.ProductoCod(Convert.ToString(ddlProductos.SelectedValue));
                Actuales = Convert.ToInt32(Minimo.Rows[0][6].ToString());
                int cantidad = Convert.ToInt32(txtCAntidad.Text);
                exitencias += Actuales - cantidad;
                if (exitencias < 0)
                {
                    lblmsj.Text = "No se puede agregar mas productos de la referencia " + Convert.ToString(ddlProductos.SelectedValue) + " actuamente solo hay " + Actuales + " " + Convert.ToString(Minimo.Rows[0][2].ToString());
                    LoDet.Eliminar_Detalles(Convert.ToString(ddlProductos.SelectedValue));
                }
                else
                {
                    lblmsj.Text = "";
                    GridViewDetalleVenta.DataSource = LoDet.Consultar_Detalles();
                    GridViewDetalleVenta.DataBind();

                    foreach (GridViewRow row in GridViewDetalleVenta.Rows)
                    {
                        tot += (Convert.ToInt32(row.Cells[5].Text));
                        txtTotalPagar.Text = "" + tot;


                    }
                }
                txtCAntidad.Text = "";
                ddlProductos.Items.Clear();
                ddlCategoria.Items.Clear();
                cargarProductos();
                txtCAntidad.Text = "0";
                txtPrecioVenta.Text = "";
                cargarCategorias();
                lbtnDescuento.Enabled = true;
                RadioButtonList1.ClearSelection();
            }
            else
            {
                lblmsj.Text = "No se puede agregar mas productos de la misma referencia, Modifique el detalle";
                btnModificarDetalle.Visible = false;
                btnQuitarDetalle.Visible = false;
                btnAgregarDetalle.Visible = true;
                txtCAntidad.Text = "";
                ddlProductos.Items.Clear();
                ddlCategoria.Items.Clear();
                cargarProductos();
                txtCAntidad.Text = "0";
                txtPrecioVenta.Text = "";
                cargarCategorias();
                lbtnDescuento.Enabled = true;
            }
        }
    }

    protected void btnQuitarDetalle_Click(object sender, EventArgs e)
    {
        LoDet.Eliminar_Detalles(Convert.ToString(ddlProductos.SelectedValue));
        GridViewDetalleVenta.DataSource = LoDet.Consultar_Detalles();
        GridViewDetalleVenta.DataBind();
        bool est = false;
        foreach (GridViewRow row in GridViewDetalleVenta.Rows)
        {
            tot += (Convert.ToInt32(row.Cells[5].Text));
            txtTotalPagar.Text = "" + tot;
            est = true;

        }
        if (est == false)
        {
            tot = 0;
            txtTotalPagar.Text = "" + tot;
        }
        btnModificarDetalle.Visible = false;
        btnQuitarDetalle.Visible = false;
        btnAgregarDetalle.Visible = true;
        txtCAntidad.Text = "";
        ddlProductos.Items.Clear();
        ddlCategoria.Items.Clear();
        cargarProductos();
        txtCAntidad.Text = "0";
        txtPrecioVenta.Text = "";
        cargarCategorias();
        lbtnDescuento.Enabled = true;
        RadioButtonList1.ClearSelection();
    }




    protected void lbtnDescuento_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridViewDetalleVenta.Rows)
        {
            tot += (Convert.ToInt32(row.Cells[5].Text));
            txtTotalPagar.Text = "" + tot;

        }
        if (ddlDescuento.SelectedItem.Text == Convert.ToString(0))
        {
            int total = Convert.ToInt32(txtTotalPagar.Text);
            txtTotalPagar.Text = "" + (total );
        }
        else if (ddlDescuento.SelectedItem.Text == Convert.ToString(5))
        {
            int total = Convert.ToInt32(txtTotalPagar.Text);
            txtTotalPagar.Text = "" + ((total * 0.95) );
        }
        else if (ddlDescuento.SelectedItem.Text == Convert.ToString(10))
        {
            int total = Convert.ToInt32(txtTotalPagar.Text);
            txtTotalPagar.Text = "" + ((total * 0.90) );
        }
        else if (ddlDescuento.SelectedItem.Text == Convert.ToString(15))
        {
            int total = Convert.ToInt32(txtTotalPagar.Text);
            txtTotalPagar.Text = "" + ((total * 0.85) );
        }
        lbtnRegistrar.Visible = true;
        btnAgregarDetalle.Enabled = false;
        lbtnDescuento.Enabled = true;
        txtCAntidad.Text = "1";

    }
    protected void lbtnRegistrar_Click(object sender, EventArgs e)
    {
        bool Registro = false;
        bool Resp = false;
        string Esta = "";
        DataTable dtRegistro = new DataTable();
        DataTable Clientes = LoCli.dt_ConsultarCliente(txtNomRazSoc.Text, txtDocNit.Text);
        foreach (DataRow Cl in Clientes.Rows)
        {
            Esta = Clientes.Rows[0][0].ToString();
            if (txtDocNit.Text == Esta)
                Registro = true;
        }
        if (Registro)
        {
            dtRegistro = LoVen.dt_RegistrarVenta(txtDocNit.Text, txtDocEmpleado.Text, int.Parse(ddlDescuento.Text), int.Parse(txtConsecutivo.Text));

            foreach (GridViewRow row in GridViewDetalleVenta.Rows)
            {
                Resp = LoDet.Agregar_Detalles(Convert.ToString(row.Cells[1].Text), Convert.ToInt32(row.Cells[3].Text), Convert.ToInt32(row.Cells[4].Text));
                if (Resp)
                {

                    LoPro.Disminuir(Convert.ToString(row.Cells[1].Text));
                    Minimo = LoPro.ProductoCod(Convert.ToString(row.Cells[1].Text));
                    StockMinimo = Convert.ToInt32(Minimo.Rows[0][4].ToString());
                    Actuales = Convert.ToInt32(Minimo.Rows[0][6].ToString());
                    int x = 0;
                    x = Convert.ToInt32(Minimo.Rows[0][1].ToString());
                    Producto = LoPro.dtConsultarProducto(row.Cells[1].Text, "", x);
                    if ((Actuales - Convert.ToInt32(row.Cells[3].Text)) == 0)
                    {
                        LoPro.ActualizarExistencias(Convert.ToString(row.Cells[1].Text));

                    }
                    Minimo = LoPro.ProductoCod(Convert.ToString(row.Cells[1].Text));
                    StockMinimo = Convert.ToInt32(Minimo.Rows[0][4].ToString());
                    Actuales = Convert.ToInt32(Minimo.Rows[0][6].ToString());
                    if (Actuales < StockMinimo)
                    {
                        lblmsj.Text += "El Producto '" + Convert.ToString(row.Cells[2].Text) + "' con referencia '" + Convert.ToString(row.Cells[1].Text) + "', se está agotando. Sólo quedan " + Actuales + ".<br/>";
                    }

                }
            }
            if (Resp)
            {
                LoDet.Elimina_Detalles();
                LoDia.Actualizar_Dian();
                dtSesiion = dia.Consultar_Dian();
                txtDocNit.Text = "";
                txtCAntidad.Text = "";
                txtTotalPagar.Text = "";
                txtNomRazSoc.Text = "";
                txtPrecioVenta.Text = "";
                this.txtConsecutivo.Text = dtSesiion.Rows[0][0].ToString();
                lblmsj2.Visible = true;
                lblmsj2.Text += "Se registró correctamente la venta";
                GridViewDetalleVenta.DataSource = LoDet.Consultar_Detalles();
                GridViewDetalleVenta.DataBind();
            }
        }
        else
        {
            LoCli.Registrar_Cliente(txtNomRazSoc.Text, " ", " ", txtDocNit.Text, " ", 1, 1, Convert.ToDateTime("01/01/2000"));
            dtRegistro = LoVen.dt_RegistrarVenta(txtDocNit.Text, txtDocEmpleado.Text, int.Parse(ddlDescuento.Text), int.Parse(txtConsecutivo.Text));

            foreach (GridViewRow row in GridViewDetalleVenta.Rows)
            {
                Resp = LoDet.Agregar_Detalles(Convert.ToString(row.Cells[1].Text), Convert.ToInt32(row.Cells[3].Text), Convert.ToInt32(row.Cells[4].Text));
                if (Resp)
                {
                    LoPro.Disminuir(Convert.ToString(row.Cells[1].Text));
                    Minimo = LoPro.ProductoCod(Convert.ToString(row.Cells[1].Text));
                    StockMinimo = Convert.ToInt32(Minimo.Rows[0][4].ToString());
                    Actuales = Convert.ToInt32(Minimo.Rows[0][6].ToString());
                    int x = 0;
                    x = Convert.ToInt32(Minimo.Rows[0][1].ToString());
                    Producto = LoPro.dtConsultarProducto(row.Cells[1].Text, "", x);
                    if ((Actuales - Convert.ToInt32(row.Cells[3].Text)) == 0)
                    {
                        LoPro.ActualizarExistencias(Convert.ToString(row.Cells[1].Text));

                    }
                    Minimo = LoPro.ProductoCod(Convert.ToString(row.Cells[1].Text));
                    StockMinimo = Convert.ToInt32(Minimo.Rows[0][4].ToString());
                    Actuales = Convert.ToInt32(Minimo.Rows[0][6].ToString());
                    if (Actuales < StockMinimo)
                    {
                        lblmsj.Text += "El Producto '" + Convert.ToString(row.Cells[2].Text) + "' con referencia '" + Convert.ToString(row.Cells[1].Text) + "', se está agotando. Sólo quedan " + Actuales + ".<br/>";
                    }

                }
            }
            if (Resp)
            {
                LoDet.Elimina_Detalles();
                LoDia.Actualizar_Dian();
                dtSesiion = dia.Consultar_Dian();
                txtDocNit.Text = "";
                txtCAntidad.Text = "";
                txtTotalPagar.Text = "";
                txtNomRazSoc.Text = "";
                txtPrecioVenta.Text = "";
                this.txtConsecutivo.Text = dtSesiion.Rows[0][0].ToString();
                lblmsj2.Visible = true;
                lblmsj2.Text += "Se registró correctamente la venta";
                GridViewDetalleVenta.DataSource = LoDet.Consultar_Detalles();
                GridViewDetalleVenta.DataBind();
                RadioButtonList1.ClearSelection();
            }
        }



    }
    protected void GridViewDetalleVenta_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridViewDetalleVenta.SelectedRow;
        cod = row.Cells[1].Text;
        ddlProductos.Items.Clear();
        ddlProductos.DataSource = LoPro.ProductoCod(cod);
        ddlProductos.DataBind();
        txtPrecioVenta.Text = row.Cells[4].Text;
        txtCAntidad.Text = row.Cells[3].Text;
        btnModificarDetalle.Visible = true;
        btnQuitarDetalle.Visible = true;
        btnAgregarDetalle.Visible = false;
        txtCAntidad.Enabled = true;
    }
    protected void btnModificarDetalle_Click(object sender, EventArgs e)
    {
        LoDet.Eliminar_Detalles(Convert.ToString(ddlProductos.SelectedValue));
        Minimo = LoPro.ProductoCod(Convert.ToString(ddlProductos.SelectedValue));
        Actuales = Convert.ToInt32(Minimo.Rows[0][6].ToString());
        int cantidad = Convert.ToInt32(txtCAntidad.Text);
        exitencias += Actuales - cantidad;
        if (exitencias < 0)
        {
            lblmsj.Text = "No se puede agregar mas productos de la referencia " + Convert.ToString(ddlProductos.SelectedValue) + " actuamente solo hay " + Actuales + " " + Convert.ToString(Minimo.Rows[0][2].ToString());
            LoDet.Eliminar_Detalles(Convert.ToString(ddlProductos.SelectedValue));
        }
        else
        {

            LoDet.Registrar_detalles(Convert.ToString(ddlProductos.SelectedValue), Convert.ToInt32(txtCAntidad.Text), Convert.ToInt32(txtPrecioVenta.Text));
            GridViewDetalleVenta.DataSource = LoDet.Consultar_Detalles();
            GridViewDetalleVenta.DataBind();
            foreach (GridViewRow row in GridViewDetalleVenta.Rows)
            {
                tot += (Convert.ToInt32(row.Cells[5].Text));
                txtTotalPagar.Text = "" + tot;

            }
            btnModificarDetalle.Visible = false;
            btnQuitarDetalle.Visible = false;
            btnAgregarDetalle.Visible = true;
            txtCAntidad.Text = "";
            ddlProductos.Items.Clear();
            ddlCategoria.Items.Clear();
            cargarProductos();
            txtCAntidad.Text = "0";
            txtPrecioVenta.Text = "";
            cargarCategorias();
            lbtnDescuento.Enabled = true;
            RadioButtonList1.ClearSelection();
        }
    }
    protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCAntidad.Enabled = true;
        ddlProductos.Enabled = true;
    }
    protected void lbtnAddConsecutivo_Click(object sender, EventArgs e)
    {
        AbrirModal2();
    }
    protected void lbtnRegistrarConsecutivo_Click(object sender, EventArgs e)
    {
        bool res = false;
        DataTable Dian = LoDia.Consultar_Dian();
        int Inicio = Convert.ToInt32(Dian.Rows[0][0].ToString());
        int Final = Convert.ToInt32(Dian.Rows[0][1].ToString());
        if (Inicio > Final)
        {
            if (Convert.ToInt32(txtRango_Final.Text) <= Convert.ToInt32(txtRango_inicial.Text))
            {

                this.lblmensageModal.Text = ("EL Rango final debe ser mayor al rango inicial");
                CerrarModalUpdatePanel();
                AbrirModal2();
            }
            else
            {
                res = dia.Registrar_dian(Convert.ToInt32(this.txtRango_inicial.Text), Convert.ToInt32(this.txtRango_Final.Text));
                if (res == true)
                {
                    this.lblmensageModal.Visible = true;
                    this.lblmensageModal.Text = ("Se registro exitosamente");
                    txtRango_inicial.Text = "";
                    txtRango_Final.Text = "";
                    CerrarModalUpdatePanel();
                    AbrirModal2();
                }
                else if (res == false)
                {
                    this.lblmensageModal.Visible = true;
                    this.lblmensageModal.Text = ("Error al registrar");
                    AbrirModal2();
                }
            }
        }
        else
        {
            this.lblmensageModal.Text = ("No se puede registrar mas consecutivos hasta acabar el actual");
            txtRango_inicial.Text = "";
            txtRango_Final.Text = "";
            CerrarModalUpdatePanel();
            AbrirModal2();
        }

    }
    protected void lbtnRegistrarCliente_Click(object sender, EventArgs e)
    {
        string Esta = "";
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
                    txtDocNit.Text = txtNit_Documento.Text;
                    txtNomRazSoc.Text = txtNombre_RazonSocial.Text;
                    //lblMensaje.Text = "Se registró el cliente correctamente";                    
                }
            }
            else if ((txtNit_Documento.Text == Clientes.Rows[0][0].ToString()) && Clientes.Rows[0][3].ToString() != " ")
            {
                Res = false;
                lblMensaje.Text = "El Cliente ya se encuentra en el sistema";
            }
        }
        if (Res)
        {
            reg = LoCli.Registrar_Cliente(txtNombre_RazonSocial.Text, txtDireccion.Text, txtTelefono.Text, txtNit_Documento.Text, txtEmail.Text, Convert.ToByte(ddlDepartamento.SelectedValue), Convert.ToInt32(ddlMunicipio.SelectedValue), Convert.ToDateTime(txtFechaCumpleanos.Text));

            if (reg == true)
            {
                txtDocNit.Text = txtNit_Documento.Text;
                txtNomRazSoc.Text = txtNombre_RazonSocial.Text;
                lblMensaje.Text = "Se registró el cliente correctamente";
                limpiarModalCliente();

                //16/07 jhon
                CerrarModalUpdatePanel();
                AbrirModal();
                
            }
            else
            {
                lblMensaje.Text = "No se registró";
            }
        }

        //CerrarModalUpdatePanel();
        //AbrirModal();
    }

    protected void txtCAntidad_TextChanged(object sender, EventArgs e)
    {
        if (txtCAntidad.Text == "")
        {
            btnAgregarDetalle.Enabled = false;
        }
        else if (txtCAntidad.Text != "")
        {
            txtCAntidad.Enabled = true;
            btnAgregarDetalle.Enabled = true;
        }
    }

    public void limpiarModalCliente()
    {
        txtNombre_RazonSocial.Text = "";
        txtNit_Documento.Text = "";
        txtFechaCumpleanos.Text = "";

        //ddlDepartamento.ClearSelection();
        //ddlMunicipio.ClearSelection();

        ddlDepartamento.Items.Clear();
        ddlMunicipio.Items.Clear();

        txtDireccion.Text = "";
        txtTelefono.Text = "";
        txtEmail.Text = "";

        cargarDepartamentos();
        cargarMunicipios();
    }

    //Trae el Nombre/Razon Social del cliente al ingresar su NIT/Documento
    protected void lbtnBuscar_Click(object sender, EventArgs e)
    {
        //DataTable Cliente = LoCli.dt_ConsultarCliente(txtNomRazSoc.Text, txtDocNit.Text);
        //txtNomRazSoc.Text = Convert.ToString(Cliente.Rows[0][2].ToString());
        //txtNomRazSoc.Enabled = false;

        //lblmsj2.Text = "";
        //lblmsj.Text = "";
        try
        {
            //DataTable dtProveedor = LoProv.dt_ConsulatarProveedores(TxtNombreRazonSocial.Text, TxtNitProveedor.Text);
            DataTable dtClientes = LoCli.dt_ListarCliente();
            foreach (DataRow fila in dtClientes.Rows)
            {
                string nombre = "" + Convert.ToString(fila[2]);
                string nitDoc = "" + Convert.ToString(fila[0]);
                if (txtDocNit.Text == nitDoc)
                {
                    txtNomRazSoc.Text = nombre;
                    lblmsj2.Text = "";
                    lblmsj.Text = "";
                }
                //else if (txtDocNit.Text != nitDoc)
                //{
                //    Respuesta.Visible = true;
                //    Respuesta.Text = "No se encontró un registro";
                //}
            }


            //TxtNombreRazonSocial.Text = "" + dtProveedor.Rows[0]["Nombre_RazonSocial"];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProductos.Enabled = true;
        txtCAntidad.Enabled = true;
        if (RadioButtonList1.SelectedValue == "Publico")
        {
            CostoVenta = LoPro.CostoVenta(ddlProductos.SelectedValue);
            this.txtPrecioVenta.Text = CostoVenta.Rows[0][0].ToString();
        }
        
        if (RadioButtonList1.SelectedValue == "Pormayor")
        {
            CostoVenta = LoPro.CostoVenta(ddlProductos.SelectedValue);
            this.txtPrecioVenta.Text = CostoVenta.Rows[0][1].ToString();
        }
    }
}