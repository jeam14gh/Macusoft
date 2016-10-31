using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;


namespace Datos
{
    public class clsCuenta
    {
        public bool RegistrarCuenta(Comun.clsCuenta objclsCuenta)
        {
            bool Registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_Registrar_Cuenta = "SP_RegistrarCuenta";
                SqlCommand cmIntCuenta = new SqlCommand(SP_Registrar_Cuenta, con);
                cmIntCuenta.CommandType = CommandType.StoredProcedure;
                cmIntCuenta.Parameters.AddWithValue("@Usario", objclsCuenta.Nombre_usuario);//Mod
                cmIntCuenta.Parameters.AddWithValue("@Contrasenia", objclsCuenta.Contrasenia);//Mod

                cmIntCuenta.Parameters.AddWithValue("@Estado", objclsCuenta.Estado_cuenta);//Mod

                if (objclsCuenta.OclsAdministrador != null)
                {
                    cmIntCuenta.Parameters.AddWithValue("@Documento", objclsCuenta.OclsAdministrador.N_documento);//Mod
                }
                else
                {
                    cmIntCuenta.Parameters.AddWithValue("@Documento", objclsCuenta.OclsVendedor.N_documento);
                }
                cmIntCuenta.Parameters.AddWithValue("@Cargo", objclsCuenta.Cargo);//Mod
                int intResultado = cmIntCuenta.ExecuteNonQuery();
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

        public bool Actualizar_Cuenta(Comun.clsCuenta objclsCuenta)
        {
            bool Registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                con = oClsConexion.slConexion();
                con.Open();
                string SP_ActualizarCuenta = "SP_ActualizarCuenta";
                SqlCommand cmIntCuenta = new SqlCommand(SP_ActualizarCuenta, con);
                cmIntCuenta.CommandType = CommandType.StoredProcedure;

                cmIntCuenta.Parameters.AddWithValue("@Estado", objclsCuenta.Estado_cuenta);//Mod

                if (objclsCuenta.OclsAdministrador != null)
                {
                    cmIntCuenta.Parameters.AddWithValue("@Documento_Empleado", objclsCuenta.OclsAdministrador.N_documento);//Mod
                }
                else
                {
                    cmIntCuenta.Parameters.AddWithValue("@Documento_Empleado", objclsCuenta.OclsVendedor.N_documento);
                }
                cmIntCuenta.Parameters.AddWithValue("@Perfil", objclsCuenta.Cargo);//Mod
                int intResultado = cmIntCuenta.ExecuteNonQuery();
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

        public DataTable Iniciar_Session(string Usuario, string Conrasenia)
        {
            DataTable dtIniciar = new DataTable("Sesion");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_Iniciar_Sesion", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Usuario", Usuario);
                //sqlcmd.Parameters.AddWithValue("@Contrasenia", Conrasenia);
                sqlcmd.Parameters.AddWithValue("@Contrasenia", Conrasenia);

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dtIniciar);
            }
            catch (Exception e)
            {
                dtIniciar = null;
            }
            return dtIniciar;

        }

        #region ELIMINAR CUENTA DEL ADMINISTRADOR
        public bool EliminarCuentaAdministrador(Comun.clsCuenta CoCuenta)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oConexion = new Conexion();
                con = oConexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_EliminarCuenta", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Documento_Empleado", CoCuenta.OclsAdministrador.N_documento);

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


        #region ELIMINAR CUENTA DEL VENDEDOR
        public bool EliminarCuentaVendedor(Comun.clsCuenta CoCuenta)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oConexion = new Conexion();
                con = oConexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_EliminarCuenta", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Documento_Empleado", CoCuenta.OclsVendedor.N_documento);

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


        public bool ModificarContrasenia(string doc, string cont)
        {
            bool Reg = false;
            SqlConnection StrConexion = new SqlConnection();
            try
            {
              
                Conexion oClsConexion = new Conexion();
                StrConexion = oClsConexion.slConexion();
                StrConexion.Open();
                string SP_ActualizarCuenta = "SP_ModificarContrasenia";
                SqlCommand cmIntCuenta = new SqlCommand(SP_ActualizarCuenta, StrConexion);
                cmIntCuenta.CommandType = CommandType.StoredProcedure;
                cmIntCuenta.Parameters.AddWithValue("@Usuario", doc);
                cmIntCuenta.Parameters.AddWithValue("@Contrasenia", cont);
                int intResultado = cmIntCuenta.ExecuteNonQuery();
                if (intResultado > 0)

                { Reg = true; }
            }
            catch (Exception e)
            { Reg = false; }
            finally
            {
                // Cierro la Conexión
                StrConexion.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                StrConexion.Dispose();
            }
            return Reg;
        }

        public bool ActualizarContrasenia(string doc, string cont)
        {
            bool Reg = false;
            SqlConnection StrConexion = new SqlConnection();
            try
            {

                Conexion oClsConexion = new Conexion();
                StrConexion = oClsConexion.slConexion();
                StrConexion.Open();
                string SP_ActualizarCuenta = "SP_ActualizarContrasenia";
                SqlCommand cmIntCuenta = new SqlCommand(SP_ActualizarCuenta, StrConexion);
                cmIntCuenta.CommandType = CommandType.StoredProcedure;
                cmIntCuenta.Parameters.AddWithValue("@Usuario", doc);
                cmIntCuenta.Parameters.AddWithValue("@Contrasenia", cont);
                int intResultado = cmIntCuenta.ExecuteNonQuery();
                if (intResultado > 0)

                { Reg = true; }
            }
            catch (Exception e)
            { Reg = false; }
            finally
            {
                // Cierro la Conexión
                StrConexion.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                StrConexion.Dispose();
            }
            return Reg;
        }   
        }

    }




