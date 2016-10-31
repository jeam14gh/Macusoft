using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class clsDetCompras
    {
        public bool Registrar_Detalles(Comun.clsDetCompra ClsDet)
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
                CmDetalles.Parameters.AddWithValue("@cod_prod", ClsDet.Cod_producto);
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
    }
}
