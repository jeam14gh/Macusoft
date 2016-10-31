using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Datos
{
    public class clsDepartamento
    {

        //Metodo para listar los departamentos -Jhon A
        public DataTable ListarDepartamentos()
        {
            DataTable dtDepartamentos = new DataTable();
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                sqlcon = oClsConexion.slConexion();
                sqlcon.Open();
                SqlDataAdapter DtlDepartamentos = new SqlDataAdapter("SP_ListarDepartamentos", sqlcon);
                DtlDepartamentos.SelectCommand.CommandType = CommandType.StoredProcedure;
                DtlDepartamentos.Fill(dtDepartamentos);
                return dtDepartamentos;
            }
            catch (Exception e)
            {
            }
            finally
            {
                sqlcon.Close();
                sqlcon.Dispose();   // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
            }
            return null;
        }
    }
}
