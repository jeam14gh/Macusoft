using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class Conexion
    {
        public SqlConnection slConexion()
        {
            SqlConnection con = new SqlConnection();

            //La siguiente linea de código hace llamar la cadena de conexión que está ubicada en nuestro archivo web.config
            //NOTA: Si aparece error en ConfigurationManager , se debe agregar la referencia desde Datos/References, seleccionar el checkbox "System.Configuration" y clic en aceptar
            con.ConnectionString = ConfigurationManager.AppSettings["MyConnection"].ToString();
            //con.ConnectionString = "Data Source=UUIYUIYIY-PC;Initial Catalog=Macusoft_V3;Integrated Security=True";
            //con.ConnectionString = "Data Source=AMBIENTE76;Initial Catalog=Macusoft_V3;Integrated Security=True";
            return con;
        }
    }
}
