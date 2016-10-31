using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class clsVentas
    {
        #region AUTOCOMPLETAR EN UN TEXTBOX
        public List<string> GetNombre_RazonSocial(string prefixText)
        {
            List<string> lista = new List<string>();
            SqlConnection sqlcon = new SqlConnection();
            Datos.Conexion con = new Datos.Conexion();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                sqlcon = con.slConexion();
                sqlcon.Open();
                sqlcmd = new SqlCommand("Select top(10) Nombre_RazonSocial from Tbl_Clientes where Nombre_RazonSocial like + @nombre +'%'", sqlcon);
                sqlcmd.Parameters.AddWithValue("@nombre", prefixText);
                sqlda = new SqlDataAdapter(sqlcmd);
                IDataReader idr = sqlcmd.ExecuteReader();
                while (idr.Read())
                {
                    lista.Add(idr.GetString(0));
                }
                idr.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }

        }
        #endregion

        #region Dian
        public DataTable dt_RegistrarVenta(Comun.clsVentas oVen)
        {
            DataTable dtVenta = new DataTable();
            SqlConnection con = new SqlConnection();
            Conexion oConexion = new Conexion();
            try
            {                
                con = oConexion.slConexion();
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SP_RegistrarVenta", con);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@Documento_Nit_Cliente", oVen.DocNit_cliente);
                sqlda.SelectCommand.Parameters.AddWithValue("@Documento_Empleado", oVen.DocEmpleado);
                sqlda.SelectCommand.Parameters.AddWithValue("@Descuento", oVen.Descuento);
                sqlda.SelectCommand.Parameters.AddWithValue("@Dian", oVen.Dian);
                //La tabla donde se guardan los datos
                sqlda.Fill(dtVenta);
                return dtVenta;
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                con.Close();                
                con.Dispose();
            }
            return null;
        }
        #endregion
    }
}
