using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
// Librerias Utilizadas para Encriptar la Clave.
using System.Security.Cryptography;
// Libreria Utilizada para Usar las Clases StringBuilder y UTF8Encoding.
using System.Text;
// Libreria para el Envio de Mensajes de Correo Electronico.
using System.Net.Mail;
using System.Net;

public partial class Login : System.Web.UI.Page
{
    private DataTable Usuarios;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session.Clear();
        //Session.Abandon();      
        lblmensaje.Visible = false;
        lblError.Visible = false;
        lblBien.Visible = false;
    }

    public void AbrirModal()
    {
        string sScriptF = "AbrirModal('#myModal');";
        ScriptManager.RegisterClientScriptBlock(this.UPPrincipal, UPPrincipal.GetType(), "ScriptAbrirModal", sScriptF, true);
    }


    public void CerrarModal()
    {
        string sScriptF = "CerrarModal('#myModal');";
        ScriptManager.RegisterClientScriptBlock(this.UPPrincipal, UPPrincipal.GetType(), "ScriptCerrarModal", sScriptF, true);
    }

    public void CerrarModalUpdatePanel()
    {
        string sScriptF = "CerrarModalUpdatePanel();";
        ScriptManager.RegisterClientScriptBlock(this.UPPrincipal, UPPrincipal.GetType(), "ScriptCerrarModalUpdatePanel", sScriptF, true);
    }


    protected void LinkButtonRecuperarContraseña_Click(object sender, EventArgs e)
    {
        AbrirModal();
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        if (txtNombre_UsuarioSession.Text != "" || txtContraseniaSesion.Text != "")
        {
            Logica.clsCuenta oclsCuenta = new Logica.clsCuenta();
            Logica.clsAdministrador oclsAdmi = new Logica.clsAdministrador();
            // A hora vamos a convertir a SHA1 la Contraseña Introducida.
            string contraseniaSHA1 = oclsCuenta.Generar_Clave_SHA1(this.txtContraseniaSesion.Text);
            //llenamos el datatable ingreso y le mandamos los parametros para que los valide
            DataTable Dt_Ingreso = oclsCuenta.Iniciar_Sesion(txtNombre_UsuarioSession.Text, contraseniaSHA1);

            if (Dt_Ingreso.Rows.Count > 0)
            {


                if (Dt_Ingreso.Rows[0][2].ToString().Equals("Habilitado"))
                {
                    Session["dataTable"] = Dt_Ingreso;
                    Response.Redirect("~/FrmUsuario.aspx",false);

                }

                else
                {
                    lblmensaje.Text = "Usuario inactivo";
                    lblmensaje.Visible = true;
                }

            }
            else
            {
                lblmensaje.Text = "Usuario no existente o los  datos son incorrectos";
                lblmensaje.Visible = true;
            }

        }
    }
    protected void btnEnviarSolicitud_Click(object sender, EventArgs e)
    {
        Logica.clsVendedor LoVen = new Logica.clsVendedor();
        Logica.clsCuenta LoCuen = new Logica.clsCuenta();
        Logica.clsAdministrador lo_Administrador = new Logica.clsAdministrador();
        CerrarModalUpdatePanel();
        AbrirModal();
        bool Usuario = false;
        Usuarios = lo_Administrador.dt_ListarUsuarios();
        foreach (DataRow Row in Usuarios.Rows)
        {
            string documento = "";
            documento = Convert.ToString(Row[0]);
            string correo = "";
            correo = Convert.ToString(Row[6]);
            if (Usuario == false)
            {

                if (txtNumeroDocumento.Text != documento && txtCorreoElectronico.Text == correo)
                {
                    lblError.Visible = true;
                    lblError.Text = "Ese número de documento no pertenese a ningún usuario";
                    Usuario = false;
                    break;
                }
                if (txtNumeroDocumento.Text == documento && txtCorreoElectronico.Text != correo)
                {
                    Usuario = false;
                    lblError.Visible = true;
                    lblError.Text = "Ese correo no pertenese a ningún usuario";
                    break;
                }
                if (txtCorreoElectronico.Text == correo && txtNumeroDocumento.Text == documento)
                {
                    Usuario = true;
                    var Persona = LoVen.Olvido_Contrasenia(txtCorreoElectronico.Text, txtNumeroDocumento.Text);

                    if (Persona.Rows.Count > 0)
                    {
                        // Random Genera un Número Aleatoriamente.
                        Random rnd = new Random();
                        // La Siguiente Instrucción Especifica, que cuando  genere el Número Aleatorio (Random).Next
                        // lo genere con números positivos y no mayores a 999.
                        int intAleatorio = rnd.Next(999);
                        //LblMensaje.Text = "Aleatori = ";
                        //LblMensaje.Text += intAleatorio;

                        // El Número Aleatorio, lo combierto a String, ya que es el Tipo de Dato que espera 
                        // la Función Generar_Clave_SHA1.
                        string strAleatorio = Convert.ToString(intAleatorio);
                        // A hora vamos a convertir a SHA1 la Contraseña Introducida.
                        string strContraseniaSHA1 = LoCuen.Generar_Clave_SHA1(strAleatorio);

                        // Le paso todos los Parametros a la Clase Persona de la Capa Comun, a travez de la Clase Cliente.
                        //Comun.clsVendedor inscomun = new Comun.clsVendedor(Persona.Nombre, Persona.Apellidos, Persona.Direccion, Persona.Telefono, Persona.N_documento, Persona.Fecha_nacimiento, Persona.Email, Persona.Municipio, Persona.Sucursal);


                        // Le paso el Objeto InsComun que es la Clase Persona a la Capa Lógica con Datos.

                        //bool bolRptActCliente = LoVen.Actualizar_Vendedores(inscomun);
                        string strDocEmpleado = Persona.Rows[0][0].ToString();

                        var persona2 = LoVen.Consultar(strDocEmpleado);
                        if (persona2 != null)
                        {
                            bool Contra = LoCuen.ModificarContrasenia(strDocEmpleado, strContraseniaSHA1);
                            if (Contra)
                            {
                                string strorigen = "masmelo-14@hotmail.com";
                                string strdestino = persona2.Rows[0][6].ToString();
                                string strAsunto = "Nueva Contraseña Macusoft";
                                string strNombreCompleto = persona2.Rows[0][2].ToString() + " " + persona2.Rows[0][3].ToString();
                                string strMensaje = "Señor/a : " + strNombreCompleto + " su nueva contraseña es : " + intAleatorio + " se recomienda cambiar la contraseña la próxima vez que entre a el sistema ";

                                //Instancia de la calse email
                                MailMessage email = new MailMessage();

                                //Quien lo resive
                                email.To.Add(new MailAddress(strdestino));
                                // Quien lo Envia.
                                email.From = new MailAddress(strorigen);
                                //El asunto del mensaje
                                email.Subject = strAsunto;
                                //El cuerpo del mensaje
                                email.Body = strMensaje;
                                //Decimos que el cuerpo va hacer html en caso de ser lo contrario lo ponemos false
                                email.IsBodyHtml = true;
                                //Le decimos al servidor la prioridad del mensaje
                                email.Priority = MailPriority.High;

                                // Esta Varible Utiliza el Protocolo SMTP (Protocolo de Transferencia de Mensajes Simples).
                                SmtpClient smtp = new SmtpClient();

                                string strNomUsuario = "masmelo-14@hotmail.com";
                                string strContrasenia = "jeamfb10";

                                //string strNomUsuario = "jhonesalvarez@gmail.com";
                                //string strContrasenia = "jeamfb10";

                                // stmp para hotmail
                                smtp.Host = "smtp.live.com";
                                // stmp para gmail.
                                //smtp.Host = "smtp.gmail.com";
                                // stmp para yahoo.
                                //stmp.Host = "out.izymail.com";
                                smtp.Port = 587;
                                //smtp.Port = 25;
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtp.EnableSsl = true;
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new NetworkCredential(strNomUsuario, strContrasenia);

                                /*********************************************************************************************
                                 * URL DONDE DAN LAS PAUTAS PARA CONFIGURAR la Variable "stmp" PARA HOTMAIL, GMAIL y YAHOO.  *
                                 * http://www.dacostabalboa.com/es/configurar-smtp-pop-e-imap-en-hotmail-gmail-y-yahoo/6770  *
                                 * Tambien Sirve para configurar el "outlook".
                                 * *******************************************************************************************/

                                // A hora Enviamos el Mensaje.
                                smtp.Send(email);
                                lblError.Visible = false;
                                lblBien.Visible = true;
                                txtCorreoElectronico.Text = "";
                                txtNumeroDocumento.Text = "";
                                lblBien.Text = "A su correo le ha sido enviada una nueva contraseña";
                                break;
                            }
                        }


                    }
                }

            }
        }
        lblError.Visible = true;
        lblError.Text = "Ese número de documento y correo no pertenese a ningún usuario";
        Usuario = false;

    }
}







