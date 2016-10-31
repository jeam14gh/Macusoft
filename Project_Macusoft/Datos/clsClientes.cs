using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

//AUTOR: Jhon Alvarez
namespace Datos
{
    public class clsClientes 
    {
        public bool Registrar_Cliente(Comun.clsClientes oCli)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oConexion = new Conexion();
                con = oConexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_RegistrarCliente", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Nombre_RazonSocial", oCli.Nombre);
                sqlcmd.Parameters.AddWithValue("@Documento_Nit", oCli.N_documento);
                sqlcmd.Parameters.AddWithValue("@Direccion", oCli.Direccion);
                sqlcmd.Parameters.AddWithValue("@IdMunicipio", oCli.Municipio.Id_municipio);
                sqlcmd.Parameters.AddWithValue("@FechaCumpleanos", oCli.Fecha_nacimiento);
                sqlcmd.Parameters.AddWithValue("@Telefono", oCli.Telefono);
                sqlcmd.Parameters.AddWithValue("@Email", oCli.Email);

                int resultado = sqlcmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    registro = true;
                }
            }
            catch (Exception e)
            {
                registro = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
            }
            return registro;
        }

        #region ACTUALIZAR CLIENTE
        public bool Actualizar_Cliente(Comun.clsClientes oCli)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oConexion = new Conexion();
                con = oConexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_ActualizarCliente", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Nombre_RazonSocial", oCli.Nombre);
                sqlcmd.Parameters.AddWithValue("@Documento_Nit", oCli.N_documento);
                sqlcmd.Parameters.AddWithValue("@Direccion", oCli.Direccion);
                sqlcmd.Parameters.AddWithValue("@IdMunicipio", oCli.Municipio.Id_municipio);
                sqlcmd.Parameters.AddWithValue("@FechaCumpleanos", oCli.Fecha_nacimiento);
                sqlcmd.Parameters.AddWithValue("@Telefono", oCli.Telefono);
                sqlcmd.Parameters.AddWithValue("@Email", oCli.Email);

                int resultado = sqlcmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    registro = true;
                }
            }
            catch (Exception e)
            {
                registro = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
            }
            return registro;
        }
        #endregion

        #region ELIMANR CLIENTE
        public bool EliminarCliente(Comun.clsClientes CoCli)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oConexion = new Conexion();
                con = oConexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_EliminarCliente", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Documento_Nit", CoCli.N_documento);

                int resultado = sqlcmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    registro = true;
                }
            }
            catch (Exception e)
            {
                registro = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
            }
            return registro;
        }
        #endregion

        public DataTable consultar(Comun.clsClientes oCli)
        {
            DataTable dtClientes = new DataTable("Cliente");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_ConsultarCliente", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Nombre_RazonSocial", oCli.Nombre);
                sqlcmd.Parameters.AddWithValue("@Documento_Nit", oCli.N_documento);

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dtClientes);
            }
            catch (Exception e)
            {
                dtClientes = null;
            }
            return dtClientes;
        }

        public DataTable listarClientes()
        {
            DataTable dt_listarClientes = new DataTable("Lista_Clientes");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_ListarClientes", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dt_listarClientes);
            }
            catch (Exception e)
            {
                dt_listarClientes = null;
            }
            return dt_listarClientes;
        }
    }
}
