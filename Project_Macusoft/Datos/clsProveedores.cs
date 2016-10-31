using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class clsProveedores
    {
        #region REGISTRAR PROVEEDOR
        public bool registrarProveedor(Comun.clsProveedores oProv)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oConexion = new Conexion();
                con = oConexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_RegistrarProveedor", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Nombre_RazonSocial", oProv.Nombre);
                sqlcmd.Parameters.AddWithValue("@Documento_Nit", oProv.N_documento);
                sqlcmd.Parameters.AddWithValue("@Direccion", oProv.Direccion);
                sqlcmd.Parameters.AddWithValue("@Telefono", oProv.Telefono);
                sqlcmd.Parameters.AddWithValue("@Email", oProv.Email);
                sqlcmd.Parameters.AddWithValue("@IdMunicipio", oProv.Municipio.Id_municipio);

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

        #region CONSULTAR PROVEEDOR
        public DataTable consultarProveedor(Comun.clsProveedores oProv)
        {
            DataTable dtProveedor = new DataTable("Proveedor");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_ConsultarProveedor", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Nombre_RazonSocial", oProv.Nombre);
                sqlcmd.Parameters.AddWithValue("@Documento_Nit", oProv.N_documento);

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dtProveedor);
            }
            catch (Exception e)
            {
                dtProveedor = null;
            }
            return dtProveedor;
        }
        #endregion

        #region ACTUALIZAR PROVEEDOR
        public bool ActualizarProveedor(Comun.clsProveedores oProv)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oConexion = new Conexion();
                con = oConexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_ActualizarProveedor", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Nombre_RazonSocial", oProv.Nombre);
                sqlcmd.Parameters.AddWithValue("@Documento_Nit", oProv.N_documento);
                sqlcmd.Parameters.AddWithValue("@Direccion", oProv.Direccion);
                sqlcmd.Parameters.AddWithValue("@Telefono", oProv.Telefono);
                sqlcmd.Parameters.AddWithValue("@Email", oProv.Email);
                sqlcmd.Parameters.AddWithValue("@IdMunicipio", oProv.Municipio.Id_municipio);

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
        #region ELIMINAR PROVEEDOR
        public bool EliminarProveedor(Comun.clsProveedores oProv)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oConexion = new Conexion();
                con = oConexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_EliminarProveedor", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Documento_Nit", oProv.N_documento);                

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
        #region LISTAR PROVEEDORES
        public DataTable listarProveedor()
        {
            DataTable dt_listarProveedores = new DataTable("Lista_Proveedores");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_ListarProveedores", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dt_listarProveedores);
            }
            catch (Exception e)
            {
                dt_listarProveedores = null;
            }
            return dt_listarProveedores;
        }
        #endregion
    }
}
