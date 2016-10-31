using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class clsCompras
    {
       

        public DataTable RegistrarCompras(Comun.clsCompras objclsCompras)
        {
            DataTable TblCompra = new DataTable();
            SqlConnection cn = new SqlConnection();


            try
            {
                Conexion oClsconexion = new Conexion();
                cn = oClsconexion.slConexion();
                cn.Open();
                string Sp_registrarCompra = "dbo.Sp_RegistrarCompra";

                //El adaptador que ejecuta el procedimiento

                SqlDataAdapter DtlCompra = new SqlDataAdapter(Sp_registrarCompra, cn);

                DtlCompra.SelectCommand.CommandType = CommandType.StoredProcedure;

                DtlCompra.SelectCommand.Parameters.AddWithValue("@docuemto_nit", objclsCompras.Documento_nit);
                DtlCompra.SelectCommand.Parameters.AddWithValue("@forma_pago", objclsCompras.Forma_pago);
                DtlCompra.SelectCommand.Parameters.AddWithValue("@id_tipo_movimiento", objclsCompras.Id_tipo_movimiento);


                //La tabla donde se guardan los datos
                DtlCompra.Fill(TblCompra);

                return TblCompra;

            }

            catch (Exception e)
            {

            }

            finally
            {
                //Cierro la conexion
                cn.Close();

                //Libero recursos no administrados, esto me garantiza que se cierre la conexion

                cn.Dispose();

            }
            return null;

        }

        public DataTable Consultarcompras()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                cn = oClsConexion.slConexion();
                cn.Open();
                string Sp_listarCompras = "Sp_ListarCompras";
                // EL adaptador que ejecutara el procedimiento
                SqlDataAdapter DtlCompras = new SqlDataAdapter(Sp_listarCompras, cn);
                DtlCompras.SelectCommand.CommandType = CommandType.StoredProcedure;
                // la tabla donde se guardaran los datos
                DataTable TblCompras = new DataTable();
                DtlCompras.Fill(TblCompras);
                return TblCompras;
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

        public DataTable ConsultarComprasProv(Comun.clsCompras comp)
        {
            DataTable TblCompras = new DataTable();
            SqlConnection cn = new SqlConnection();


            try
            {
                Conexion oClsconexion = new Conexion();
                cn = oClsconexion.slConexion();
                cn.Open();
                string Sp_consultarcategorianomb = "Sp_ConsultarComp";

                //El adaptador que ejecuta el procedimiento

                SqlDataAdapter DtlCategoria = new SqlDataAdapter(Sp_consultarcategorianomb, cn);

                DtlCategoria.SelectCommand.CommandType = CommandType.StoredProcedure;
                DtlCategoria.SelectCommand.Parameters.AddWithValue("@provee",comp.Documento_nit);
                //La tabla donde se guardan los datos
                DtlCategoria.Fill(TblCompras);

                return TblCompras;

            }

            catch (Exception e)
            {

            }

            finally
            {
                //Cierro la conexion
                cn.Close();

                //Libero recursos no administrados, esto me garantiza que se cierre la conexion

                cn.Dispose();

            }
            return null;

        }




    }
}
