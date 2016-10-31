using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class clsDian
    {
        #region Registrar_Dian
        public bool Registrar_Dian(Comun.clsDian objDian)
        {
            bool res = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion ClsConexion = new Conexion();
                con = ClsConexion.slConexion();
                con.Open();
                string Sp_Registrar_Dian = "Sp_Registrar_Dian";
                SqlCommand CmdDian = new SqlCommand(Sp_Registrar_Dian, con);
                CmdDian.CommandType = CommandType.StoredProcedure;
                CmdDian.Parameters.AddWithValue("@Dian_inicio", objDian.Rango_Inicial);
                CmdDian.Parameters.AddWithValue("@Dian_Final", objDian.Rango_Final);
                int Resultado = CmdDian.ExecuteNonQuery();
                if (Resultado > 0)
                {
                    res = true;
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return res;
        }
        #endregion
        #region Actualizar_Dian
        public bool Actualizar_Dian()
        {
            bool res = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion ClsConexion = new Conexion();
                con = ClsConexion.slConexion();
                con.Open();
                string Sp_Actaulizar_Dian = "Sp_Actaulizar_Dian";
                SqlCommand CmdDian = new SqlCommand(Sp_Actaulizar_Dian, con);
                CmdDian.CommandType = CommandType.StoredProcedure;
                int Resultado = CmdDian.ExecuteNonQuery();
                if (Resultado > 0)
                {
                    res = true;
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return res;
        }
        #endregion
        #region Consultar_Dian
        public DataTable Consultar_Dian()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                cn = oClsConexion.slConexion();
                cn.Open();
                string Sp_Consultar_Dian = "dbo.Sp_Consultar_Dian";
                // EL adaptador que ejecutara el procedimiento
                SqlDataAdapter DtlSurcurlsal = new SqlDataAdapter(Sp_Consultar_Dian, cn);
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
        #endregion
        #region Ventas
        public DataTable Consultar_Ventas(int Dian)
        {
            Conexion oCon = new Conexion();
            SqlConnection sqlcon = new SqlConnection();
            DataTable dtMunicipio = new DataTable();
            SqlDataAdapter sqlda;
            try
            {
                sqlcon = oCon.slConexion();
                sqlcon.Open();
                sqlda = new SqlDataAdapter("SP_ConsultarVentas", sqlcon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@Id_Dian", Dian);
                sqlda.Fill(dtMunicipio);

                return dtMunicipio;
            }
            catch (Exception e)
            {
                dtMunicipio = null;
            }
            finally
            {
                // Cierro la Conexión
                sqlcon.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                sqlcon.Dispose();
            }
            return dtMunicipio;
        }
        #endregion
    }
}
