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
        public DataTable Listar_Municipio(int id_Depatamento)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                Conexion ClsConexion = new Conexion();
                con = ClsConexion.slConexion();
                con.Open();
                 //variable que tendra el procediemiento almacenado
                string SP_Listar_Municipios = "dbo.SP_Listar_Municipios";
                // EL adaptador que ejecutara el procedimiento
                SqlDataAdapter DtlMunicipios = new SqlDataAdapter(SP_Listar_Municipios, con);
                DtlMunicipios.SelectCommand.CommandType = CommandType.StoredProcedure;
                DtlMunicipios.SelectCommand.Parameters.AddWithValue("@Id_Departamento", id_Depatamento);
                // la tabla donde se guardaran los datos
                DataTable TblMunicipio = new DataTable();
                DtlMunicipios.Fill(TblMunicipio);
                return TblMunicipio;
            }
            catch (Exception e)
            { }
            finally
            {
                // Cierro la Conexión
                con.Close();
                // Libero Recursos NO Administrados, esto me garantiza que se Cierra la Conexión
                con.Dispose();
            }
            return null;
        }
    }
}
