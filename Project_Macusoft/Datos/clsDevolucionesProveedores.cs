using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class clsDevolucionesProveedores
    {
        public bool RegistrarDevProv(Comun.clsDevolucionesProveedores DevPro)
        {
            bool res = false;
            SqlConnection Cn = new SqlConnection();
            try
            {
                Conexion con = new Conexion();
                Cn = con.slConexion();
                Cn.Open();
                string SP_Registrar_Dvoluciones_Proveedores = "SP_RegistrarDevolucionesProveedores";
                SqlCommand CmdDevPro = new SqlCommand(SP_Registrar_Dvoluciones_Proveedores, Cn);
                CmdDevPro.CommandType = CommandType.StoredProcedure;
                CmdDevPro.Parameters.AddWithValue("@nit_proveedor", DevPro.Documento_Proveedor);
                CmdDevPro.Parameters.AddWithValue("@Motivos", DevPro.Motivos);
                CmdDevPro.Parameters.AddWithValue("@Tipo_Movimiento", DevPro.ID_Tipo_Movimiento);
                int Resultado = CmdDevPro.ExecuteNonQuery();
                if (Resultado > 0)
                {
                    res = true;
                }
            }
            catch (Exception e)
            {
                res = false;
            }
            finally
            {
                Cn.Close();
                Cn.Dispose();
            }
            return res;
        
        }
        #region
        public DataTable Consultar_Decoluciones_Proveedores(string nit, string Cod)
        {
            Conexion oCon = new Conexion();
            SqlConnection sqlcon = new SqlConnection();
            DataTable dtMunicipio = new DataTable();
            SqlDataAdapter sqlda;
            try
            {
                sqlcon = oCon.slConexion();
                sqlcon.Open();
                sqlda = new SqlDataAdapter("SP_ConsultarDevolucionProveedores", sqlcon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@Documento_Nit_Proveedor", nit);
                sqlda.SelectCommand.Parameters.AddWithValue("@Nombre_RazonSocial", Cod);
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
