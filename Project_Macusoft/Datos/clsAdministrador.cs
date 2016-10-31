using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class clsAdministrador 
    {
        //Metodo para registrar un administrador y esta es la conecxion con la base de datos y el llamado 
        //del procedimiento almacenado para registrar usuarios
        public bool Registrar_Administrador(Comun.clsAdministrador admin)
        {
            bool Registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_Registrar_Usuarios = "SP_RegistrarUsuarios";
                SqlCommand cmAdmin = new SqlCommand(SP_Registrar_Usuarios, con);
                cmAdmin.CommandType = CommandType.StoredProcedure;
                cmAdmin.Parameters.AddWithValue("@Nombre_Empleado", admin.Nombre);
                cmAdmin.Parameters.AddWithValue("@Apellido_Empleado", admin.Apellidos);
                cmAdmin.Parameters.AddWithValue("@Documento_Empleado", admin.N_documento);
                cmAdmin.Parameters.AddWithValue("@Direccion_Empleado", admin.Direccion);
                cmAdmin.Parameters.AddWithValue("@Telefono_Empleado", admin.Telefono);
                cmAdmin.Parameters.AddWithValue("@Correo_Empleado", admin.Email);
                cmAdmin.Parameters.AddWithValue("@Fecha_Nacimiento", admin.Fecha_nacimiento);
                cmAdmin.Parameters.AddWithValue("@Municipio_Empleado", admin.Municipio.Id_municipio);
                //Envia nulos a un atributo de la base de datos como el administrador no tiene almacen 
                //si no que administra todo no es necesario enviar el almacen que administra
                cmAdmin.Parameters.AddWithValue("@Surcursal_Empleado", System.Data.SqlTypes.SqlByte.Null);
                

                int intResultado = cmAdmin.ExecuteNonQuery();
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

        public bool Actualizar_Administrador(Comun.clsAdministrador admin)
        {
            bool Registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_ActualizarUsuario = "SP_ActualizarUsuario";
                SqlCommand cmAdmin = new SqlCommand(SP_ActualizarUsuario, con);
                cmAdmin.CommandType = CommandType.StoredProcedure;
                cmAdmin.Parameters.AddWithValue("@Nombres", admin.Nombre);
                cmAdmin.Parameters.AddWithValue("@Apellidos", admin.Apellidos);
                cmAdmin.Parameters.AddWithValue("@Documento_Empleado", admin.N_documento);
                cmAdmin.Parameters.AddWithValue("@Direccion", admin.Direccion);
                cmAdmin.Parameters.AddWithValue("@Telefono", admin.Telefono);
                cmAdmin.Parameters.AddWithValue("@Email", admin.Email);
                cmAdmin.Parameters.AddWithValue("@Fecha_Nacimiento", admin.Fecha_nacimiento);
                cmAdmin.Parameters.AddWithValue("@Id_Municipio", admin.Municipio.Id_municipio);
                //Envia nulos a un atributo de la base de datos como el administrador no tiene almacen 
                //si no que administra todo no es necesario enviar el almacen que administra
                cmAdmin.Parameters.AddWithValue("@Id_Sucursal", System.Data.SqlTypes.SqlByte.Null);


                int intResultado = cmAdmin.ExecuteNonQuery();
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

        //Metodo para listar todos los usuarios del sistema en un griwvied
        public DataTable listarUsuarios()
        {
            DataTable dt_listarusuarios = new DataTable("Lista_Usuarios");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_Listar_Usuarios", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dt_listarusuarios);
            }
            catch (Exception e)
            {
                dt_listarusuarios = null;
            }
            return dt_listarusuarios;
        }
      
        //Metodo para consultar usuarios del sistema por numero de documento,apellido o nombre del empleado
        public DataTable ConsultarUsuarios(Comun.clsAdministrador oAdmin)
        {
            DataTable dtUsuarios = new DataTable("Usuarios");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_ConsultarUsuarios", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Nombre_Empleado", oAdmin.Nombre);
                sqlcmd.Parameters.AddWithValue("@Apellido_Empleado", oAdmin.Apellidos);
                sqlcmd.Parameters.AddWithValue("@Documento_Empleado", oAdmin.N_documento);

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dtUsuarios);
            }
            catch (Exception e)
            {
                dtUsuarios = null;
            }
            return dtUsuarios;
        }

        public bool Olvido_Contrasenia(Comun.clsAdministrador Admin)
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

                cmIntVendedor.Parameters.AddWithValue("@Documento_Empleado", Admin.N_documento);
                cmIntVendedor.Parameters.AddWithValue("@Correo_Empleado", Admin.Email);

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

        
    }
}
