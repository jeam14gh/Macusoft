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
        //Metodo para listar los departamentos
        public DataTable Listar_Departamentos()
        {
            DataTable Dt_Dptos = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                Conexion oClsConexion = new Conexion();
                cn = oClsConexion.slConexion();
                cn.Open();
                //variable que tendra el procediemiento almacenado
                string SP_Listar_Departamentos = "dbo.SP_Listar_Departamento";
                // EL adaptador que ejecutara el procedimiento
                SqlDataAdapter DtlDepartamentos = new SqlDataAdapter(SP_Listar_Departamentos, cn);
                DtlDepartamentos.SelectCommand.CommandType = CommandType.StoredProcedure;
                DtlDepartamentos.Fill(Dt_Dptos);
                return Dt_Dptos;
            }
            catch (Exception e)
            {
            }
            finally
            {
                // Cierro la Conexión
                cn.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                cn.Dispose();
            }

            return null;

        }
    }
}
