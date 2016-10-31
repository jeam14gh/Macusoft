using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class clsDetalles
    {
        #region Agregar Detalles a la tabla aparte
        public bool Agregar_Detalles(Comun.clsDetalles dtDt)
        {
            bool res = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oconexion = new Conexion();
                con = oconexion.slConexion();
                con.Open();
                string SP_RegistraDetalles = "SP_RegistraDetalles";
                SqlCommand CmdDetalles = new SqlCommand(SP_RegistraDetalles, con);
                CmdDetalles.CommandType = CommandType.StoredProcedure;
                CmdDetalles.Parameters.AddWithValue("@Codigo", dtDt.Cod_Product);
                CmdDetalles.Parameters.AddWithValue("@Cantidad", dtDt.Cantidad);
                CmdDetalles.Parameters.AddWithValue("@Valor", dtDt.Valor);
                int Resultado = CmdDetalles.ExecuteNonQuery();
                if (Resultado > 0) res = true;
            }
            catch (Exception e)
            {
                res = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return res;
        }
        #endregion
        #region Consultar Detalles
        public DataTable Consultar_Detalles()
        {
            DataTable DtDetalles = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oclsconexion = new Conexion();
                con = oclsconexion.slConexion();
                con.Open();
                string SP_Consultar_Detalles = "SP_ConsultarDetalles";
                SqlDataAdapter AdDeta = new SqlDataAdapter(SP_Consultar_Detalles, con);
                AdDeta.SelectCommand.CommandType = CommandType.StoredProcedure;
                AdDeta.Fill(DtDetalles);
                return DtDetalles;
            }
            catch (Exception e)
            {
                DtDetalles = null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return DtDetalles;
        }
        #endregion
        public bool Registrar_Detalles(Comun.clsDetalles ClsDet)
        {
            bool Res = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oconexion = new Conexion();
                con = oconexion.slConexion();
                con.Open();
                string SP_RegistrarDetallesDevoluciones = "SP_RegistrarDetallesMov";
                SqlCommand CmDetalles = new SqlCommand(SP_RegistrarDetallesDevoluciones, con);
                CmDetalles.CommandType = CommandType.StoredProcedure;
                CmDetalles.Parameters.AddWithValue("@cod_prod", ClsDet.Cod_Product);
                CmDetalles.Parameters.AddWithValue("@cantidad", ClsDet.Cantidad);
                CmDetalles.Parameters.AddWithValue("@valor", ClsDet.Valor);
                int Resultado = CmDetalles.ExecuteNonQuery();
                if (Resultado > 0) Res = true;
            }
            catch (Exception)
            {
                Res = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return Res;
        }
        public bool Eliminar_Detalles()
        {
            bool Res = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oconexion = new Conexion();
                con = oconexion.slConexion();
                con.Open();
                string SP_EliminarDetalles = "SP_EliminarDetalles";
                SqlCommand CmdDetalles = new SqlCommand(SP_EliminarDetalles, con);
                CmdDetalles.CommandType = CommandType.StoredProcedure;
                int Resultado = CmdDetalles.ExecuteNonQuery();
                if (Resultado > 0) Res = true;
            }
            catch (Exception e)
            {
                Res = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return Res;
        }
        public bool Eliminar_Detalle(Comun.clsDetalles ClsDet)
        {
            bool Res = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion Oconexion = new Conexion();
                con = Oconexion.slConexion();
                con.Open();
                string SP_ElimarProxDetalle = "SP_ElimarProxDetalle";
                SqlCommand CmdDetalles = new SqlCommand(SP_ElimarProxDetalle, con);
                CmdDetalles.CommandType = CommandType.StoredProcedure;
                CmdDetalles.Parameters.AddWithValue("@Cod_producto", ClsDet.Cod_Product);
                int Resultado = CmdDetalles.ExecuteNonQuery();
                if (Resultado > 0) Res = true;
            }
            catch (Exception e)
            {
                Res = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return Res;
        }
    }
}
