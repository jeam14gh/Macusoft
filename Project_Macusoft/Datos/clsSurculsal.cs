using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Datos
{
    public class clsSurculsal
    {
        public bool Registrar_surcurlsale(Comun.clsSucursal objclsSucursal)
        {
            bool bolResultado = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion ClsConexion = new Conexion();
                con = ClsConexion.slConexion();
                con.Open();
                //variable que tendra el procediemiento almacenado
                string SP_Registrar_surculsal = "dbo.SP_RegistrarSurculsal";
                // EL adaptador que ejecutara el procedimiento
                SqlCommand CmdSurculsal = new SqlCommand(SP_Registrar_surculsal, con);
                CmdSurculsal.CommandType = CommandType.StoredProcedure;

                //CmdSurculsal.Parameters.AddWithValue("@Id_surcurlsa",  objclsSucursal.Id_sucursal);
                CmdSurculsal.Parameters.AddWithValue("@nombre", objclsSucursal.Nombre_sucursal);
                CmdSurculsal.Parameters.AddWithValue("@Telefono", objclsSucursal.Telefono_sucursal);
                CmdSurculsal.Parameters.AddWithValue("@Direccion", objclsSucursal.Direccion_sucursal);

                int intResultado = CmdSurculsal.ExecuteNonQuery();
                if (intResultado > 0)
                { bolResultado = true; }



            }
            catch (Exception e)
            { }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return bolResultado;
        }


        //Listar Sucursales
        public DataTable ListarSucursal()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                cn = oClsConexion.slConexion();
                cn.Open();
                string SP_ListarSucursales = "SP_ListarSucursales";
                // EL adaptador que ejecutara el procedimiento
                SqlDataAdapter DtlSurcurlsal = new SqlDataAdapter(SP_ListarSucursales, cn);
                DtlSurcurlsal.SelectCommand.CommandType = CommandType.StoredProcedure;
                // la tabla donde se guardaran los datos
                DataTable TblSurculsal = new DataTable();
                DtlSurcurlsal.Fill(TblSurculsal);
                return TblSurculsal;
            }
            catch (Exception e)
            { }
            finally
            {
                // Cierro la Conexión
                cn.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                cn.Dispose();
            }
            return null;
        }


        //Consultar Sucursal
        public DataTable ConsultarSucursal(Comun.clsSucursal objSucursal)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                cn = oClsConexion.slConexion();
                cn.Open();
                string SP_Listar_Surculsales = "dbo.Sp_ConsultarSucursalxnomb";
                // EL adaptador que ejecutara el procedimiento
                SqlDataAdapter DtlSurcurlsal = new SqlDataAdapter(SP_Listar_Surculsales, cn);
                DtlSurcurlsal.SelectCommand.CommandType = CommandType.StoredProcedure;
                DtlSurcurlsal.SelectCommand.Parameters.AddWithValue("@nombre", objSucursal.Nombre_sucursal);
                // la tabla donde se guardaran los datos
                DataTable TblSurculsal = new DataTable();
                DtlSurcurlsal.Fill(TblSurculsal);
                return TblSurculsal;
            }
            catch (Exception e)
            { }
            finally
            {
                // Cierro la Conexión
                cn.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                cn.Dispose();
            }
            return null;
        }



        //Actualizar Sucursal
        public bool ActualizarSucursales(Comun.clsSucursal objclsSucursal)
        {
            bool bolResultado = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion ClsConexion = new Conexion();
                con = ClsConexion.slConexion();
                con.Open();
                //variable que tendra el procediemiento almacenado
                string SP_Registrar_surculsal = "dbo.Sp_ActualizarSucursal";
                // EL adaptador que ejecutara el procedimiento
                SqlCommand CmdSurculsal = new SqlCommand(SP_Registrar_surculsal, con);
                CmdSurculsal.CommandType = CommandType.StoredProcedure;

                CmdSurculsal.Parameters.AddWithValue("@id_sucursal", objclsSucursal.Id_sucursal);
                CmdSurculsal.Parameters.AddWithValue("@Nombre_sucursal", objclsSucursal.Nombre_sucursal);
                CmdSurculsal.Parameters.AddWithValue("@Telefono", objclsSucursal.Telefono_sucursal);
                CmdSurculsal.Parameters.AddWithValue("@Direccion", objclsSucursal.Direccion_sucursal);

                int intResultado = CmdSurculsal.ExecuteNonQuery();
                if (intResultado > 0)
                { bolResultado = true; }

                // la tabla donde se guardaran los datos

            }
            catch (Exception e)
            { }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return bolResultado;
        }

    }
}