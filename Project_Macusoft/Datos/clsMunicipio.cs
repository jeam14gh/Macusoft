using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Datos
{
    public class clsMunicipio
    {

        public DataTable ListarMunicipios(byte idDepartamento)
        {
            Conexion oCon = new Conexion();
            SqlConnection sqlcon = new SqlConnection();
            DataTable dtMunicipio = new DataTable();
            SqlDataAdapter sqlda;
            try
            {
                sqlcon = oCon.slConexion();
                sqlcon.Open();
                sqlda = new SqlDataAdapter("SP_ListarMunicipios", sqlcon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                sqlda.Fill(dtMunicipio); //Llenamos el DataTable "dtMunicipios" con la funcion Fill

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
            return null;
        }
    }
}