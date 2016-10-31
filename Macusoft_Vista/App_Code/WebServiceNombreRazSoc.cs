using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;

/// <summary>
/// Descripción breve de WebServiceNombreRazSoc
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class WebServiceNombreRazSoc : System.Web.Services.WebService {

    public WebServiceNombreRazSoc () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod()]
    [ScriptMethod()]  
        
    public string[] GetNombreRazSoc(string prefixText, int count)
    {
        //Del archivo web.config y la etiqueta <connectionStrings> copiamos el "name" y se lo pasamos a la siquiente línea de código
        string connstring = ConfigurationManager.ConnectionStrings["Macusoft_V3ConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connstring))
        {
            SqlCommand comando = new SqlCommand("select Nombre_RazonSocial from Tbl_Clientes where Nombre_RazonSocial  LIKE '%' + @param + '%' ", conn);
            comando.Parameters.AddWithValue("@param", prefixText);
            SqlDataReader dr = default(SqlDataReader);
            comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();

            while (dr.Read())
            {
                //Debe ser igual el nombre de la columna que está en la tabla de la BD
                items.Add(dr["Nombre_RazonSocial"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }

    [WebMethod()]
    [ScriptMethod()] 
    public string[] GetDocNit(string prefixText, int count)
    {
        //Del archivo web.config y la etiqueta <connectionStrings> copiamos el "name" y se lo pasamos a la siquiente línea de código
        string connstring = ConfigurationManager.ConnectionStrings["Macusoft_V3ConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connstring))
        {
            SqlCommand comando = new SqlCommand("select Documento_Nit from Tbl_Clientes where Documento_Nit  LIKE '%' + @param + '%' ", conn);
            comando.Parameters.AddWithValue("@param", prefixText);
            SqlDataReader dr = default(SqlDataReader);
            comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();

            while (dr.Read())
            {
                //Debe ser igual el nombre de la columna que está en la tabla de la BD
                items.Add(dr["Documento_Nit"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }

    [WebMethod()]
    [ScriptMethod()]
    public string[] GetNombreProducto(string prefixText, int count) 
    {
        //Del archivo web.config y la etiqueta <connectionStrings> copiamos el "name" y se lo pasamos a la siquiente línea de código
        string connstring = ConfigurationManager.ConnectionStrings["Macusoft_V3ConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connstring))
        {
            SqlCommand comando = new SqlCommand("select Nombre_Producto from Tbl_Productos where Nombre_Producto  LIKE '%' + @param + '%' ", conn);
            comando.Parameters.AddWithValue("@param", prefixText);
            SqlDataReader dr = default(SqlDataReader);
            comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();

            while (dr.Read())
            {
                //Debe ser igual el nombre de la columna que está en la tabla de la BD
                items.Add(dr["Nombre_Producto"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }

    [WebMethod()]
    [ScriptMethod()]
    public string[] GetCodProducto(string prefixText, int count)
    {
        //Del archivo web.config y la etiqueta <connectionStrings> copiamos el "name" y se lo pasamos a la siquiente línea de código
        string connstring = ConfigurationManager.ConnectionStrings["Macusoft_V3ConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connstring))
        {
            SqlCommand comando = new SqlCommand("select Cod_Producto from Tbl_Productos where Cod_Producto  LIKE '%' + @param + '%' ", conn);
            comando.Parameters.AddWithValue("@param", prefixText);
            SqlDataReader dr = default(SqlDataReader);
            comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();

            while (dr.Read())
            {
                //Debe ser igual el nombre de la columna que está en la tabla de la BD
                items.Add(dr["Cod_Producto"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }

    [WebMethod()]
    [ScriptMethod()]
    public string[] GetNombre_RazonSocial(string prefixText, int count)
    {
        //Del archivo web.config y la etiqueta <connectionStrings> copiamos el "name" y se lo pasamos a la siquiente línea de código
        string connstring = ConfigurationManager.ConnectionStrings["Macusoft_V3ConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connstring))
        {
            SqlCommand comando = new SqlCommand("select Nombre_RazonSocial from Tbl_Proveedores where Nombre_RazonSocial  LIKE '%' + @param + '%' ", conn);
            comando.Parameters.AddWithValue("@param", prefixText);
            SqlDataReader dr = default(SqlDataReader);
            comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();

            while (dr.Read())
            {
                //Debe ser igual el nombre de la columna que está en la tabla de la BD
                items.Add(dr["Nombre_RazonSocial"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }

    [WebMethod()]
    [ScriptMethod()]
    public string[] GetNit_Documento(string prefixText, int count)
    {
        //Del archivo web.config y la etiqueta <connectionStrings> copiamos el "name" y se lo pasamos a la siquiente línea de código
        string connstring = ConfigurationManager.ConnectionStrings["Macusoft_V3ConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connstring))
        {
            SqlCommand comando = new SqlCommand("select Documento_Nit from Tbl_Proveedores where Documento_Nit  LIKE '%' + @param + '%' ", conn);
            comando.Parameters.AddWithValue("@param", prefixText);
            SqlDataReader dr = default(SqlDataReader);
            comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();

            while (dr.Read())
            {
                //Debe ser igual el nombre de la columna que está en la tabla de la BD
                items.Add(dr["Documento_Nit"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }
    
}
