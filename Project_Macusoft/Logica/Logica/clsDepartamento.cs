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
        public DataTable Listar_Departamentos()
        {
            Datos.clsDepartamento oclsDepartamento = new Datos.clsDepartamento();
            return oclsDepartamento.Listar_Departamentos();
 
        }
    }
}
