using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class clsVendedor
    {

        //esta es la conecxion a la base de datos para registrar un vendedor que son los que tienen sucursal

        public bool Registrar_Vendedor(Comun.clsVendedor vend)
        {
            bool Registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_Registrar_Usuarios = "SP_RegistrarUsuarios";
                SqlCommand cmIntVendedor = new SqlCommand(SP_Registrar_Usuarios, con);
                cmIntVendedor.CommandType = CommandType.StoredProcedure;

                cmIntVendedor.Parameters.AddWithValue("@Nombre_Empleado", vend.Nombre);
                cmIntVendedor.Parameters.AddWithValue("@Apellido_Empleado", vend.Apellidos);
                cmIntVendedor.Parameters.AddWithValue("@Documento_Empleado", vend.N_documento);
                cmIntVendedor.Parameters.AddWithValue("@Direccion_Empleado", vend.Direccion);
                cmIntVendedor.Parameters.AddWithValue("@Telefono_Empleado", vend.Telefono);
                cmIntVendedor.Parameters.AddWithValue("@Correo_Empleado", vend.Email);
                cmIntVendedor.Parameters.AddWithValue("@Fecha_Nacimiento", vend.Fecha_nacimiento);
                cmIntVendedor.Parameters.AddWithValue("@Municipio_Empleado", vend.Municipio.Id_municipio);
                cmIntVendedor.Parameters.AddWithValue("@Surcursal_Empleado", vend.Sucursal.Id_sucursal);


                int intResultado = cmIntVendedor.ExecuteNonQuery();
                if (intResultado > 0)
                { Registro = true; }
            }
            catch (Exception e)
            { Registro = false; }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return Registro;

        }

        public bool Actualizar_Vendedor(Comun.clsVendedor vend)
        {
            bool Registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_ActualizarUsuario = "SP_ActualizarUsuario";
                SqlCommand cmIntVendedor = new SqlCommand(SP_ActualizarUsuario, con);
                cmIntVendedor.CommandType = CommandType.StoredProcedure;

                cmIntVendedor.Parameters.AddWithValue("@Documento_Empleado", vend.N_documento);
                cmIntVendedor.Parameters.AddWithValue("@Nombres", vend.Nombre);
                cmIntVendedor.Parameters.AddWithValue("@Apellidos", vend.Apellidos);
                cmIntVendedor.Parameters.AddWithValue("@Direccion", vend.Direccion);
                cmIntVendedor.Parameters.AddWithValue("@Telefono", vend.Telefono);
                cmIntVendedor.Parameters.AddWithValue("@Email", vend.Email);
                cmIntVendedor.Parameters.AddWithValue("@Fecha_Nacimiento", vend.Fecha_nacimiento);
                cmIntVendedor.Parameters.AddWithValue("@Id_Municipio", vend.Municipio.Id_municipio);
                cmIntVendedor.Parameters.AddWithValue("@Id_Sucursal", vend.Sucursal.Id_sucursal);


                int intResultado = cmIntVendedor.ExecuteNonQuery();
                if (intResultado > 0)
                { Registro = true; }
            }
            catch (Exception e)
            { Registro = false; }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return Registro;

        }


        public DataTable Olvido_Contrasenia(string correo, string documento)
        {
            DataTable dtVendedor = new DataTable();
            
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_OlvidoSuContrasenia = "SP_OlvidoSuContrasenia";


                SqlDataAdapter cmIntVendedor = new SqlDataAdapter(SP_OlvidoSuContrasenia, con);
                cmIntVendedor.SelectCommand.CommandType = CommandType.StoredProcedure;

                cmIntVendedor.SelectCommand.Parameters.AddWithValue("@Documento", documento);
                cmIntVendedor.SelectCommand.Parameters.AddWithValue("@Email", correo);

                cmIntVendedor.Fill(dtVendedor);
                return dtVendedor;
            }
            catch (Exception e)
            {
            }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return null;
        }
         

        /*
        public Comun.clsVendedor Olvido_Contrasenia(string correo, string documento)
        {
            var Resultado = new List<Comun.clsVendedor>();
            
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_OlvidoSuContrasenia = "SP_OlvidoSuContrasenia";


                SqlCommand cmIntVendedor = new SqlCommand(SP_OlvidoSuContrasenia, con);
                cmIntVendedor.CommandType = CommandType.StoredProcedure;

                cmIntVendedor.Parameters.AddWithValue("@Documento", documento);
                cmIntVendedor.Parameters.AddWithValue("@Email", correo);

                var dr = cmIntVendedor.ExecuteReader();
                while (dr.Read())
                {
                        Resultado.Add(new Comun.clsVendedor(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4),
                        dr.GetDateTime(5), dr.GetString(6),null,null));

                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            // Si la Propiedad "Count" de la variable DataReader (Resultado) No es Mayor a 0
            // Se retorna El Objeto "InsPersona" Vacio.
            if (Resultado.Count > 0)
            {
                return Resultado[0];
            }
            else
            {
                Comun.clsVendedor InsPersona = new Comun.clsVendedor();
                return InsPersona;
            }
        }
         */




        public DataTable Consultar(string strDocEmpleado)
        {
            DataTable dtVendedor = new DataTable();

            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_OlvidoSuContrasenia = "SP_ConsultarUsuario";


                SqlDataAdapter cmIntVendedor = new SqlDataAdapter(SP_OlvidoSuContrasenia, con);
                cmIntVendedor.SelectCommand.CommandType = CommandType.StoredProcedure;

                cmIntVendedor.SelectCommand.Parameters.AddWithValue("@Documento", strDocEmpleado);

                cmIntVendedor.Fill(dtVendedor);
                return dtVendedor;
            }
            catch (Exception e)
            {
            }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return null;
        }
    }
    }
