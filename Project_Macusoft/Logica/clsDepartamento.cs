using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Logica
{
    public class clsDepartamento
    {
        public DataTable dtDepartamentos()
        {
            return new Datos.clsDepartamento().ListarDepartamentos();
        }
    }
}
