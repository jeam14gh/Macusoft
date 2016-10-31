using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class clsCategorias
    {
        public bool Registrar_categoria(Comun.clsCategorias objclsCategoria)
        {
            bool bolResultado = false;
            SqlConnection con = new SqlConnection();

            try
            {
                Conexion Clsconexion = new Conexion();
                con = Clsconexion.slConexion();
                con.Open();
                //Variable que tendra el procedimiento almaceno
                string SP_Registrar_categoria = "dbo.SP_RegistrarCategoria";
                //El adaptador que ejecuta el procedimiento
                SqlCommand CmdCategoria = new SqlCommand(SP_Registrar_categoria, con);
                CmdCategoria.CommandType = CommandType.StoredProcedure;
                CmdCategoria.Parameters.AddWithValue("@nombre", objclsCategoria.nomb_catego);

                int intResultado = CmdCategoria.ExecuteNonQuery();

                if (intResultado > 0)
                { bolResultado = true; }

            }
            catch (Exception e)
            { }

            finally
            {
                //Cierro la conexion
                con.Close();
                //Libero Recursos no administrados, eso me garantiza que se cierre la conexion
                con.Dispose();
            }

            return bolResultado;

        }


        public DataTable ListarCategoria()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                cn = oClsConexion.slConexion();
                cn.Open();
                string Sp_listarCategorias = "dbo.Sp_listarCategorias";
                // EL adaptador que ejecutara el procedimiento
                SqlDataAdapter Dtlcategorias = new SqlDataAdapter(Sp_listarCategorias, cn);
                Dtlcategorias.SelectCommand.CommandType = CommandType.StoredProcedure;
                // la tabla donde se guardaran los datos
                DataTable Tblcateogorias = new DataTable();
                Dtlcategorias.Fill(Tblcateogorias);
                return Tblcateogorias;
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


        public DataTable ConsultarCategoria(Comun.clsCategorias catego)
        {
            DataTable Tblcategoria = new DataTable();
            SqlConnection cn = new SqlConnection();


            try
            {
                Conexion oClsconexion = new Conexion();
                cn = oClsconexion.slConexion();
                cn.Open();
                string Sp_consultarcategorianomb = "dbo.Sp_ConsultarCategoria_nomb";

                //El adaptador que ejecuta el procedimiento

                SqlDataAdapter DtlCategoria = new SqlDataAdapter(Sp_consultarcategorianomb, cn);
                DtlCategoria.SelectCommand.CommandType = CommandType.StoredProcedure;
                DtlCategoria.SelectCommand.Parameters.AddWithValue("@nombre", catego.nomb_catego);
                //La tabla donde se guardan los datos
                DtlCategoria.Fill(Tblcategoria);
                return Tblcategoria;

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


        public bool Actualizar_Categoria(Comun.clsCategorias objclsCategoria)
        {
            bool bolResultado = false;
            SqlConnection con = new SqlConnection();

            try
            {
                Conexion Clsconexion = new Conexion();
                con = Clsconexion.slConexion();
                con.Open();
                //Variable que tendra el procedimiento almaceno
                string SP_Registrar_categoria = "dbo.Sp_ActualizarCategoria";
                //El adaptador que ejecuta el procedimiento
                SqlCommand CmdCategoria = new SqlCommand(SP_Registrar_categoria, con);
                CmdCategoria.CommandType = CommandType.StoredProcedure;
                CmdCategoria.Parameters.AddWithValue("@id_categoria", objclsCategoria.Id_categoria);
                CmdCategoria.Parameters.AddWithValue("@nombre", objclsCategoria.nomb_catego);

                int intResultado = CmdCategoria.ExecuteNonQuery();

                if (intResultado > 0)
                { bolResultado = true; }

                //La tabla donde se guardan los datos.

            }
            catch (Exception e)
            { }

            finally
            {
                //Cierro la conexion
                con.Close();
                //Libero Recursos no administrados, eso me garantiza que se cierre la conexion
                con.Dispose();
            }

            return bolResultado;

        }
        public DataTable ConsultarCategoria(int cod)
        {
            DataTable Tblcategoria = new DataTable();
            SqlConnection cn = new SqlConnection();


            try
            {
                Conexion oClsconexion = new Conexion();
                cn = oClsconexion.slConexion();
                cn.Open();
                string Sp_consultarcategorianomb = "dbo.SP_ProductCat";

                //El adaptador que ejecuta el procedimiento

                SqlDataAdapter DtlCategoria = new SqlDataAdapter(Sp_consultarcategorianomb, cn);
                DtlCategoria.SelectCommand.CommandType = CommandType.StoredProcedure;
                DtlCategoria.SelectCommand.Parameters.AddWithValue("@id_categoria", cod);
                //La tabla donde se guardan los datos
                DtlCategoria.Fill(Tblcategoria);
                return Tblcategoria;

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
