using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Datos
{
    public class clsComidas
    {
        SqlConnection sqlCon = null;
        Conexion oCon = new Conexion();
        SqlCommand sqlcmd = null;

        #region Registrar_Producto
        public static int RegistrarComida(Comun.clsComidas oCom)
        {
            int idComida = -1;
            SqlConnection con = new SqlConnection();
            try
            {
                var oCon = new Conexion();
                con = oCon.slConexion(); //de la clase conexion tomamos el metodo slConexion
                con.Open();
                var sqlcmd = new SqlCommand("SP_RegistrarComida", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@NombreComida", oCom.Comida);
                sqlcmd.Parameters.AddWithValue("@Precio", oCom.Precio);
                var idReturn = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                idReturn.Direction = ParameterDirection.ReturnValue;
                sqlcmd.Parameters.Add(idReturn);
                //var id= sqlcmd.ExecuteScalar();    
      
                using (SqlDataReader dr = sqlcmd.ExecuteReader())
                {
                    idComida = Convert.ToInt32(idReturn.Value);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
            finally
            {
                con.Close();
            }
            return idComida;
        }
        #endregion

        #region Registrar detalle Comida por producto
        public bool RegistrarDetalleComidaXProd(string idProducto,int cantidad,int idComida)
        {
            bool res = false;
            var con = new SqlConnection();
            try
            {
                var oCon = new Conexion();
                con = oCon.slConexion(); 
                con.Open();
                var sqlcmd = new SqlCommand("SP_RegistrarDetalleComidaXProd", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@idComida", idComida);
                sqlcmd.Parameters.AddWithValue("@cod_Producto", idProducto);
                sqlcmd.Parameters.AddWithValue("@cantidad", cantidad);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                res = true;
            }
            return res;
        }
        #endregion
    }
}
