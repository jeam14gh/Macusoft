using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class clsProductos
    {
        SqlConnection sqlCon = new SqlConnection();
        Conexion oCon = new Conexion();
        SqlCommand sqlcmd = new SqlCommand();

        #region Registrar_Producto
        public bool RegistrarProducto(Comun.clsProductos oPro)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oCon = new Conexion();
                con = oCon.slConexion(); //de la clase conexion tomamos el metodo slConexion
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_RegistrarProducto", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cod_Producto", oPro.Referencia);
                sqlcmd.Parameters.AddWithValue("@Id_Categoria", oPro.OCatgorias.Id_categoria);
                sqlcmd.Parameters.AddWithValue("@Nombre_Producto", oPro.Nombre_producto);
                sqlcmd.Parameters.AddWithValue("@ExistenciasActuales", oPro.Existencias_actuales);
                sqlcmd.Parameters.AddWithValue("@Stock_Minimo", oPro.Stock_minimo);
                sqlcmd.Parameters.AddWithValue("@Stock_Maximo", oPro.Stock_maximo);
                sqlcmd.Parameters.AddWithValue("@CostoCompra", oPro.Costo_compra);
                sqlcmd.Parameters.AddWithValue("@CostoVenta", oPro.Costo_venta);
                sqlcmd.Parameters.AddWithValue("@Mayor", oPro.Mayor);
                int res = sqlcmd.ExecuteNonQuery();
                if (res > 0)
                {
                    registro = true;
                }
            }
            catch (Exception ex)
            {
                registro = false;
            }
            finally
            {
                con.Close();
            }
            return registro;
        }
        #endregion

        #region Actualizar Producto
        public bool ActualizarProducto(Comun.clsProductos oPro)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oCon = new Conexion();
                con = oCon.slConexion(); //de al clase conexion tomamos el metodo slConexion
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_ActualizarProducto", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cod_Producto", oPro.Referencia);
                sqlcmd.Parameters.AddWithValue("@Id_Categoria", oPro.OCatgorias.Id_categoria);
                sqlcmd.Parameters.AddWithValue("@Nombre_Producto", oPro.Nombre_producto);
                sqlcmd.Parameters.AddWithValue("@ExistenciasActuales", oPro.Existencias_actuales);
                sqlcmd.Parameters.AddWithValue("@Stock_Minimo", oPro.Stock_minimo);
                sqlcmd.Parameters.AddWithValue("@Stock_Maximo", oPro.Stock_maximo);
                sqlcmd.Parameters.AddWithValue("@CostoCompra", oPro.Costo_compra);
                sqlcmd.Parameters.AddWithValue("@CostoVenta", oPro.Costo_venta);
                sqlcmd.Parameters.AddWithValue("@Mayor", oPro.Mayor);
                int res = sqlcmd.ExecuteNonQuery();
                if (res > 0)
                {
                    registro = true;
                }
            }
            catch (Exception ex)
            {
                registro = false;
            }
            finally
            {
                con.Close();
            }
            return registro;
        }
        #endregion

        #region Consultar Producto
        public DataTable ConsultarProducto(Comun.clsProductos oPro)
        {
            DataTable dtProductos = new DataTable("Productos");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_ConsultarProducto", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cod_Producto", oPro.Referencia);
                sqlcmd.Parameters.AddWithValue("@Nombre_Producto", oPro.Nombre_producto);
                sqlcmd.Parameters.AddWithValue("@Id_Categoria", oPro.OCatgorias.Id_categoria);                

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dtProductos);
            }
            catch (Exception e)
            {
                dtProductos = null;
            }
            return dtProductos;
        }
        #endregion
        #region Consultar Prodcutos por codigo
        public DataTable ConsultarProductoCod(string cod)
        {
            DataTable dtProductos = new DataTable("Productos");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_ConsultaProdCod", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cod_Producto", cod);
                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dtProductos);
            }
            catch (Exception e)
            {
                dtProductos = null;
            }
            return dtProductos;
        }

        #endregion

        #region
        public DataTable listarProductos()
        {
            DataTable dt_listarProductos = new DataTable("Lista_Productos");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oCon = new Conexion();
                sqlcon = oCon.slConexion();
                sqlcmd = new SqlCommand("SP_ListarProductos", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dt_listarProductos);
            }
            catch (Exception e)
            {
                dt_listarProductos = null;
            }
            return dt_listarProductos;
        }
        #endregion
        #region AUTOCOMPLETAR EN UN TEXTBOX
        public static List<string> GetNombreProducto(string prefixText)
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
                sqlcmd = new SqlCommand("Select top(10) Nombre_Producto from Tbl_Productos where Nombre_Producto like + @nombre +'%'", sqlcon);
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

        #region  Promedio Ponderado
        public bool PromedioPondedaroEntradas(Comun.clsProductos Tblpro)
        {
            bool Res = false;
            SqlConnection Con = new SqlConnection();
            try
            {
                Conexion oCon = new Conexion();
                Con = oCon.slConexion();
                Con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_PromedioPondedaroEntradas", Con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cod_producto", Tblpro.Referencia);
                int res = sqlcmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Res = true;
                }
            }
            catch (Exception e)
            {
                Res = false;
            }
            finally
            {
                Con.Close();
            }
            return Res;
        }
        #endregion


        public bool PromedioPondedaroSalidas(Comun.clsProductos Tblpro)
        {
            bool Res = false;
            SqlConnection Con = new SqlConnection();
            try
            {
                Conexion oCon = new Conexion();
                Con = oCon.slConexion();
                Con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_PromedioPondedaroSalidas", Con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cod_producto", Tblpro.Referencia);
                int res = sqlcmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Res = true;
                }
            }
            catch (Exception e)
            {
                Res = false;
            }
            finally
            {
                Con.Close();
            }
            return Res;
        }

        #region Listar producto por categoria
        public DataTable ListarProductosXCategoria(int idCategoria)
        {
            Conexion oCon = new Conexion();
            SqlConnection sqlcon = new SqlConnection();
            DataTable dtProductos = new DataTable();
            SqlDataAdapter sqlda;
            try
            {
                sqlcon = oCon.slConexion();
                sqlcon.Open();
                sqlda = new SqlDataAdapter("SP_ListarProductosXCategoria", sqlcon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@Id_Categoria", idCategoria);
                sqlda.Fill(dtProductos); //Llenamos el DataTable "dtMunicipios" con la funcion Fill

                return dtProductos;
            }
            catch (Exception e)
            {
                dtProductos = null;
            }
            finally
            {
                // Cierro la Conexión
                sqlcon.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                sqlcon.Dispose();
            }
            return null;
        }
        #endregion


        public DataTable CostoVenta(string cod)
        {
            DataTable dtProductos = new DataTable("Productos");
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd;
            SqlDataAdapter sqlda;
            try
            {
                Conexion oConexion = new Conexion();
                sqlcon = oConexion.slConexion();
                sqlcmd = new SqlCommand("SP_CostoVenta", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CodProducto", cod);

                sqlda = new SqlDataAdapter(sqlcmd);
                sqlda.Fill(dtProductos);
            }
            catch (Exception e)
            {
                dtProductos = null;
            }
            return dtProductos;
        }
        #region Actualizar Producto
        public bool ActualizarExistencias(string cod)
        {
            bool registro = false;
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion oCon = new Conexion();
                con = oCon.slConexion(); //de al clase conexion tomamos el metodo slConexion
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_ActualizarExistencias", con);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cod_Producto",cod);

                int res = sqlcmd.ExecuteNonQuery();
                if (res > 0)
                {
                    registro = true;
                }
            }
            catch (Exception ex)
            {
                registro = false;
            }
            finally
            {
                con.Close();
            }
            return registro;
        }
        #endregion
    }
}
