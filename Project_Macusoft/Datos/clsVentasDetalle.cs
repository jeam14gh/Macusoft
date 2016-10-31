using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class clsVentasDetalle
    {
        public bool RegistrarDetalles(Comun.clsVentasDetalle oVenDet)
        {
            bool Res = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oconexion = new Conexion();
                con = oconexion.slConexion();
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_RegistrarDetallesVenta", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                //sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@Cod_Producto", oVenDet.Cod_Product);
                sqlcmd.Parameters.AddWithValue("@Cantidad", oVenDet.Cantidad);
                sqlcmd.Parameters.AddWithValue("@Valor", oVenDet.Valor);
                int Resultado = sqlcmd.ExecuteNonQuery();
                if (Resultado > 0)
                {
                    Res = true;
                }
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

        public bool RegistrarDetallesVenta(DataTable dtDetallesVenta)
        {
            bool resultado = false;
            SqlConnection sqlcon = new SqlConnection();

            try
            {
                Conexion oCon = new Conexion();
                sqlcon = oCon.slConexion();
                sqlcon.Open();

                int k;
                //int intsrv_id, intsrv_valor, intsrv_nrohoras;

                for (k = 0; k < dtDetallesVenta.Rows.Count; k++)
                {                    
                    SqlCommand sqlcmd = new SqlCommand("SP_RegistrarDetallesVenta", sqlcon);
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //intsrv_id = Convert.ToInt32(dtllsrvs.Rows[k][0]);
                    //intsrv_valor = Convert.ToInt32(dtllsrvs.Rows[k][2]);
                    //intsrv_nrohoras = Convert.ToInt32(dtllsrvs.Rows[k][3]);

                    sqlcmd.Parameters.AddWithValue("@Cod_Producto", dtDetallesVenta.Rows[k][2]);
                    sqlcmd.Parameters.AddWithValue("@Cantidad", dtDetallesVenta.Rows[k][3]);
                    sqlcmd.Parameters.AddWithValue("@Valor", dtDetallesVenta.Rows[k][4]);

                    //sqlcmd.Parameters.AddWithValue("@fac_numero", nroservicio);
                    //sqlcmd.Parameters.AddWithValue("@srv_id", intsrv_id);
                    //sqlcmd.Parameters.AddWithValue("@srv_valor", intsrv_valor);
                    //sqlcmd.Parameters.AddWithValue("@srv_nrohoras", intsrv_nrohoras);

                    int cantidad = sqlcmd.ExecuteNonQuery();
                    if (cantidad > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }
            }

            catch (Exception e)
            {
                resultado = false;
            }

            finally
            {
                // Cierro la Conexión
                sqlcon.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                sqlcon.Dispose();
            }
            return resultado;
        }
    }
}
